using AgenciaViajes.DbContexts;
using AgenciaViajes.Models;
using Microsoft.EntityFrameworkCore;

namespace AgenciaViajes.Repository
{
    public class VueloSQLRepository : IVueloRepository
    {
        private AppDbContext dbContext;
        public VueloSQLRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //////////////////////LISTAR//////////////////////
        public async Task<IEnumerable<Vuelo>> GetVuelos()
        {
            return await dbContext.vuelos.ToListAsync();
        }

        //////////////////////AGREGAR//////////////////////
        public async Task<bool> PlaceVuelo(Vuelo vuelo)
        {
            dbContext.vuelos.Add(vuelo);
            await dbContext.SaveChangesAsync();
            return true;
        }

        //////////////////////ACTUALIZAR//////////////////////
        public async Task<Vuelo> UpdateVuelo(Vuelo vuelo)
        {
            dbContext.vuelos.Update(vuelo);
            await dbContext.SaveChangesAsync();
            return vuelo;
        }

        //////////////////////ELIMINAR//////////////////////
        public async Task<bool> DeleteVuelo(int id)
        {
            var vuelo = await dbContext.vuelos.FirstOrDefaultAsync(c => c.idVuelo == id);
            if (vuelo == null)
            {
                return false;
            }
            dbContext.Remove(vuelo);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
