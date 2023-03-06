using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingApi.Dto.Dtos;
using ShoppingApi.Service.Abstract.Command;
using ShoppingApi.Service.Abstract.Query;

namespace ShoppingApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly ICommandProductService _commandProductService;
        private readonly IQueryProductService _queryProductService;
        public ProductController(ICommandProductService commandProductService, IQueryProductService queryProductService)
        {
            _commandProductService = commandProductService;
            _queryProductService = queryProductService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var products = await _queryProductService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("byId/{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var productById = await _queryProductService.GetByIdAsync(id);
            return Ok(productById);
        }

        [HttpGet("byShoppingListId/{shoppingListId}")]
        [Authorize]
        public async Task<IActionResult> GetByShoppingListId(int shoppingListId)
        {
            var productsByShoppingList = await _queryProductService.GetByShoppingListIdAsync(shoppingListId);
            return Ok(productsByShoppingList);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] ProductDto productDto)
        {
            _commandProductService.InsertAsync(productDto);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] ProductDto productDto)
        {
            _commandProductService.UpdateAsync(id, productDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            _commandProductService.RemoveAsync(id);
            return Ok();
        }
    }
}
