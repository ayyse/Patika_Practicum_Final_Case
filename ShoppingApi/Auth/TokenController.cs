using Microsoft.AspNetCore.Mvc;
using ShoppingApi.Base.Jwt;
using ShoppingApi.Dto.TokenModels;
using ShoppingApi.Service.Abstract;
using System.Configuration;

namespace ShoppingApi.Auth
{
    [Route("[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        private readonly ITokenManagementService _tokenManagementService;
        public TokenController(ITokenManagementService tokenManagementService)
        {
            _tokenManagementService = tokenManagementService;
        }

        [HttpPost("token")]
        public async Task<IActionResult> LoginAsync([FromBody] TokenRequest request)
        {
            var userAgent = Request.Headers["User-Agent"].ToString();
            var result = await _tokenManagementService.GenerateTokensAsync(request, DateTime.UtcNow, userAgent);

            if (result.Success)
            {
                //Log.Information($"User: {result.Response.UserName}, Role: {result.Response.Role} is logged in.");
                return Ok(result);
            }

            return Unauthorized();
        }
    }
}
