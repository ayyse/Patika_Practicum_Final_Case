using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingApi.Base.Types;
using ShoppingApi.Dto.Dtos;
using ShoppingApi.Dto.Validators;
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
        [Authorize(Roles = $"{Role.Admin}")]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _queryCategoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = $"{Role.Admin}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _queryCategoryService.GetByIdAsync(id);
            return Ok(category);
        }

        [HttpPost]
        [Authorize(Roles = $"{Role.Viewer}")]
        public async Task<IActionResult> Create([FromBody] CategoryDto categoryDto)
        {
            await _commandCategoryService.InsertAsync(categoryDto);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = $"{Role.Viewer}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryDto categoryDto)
        {
            await _commandCategoryService.UpdateAsync(id, categoryDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = $"{Role.Viewer}")]
        public async Task<IActionResult> Delete(int id)
        {
            CategoryDto categoryDto = new CategoryDto();
            await _commandCategoryService.RemoveAsync(id);
            return Ok();
        }
    }
}
