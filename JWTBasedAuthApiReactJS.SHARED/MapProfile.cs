using AutoMapper;
using JWTBasedAuthApiReactJS.CORE.DTOs;
using JWTBasedAuthApiReactJS.CORE.Models;

namespace JWTBasedAuthApiReactJS.SHARED
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<UserAppDto, UserApp>().ReverseMap();
            CreateMap<TransactionDto, TransactionApp>().ReverseMap();
            CreateMap<CustomerDto, CustomerApp>().ReverseMap();

        }
    }
}
