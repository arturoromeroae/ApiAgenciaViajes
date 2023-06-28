using AgenciaViajes.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaViajes.Dtos
{
    public class ActividadDto
    {
        public int idAct { get; set; }
        public string? nameAct { get; set; }
        public string? duracionAct { get; set; }
        public decimal precioAct { get; set; }
        public ICollection<Compra>? compra { get; set; }
    }
}
