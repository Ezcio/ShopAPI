using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sklep.Models;
using Sklep.Services.ItemService;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;


namespace Sklep.Controllers
{


    [ApiController]
    [Route("api/Item/")]
    public class ItemController : ControllerBase
    {
        private readonly ILogger<ItemController> _logger;
        private readonly IItemServices _itemService;

        public ItemController(ILogger<ItemController> logger, IItemServices itemService)
        {
            _logger = logger;
            _itemService = itemService;
        }

        [HttpPost("AddItem")]
        public async Task<ActionResult> AddItem([FromBody] AddItemDto dto)
        {
            await _itemService.AddItem(dto);
            return NoContent();
        }
        
        [Authorize]
        [HttpPost("GetCategoryById/{id}")]
        public async Task<ActionResult> GetCategoryById(int id)
        {
            var result = await _itemService.GetCategoryById(id);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("GetAllCategores")]
        public async Task<ActionResult<string>> GetAllCategores()
        {
            var result = await _itemService.GetAllCategores();
            return Ok(JsonSerializer.Serialize(result));
        }

        [Authorize]
        [HttpPost("GetProposedItems")]
        public async Task<ActionResult<string>> GetProposedItems([FromBody] ProposedItemsRequest dto)
        {
            var result = await _itemService.GetProposedItems(dto);
            return Ok(JsonSerializer.Serialize(result));

        }

        [HttpGet("GetAllItems")]
        public async Task<ActionResult<string>> GetAllItems([FromQuery]string searchPhrasem, ItemsDto dto )
        {
            var response = _itemService.GetAllItems(dto, searchPhrasem);
            var resultJson = JsonSerializer.Serialize(response);    
            return resultJson;
        }



    }
}
