using eTicaret.DataAccsess;
using eTicaret.Entities;
using ETicaret.API.Models;
using ETicaret.Business.Abstract;
using ETicaret.Business.Concrete;
using ETicaret.Conctrats;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Serilog.Formatting.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JwtApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IETicaretService _eTicaretService;
        private IConfiguration _config;

        public LoginController(IConfiguration config,IETicaretService eTicaretService)
        {
            _eTicaretService = eTicaretService;
            _config = config;
        }

        #region Customer Login
        [AllowAnonymous]
        [HttpPost("customer")]
        public IActionResult Customer([FromBody] CustomerDto userLogin)
        {
            var user = Authenticate(userLogin);

            if (user != null)
            {
                var token = Generate(user);
                return new JsonResult(token);
            }

            return NotFound("User not found");
        }
        [AllowAnonymous]
        private string Generate(CustomerDto user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.EmailAddress),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Surname, user.lastName),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [AllowAnonymous]
        private CustomerDto Authenticate(CustomerDto userLogin)
        {
            var customers = _eTicaretService.GetAllCustomer();
            var customer = customers.FirstOrDefault(o => o.EmailAddress.ToLower() == userLogin.EmailAddress.ToLower() && o.Password == userLogin.Password);

            if (customer != null)
            {
                return customer;
            }

            return null;
        }

        #endregion

        #region Seller Login
        [AllowAnonymous]
        [HttpPost("company")]
        public IActionResult Company([FromBody] CompanyDto userLogin)
        {
            var user = Authenticate(userLogin);

            if (user != null)
            {
                var token = Generate(user);
                return new JsonResult(token);
            }

            return NotFound("User not found");
        }
        [AllowAnonymous]
        private string Generate(CompanyDto user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.ManagerPhone),
                new Claim(ClaimTypes.Name, user.CompanyName),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [AllowAnonymous]
        private CompanyDto Authenticate(CompanyDto userLogin)
        {
            var companies = _eTicaretService.GetAllCompanies();
            var company = companies.FirstOrDefault(o => o.ManagerPhone.ToLower() == userLogin.ManagerPhone.ToLower() && o.Password == userLogin.Password);

            if (company != null)
            {
                return company;
            }

            return null;
        }

        #endregion

        #region Admin
        [AllowAnonymous]
        [HttpPost("admin")]
        public IActionResult Company([FromBody] AdminDto userLogin)
        {
            var user = Authenticate(userLogin);

            if (user != null)
            {
                var token = Generate(user);
                return new JsonResult(token);
            }

            return NotFound("User not found");
        }
        [AllowAnonymous]
        private string Generate(AdminDto user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [AllowAnonymous]
        private AdminDto Authenticate(AdminDto userLogin)
        {
            var admins = _eTicaretService.GetAdmins();
            var admin = admins.FirstOrDefault(o => o.Username.ToLower() == userLogin.Username.ToLower() && o.Password == userLogin.Password);

            if (admin != null)
            {
                return admin;
            }

            return null;
        }
        #endregion

    }
}
