using EstoqueOnline.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueService _service;
        private ILogger<EstoqueController> _logger;
        public EstoqueController(IEstoqueService service, ILogger<EstoqueController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> ObterEstoque()
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
                var estoque = await _service.FindEstoque(userId);
                return Ok(estoque);
            }
            catch(Exception ex)
            {
                return BadRequest("Erro ao tentar obter um estoque");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEstoque([FromBody] string? localizacao)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
                await _service.AddEstoque(userId, localizacao);
                return Created();
            }
            catch (Exception ex) {
                return BadRequest("Erro ao tentar adicionar um estoque, procure nosso time de suporte!");
            }
        }
    }
}
