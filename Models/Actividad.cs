using System.ComponentModel.DataAnnotations;

namespace AgenciaViajes.Models
{
    public class Actividad
    {
        [Key]
        public int idAct { get; set; }
        public string? nameAct { get; set; }
        public string? duracionAct { get; set; }
        public decimal precioAct { get; set; }
        public ICollection<Compra>? compra { get; set; }
    }
}
