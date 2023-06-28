using AgenciaViajes.DbContexts;
using AgenciaViajes.Models;
using Microsoft.EntityFrameworkCore;

namespace AgenciaViajes.Repository
{
    public class AerolineaSQLRepository : IAerolineaRepository
    {
        private AppDbContext dbContext;
        public AerolineaSQLRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //////////////////////LISTAR//////////////////////
        public async Task<IEnumerable<Aerolinea>> GetAerolineas()
        {
            return await dbContext.aerolineas.ToListAsync();
        }
        
        //////////////////////AGREGAR//////////////////////
        public async Task<bool> placeAero(Aerolinea aerolinea)
        {
            dbContext.aerolineas.Add(aerolinea);
            await dbContext.SaveChangesAsync();
            return true;
        }

        //////////////////////ACTUALIZAR//////////////////////
        public async Task<Aerolinea> UpdateAerolinea(Aerolinea aerolinea)
        {
            dbContext.aerolineas.Update(aerolinea);
            await dbContext.SaveChangesAsync();
            return aerolinea;
        }
        
        //////////////////////ELIMINAR//////////////////////
        public async Task<bool> DeleteAerolinea(int id)
        {
            var aerolinea = await dbContext.aerolineas.FirstOrDefaultAsync(c => c.idAero == id);
            if (aerolinea == null)
            {
                return false;
            }
            dbContext.Remove(aerolinea);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
