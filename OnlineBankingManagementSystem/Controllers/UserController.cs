using Microsoft.AspNetCore.Mvc;
using OnlineBankingManagementSystem.BLL.Services;

namespace OnlineBankingManagementSystem.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController
    {
        private readonly IUserService userservice;
        public UserController(IUserService _userservice) { 
            this.userservice = _userservice;
        }
    }
}
