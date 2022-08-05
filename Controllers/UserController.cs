using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            IList<User> list = new List<User>(){
                new User{Id=1, UserName="Prakash Besra", Email="psbesra@gmail.com", Address="Bangalore"},
                new User{Id=2, UserName="Ajeet", Email="ajeet@gmail.com", Address="Delhi"},
                new User{Id=3, UserName="Ravi", Email="ravi@gmail.com", Address="Pune"},
                new User{Id=4, UserName="Hemant", Email="hemant@gmail.com", Address="Hyderabad"},
            };
            return list;
        }

        [HttpGet("{id}")]
        // [Route("{id:int}")]
        public User Get(int id)
        {
            int a = 10;
            a.ToString();
            string b = Convert.ToString(a);

            return new User { Id = 1, UserName = "Prakash Besra", Email = "psbesra@gmail.com", Address = "Bangalore" };
        }
    }
}
