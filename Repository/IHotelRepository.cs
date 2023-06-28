using AgenciaViajes.Models;

namespace AgenciaViajes.Repository
{
    public interface IHotelRepository
    {
        //AGREGAR
        public Task<bool> placeHotel(Hotel hotel);

        //LISTAR
        Task<IEnumerable<Hotel>> GetHoteles();
        Task<Hotel> GetHotelById(int id);

        //ACTUALIZAR
        Task<Hotel> UpdateHotel(Hotel hotel);

        //ELIMINAR
        Task<bool> DeleteHotel(int id);
    }
}
