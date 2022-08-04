using JWTBasedAuthApiReactJS.CORE.DTOs;

namespace JWTBasedAuthApiReactJS.CORE.Services
{
    public interface IUserService
    {

        Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto);
        Response<IEnumerable<UserAppDto>> GetAllUser();


    }
}
