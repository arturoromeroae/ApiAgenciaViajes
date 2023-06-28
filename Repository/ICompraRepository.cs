using AgenciaViajes.Models;

namespace AgenciaViajes.Repository
{
    public interface ICompraRepository
    {
        //AGREGAR
        public Task<bool> placeCompra(Compra compra);

        //LISTAR
        Task<IEnumerable<Compra>> GetCompras();

        //ACTUALIZAR
        Task<Compra> UpdateCompra(Compra compra);

        //ELIMINAR
        Task<bool> DeleteCompra(int id);
    }
}
