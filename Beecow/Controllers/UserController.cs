using Microsoft.AspNetCore.Mvc;
using Beecow.Interfaces;
using System.Threading.Tasks;
using Beecow.DTOs.User;
using System;

namespace Beecow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IBusinessService _businessService;

        public UserController(IUserService userService,
            IBusinessService businessService)
        {
            _userService = userService;
            _businessService = businessService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginUserModel loginRequest)
        {
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Username) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return BadRequest("Missing login details");
            }

            var loginResponse = await _userService.Login(loginRequest);

            if (loginResponse == null)
            {
                return Ok(new { status = 104, message = $"The username or password was not correct" });
            }

            return Ok(loginResponse);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(CreateUserModel registerRequest)
        {
            try
            {
                if (registerRequest == null || string.IsNullOrEmpty(registerRequest.Fullname) || string.IsNullOrEmpty(registerRequest.Password))
                {
                    return BadRequest(new { message = $"User exists" });
                }

                var registerResponse = await _userService.Register(registerRequest);

                if (registerResponse == null)
                {
                    return Ok(new { status = 999, message = $"User exists" });
                }

                return Ok(registerResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        [Route("get-all-businesses")]
        public async Task<IActionResult> GetAllBusinesses()
        {
            var result = await _businessService.GetAllBusinesses();

            return Ok(result);
        }
    }
}
