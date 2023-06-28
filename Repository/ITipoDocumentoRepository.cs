using AgenciaViajes.Models;

namespace AgenciaViajes.Repository
{
    public interface ITipoDocumentoRepository
    {
        //AGREGAR
        public Task<bool> placeTipoDoc(TipoDocumento tipoDocumento);

        //LISTAR
        Task<IEnumerable<TipoDocumento>> GetTiposDocs();
        Task<TipoDocumento> GetTipoDocumentoById(int id);

        //ACTUALIZAR
        Task<TipoDocumento> UpdateTipoDocumento(TipoDocumento tipoDocumento);

        //ELIMINAR
        Task<bool> DeleteTipoDocumento(int id);
    }
}
