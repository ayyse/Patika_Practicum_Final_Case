using ShoppingApi.Base.Response;
using ShoppingApi.Dto.TokenModels;

namespace ShoppingApi.Service.Abstract
{
    public interface ITokenManagementService
    {
        Task<BaseResponse<TokenResponse>> GenerateTokensAsync(TokenRequest loginResource, DateTime now, string userAgent);
    }
}
