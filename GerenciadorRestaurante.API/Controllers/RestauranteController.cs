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

        public RestauranteController(IRestauranteService restauranteService)
        {
            _restauranteService = restauranteService;
        }

        [HttpPost("cadastrar-restaurante")]
        public async Task<IActionResult> CadastrarRestaurante([FromBody] RestauranteInputModel restauranteInputModel)
        {
            try
            {
                await _restauranteService.CadastrarRestaurante(restauranteInputModel);
                return Ok();
            }
            catch (Exception e)
            {

               return BadRequest(e.Message);
            }
            
        }
    }
}
