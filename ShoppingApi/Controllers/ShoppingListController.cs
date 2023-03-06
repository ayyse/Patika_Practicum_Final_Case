using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingApi.Dto.Dtos;
using ShoppingApi.Service.Abstract.Command;
using ShoppingApi.Service.Abstract.Query;

namespace ShoppingApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShoppingListController : Controller
    {
        private readonly ICommandShoppingListService _commandShoppingListService;
        private readonly IQueryShoppingListService _queryShoppingListService;
        public ShoppingListController(ICommandShoppingListService commandShoppingListService, IQueryShoppingListService queryShoppingListService)
        {
            _commandShoppingListService = commandShoppingListService;
            _queryShoppingListService = queryShoppingListService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var shoppingLists = await _queryShoppingListService.GetAllAsync();
            return Ok(shoppingLists);
        }

        [HttpGet("byId/{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var shoppingListById = await _queryShoppingListService.GetByIdAsync(id);
            return Ok(shoppingListById);
        }

        [HttpGet("byCategoryId/{categoryId}")]
        [Authorize]
        public async Task<IActionResult> GetByCategoryId(int categoryId)
        {
            var shoppingListByCategory = await _queryShoppingListService.GetByCategoryIdAsync(categoryId);
            return Ok(shoppingListByCategory);
        }

        [HttpGet("byCreateDate/{createDate}")]
        [Authorize]
        public async Task<IActionResult> GetByCreateDate(DateTime createDate)
        {
            var shoppingListByCreateDate = await _queryShoppingListService.GetByCreateDateAsync(createDate);
            return Ok(shoppingListByCreateDate);
        }

        [HttpGet("byCompleteDate/{completeDate}")]
        [Authorize]
        public async Task<IActionResult> GetByCompleteDate(DateTime completeDate)
        {
            var shoppingListByCompleteDate = await _queryShoppingListService.GetByCompleteDateAsync(completeDate);
            return Ok(shoppingListByCompleteDate);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create([FromBody] ShoppingListDto shoppingListDto)
        {
            _commandShoppingListService.InsertAsync(shoppingListDto);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Update(int id, [FromBody] ShoppingListDto shoppingListDto)
        {
            _commandShoppingListService.UpdateAsync(id, shoppingListDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            _commandShoppingListService.RemoveAsync(id);
            return Ok();
        }
    }
}
