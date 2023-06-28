using AgenciaViajes.Dtos;
using AgenciaViajes.Models;
using AgenciaViajes.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AgenciaViajes.Controllers
{
    [Route("/api/Hotel")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private IHotelRepository hotelRepository;
        private ResponseDto responseDto;

        public HotelController(IHotelRepository hotelRepository)
        {
            this.hotelRepository = hotelRepository;
            this.responseDto = new ResponseDto();
        }

        //////////////////////LISTAR//////////////////////
        [HttpGet]
        [Route("/GetHoteles")]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHoteles()
        {
            IEnumerable<Hotel> hoteles = await hotelRepository.GetHoteles();
            IEnumerable<HotelDto> hotelesDtos = hoteles.Select(c =>
            {
                return new HotelDto
                {
                    idHot = c.idHot,
                    nameHot = c.nameHot,
                    addressHot = c.addressHot,
                    priceHot = c.priceHot
                };
            });

            this.responseDto.IsSucceed = true;
            this.responseDto.Result = hotelesDtos;
            this.responseDto.DisplayMessage = "Success";

            return StatusCode(StatusCodes.Status200OK, responseDto);
        }

        [Route("/GetHotel/{id}")]
        [HttpGet]
        public async Task<ActionResult<Hotel>> GetHotelById(int id)
        {
            return StatusCode(StatusCodes.Status200OK, await hotelRepository.GetHotelById(id));
        }

        //////////////////////AGREGAR//////////////////////
        [HttpPost]
        [Route("/PlaceHotel")]
        public async Task<ActionResult<bool>> placeHotel(Hotel hotel)
        {
            return StatusCode(StatusCodes.Status201Created, await hotelRepository.placeHotel(hotel));
        }

        //////////////////////ACTUALIZAR//////////////////////
        [HttpPut]
        [Route("/UpdateHotel")]
        public async Task<ActionResult<Hotel>> UpdateHotel(Hotel hotel)
        {
            return Ok(await hotelRepository.UpdateHotel(hotel));
        }

        /////////////////////////ELIMINAR//////////////////////
        [HttpDelete]
        [Route("/DeleteHotel/{id}")]
        public async Task<ActionResult<bool>> DeleteHotel(int id)
        {
            return StatusCode(StatusCodes.Status200OK, await hotelRepository.DeleteHotel(id));
        }
    }
}
