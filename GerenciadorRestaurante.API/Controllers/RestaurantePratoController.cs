using GerenciadorRestaurante.Application.Models.InputModels;
using GerenciadorRestaurante.Application.Services.Interfaces;
using GerenciadorRestaurante.Core.Entites;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorRestaurante.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantePratoController : ControllerBase
    {
        private readonly IRestaurantePratoService _restaurantePratoService;

        public RestaurantePratoController(IRestaurantePratoService restaurantePratoService)
        {
            _restaurantePratoService = restaurantePratoService;
        }

        [HttpPost("cadastrar-restaurante-prato")]
        public async Task<IActionResult> CadastrarPratoRestaurante([FromBody] RestaurantePratoInputModel restaurantePratoInputModel)
        {
            try
            {
                await _restaurantePratoService.CadastrarPratoRestaurante(restaurantePratoInputModel);
                return Ok("RestaurantePrato Cadastrado com Sucesso");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
        [HttpGet("obter-restaurante-prato/{id}")]
        public async Task<IActionResult> ObterRestaurantePrato([FromRoute] long id)
        {
            try
            {
                var restaurantePrato = await _restaurantePratoService.ObterRestaurantePrato(id);
                return Ok(restaurantePrato);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("obter-todos-restaurante-prato")]
        public async Task<IActionResult> ObterTodosRestaurantePrato()
        {
            try
            {
                var restaurantePratos = await _restaurantePratoService.ObterTodosRestaurantePrato();
                return Ok(restaurantePratos);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut("atualizar-restaurante-prato/{id}")]
        public async Task<IActionResult> AtualizarRestaurantePrato([FromRoute] long id, [FromBody] RestaurantePratoUpdateModel restaurantePratoUpdateModel)
        {
            try
            {
                await _restaurantePratoService.AtualizarRestaurantePrato(id, restaurantePratoUpdateModel);
                return Ok("RestaurantePrato Atualizado com Sucesso");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
