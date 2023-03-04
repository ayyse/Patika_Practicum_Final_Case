using Microsoft.AspNetCore.Mvc;
using ShoppingApi.Dto.Dtos;
using ShoppingApi.Service.Abstract.Command;
using ShoppingApi.Service.Abstract.Query;
using ShoppingApi.Service.Concrete.Command;
using ShoppingApi.Service.Concrete.Query;

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
        public async Task<IActionResult> GetAll()
        {
            var shoppingLists = await _queryShoppingListService.GetAllAsync();
            return Ok(shoppingLists);
        }

        [HttpGet("byId/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var shoppingListById = await _queryShoppingListService.GetByIdAsync(id);
            return Ok(shoppingListById);
        }

        [HttpGet("byCategoryId/{categoryId}")]
        public async Task<IActionResult> GetByCategoryId(int categoryId)
        {
            var shoppingListByCategory = await _queryShoppingListService.GetByCategoryIdAsync(categoryId);
            return Ok(shoppingListByCategory);
        }

        [HttpGet("byCreateDate/{createDate}")]
        public async Task<IActionResult> GetByCreateDate(DateTime createDate)
        {
            var shoppingListByCreateDate = await _queryShoppingListService.GetByCreateDateAsync(createDate);
            return Ok(shoppingListByCreateDate);
        }

        [HttpGet("byCompleteDate/{completeDate}")]
        public async Task<IActionResult> GetByCompleteDate(DateTime completeDate)
        {
            var shoppingListByCompleteDate = await _queryShoppingListService.GetByCompleteDateAsync(completeDate);
            return Ok(shoppingListByCompleteDate);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ShoppingListDto shoppingListDto)
        {
            _commandShoppingListService.InsertAsync(shoppingListDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ShoppingListDto shoppingListDto)
        {
            _commandShoppingListService.UpdateAsync(id, shoppingListDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _commandShoppingListService.RemoveAsync(id);
            return Ok();
        }
    }
}
