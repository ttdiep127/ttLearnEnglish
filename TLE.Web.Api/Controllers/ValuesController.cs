using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TLE.Entities.Models.AppModule;
using TLE.Entities.Models.EntityModels;
using TLE.Entities.Service;
using TLE.Service;

namespace TLE.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //private readonly UserService _userService;

        //public ValuesController(UserService service)
        //{
        //    _userService = service;
        //}

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        //// POST api/values
        //[HttpPost("login")]
        //public async Task<ActionResult<LoginResponse>> Post([FromBody] AuthenticationInput input)
        //{
        //    return await _userService.Login(input);
        //}

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
