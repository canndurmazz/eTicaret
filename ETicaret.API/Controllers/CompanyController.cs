using eTicaret.DataAccsess;
using ETicaret.Business.Abstract;
using ETicaret.Conctrats;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;

namespace ETicaret.API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IETicaretService _eTicaretService;
        public CompanyController(IETicaretService eTicaretService)
        {
            _eTicaretService = eTicaretService;
        }

        [HttpGet]
        public List<CompanyDto> Get()
        {
            return _eTicaretService.GetAllCompanies();
        }

        [HttpGet("{ıd}")]
        public CompanyDto Get(int ıd)
        {
            return _eTicaretService.GetCompanyById(ıd);
        }
        
        [HttpPost]
        [Authorize(Policy = "CompanyAndAdmin")]
        public CompanyDto Post([FromBody] CompanyDto company)
        {
            return _eTicaretService.CreateCompany(company);
        }

        [HttpDelete("{ıd}")]
        [Authorize(Policy = "CompanyAndAdmin")]
        public void Delete(int ıd)
        {
            _eTicaretService.DeleteCompanyById(ıd);
        }

        [HttpPut]
        [Authorize(Policy = "CompanyAndAdmin")]
        public CompanyDto Put([FromBody] CompanyDto company)
        {
            return _eTicaretService.UpdateCompany(company);
        }    
    }
}
