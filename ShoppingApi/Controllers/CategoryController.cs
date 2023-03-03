using Microsoft.AspNetCore.Mvc;
using ShoppingApi.Dto.Dtos;
using ShoppingApi.Service.Abstract.Command;
using ShoppingApi.Service.Abstract.Query;

namespace ShoppingApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICommandCategoryService _commandCategoryService;
        private readonly IQueryCategoryService _queryCategoryService;
        public CategoryController(ICommandCategoryService commandCategoryService, IQueryCategoryService queryCategoryService)
        {
            _commandCategoryService = commandCategoryService;
            _queryCategoryService = queryCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _queryCategoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _queryCategoryService.GetByIdAsync(id);
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CategoryDto categoryDto)
        {
            _commandCategoryService.InsertAsync(categoryDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CategoryDto categoryDto)
        {
            _commandCategoryService.UpdateAsync(id, categoryDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _commandCategoryService.RemoveAsync(id);
            return Ok();
        }
    }
}
