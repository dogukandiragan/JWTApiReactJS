﻿using JWTBasedAuthApiReactJS.CORE.DTOs;
using JWTBasedAuthApiReactJS.CORE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JWTBasedAuthApiReactJS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }



        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            return Ok(await _userService.CreateUserAsync(createUserDto));
        }



        [HttpGet]
        public  IActionResult GetUsers()
        {
            return Ok( _userService.GetAllUser());
        }

   


    }
}
