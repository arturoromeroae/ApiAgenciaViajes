using AgenciaViajes.Models;

namespace AgenciaViajes.Repository
{
    public interface IAerolineaRepository
    {
        //AGREGAR
        public Task<bool> placeAero(Aerolinea aerolinea);

        //LISTAR
        Task<IEnumerable<Aerolinea>> GetAerolineas();

        //ACTUALIZAR
        Task<Aerolinea> UpdateAerolinea(Aerolinea aerolinea);

        //ELIMINAR
        Task<bool> DeleteAerolinea(int id);
    }
}
