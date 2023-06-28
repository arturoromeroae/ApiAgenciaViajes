using AgenciaViajes.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaViajes.Dtos
{
    public class TipoDocumentoDto
    {
        public int idTd { get; set; }
        public string? nameTd { get; set; }
        public ICollection<Trabajador>? trabajadores { get; set; }
        public ICollection<Cliente>? clientes { get; set; }
    }
}
