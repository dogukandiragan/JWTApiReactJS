using AutoMapper;
using JWTBasedAuthApiReactJS.CORE.DTOs;
using JWTBasedAuthApiReactJS.CORE.Models;
using JWTBasedAuthApiReactJS.CORE.Services;
using Microsoft.AspNetCore.Mvc;

namespace JWTBasedAuthApiReactJS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
   
        private readonly IMapper _mapper;
        private readonly ITransactionService _service;


        public TransactionController(IMapper mapper, ITransactionService transactionService)
        {
            _mapper = mapper;
            _service = transactionService;
        }



        [HttpGet]
        public async Task<IActionResult> All()
        {
            return Ok(await _service.GetAllAsync());
        }


        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var transaction = await _service.GetByIdAsync(id);
            var transactionDto = _mapper.Map<TransactionDto>(transaction);
            return Ok(transactionDto);
        }

         
        [HttpPost]
        public async Task<IActionResult> Add(TransactionDto transactionDto)
        {
            var transaction = await _service.AddAsync(_mapper.Map<TransactionApp>(transactionDto));
            var TransactionDTO = _mapper.Map<TransactionDto>(transaction);
            return Ok();
        }


       
        [HttpPut]
        public async Task<IActionResult> Update(TransactionDto transactionDto)
        {
            await _service.UpdateAsync(_mapper.Map<TransactionApp>(transactionDto));
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
