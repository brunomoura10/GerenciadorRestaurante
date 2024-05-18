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
                var restaurante = await _restauranteService.ObterPorId(id);
                return Ok(restaurante);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        //endpoint para obter o restaurante e todas as suas reservas para o dia
        //será passado o id do restaurante e a data que deseja obter as reservas

        [HttpGet("obter-reservas-por-data/{id}/{data}")]      
        public async Task<IActionResult> ObterReservasPorData([FromRoute] long id, [FromRoute] DateTime data)
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
