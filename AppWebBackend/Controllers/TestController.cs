using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("GetSome")]
        public List<User> GetSome()
        {
            return new List<User>()
            {
            new User()
            {
                Id = new Random().Next(100),
                Name = "Саша"
            },
            new User()
            {
                Id = new Random().Next(100),
                Name = "Андрей"
            }
            };
        }

    }

   public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
