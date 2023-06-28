using AgenciaViajes.DbContexts;
using AgenciaViajes.Exceptions;
using AgenciaViajes.Models;
using Microsoft.EntityFrameworkCore;

namespace AgenciaViajes.Repository
{
    public class ClienteSQLRepository : IClienteRepository
    {
        private AppDbContext dbContext;
        public ClienteSQLRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //////////////////////LISTAR//////////////////////
        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await dbContext.clientes.ToListAsync();
        }

        public async Task<Cliente> GetClienteById(int id)
        {
            var cliente = await dbContext.clientes.Where(c => c.idCl == id)
                .FirstOrDefaultAsync();

            if (cliente == null)
            {
                throw new NotFoundException("Cliente not found with id: " + id.ToString());
            }
            return cliente;
        }

        //////////////////////AGREGAR//////////////////////
        public async Task<bool> placeCliente(Cliente cliente)
        {
            dbContext.clientes.Add(cliente);
            await dbContext.SaveChangesAsync();
            return true;
        }

        //////////////////////ACTUALIZAR//////////////////////
        public async Task<Cliente> UpdateCliente(Cliente cliente)
        {
            dbContext.clientes.Update(cliente);
            await dbContext.SaveChangesAsync();
            return cliente;
        }

        //////////////////////ELIMINAR//////////////////////
        public async Task<bool> DeleteCliente(int id)
        {
            var cliente = await dbContext.clientes.FirstOrDefaultAsync(c => c.idCl == id);
            if (cliente == null)
            {
                return false;
            }
            dbContext.Remove(cliente);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
