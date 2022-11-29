using ETicaret.Business.Abstract;
using ETicaret.Conctrats;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ETicaret.API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class WaitingProductController : ControllerBase
    {
        private readonly IETicaretService _eTicaretService;
        public WaitingProductController(IETicaretService eTicaretService)
        {
            _eTicaretService = eTicaretService;
        }
        [HttpGet("AllWaitingProducts")]
        [Authorize(Policy = "Admin")]
        public List<WaitingProductDto> Get()
        {
            return _eTicaretService.GetAllWaitingProduct();
        }
        /// <summary>
        /// Get Waiting Product
        /// </summary>
        /// <param name="ıd"></param>
        /// <returns></returns>
        [HttpGet("{ıd}")]
        [Authorize(Policy = "Admin")]
        public WaitingProductDto Get(int ıd)
        {
            return _eTicaretService.GetWaitingProductById(ıd);
        }

        [Authorize(Policy = "Admin")]
        [HttpGet("{productId:int}")]
        public ProductDto CreateProduct(int productId)
        {
            return _eTicaretService.CreateProduct(productId);
        }

        /// <summary>
        /// Update Waiting Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Policy = "CompanyAndAdmin")]
        public WaitingProductDto Put([FromBody] WaitingProductDto product)
        {
            return _eTicaretService.UpdateWaitingProduct(product);
        }
        /// <summary>
        /// Delete Waiting Product
        /// </summary>
        /// <param name="ıd"></param>
        [Authorize(Policy = "CompanyAndAdmin")]
        [HttpDelete("{ıd}")]
        public void Delete(int ıd)
        {
            _eTicaretService.DeleteWaitingProductById(ıd);
        }

    }
}
