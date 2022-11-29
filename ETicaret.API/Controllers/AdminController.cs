using ETicaret.Business.Abstract;
using ETicaret.Conctrats;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ETicaret.API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IETicaretService _eTicaretService;
        public AdminController(IETicaretService eTicaretService)
        {
            _eTicaretService = eTicaretService;
        }
        [HttpGet("Earning")]
        [Authorize(Policy = "Admin")]
        public double Earning()
        {
            var shoppings = _eTicaretService.GetAllShopping();
            var earning = shoppings.Sum(p => p.SitesEarning);
            return earning;
        }

        [HttpGet("CompanyCount")]
        [Authorize(Policy = "Admin")]
        public int CompanyCount()
        {
            var companies = _eTicaretService.GetAllCompanies();
            var companycount = companies.Count(p => p.CompanyId != 0);
            return companycount;
        }

        [HttpGet("ProductCount")]
        [Authorize(Policy = "Admin")]
        public int ProductCount()
        {
            var products = _eTicaretService.GetAllProduct();
            var productscount = products.Count(p => p.ProductId != 0);
            return productscount;
        }

        [HttpGet("Categories")]
        [Authorize(Policy = "Admin")]
        public List<CategoryDto> Get()
        {
            return _eTicaretService.GetAllCategories();
        }
    }
}
