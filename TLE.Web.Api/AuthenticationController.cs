using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TLE.Entities.Models.AppModule;
using TLE.Entities.Models.EntityModels;
using TLE.Entities.Service;
using TLE.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TLE.Web.Api
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly UserService _userService;
        
        public AuthenticationController(UserService service)
        {
            _userService = service;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Post([FromBody]AuthenticationInput input)
        {
            return await _userService.Login(input);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
