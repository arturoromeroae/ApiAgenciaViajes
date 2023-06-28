using System.ComponentModel.DataAnnotations;

namespace AgenciaViajes.Models
{
    public class Aerolinea
    {
        [Key]
        public int idAero { get; set; }
        public string? nameAero { get; set; }
        public ICollection<Vuelo>? vuelos { get; set; }
    }
}
