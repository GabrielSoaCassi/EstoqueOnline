using EstoqueOnline.Application.Services;
using EstoqueOnline.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ItemController : ControllerBase
    {
        private readonly ILogger<ItemController> _logger;
        private readonly IItemService _itemService;

        public ItemController(ILogger<ItemController> logger, IItemService itemService)
        {
            _logger = logger;
            _itemService = itemService;
        }

        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] Item item)
        {
            try
            {
                if (item == null) return BadRequest("Item não pode ser vazio");
                var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
                _itemService.AddItem(userId, item);
                return CreatedAtAction(nameof(AddItem), null);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
