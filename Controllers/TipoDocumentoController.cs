using AgenciaViajes.Dtos;
using AgenciaViajes.Models;
using AgenciaViajes.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AgenciaViajes.Controllers
{
    [Route("/api/TipoDocuemento")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
        private ITipoDocumentoRepository tipoDocumentoRepository;
        private ResponseDto responseDto;

        public TipoDocumentoController(ITipoDocumentoRepository tipoDocumentoRepository)
        {
            this.tipoDocumentoRepository = tipoDocumentoRepository;
            this.responseDto = new ResponseDto();
        }

        //////////////////////LISTAR//////////////////////
        [HttpGet]
        [Route("/GetTiposDocs")]
        public async Task<ActionResult<IEnumerable<TipoDocumento>>> GetTiposDocs()
        {
            IEnumerable<TipoDocumento> tiposDocumentos = await tipoDocumentoRepository.GetTiposDocs();
            IEnumerable<TipoDocumentoDto> tiposDocumentosDtos = tiposDocumentos.Select(c =>
            {
                return new TipoDocumentoDto
                {
                    idTd = c.idTd,
                    nameTd = c.nameTd
                };
            });

            this.responseDto.IsSucceed = true;
            this.responseDto.Result = tiposDocumentosDtos;
            this.responseDto.DisplayMessage = "Success";

            return StatusCode(StatusCodes.Status200OK, responseDto);
        }

        [Route("/GetTipoDocumento/{id}")]
        [HttpGet]
        public async Task<ActionResult<TipoDocumento>> GetTipoDocumentoById(int id)
        {
            return StatusCode(StatusCodes.Status200OK, await tipoDocumentoRepository.GetTipoDocumentoById(id));
        }

        //////////////////////AGREGAR//////////////////////
        [HttpPost]
        [Route("/PlaceTipoDoc")]
        public async Task<ActionResult<bool>> placeTipoDoc(TipoDocumento tipoDocumento)
        {
            return StatusCode(StatusCodes.Status201Created, await tipoDocumentoRepository.placeTipoDoc(tipoDocumento));
        }

        //////////////////////ACTUALIZAR//////////////////////
        [HttpPut]
        [Route("/UpdateTipoDocumento")]
        public async Task<ActionResult<TipoDocumento>> UpdateTipoDocumento(TipoDocumento tipoDocumento)
        {
            return Ok(await tipoDocumentoRepository.UpdateTipoDocumento(tipoDocumento));
        }

        /////////////////////////ELIMINAR//////////////////////
        [HttpDelete]
        [Route("/DeleteTipoDocumento/{id}")]
        public async Task<ActionResult<bool>> DeleteTipoDocumento(int id)
        {
            return StatusCode(StatusCodes.Status200OK, await tipoDocumentoRepository.DeleteTipoDocumento(id));
        }
    }
}
