using AgenciaViajes.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaViajes.Dtos
{
    public class HotelDto
    {
        public int idHot { get; set; }
        public string? nameHot { get; set; }
        public string? addressHot { get; set; }
        public decimal priceHot { get; set; }
        public ICollection<Compra>? compras { get; set; }
    }
}
