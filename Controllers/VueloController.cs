using AgenciaViajes.Dtos;
using AgenciaViajes.Models;
using AgenciaViajes.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AgenciaViajes.Controllers
{
    [Route("/api/Vuelo")]
    [ApiController]
    public class VueloController : ControllerBase
    {
        private IVueloRepository vueloRepository;
        private ResponseDto responseDto;

        public VueloController(IVueloRepository vueloRepository)
        {
            this.vueloRepository = vueloRepository;
            this.responseDto = new ResponseDto();
        }

        //////////////////////LISTAR//////////////////////
        [HttpGet]
        [Route("/GetVuelos")]
        public async Task<ActionResult<IEnumerable<Vuelo>>> GetVuelos()
        {
            IEnumerable<Vuelo> vuelos = await vueloRepository.GetVuelos();
            IEnumerable<VueloDto> vuelosDtos = vuelos.Select(c =>
            {
                return new VueloDto
                {
                    idVuelo = c.idVuelo,
                    destinoVuelo = c.destinoVuelo,
                    salidaVuelo = c.salidaVuelo,
                    dateVuelo = c.dateVuelo,
                    asientoVuelo = c.asientoVuelo,
                    precio = c.precio,
                    idAero = c.idAero
                };
            });

            this.responseDto.IsSucceed = true;
            this.responseDto.Result = vuelosDtos;
            this.responseDto.DisplayMessage = "Success";

            return StatusCode(StatusCodes.Status200OK, responseDto);
        }

        [Route("/GetVuelo/{id}")]
        [HttpGet]
        public async Task<ActionResult<Trabajador>> GetVueloById(int id)
        {
            return StatusCode(StatusCodes.Status200OK, await vueloRepository.GetVueloById(id));
        }

        //////////////////////AGREGAR//////////////////////
        [HttpPost]
        [Route("/PlaceVuelo")]
        public async Task<ActionResult<bool>> placeVuelo(Vuelo vuelo)
        {
            return StatusCode(StatusCodes.Status201Created, await vueloRepository.PlaceVuelo(vuelo));
        }

        //////////////////////ACTUALIZAR//////////////////////
        [HttpPut]
        [Route("/UpdateVuelo")]
        public async Task<ActionResult<Vuelo>> UpdateVuelo(Vuelo vuelo)
        {
            return Ok(await vueloRepository.UpdateVuelo(vuelo));
        }

        /////////////////////////ELIMINAR//////////////////////
        [HttpDelete]
        [Route("/DeleteVuelo/{id}")]
        public async Task<ActionResult<bool>> DeleteVuelo(int id)
        {
            return StatusCode(StatusCodes.Status200OK, await vueloRepository.DeleteVuelo(id));
        }
    }
}
