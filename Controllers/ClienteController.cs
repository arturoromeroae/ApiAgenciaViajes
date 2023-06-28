using AgenciaViajes.Dtos;
using AgenciaViajes.Models;
using AgenciaViajes.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AgenciaViajes.Controllers
{
    [Route("/api/Cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteRepository clienteRepository;
        private ResponseDto responseDto;

        public ClienteController(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
            this.responseDto = new ResponseDto();
        }

        //////////////////////LISTAR//////////////////////
        [HttpGet]
        [Route("/GetClientes")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            IEnumerable<Cliente> clientes = await clienteRepository.GetClientes();
            IEnumerable<ClienteDto> clientesDtos = clientes.Select(c =>
            {
                return new ClienteDto
                {
                    idCl = c.idCl,
                    nameCl = c.nameCl,
                    lnameCl = c.lnameCl,
                    nroDocCl = c.nroDocCl,
                    idTd = c.idTd
                };
            });

            this.responseDto.IsSucceed = true;
            this.responseDto.Result = clientesDtos;
            this.responseDto.DisplayMessage = "Success";

            return StatusCode(StatusCodes.Status200OK, responseDto);
        }

        //////////////////////AGREGAR//////////////////////
        [HttpPost]
        [Route("/PlaceCliente")]
        public async Task<ActionResult<bool>> placeCliente(Cliente cliente)
        {
            return StatusCode(StatusCodes.Status201Created, await clienteRepository.placeCliente(cliente));
        }

        //////////////////////ACTUALIZAR//////////////////////
        [HttpPut]
        [Route("/UpdateCliente")]
        public async Task<ActionResult<Cliente>> UpdateCliente(Cliente cliente)
        {
            return Ok(await clienteRepository.UpdateCliente(cliente));
        }

        /////////////////////////ELIMINAR//////////////////////
        [HttpDelete]
        [Route("/DeleteCliente/{id}")]
        public async Task<ActionResult<bool>> DeleteCliente(int id)
        {
            return StatusCode(StatusCodes.Status200OK, await clienteRepository.DeleteCliente(id));
        }
    }
}
