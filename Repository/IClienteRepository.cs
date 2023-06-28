using AgenciaViajes.Models;

namespace AgenciaViajes.Repository
{
    public interface IClienteRepository
    {
        //AGREGAR
        public Task<bool> placeCliente(Cliente cliente);

        //LISTAR
        Task<IEnumerable<Cliente>> GetClientes();

        //ACTUALIZAR
        Task<Cliente> UpdateCliente(Cliente cliente);

        //ELIMINAR
        Task<bool> DeleteCliente(int id);
    }
}
