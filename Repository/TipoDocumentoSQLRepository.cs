using AgenciaViajes.DbContexts;
using AgenciaViajes.Models;
using Microsoft.EntityFrameworkCore;

namespace AgenciaViajes.Repository
{
    public class TipoDocumentoSQLRepository : ITipoDocumentoRepository
    {
        private AppDbContext dbContext;
        public TipoDocumentoSQLRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //////////////////////LISTAR//////////////////////
        public async Task<IEnumerable<TipoDocumento>> GetTiposDocs()
        {
            return await dbContext.tiposDocumentos.ToListAsync();
        }

        //////////////////////AGREGAR//////////////////////
        public async Task<bool> placeTipoDoc(TipoDocumento tipoDocumento)
        {
            dbContext.tiposDocumentos.Add(tipoDocumento);
            await dbContext.SaveChangesAsync();
            return true;
        }

        //////////////////////ACTUALIZAR//////////////////////
        public async Task<TipoDocumento> UpdateTipoDocumento(TipoDocumento tipoDocumento)
        {
            dbContext.tiposDocumentos.Update(tipoDocumento);
            await dbContext.SaveChangesAsync();
            return tipoDocumento;
        }

        //////////////////////ELIMINAR//////////////////////
        public async Task<bool> DeleteTipoDocumento(int id)
        {
            var tipoDocumento = await dbContext.tiposDocumentos.FirstOrDefaultAsync(c => c.idTd == id);
            if (tipoDocumento == null)
            {
                return false;
            }
            dbContext.Remove(tipoDocumento);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
