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
        public async Task<IActionResult> GetAll()
        {
            var users = await _queryUserService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _queryUserService.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserDto userDto)
        {
            _commandUserService.InsertAsync(userDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UserDto userDto)
        {
            _commandUserService.UpdateAsync(id, userDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _commandUserService.RemoveAsync(id);
            return Ok();
        }
    }
}
