using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingApi.Base.Types;
using ShoppingApi.Dto.Dtos;
using ShoppingApi.Service.Abstract.Command;
using ShoppingApi.Service.Abstract.Query;
using ShoppingApi.Service.Concrete.Command;
using ShoppingApi.Service.Concrete.Query;

namespace ShoppingApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ICommandUserService _commandUserService;
        private readonly IQueryUserService _queryUserService;
        public UserController(ICommandUserService commandUserService, IQueryUserService queryUserService)
        {
            _commandUserService = commandUserService;
            _queryUserService = queryUserService;
        }

        [HttpGet]
        [Authorize(Roles = $"{Role.Admin}")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _queryUserService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = $"{Role.Admin}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _queryUserService.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpPost]
        [Authorize(Roles = $"{Role.Admin}, {Role.Viewer}")]
        public async Task<IActionResult> Create([FromBody] UserDto userDto)
        {
            await _commandUserService.InsertAsync(userDto);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = $"{Role.Admin}, {Role.Viewer}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserDto userDto)
        {
            await _commandUserService.UpdateAsync(id, userDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = $"{Role.Admin}, {Role.Viewer}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _commandUserService.RemoveAsync(id);
            return Ok();
        }
    }
}
