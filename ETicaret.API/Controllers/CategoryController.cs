using eTicaret.Entities;
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
    public class CategoryController : ControllerBase
    {
        private readonly IETicaretService _eTicaretService;
        public CategoryController(IETicaretService eTicaretService)
        {
            _eTicaretService = eTicaretService;
        }

        
        [HttpGet]
        public List<CategoryDto> Get()
        {
            return _eTicaretService.GetAllCategories();
        }

        [HttpGet("{ıd}")]
        public CategoryDto Get(int ıd)
        {
            return _eTicaretService.GetCategoryById(ıd);
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public CategoryDto Post([FromBody] CategoryDto category)
        {
            return _eTicaretService.CreateCategory(category);
        }

        [HttpDelete("{ıd}")]
        [Authorize(Policy = "Admin")]
        public void Delete(int ıd)
        {
            _eTicaretService.DeleteCategoryById(ıd);
        }

        [HttpPut]
        [Authorize(Policy = "Admin")]
        public CategoryDto Put([FromBody] CategoryDto category)
        {
            return _eTicaretService.UpdateCategory(category);
        }

        [HttpGet("GetProdcutByCategoryId")]
        public CategoryDto GetProdcutByCategoryId(int categoryId)
        {
            return _eTicaretService.GetProductByCategoryId(categoryId);
        }
    }
}
