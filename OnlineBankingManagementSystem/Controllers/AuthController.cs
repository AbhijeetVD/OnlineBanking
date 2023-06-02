using Microsoft.AspNetCore.Mvc;
using OnlineBankingManagementSystem.BLL.DTOs;
using OnlineBankingManagementSystem.BLL.Services;

namespace OnlineBankingManagementSystem.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authservice;
        public AuthController(IAuthService _authservice)
        {
            this.authservice = _authservice;
        }
        [HttpPost("register")]
        public IActionResult RegisterUser(RegisterDTO register)
        {
            try
            {
                authservice.RegisterUser(register);
                return Ok("Successfully Registered");
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("login")]
        public IActionResult Login(LoginDTO login)
        {
            try
            {
                var token = authservice.LoginUser(login);
                return Ok(new { Token = token });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
