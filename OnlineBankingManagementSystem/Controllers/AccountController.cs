using Microsoft.AspNetCore.Mvc;
using OnlineBankingManagementSystem.BLL.DTOs;
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
        [HttpGet]
        public IActionResult GetAllAccounts() {
            var accounts = accountservice.GetAllAccounts();
            return Ok(accounts);
        }
        [HttpGet("{accountNumber}")]
        public IActionResult GetAccountByAccountNumber(string accountNumber) {
            var account = accountservice.GetAccountByAccountNumber(accountNumber);
            if(account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }
        [HttpPost]
        public IActionResult AddAccount(AccountDTO account)
        {
            accountservice.AddAccount(account);
            return CreatedAtAction(nameof(GetAccountByAccountNumber), new { accountNumber = account.AccountNumber }, account);
        }
        [HttpPut]
        public IActionResult UpdateAccount(AccountDTO account)
        {
            accountservice.UpdateAccount(account);
            return Ok(account);
        }
        [HttpDelete("{accountNumber}")]
        public IActionResult DeleteAccount(string accountNumber)
        {
            accountservice.DeleteAccount(accountNumber);
            return NoContent();
        }
    }
}
