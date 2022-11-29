using ETicaret.Business.Abstract;
using eTicaret.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ETicaret.Conctrats;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace ETicaret.API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IETicaretService _eTicaretService;
        public ProductController(IETicaretService eTicaretService)
        {
            _eTicaretService = eTicaretService;
        }

        [HttpGet]
        public List<ProductDto> Get()
        {
            return _eTicaretService.GetAllProduct();
        }

        [HttpGet("{ıd}")]
        public ProductDto Get(int ıd)
        {
            return _eTicaretService.GetProductById(ıd);
        }

       
        [HttpPut]
        [Authorize(Policy = "CompanyAndAdmin")]
        public ProductDto Put([FromBody] ProductDto product)
        {
            return _eTicaretService.UpdateProduct(product);
        }

        [HttpPut("{ıd},{newstock}")]
        [Authorize(Policy = "CompanyAndAdmin")]
        public ProductDto Put(int ıd, int newstock)
        {
            return _eTicaretService.UpdateProductStock(ıd, newstock);
        }

        [HttpPost]
        [Authorize(Policy = "CompanyAndAdmin")]
        public WaitingProductDto Post([FromBody] WaitingProductDto product)
        {
            return _eTicaretService.CreateWaitingProduct(product);
        }
        //[HttpPost]
        //public ProductDto Post([FromBody] ProductDto product)
        //{
        //    return _eTicaretService.CreateProduct(product);
        //}

        [HttpDelete("{ıd}")]
        [Authorize(Policy = "CompanyAndAdmin")]
        public void Delete(int ıd)
        {
            _eTicaretService.DeleteProductById(ıd);
        }
  
    }
}
