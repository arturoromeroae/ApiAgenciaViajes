using AgenciaViajes.Dtos;
using AgenciaViajes.Models;
using AgenciaViajes.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AgenciaViajes.Controllers
{
    [Route("/api/Actividad")]
    [ApiController]
    public class ActividadController : ControllerBase
    {
        private IActividadRepository actividadRepository;
        private ResponseDto responseDto;

        public ActividadController(IActividadRepository actividadRepository)
        {
            this.actividadRepository = actividadRepository;
            this.responseDto = new ResponseDto();
        }

        //////////////////////LISTAR//////////////////////
        [HttpGet]
        [Route("/GetActividades")]
        public async Task<ActionResult<IEnumerable<Actividad>>> GetActividades()
        {
            IEnumerable<Actividad> actividades = await actividadRepository.GetActividades();
            IEnumerable<ActividadDto> actividadesDtos = actividades.Select(c =>
            {
                return new ActividadDto
                {
                    idAct = c.idAct,
                    nameAct = c.nameAct,
                    duracionAct = c.duracionAct,
                    precioAct = c.precioAct
                };
            });

            this.responseDto.IsSucceed = true;
            this.responseDto.Result = actividadesDtos;
            this.responseDto.DisplayMessage = "Success";

            return StatusCode(StatusCodes.Status200OK, responseDto);
        }

        [Route("/GetActividad/{id}")]
        [HttpGet]
        public async Task<ActionResult<Actividad>> GetCustomerById(int id)
        {
            return StatusCode(StatusCodes.Status200OK, await actividadRepository.GetActividadById(id));
        }

        //////////////////////AGREGAR//////////////////////
        [HttpPost]
        [Route("/PlaceActividad")]
        public async Task<ActionResult<bool>> placeActividad(Actividad actividad)
        {
            return StatusCode(StatusCodes.Status201Created, await actividadRepository.placeActividad(actividad));
        }

        //////////////////////ACTUALIZAR//////////////////////
        [HttpPut]
        [Route("/UpdateActividad")]
        public async Task<ActionResult<Actividad>> UpdateActividad(Actividad actividad)
        {
            return Ok(await actividadRepository.UpdateActividad(actividad));
        }

        /////////////////////////ELIMINAR//////////////////////
        [HttpDelete]
        [Route("/DeleteActividad/{id}")]
        public async Task<ActionResult<bool>> DeleteActividad(int id)
        {
            return StatusCode(StatusCodes.Status200OK, await actividadRepository.DeleteActividad(id));
        }
    }
}
