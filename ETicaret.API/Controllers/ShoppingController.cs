using eTicaret.DataAccsess.Abstract;
using ETicaret.Business.Abstract;
using ETicaret.Conctrats;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.IO.Pipelines;

namespace ETicaret.API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private readonly IETicaretService _eTicaretService;
        public ShoppingController(IETicaretService eTicaretService)
        {
            _eTicaretService = eTicaretService;
        }

        [Authorize(Policy = "Shopping")]
        [HttpPost]
        public ShoppingDto Post([FromBody] ShoppingDto shopping)
        {
            return _eTicaretService.CreateShopping(shopping);
        }

        [HttpGet]
        [Authorize(Policy = "Admin")]
        public List<ShoppingDto> Get()
        {
            return _eTicaretService.GetAllShopping();
        }

        [HttpGet("{ıd}")]
        [Authorize(Policy = "Admin")]
        public ShoppingDto Get(int ıd)
        {
            return _eTicaretService.GetShoppingById(ıd);
        }

        [Authorize(Policy = "CustomerAndAdmin")]
        [HttpDelete("{ReturnShoppingById:int}")]
        public void ReturnShoppingById(int ReturnShoppingById)
        {           
            _eTicaretService.ReturnShoppingById(ReturnShoppingById);
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("{ıd}")]
        public void Delete(int ıd)
        {
            _eTicaretService.DeleteShoppingById(ıd);
        }
        
    }
}
