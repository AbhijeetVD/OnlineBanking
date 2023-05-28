using Microsoft.AspNetCore.Mvc;
using OnlineBankingManagementSystem.BLL.Services;

namespace OnlineBankingManagementSystem.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountservice;
        public AccountController(IAccountService _accountservice)
        {
            this.accountservice = _accountservice;
        }
    }
}
