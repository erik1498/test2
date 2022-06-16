using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TestApi.Repository;


namespace TestApi.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private IRepository _IRepository;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
            _IRepository = new IRepository();
        }
        
        [HttpGet]
        public IActionResult GetUsers()
        {
            var keys = "";
            if (HttpContext.Request.Query.Count() < 2)
            {
                foreach (var item in HttpContext.Request.Query.Keys)
                    keys = item;
    
                if (keys == "name")
                    _IRepository.searchByName = HttpContext.Request.Query[keys];
    
                if (keys == "role")
                    _IRepository.searchByRole = HttpContext.Request.Query[keys];
    
                if (keys == "id")
                    _IRepository.searchById = int.Parse(HttpContext.Request.Query[keys]);
            }else
                _IRepository.searchById = 0;

            return Ok(_IRepository.GetUsers());
        }
    }
}