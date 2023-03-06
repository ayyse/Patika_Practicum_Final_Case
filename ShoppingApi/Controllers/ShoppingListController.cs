using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingApi.Base.Types;
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
        [Authorize(Roles = $"{Role.Admin}")]
        public async Task<IActionResult> GetAll()
        {
            var shoppingLists = await _queryShoppingListService.GetAllAsync();
            return Ok(shoppingLists);
        }

        [HttpGet("byId/{id}")]
        [Authorize(Roles = $"{Role.Admin}")]
        public async Task<IActionResult> GetById(int id)
        {
            var shoppingListById = await _queryShoppingListService.GetByIdAsync(id);
            return Ok(shoppingListById);
        }

        [HttpGet("byCategoryId/{categoryId}")]
        [Authorize(Roles = $"{Role.Admin}, {Role.Viewer}")]
        public async Task<IActionResult> GetByCategoryId(int categoryId)
        {
            var shoppingListByCategory = await _queryShoppingListService.GetByCategoryIdAsync(categoryId);
            return Ok(shoppingListByCategory);
        }

        [HttpGet("byUserId/{userId}")]
        [Authorize(Roles = $"{Role.Admin}, {Role.Viewer}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var shoppingListByUser = await _queryShoppingListService.GetByUserIdAsync(userId);
            return Ok(shoppingListByUser);
        }

        [HttpGet("byCreateDate/{createDate}")]
        [Authorize(Roles = $"{Role.Admin}, {Role.Viewer}")]
        public async Task<IActionResult> GetByCreateDate(DateTime createDate)
        {
            var shoppingListByCreateDate = await _queryShoppingListService.GetByCreateDateAsync(createDate);
            return Ok(shoppingListByCreateDate);
        }

        [HttpGet("byCompleteDate/{completeDate}")]
        [Authorize(Roles = $"{Role.Admin}, {Role.Viewer}")]
        public async Task<IActionResult> GetByCompleteDate(DateTime completeDate)
        {
            var shoppingListByCompleteDate = await _queryShoppingListService.GetByCompleteDateAsync(completeDate);
            return Ok(shoppingListByCompleteDate);
        }

        [HttpPost]
        [Authorize(Roles = $"{Role.Viewer}")]
        public async Task<IActionResult> Create([FromBody] ShoppingListDto shoppingListDto)
        {
            await _commandShoppingListService.InsertAsync(shoppingListDto);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = $"{Role.Viewer}")]
        public async Task<IActionResult> Update(int id, [FromBody] ShoppingListDto shoppingListDto)
        {
            await _commandShoppingListService.UpdateAsync(id, shoppingListDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = $"{Role.Viewer}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _commandShoppingListService.RemoveAsync(id);
            return Ok();
        }
    }
}
