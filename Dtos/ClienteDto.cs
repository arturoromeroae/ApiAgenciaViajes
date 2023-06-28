using AgenciaViajes.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaViajes.Dtos
{
    public class ClienteDto
    {
        public int idCl { get; set; }
        public string? nameCl { get; set; }
        public string? lnameCl { get; set; }
        public string? nroDocCl { get; set; }
        public DateTime birthdateCl { get; set; }

        public int? idTd { get; set; }
        [ForeignKey("idTd")]
        public TipoDocumento? tipoDocumento { get; set; }

        public ICollection<Compra>? compra { get; set; }
    }
}
