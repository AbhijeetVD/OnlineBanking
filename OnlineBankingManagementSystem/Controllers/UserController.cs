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
            userservice.AddUser(user);
            return CreatedAtAction(nameof(GetUserByUserId), new { id = user.UserId }, user);
        }
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = userservice.GetAllUsers();
            return Ok(users);
        }
        [HttpGet("{accountNumber}")]
        public IActionResult GetUserByAccountNumber(string accountNumber)
        {
            var user = userservice.GetUserByAccountNumber(accountNumber);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpGet("{userId}")]
        public IActionResult GetUserByUserId(int userId)
        {
            var user = userservice.GetUserByUserId(userId);
            if( user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
