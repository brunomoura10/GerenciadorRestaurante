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
    public class PratoController : ControllerBase
    {
                private readonly IPratoService _pratoService;

        public PratoController(IPratoService pratoService)
        {
            _pratoService = pratoService;
        }

        [HttpPost("cadastrar-prato")]
        public async Task<IActionResult> CadastrarPrato([FromBody] PratoInputModel pratoInputModel)
        {
            try
            {
                await _pratoService.CadastrarPrato(pratoInputModel);
                return Ok("Mesa Cadastrada com Sucesso");
            }
            catch (Exception e)
            {

               return BadRequest(e.Message);
            }
            
        }

        [HttpPut("atualizar-prato/{id}")]
        public async Task<IActionResult> AtualizarPrato([FromRoute] long id, [FromBody] PratoInputModel pratoInputModel)
        {
            try
            {
                await _pratoService.AtualizarPrato(id, pratoInputModel);
                return Ok("Prato Atualizado com Sucesso");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("excluir-prato/{id}")]
        public async Task<IActionResult> ExcluirPrato([FromRoute] long id)
        {
            try
            {
                await _pratoService.ExcluirPrato(id);
                return Ok($"Prato com id: {id} excluido");
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
                var mesas = await _pratoService.ObterTodos();
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
                var mesa = await _pratoService.ObterPorId(id);
                return Ok(mesa);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}