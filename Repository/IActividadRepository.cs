using AgenciaViajes.Models;

namespace AgenciaViajes.Repository
{
    public interface IActividadRepository
    {
        //AGREGAR
        public Task<bool> placeActividad(Actividad actividad);

        //LISTAR
        Task<IEnumerable<Actividad>> GetActividades();

        //ACTUALIZAR
        Task<Actividad> UpdateActividad(Actividad actividad);

        //ELIMINAR
        Task<bool> DeleteActividad(int id);
    }
}
