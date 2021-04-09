using Microsoft.AspNetCore.Mvc;
using Beecow.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Beecow.Entities;
using Microsoft.Extensions.Configuration;
using Beecow.DTOs.Account;

namespace Beecow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService loginService)
        {
            this._accountService = loginService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginUserModel loginRequest)
        {
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Username) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return BadRequest("Missing login details");
            }

            var loginResponse = await _accountService.Login(loginRequest);

            if (loginResponse == null)
            {
                return BadRequest($"Invalid credentials");
            }

            return Ok(loginResponse);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(CreateUserModel registerRequest)
        {
            if (registerRequest == null || string.IsNullOrEmpty(registerRequest.Fullname) || string.IsNullOrEmpty(registerRequest.Password))
            {
                return BadRequest($"User exists");
            }

            var registerResponse = await _accountService.Register(registerRequest);

            if (registerResponse == null)
            {
                return BadRequest($"Invalid credentials");
            }

            return Ok(registerResponse);
        }
    }
}
