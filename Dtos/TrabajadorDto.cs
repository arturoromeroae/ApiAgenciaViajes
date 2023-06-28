using AgenciaViajes.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaViajes.Dtos
{
    public class TrabajadorDto
    {
        public int idTrab { get; set; }
        public string? nameTrab { get; set; }
        public string? lnameTrab { get; set; }
        public string? nroDocTrab { get; set; }

        public int idTd { get; set; }
        [ForeignKey("idTd")]
        public TipoDocumento? tipoDocumento { get; set; }

        public ICollection<Compra>? compra { get; set; }
    }
}
