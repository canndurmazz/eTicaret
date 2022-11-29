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
    public class ChangeLogController : ControllerBase
    {
        private readonly IETicaretService _eTicaretService;
        public ChangeLogController(IETicaretService eTicaretService)
        {
            _eTicaretService = eTicaretService;
        }

        [HttpGet]
        [Authorize(Policy = "Admin")]
        public List<ChangeLogDto> Get()
        {
            return _eTicaretService.GetAllChangeLog(); 
        }
    }
}
