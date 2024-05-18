using GerenciadorRestaurante.Application.Models.InputModels;
using GerenciadorRestaurante.Application.Services;
using GerenciadorRestaurante.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace GerenciadorRestaurante.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {

        #region Atributos
        private readonly IClienteService _clienteService;
        #endregion

        #region Construtor
        public ClienteController(IClienteService clienteService)
        {

            _clienteService = clienteService;
        }
        #endregion
        #region Cadastrar Cliente
        [HttpPost("cadastrar-cliente")]
        public async Task<IActionResult> CadastrarCliente([FromBody] ClienteInputModel clienteInputModel)
        {
            try
            {
                await _clienteService.CadastrarCliente(clienteInputModel);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        #endregion

        #region Consultar Cliente Por Id
        [HttpGet("consultar-cliente/{id}")]
        public async Task<IActionResult> ConsultarClienteporId(int id)
        {
            try
            {
                var reserva = await _clienteService.ConsultarClientePorId(id);
                if (reserva == null)
                {
                    return NotFound();
                }
                return Ok(reserva);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion

        #region Consultar Clientes
        [HttpGet("consultar-clientes")]
        public async Task<IActionResult> ConsultarTodasAsReservas()
        {
            try
            {
                var reservas = await _clienteService.ConsultarTodosClientes();
                return Ok(reservas);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion

        #region Deletar Cliente
        [HttpDelete("deletar-cliente/{id}")]
        public async Task<IActionResult> DeletarCliente(int id)
        {
            try
            {
                await _clienteService.DeletarReserva(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion

        #region Atualizar Cliente
        [HttpPut("atualizar-cliente/{id}")]
        public async Task<IActionResult> AtualizarReserva(int id, [FromBody] ClienteInputModel clienteInputModel)
        {
            try
            {
                await _clienteService.AtualizarCliente(id, clienteInputModel);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion
    }
}
