using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShoppingApi.Base.Jwt;
using ShoppingApi.Base.Response;
using ShoppingApi.Data.Model;
using ShoppingApi.Data.Repository.Abstract;
using ShoppingApi.Data.UnitOfWork.Abstract;
using ShoppingApi.Dto.TokenModels;
using ShoppingApi.Service.Abstract;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShoppingApi.Service.Concrete
{
    public class TokenManagementService : ITokenManagementService
    {
        private readonly IUserRepository _genericRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtConfig _jwtConfig;
        private readonly byte[] _secret;

        public TokenManagementService(IUserRepository genericRepository, IMapper mapper, IUnitOfWork unitOfWork, IOptionsMonitor<JwtConfig> jwtConfig)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _jwtConfig = jwtConfig.CurrentValue;
            _secret = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
        }
        public async Task<BaseResponse<TokenResponse>> GenerateTokensAsync(TokenRequest tokenRequest, DateTime now, string userAgent)
        {
            var user = _genericRepository.Where(x => x.UserName == tokenRequest.UserName).FirstOrDefault();

            if (user is null)
                throw new InvalidOperationException("Invalid user information");

            if (user.Password != tokenRequest.Password)
                throw new InvalidOperationException("Invalid user information");

            var token = GenerateAccessToken(user, now);

            user.LastActivity = DateTime.Now;
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.CompleteAsync();

            TokenResponse response = new TokenResponse
            {
                AccessToken = token,
                ExpireTime = now.AddMinutes(_jwtConfig.AccessTokenExpiration),
                Role = user.Role,
                UserName = user.UserName
            };

            return new BaseResponse<TokenResponse>(response);
        }

        private string GenerateAccessToken(User user, DateTime now)
        {
            // Get claim value
            Claim[] claims = GetClaim(user);

            var shouldAddAudienceClaim = string.IsNullOrWhiteSpace(claims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value);

            var jwtToken = new JwtSecurityToken(
                _jwtConfig.Issuer,
                shouldAddAudienceClaim ? _jwtConfig.Audience : string.Empty,
                claims,
                expires: now.AddMinutes(_jwtConfig.AccessTokenExpiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(_secret), SecurityAlgorithms.HmacSha256Signature));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return accessToken;
        }

        private static Claim[] GetClaim(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("AccountId", user.Id.ToString()),
                new Claim("LastActivity", user.LastActivity.ToLongTimeString())
            };

            return claims;
        }
    }
}
