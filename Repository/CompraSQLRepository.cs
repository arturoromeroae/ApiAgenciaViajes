using AgenciaViajes.DbContexts;
using AgenciaViajes.Models;
using Microsoft.EntityFrameworkCore;

namespace AgenciaViajes.Repository
{
    public class CompraSQLRepository : ICompraRepository
    {
        private AppDbContext dbContext;
        public CompraSQLRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //////////////////////LISTAR//////////////////////
        public async Task<IEnumerable<Compra>> GetCompras()
        {
            return await dbContext.compras.ToListAsync();
        }

        //////////////////////AGREGAR//////////////////////
        public async Task<bool> placeCompra(Compra compra)
        {
            dbContext.compras.Add(compra);
            await dbContext.SaveChangesAsync();
            return true;
        }

        //////////////////////ACTUALIZAR//////////////////////
        public async Task<Compra> UpdateCompra(Compra compra)
        {
            dbContext.compras.Update(compra);
            await dbContext.SaveChangesAsync();
            return compra;
        }

        //////////////////////ELIMINAR//////////////////////
        public async Task<bool> DeleteCompra(int id)
        {
            var compra = await dbContext.compras.FirstOrDefaultAsync(c => c.idCr == id);
            if (compra == null)
            {
                return false;
            }
            dbContext.Remove(compra);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
