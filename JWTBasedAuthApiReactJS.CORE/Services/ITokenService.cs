using JWTBasedAuthApiReactJS.CORE.DTOs;
using JWTBasedAuthApiReactJS.CORE.Models;

namespace JWTBasedAuthApiReactJS.CORE.Services
{
    public interface ITokenService
    {
        Task<TokenDto> CreateToken(UserApp userApp);

    }
}
