using AgenciaViajes.Dtos;
using AgenciaViajes.Exceptions;
using AgenciaViajes.Models;
using AgenciaViajes.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgenciaViajes.Controllers
{
    [Route("/api/Aerolinea")]
    [ApiController]
    public class AerolineaController : ControllerBase
    {
        private IAerolineaRepository aerolineaRepository;
        private ResponseDto responseDto;

        public AerolineaController(IAerolineaRepository aerolineaRepository)
        {
            this.aerolineaRepository = aerolineaRepository;
            this.responseDto = new ResponseDto();
        }

        //////////////////////LISTAR//////////////////////
        [HttpGet]
        [Route("/GetAerolineas")]
        public async Task<ActionResult<IEnumerable<Aerolinea>>> GetAerolineas()
        {
            IEnumerable<Aerolinea> aerolineas = await aerolineaRepository.GetAerolineas();
            IEnumerable<AerolineaDto> aerolineasDtos = aerolineas.Select(c =>
            {
                return new AerolineaDto
                {
                    idAero = c.idAero,
                    nameAero = c.nameAero
                };
            });

            this.responseDto.IsSucceed = true;
            this.responseDto.Result = aerolineasDtos;
            this.responseDto.DisplayMessage = "Success";

            return StatusCode(StatusCodes.Status200OK, responseDto);
        }

        [Route("/GetAerolinea/{id}")]
        [HttpGet]
        public async Task<ActionResult<Actividad>> GetAerolineaById(int id)
        {
            return StatusCode(StatusCodes.Status200OK, await aerolineaRepository.GetAerolineaById(id));
        }

        //////////////////////AGREGAR//////////////////////
        [HttpPost]
        [Route("/PlaceAero")]
        public async Task<ActionResult<bool>> placeAero(Aerolinea aerolinea)
        {
            return StatusCode(StatusCodes.Status201Created, await aerolineaRepository.placeAero(aerolinea));
        }

        //////////////////////ACTUALIZAR//////////////////////
        [HttpPut]
        [Route("/UpdateAerolinea")]
        public async Task<ActionResult<Aerolinea>> UpdateAerolinea(Aerolinea aerolinea)
        {
            return Ok(await aerolineaRepository.UpdateAerolinea(aerolinea));
        }

        /////////////////////////ELIMINAR//////////////////////
        [HttpDelete]
        [Route("/DeleteAerolinea/{id}")]
        public async Task<ActionResult<bool>> DeleteAerolinea(int id)
        {
            return StatusCode(StatusCodes.Status200OK, await aerolineaRepository.DeleteAerolinea(id));
        }
    }
}
