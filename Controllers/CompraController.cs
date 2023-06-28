using AgenciaViajes.Dtos;
using AgenciaViajes.Models;
using AgenciaViajes.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AgenciaViajes.Controllers
{
    [Route("/api/Compra")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private ICompraRepository compraRepository;
        private ResponseDto responseDto;

        public CompraController(ICompraRepository compraRepository)
        {
            this.compraRepository = compraRepository;
            this.responseDto = new ResponseDto();
        }

        //////////////////////LISTAR//////////////////////
        [HttpGet]
        [Route("/GetCompras")]
        public async Task<ActionResult<IEnumerable<Compra>>> GetCompras()
        {
            IEnumerable<Compra> compras = await compraRepository.GetCompras();
            IEnumerable<CompraDto> comprasDtos = compras.Select(c =>
            {
                return new CompraDto
                {
                    idCr = c.idCr,
                    subtotalCr = c.subtotalCr,
                    totalCr = c.totalCr,
                    idVuelo = c.idVuelo,
                    vuelo = c.vuelo,
                    idHot = c.idHot,
                    hotel = c.hotel,
                    idCl = c.idCl,
                    cliente = c.cliente,
                    idTb = c.idTb,
                    trabajador = c.trabajador,
                    idAct = c.idAct,
                    actividad = c.actividad
                };
            });

            this.responseDto.IsSucceed = true;
            this.responseDto.Result = comprasDtos;
            this.responseDto.DisplayMessage = "Success";

            return StatusCode(StatusCodes.Status200OK, responseDto);
        }

        //////////////////////AGREGAR//////////////////////
        [HttpPost]
        [Route("/PlaceCompra")]
        public async Task<ActionResult<bool>> placeWorker(Compra compra)
        {
            return StatusCode(StatusCodes.Status201Created, await compraRepository.placeCompra(compra));
        }

        //////////////////////ACTUALIZAR//////////////////////
        [HttpPut]
        [Route("/UpdateCompra")]
        public async Task<ActionResult<Compra>> UpdateCompra(Compra compra)
        {
            return Ok(await compraRepository.UpdateCompra(compra));
        }

        /////////////////////////ELIMINAR//////////////////////
        [HttpDelete]
        [Route("/DeleteCompra/{id}")]
        public async Task<ActionResult<bool>> DeleteCompra(int id)
        {
            return StatusCode(StatusCodes.Status200OK, await compraRepository.DeleteCompra(id));
        }
    }
}
