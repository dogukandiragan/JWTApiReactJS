﻿using AutoMapper;
using JWTBasedAuthApiReactJS.CORE.DTOs;
using JWTBasedAuthApiReactJS.CORE.Models;
using JWTBasedAuthApiReactJS.CORE.Services;
using Microsoft.AspNetCore.Mvc;


namespace JWTBasedAuthApiReactJS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
 
        private readonly IMapper _mapper;
        private readonly ICustomerService _service;


        public CustomerController(IMapper mapper, ICustomerService customerService)
        {
            _mapper = mapper;
            _service = customerService;
        }



 
        [HttpGet]
        public async Task<IActionResult> All()
        {
            return Ok(await _service.GetAllAsync());
        }

 
 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _service.GetByIdAsync(id);
            var customerDTO = _mapper.Map<CustomerDto>(customer);
            return Ok(customerDTO);
        }


 
        [HttpPost]
        public async Task<IActionResult> Add(CustomerDto customerDto)
        {
            var customer = await _service.AddAsync(_mapper.Map<CustomerApp>(customerDto));
            return Ok();
        }


 
        [HttpPut]
        public async Task<IActionResult> Update(CustomerDto customerDto)
        {
            await _service.UpdateAsync(_mapper.Map<CustomerApp>(customerDto));
            return Ok();
        }


 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var transaction = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(transaction);
            return Ok();
        }






    }
}
