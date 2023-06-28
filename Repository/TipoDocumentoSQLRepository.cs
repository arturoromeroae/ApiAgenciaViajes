using AgenciaViajes.DbContexts;
using AgenciaViajes.Exceptions;
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

        public async Task<TipoDocumento> GetTipoDocumentoById(int id)
        {
            var tipoDocumento = await dbContext.tiposDocumentos.Where(c => c.idTd == id)
                .FirstOrDefaultAsync();

            if (tipoDocumento == null)
            {
                throw new NotFoundException("Tipo Documento not found with id: " + id.ToString());
            }
            return tipoDocumento;
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
