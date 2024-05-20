using GerenciadorRestaurante.Application.Models.InputModels;
using GerenciadorRestaurante.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorRestaurante.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestauranteController : ControllerBase
    {
        private readonly IRestauranteService _restauranteService;
        private readonly ILogger<RestauranteController> _logger;

        public RestauranteController(IRestauranteService restauranteService, ILogger<RestauranteController> logger)
        {
            _restauranteService = restauranteService;
            _logger = logger;
        }

        [HttpPost("cadastrar-restaurante")]
        public async Task<IActionResult> CadastrarRestaurante([FromBody] RestauranteInputModel restauranteInputModel)
        {
            try
            {
                await _restauranteService.CadastrarRestaurante(restauranteInputModel);
                return Ok("Restaurante Cadastrado com Sucesso");
            }
            catch (Exception e)
            {

               return BadRequest(e.Message);
            }
            
        }

        [HttpPut("atualizar-restaurante/{id}")]
        public async Task<IActionResult> AtualizarRestaurante([FromRoute] long id, [FromBody] RestauranteInputModel restauranteInputModel)
        {
            try
            {
                await _restauranteService.AtualizarRestaurante(id, restauranteInputModel);
                return Ok("Restaurante Atualizado com Sucesso");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("excluir-restaurante/{id}")]
        public async Task<IActionResult> ExcluirRestaurante([FromRoute] long id)
        {
            try
            {
                await _restauranteService.ExcluirRestaurante(id);
                return Ok($"Restaurante com id: {id} excluido");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("obter-todos")]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                var restaurantes = await _restauranteService.ObterTodos();
                return Ok(restaurantes);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpGet("obter-por-id/{id}")]      
        public async Task<IActionResult> ObterPorId([FromRoute] long id)
        {
            try
            {
                _logger.LogInformation("Obtendo restaurante por id");
                var restaurante = await _restauranteService.ObterPorId(id);
                return Ok(restaurante);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("obter-restaurante-com-reserva-por-data/{id}/{data}")]
        public async Task<IActionResult> ObterRestauranteComReservas([FromRoute] long id, [FromRoute] DateTime data)
        {
            try
            {
                var restaurante = await _restauranteService.ObterRestauranteComReservas(id, data);
                return Ok(restaurante);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
