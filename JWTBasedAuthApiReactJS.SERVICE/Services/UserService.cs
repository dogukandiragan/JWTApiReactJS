﻿using AutoMapper;
using JWTBasedAuthApiReactJS.CORE.DTOs;
using JWTBasedAuthApiReactJS.CORE.Models;
using JWTBasedAuthApiReactJS.CORE.Services;
using Microsoft.AspNetCore.Identity;

namespace JWTBasedAuthApiReactJS.SERVICE.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<UserApp> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;

        }

        public async Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
            var user = new UserApp { Email = createUserDto.Email, UserName = createUserDto.UserName };

            var result = await _userManager.CreateAsync(user, createUserDto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();

                return Response<UserAppDto>.Fail(new ErrorDto(errors, true), 400);
            }
            return Response<UserAppDto>.Success(_mapper.Map<UserAppDto>(user), 200);
        }

        public Response<IEnumerable<UserAppDto>> GetAllUser()
        {
            var users = _userManager.Users.ToList();

            if (users == null)
            {
                return Response<IEnumerable<UserAppDto>>.Fail("UserName not found", 404, true);
            }

            return Response<IEnumerable<UserAppDto>>.Success(_mapper.Map<IEnumerable<UserAppDto>>(users), 200);
        }



    }
}
