using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorRestaurante.Application.Models.InputModels;
using GerenciadorRestaurante.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorRestaurante.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MesaController : ControllerBase
    {
        private readonly IMesaService _mesaService;

        public MesaController(IMesaService mesaService)
        {
            _mesaService = mesaService;
        }

        [HttpPost("cadastrar-mesa")]
        public async Task<IActionResult> CadastrarMesa([FromBody] MesaInputModel mesaInputModel)
        {
            try
            {
                await _mesaService.CadastrarMesa(mesaInputModel);
                return Ok("Mesa Cadastrada com Sucesso");
            }
            catch (Exception e)
            {

               return BadRequest(e.Message);
            }
            
        }

        [HttpPut("atualizar-mesa/{id}")]
        public async Task<IActionResult> AtualizarMesa([FromRoute] long id, [FromBody] MesaInputModel mesaInputModel)
        {
            try
            {
                await _mesaService.AtualizarMesa(id, mesaInputModel);
                return Ok("Mesa Atualizada com Sucesso");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("excluir-mesa/{id}")]
        public async Task<IActionResult> ExcluirMesa([FromRoute] long id)
        {
            try
            {
                await _mesaService.ExcluirMesa(id);
                return Ok($"Mesa com id: {id} excluida");
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
                var mesas = await _mesaService.ObterTodos();
                return Ok(mesas);
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
                var mesa = await _mesaService.ObterPorId(id);
                return Ok(mesa);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}