using AgenciaViajes.Models;

namespace AgenciaViajes.Repository
{
    public interface IVueloRepository
    {
        //AGREGAR
        public Task<bool> PlaceVuelo(Vuelo vuelo);

        //LISTAR
        Task<IEnumerable<Vuelo>> GetVuelos();

        //ACTUALIZAR
        Task<Vuelo> UpdateVuelo(Vuelo vuelo);

        //ELIMINAR
        Task<bool> DeleteVuelo(int id);
    }
}
