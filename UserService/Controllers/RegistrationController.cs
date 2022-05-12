using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.DTO.Request;
using UserService.Repository.Interfaces;

namespace UserService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IUserRegistrationServices _userRegistrationServices;

        public RegistrationController(IUserRegistrationServices userRegistrationServices)
        {
            _userRegistrationServices = userRegistrationServices ?? throw new ArgumentNullException(nameof(userRegistrationServices));
        }


        // GET api/<RegistrationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost, ActionName("Login")]
        public async Task<string> Login([FromBody] UserRegistrationRequest LogIndata)
        {
            string result = string.Empty;

            //if (username == "Admin@123" && password == "Admin@123")
            //{
            //    result = "admin";
            //}
            //else
            //{
            //    result = await _userRegistrationServices.Login(username,password);
            //}
            if (LogIndata != null)
            {

                result = await _userRegistrationServices.Login(LogIndata.UserName, LogIndata.PassWord);
            }
            else
            {
                result = "Unauthorized";
            }



            return result;
        }

        // POST api/<RegistrationController>
        [HttpPost, ActionName("register")]
        [HttpPost]
        public async Task<bool> Register([FromBody] UserRegistrationRequest userRegistrationRequest)
        {
            var result = await _userRegistrationServices.RegisterUser(userRegistrationRequest);

            return result;
        }

        // PUT api/<RegistrationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RegistrationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
