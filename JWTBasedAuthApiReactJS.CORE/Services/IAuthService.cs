using JWTBasedAuthApiReactJS.CORE.DTOs;

namespace JWTBasedAuthApiReactJS.CORE.Services
{
    public interface IAuthService
    {
        Task<Response<TokenDto>> CreateTokenAsync(LoginDto loginDto);
        Task<Response<TokenDto>> CreateTokenByRefreshTokenAsync(string refreshToken);
        Task<Response<EmptyDto>> RevokeRefreshTokenAsync(string refreshToken);

    }
}
