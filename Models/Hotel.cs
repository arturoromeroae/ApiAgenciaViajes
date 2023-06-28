using System.ComponentModel.DataAnnotations;

namespace AgenciaViajes.Models
{
    public class Hotel
    {
        [Key]
        public int idHot { get; set; }
        public string? nameHot { get; set; }
        public string? addressHot { get; set; }
        public decimal priceHot { get; set; }
        public ICollection<Compra>? compras { get; set; }
    }
}
