using GerenciadorRestaurante.Application.Models.InputModels;
using GerenciadorRestaurante.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorRestaurante.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public LoginController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("GerarToken")]
        public async Task<IActionResult> GerarToken([FromBody] LoginInputModel loginDTO)
        {
            var token = await _tokenService.GerarToken(loginDTO);

            return Ok(token);
        }
    }
}
