using AgenciaViajes.Models;

namespace AgenciaViajes.Repository
{
    public interface ITrabajadorRepository
    {
        //AGREGAR
        public Task<bool> placeWorker(Trabajador trabajador);

        //LISTAR
        Task<IEnumerable<Trabajador>> GetWorkers();
        Task<Trabajador> GetTrabajadorById(int id);

        //ACTUALIZAR
        Task<Trabajador> UpdateTrabajador(Trabajador trabajador);

        //ELIMINAR
        Task<bool> DeleteTrabajador(int id);
    }
}
