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
        public async Task<IActionResult> GetAll()
        {
            var products = await _queryProductService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("byId/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var productById = await _queryProductService.GetByIdAsync(id);
            return Ok(productById);
        }

        [HttpGet("byShoppingListId/{shoppingListId}")]
        public async Task<IActionResult> GetByShoppingListId(int shoppingListId)
        {
            var productsByShoppingList = await _queryProductService.GetByShoppingListIdAsync(shoppingListId);
            return Ok(productsByShoppingList);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductDto productDto)
        {
            _commandProductService.InsertAsync(productDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProductDto productDto)
        {
            _commandProductService.UpdateAsync(id, productDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _commandProductService.RemoveAsync(id);
            return Ok();
        }
    }
}
