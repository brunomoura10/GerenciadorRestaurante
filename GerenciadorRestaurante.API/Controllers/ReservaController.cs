using GerenciadorRestaurante.Application.Models.InputModels;
using GerenciadorRestaurante.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorRestaurante.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservaController : ControllerBase
    {
        #region Atributos
        private readonly IReservaService _reservaService;
        #endregion

        #region Construtor
        public ReservaController(IReservaService reservaSerivce)
        {

            _reservaService = reservaSerivce;
        }
        #endregion

        #region CadastrarReserva
        [HttpPost("cadastrar-reserva")]
        public async Task<IActionResult> CadastrarReserva([FromBody] ReservaInputModel reservaInputModel)
        {
            try
            {
                await _reservaService.CadastrarReserva(reservaInputModel);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        #endregion

        #region ConsultarReservaPorId
        [HttpGet("consultar-reserva/{id}")]
        public async Task<IActionResult> ConsultarReservaPorId(int id)
        {
            try
            {
                var reserva = await _reservaService.ConsultarReservaPorId(id);
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

        #region ConsultarReservas
        [HttpGet("consultar-reservas")]
        public async Task<IActionResult> ConsultarTodasAsReservas()
        {
            try
            {
                var reservas = await _reservaService.ConsultarTodasAsReservas();
                return Ok(reservas);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion

        #region Deletar Reserva
        [HttpDelete("deletar-reserva/{id}")]
        public async Task<IActionResult> DeletarReserva(int id)
        {
            try
            {
                await _reservaService.DeletarReserva(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion

        #region AtualizarReserva
        [HttpPut("atualizar-reserva/{id}")]
        public async Task<IActionResult> AtualizarReserva(int id, [FromBody] ReservaInputModel reservaInputModel)
        {
            try
            {
                await _reservaService.AtualizarReserva(id, reservaInputModel);
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
