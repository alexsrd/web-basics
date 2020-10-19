using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using web_basics.data.Entities;

namespace web_basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        business.Domains.Dog domain;

        public DogController(IConfiguration configuration)
        {
            this.domain = new business.Domains.Dog(configuration);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var dogs = this.domain.Get();
            return Ok(dogs);
        }

        [Route("create")]
        [HttpPost]
        public  IActionResult Create([FromBody]Dog dog)
        {
            this.domain.Add(dog);
            return Ok(dog);
        }
    }
}
