using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace AgenciaViajes.Models
{
    public class Trabajador
    {
        [Key]
        public int idTrab { get; set; }
        public string? nameTrab { get; set; }
        public string? lnameTrab { get; set;}
        public string? nroDocTrab { get; set; }

        public int idTd { get; set; }
        [ForeignKey("idTd")]
        public TipoDocumento? tipoDocumento { get; set; }

        public ICollection<Compra>? compra { get; set; }
    }
}
