using EstoqueOnline.Application.DTOS;
using EstoqueOnline.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private ILogger<UsuarioController> _logger;
        private IUsuarioService _usuarioService;

        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioService usuarioService)
        {
            _logger = logger;
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarUsuario([FromBody] UsuarioDTO usuario)
        {
            if (usuario == null) return BadRequest("Usuário não pode ser nulo");
            _usuarioService.RegistrarUsuario(usuario);
            return CreatedAtAction(nameof(CadastrarUsuario),null);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogarUsuario([FromBody] UsuarioLoginDTO usuario)
        {
            var token = await _usuarioService.LogarUsuario(usuario);
            if (string.IsNullOrEmpty(token)) return BadRequest("usuário ou senha inválido");
            return Ok(token);
        }
    }
}
