using System.ComponentModel.DataAnnotations;

namespace AgenciaViajes.Models
{
    public class TipoDocumento
    {
        [Key]
        public int idTd { get; set; }
        public string? nameTd { get; set; }
        public ICollection<Trabajador>? trabajadores { get; set; }
        public ICollection<Cliente>? clientes { get; set; }
    }
}
