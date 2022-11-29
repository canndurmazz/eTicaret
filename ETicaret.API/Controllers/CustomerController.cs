using ETicaret.API.Models;
using ETicaret.Business.Abstract;
using ETicaret.Conctrats;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;


namespace ETicaret.API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IETicaretService _eTicaretService;
     
        public CustomerController(IETicaretService eTicaretService,IConfiguration config)
        {           
            _eTicaretService = eTicaretService;
        }

      
        [HttpGet]
        [Authorize(Policy = "CompanyAndAdmin")]
        public List<CustomerDto> Get()
        {
            return _eTicaretService.GetAllCustomer();
        }

        [HttpGet("{ıd}")]
        [Authorize(Policy = "CompanyAndAdmin")]
        public CustomerDto Get(int ıd)
        {
            return _eTicaretService.GetCustomertById(ıd);
        }

        [HttpPut]
        [Authorize(Policy = "CustomerAndAdmin")]
        public CustomerDto Put([FromBody] CustomerDto customer)
        {
            return _eTicaretService.UpdateCustomer(customer);
        }

        [HttpPost]
        [Authorize(Policy = "CustomerAndAdmin")]
        public CustomerDto Post([FromBody] CustomerDto customer)
        {
            return _eTicaretService.CreateCustomer(customer);
        }

        [HttpDelete("{ıd}")]
        [Authorize(Policy = "CustomerAndAdmin")]
        public void Delete(int ıd)
        {
            _eTicaretService.DeleteCustomerById(ıd);
        }

    }
}
