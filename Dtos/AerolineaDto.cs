using AgenciaViajes.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaViajes.Dtos
{
    public class AerolineaDto
    {
        public int idAero { get; set; }
        public string? nameAero { get; set; }
        public ICollection<Vuelo>? vuelos { get; set; }
    }
}
