using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineBankingManagementSystem.BLL.DTOs;
using OnlineBankingManagementSystem.BLL.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineBankingManagementSystem.Controllers
{
    [ApiController]
    [Route("CtsBank/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userservice;
        private readonly IConfiguration _configuration;
        public UserController(IUserService userservice, IConfiguration configuration) { 
            this._userservice = userservice;
            _configuration = configuration;
        }
        [HttpGet]
        [EnableCors("AllowLocalhost")]
        public ActionResult<IEnumerable<UserDTO>> GetAllUsers()
        {
            try
            {
                return Ok(_userservice.GetAllUsers());
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("getUserByAccountNumber/{accountNumber}")]
        [EnableCors("AllowLocalhost")]
        public ActionResult<IEnumerable<UserDTO>> GetUserByAccountNumber(int accountNumber)
        {
            try
            {
                return Ok(_userservice.GetUserByAccountNumber(accountNumber));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("getUserByUserId/{userId}")]
        [EnableCors("AllowLocalhost")]
        public ActionResult<IEnumerable<UserDTO>> GetUserByUserId(int userId)
        {
            try
            { 
                return Ok(_userservice.GetUserByUserId(userId));
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("getUserByEmail/{email}")]
        [EnableCors("AllowLocalhost")]
        public ActionResult<IEnumerable<UserDTO>> GetUserByEmail(string email)
        {
            try
            {
                return Ok(_userservice.GetUserByEmail(email));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("getUserByUsername/{username}")]
        [EnableCors("AllowLocalhost")]
        public ActionResult<IEnumerable<UserDTO>> GetUserByUsername(string username)
        {
            try
            {
                return Ok(_userservice.GetUserByUsername(username));
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpPost("register")]
        [EnableCors("AllowLocalHost")]
        public IActionResult RegisterUser([FromBody] RegisterDTO register)
        {
            if(register == null)
            {
                return BadRequest();
            }
            var user = _userservice.RegisterUser(register);
            return CreatedAtAction(nameof(GetUserByUserId), new { userId = user.UserId}, user);
        }
        [HttpPut]
        [EnableCors("AllowLocalhost")]
        public IActionResult UpdateUser(int userId, [FromBody] UserDTO user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            _userservice.UpdateUser(userId, user);
            return NoContent();
        }
        [HttpDelete("{userId}")]
        [EnableCors("AllowLocalhost")]
        public IActionResult DeleteUser(int userId)
        {
            _userservice.DeleteUser(userId);
            return NoContent();
        }
        [HttpPost("signup")]
        [EnableCors("AllowLocalhost")]
        public IActionResult SignUp(UserDTO user)
        {
            try
            {
                _userservice.SignUp(user);
                return Ok(user);
            }
            catch (Exception e) 
            { 
                return BadRequest(e.Message);    
            }
        }
        [HttpPost("login")]
        [EnableCors("AllowLocalhost")]
        public IActionResult Login([FromBody] LoginDTO login)
        {
            try
            {
                var user = _userservice.LoginUser(login);
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Jwt:Key"));
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Email, user.Email),
                    }),
                    Expires = DateTime.UtcNow.AddHours(_configuration.GetValue<int>("Jwt:ExpiryInHours")),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
                return Ok(new { Token = tokenString });
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
