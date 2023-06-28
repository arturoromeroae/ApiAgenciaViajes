using AgenciaViajes.Dtos;
using AgenciaViajes.Models;
using AgenciaViajes.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AgenciaViajes.Controllers
{
    [Route("/api/Trabajador")]
    [ApiController]
    public class TrabajadorController : ControllerBase
    {
        private ITrabajadorRepository trabajadorRepository;
        private ResponseDto responseDto;

        public TrabajadorController(ITrabajadorRepository trabajadorRepository)
        {
            this.trabajadorRepository = trabajadorRepository;
            this.responseDto = new ResponseDto();
        }

        //////////////////////LISTAR//////////////////////
        [HttpGet]
        [Route("/GetWorkers")]
        public async Task<ActionResult<IEnumerable<Trabajador>>> GetWorkers()
        {
            IEnumerable<Trabajador> trabajadores = await trabajadorRepository.GetWorkers();
            IEnumerable<TrabajadorDto> trabajadoresDtos = trabajadores.Select(c =>
            {
                return new TrabajadorDto
                {
                    idTrab = c.idTrab,
                    nameTrab = c.nameTrab,
                    lnameTrab = c.lnameTrab,
                    nroDocTrab = c.nroDocTrab,
                    idTd = c.idTd
                };
            });

            this.responseDto.IsSucceed = true;
            this.responseDto.Result = trabajadoresDtos;
            this.responseDto.DisplayMessage = "Success";

            return StatusCode(StatusCodes.Status200OK, responseDto);
        }

        [Route("/GetTrabajador/{id}")]
        [HttpGet]
        public async Task<ActionResult<Trabajador>> GetTrabajadorById(int id)
        {
            return StatusCode(StatusCodes.Status200OK, await trabajadorRepository.GetTrabajadorById(id));
        }

        //////////////////////AGREGAR//////////////////////
        [HttpPost]
        [Route("/PlaceWorker")]
        public async Task<ActionResult<bool>> placeWorker(Trabajador trabajador)
        {
            return StatusCode(StatusCodes.Status201Created, await trabajadorRepository.placeWorker(trabajador));
        }

        //////////////////////ACTUALIZAR//////////////////////
        [HttpPut]
        [Route("/UpdateTrabajador")]
        public async Task<ActionResult<Trabajador>> UpdateTrabajador(Trabajador trabajador)
        {
            return Ok(await trabajadorRepository.UpdateTrabajador(trabajador));
        }

        /////////////////////////ELIMINAR//////////////////////
        [HttpDelete]
        [Route("/DeleteTrabajador/{id}")]
        public async Task<ActionResult<bool>> DeleteTrabajador(int id)
        {
            return StatusCode(StatusCodes.Status200OK, await trabajadorRepository.DeleteTrabajador(id));
        }
    }
}
