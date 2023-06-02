using Microsoft.AspNetCore.Mvc;
using OnlineBankingManagementSystem.BLL.DTOs;
using OnlineBankingManagementSystem.BLL.Services;

namespace OnlineBankingManagementSystem.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userservice;
        public UserController(IUserService _userservice) { 
            this.userservice = _userservice;
        }
        [HttpPost]
        public IActionResult AddUser(UserDTO user)
        {
            try
            {
                userservice.AddUser(user);
                return CreatedAtAction(nameof(GetUserByUserId), new { id = user.UserId }, user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = userservice.GetAllUsers();
                return Ok(users);
            }
            catch (Exception e) { 
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{accountNumber}")]
        public IActionResult GetUserByAccountNumber(string accountNumber)
        {
            try
            {
                var user = userservice.GetUserByAccountNumber(accountNumber);
                if(user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{userId}")]
        public IActionResult GetUserByUserId(int userId)
        {
            try
            {
                var user = userservice.GetUserByUserId(userId);
                if( user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception e) { 
                return BadRequest(e.Message) ;
            }
        }
    }
}
