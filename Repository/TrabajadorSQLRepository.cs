using AgenciaViajes.DbContexts;
using AgenciaViajes.Models;
using Microsoft.EntityFrameworkCore;

namespace AgenciaViajes.Repository
{
    public class TrabajadorSQLRepository : ITrabajadorRepository
    {
        private AppDbContext dbContext;
        public TrabajadorSQLRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //////////////////////LISTAR//////////////////////
        public async Task<IEnumerable<Trabajador>> GetWorkers()
        {
            return await dbContext.trabajadores.ToListAsync();
        }

        //////////////////////AGREGAR//////////////////////
        public async Task<bool> placeWorker(Trabajador trabajador)
        {
            dbContext.trabajadores.Add(trabajador);
            await dbContext.SaveChangesAsync();
            return true;
        }

        //////////////////////ACTUALIZAR//////////////////////
        public async Task<Trabajador> UpdateTrabajador(Trabajador trabajador)
        {
            dbContext.trabajadores.Update(trabajador);
            await dbContext.SaveChangesAsync();
            return trabajador;
        }

        //////////////////////ELIMINAR//////////////////////
        public async Task<bool> DeleteTrabajador(int id)
        {
            var trabajador = await dbContext.trabajadores.FirstOrDefaultAsync(c => c.idTrab == id);
            if (trabajador == null)
            {
                return false;
            }
            dbContext.Remove(trabajador);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
