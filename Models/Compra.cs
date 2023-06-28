using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaViajes.Models
{
    public class Compra
    {
        [Key]
        public int idCr { get; set; }
        public decimal subtotalCr { get; set; }
        public decimal totalCr { get; set; }

        public int? idVuelo { get; set; }
        [ForeignKey("idVuelo")]
        public Vuelo? vuelo { get; set; }

        public int? idHot { get; set; }
        [ForeignKey("idHot")]
        public Hotel? hotel { get; set; }

        public int? idCl { get; set; }
        [ForeignKey("idCl")]
        public Cliente? cliente { get; set; }

        public int? idTb { get; set; }
        [ForeignKey("idTb")]
        public Trabajador? trabajador { get;set; }

        public int? idAct { get; set; }
        [ForeignKey("idAct")]
        public Actividad? actividad { get; set; }
    }
}
