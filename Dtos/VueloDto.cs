using AgenciaViajes.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaViajes.Dtos
{
    public class VueloDto
    {
        public int idVuelo { get; set; }
        public string? destinoVuelo { get; set; }
        public string? salidaVuelo { get; set; }
        public DateTime dateVuelo { get; set; }
        public string? asientoVuelo { get; set; }
        public decimal precio { get; set; }

        public int idAero { get; set; }
        [ForeignKey("idAero")]
        public Aerolinea? aerolinea { get; set; }

        public ICollection<Compra>? compras { get; set; }
    }
}
