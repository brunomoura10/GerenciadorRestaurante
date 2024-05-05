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

        [HttpPost("cadastrar-prato-restaurante")]
        public async Task<IActionResult> CadastrarPratoRestaurante([FromBody] RestaurantePratoInputModel pratoInputModel)
        {
            try
            {
                await _restaurantePratoService.CadastrarPratoRestaurante(pratoInputModel);
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
                return Ok(new {restaurantePrato.Id,
                    restaurantePrato.RestauranteId,
                    restaurantePrato.PratoId,
                    restaurantePrato.Disponivel, 
                    Restaurante =  new {RestauranteNome = restaurantePrato.Restaurante.Nome},
                    Prato = new
                    {
                        PratoNome = restaurantePrato.Prato.Nome,
                        PratoPreco = restaurantePrato.Prato.Preco
                    }
                    });;
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
