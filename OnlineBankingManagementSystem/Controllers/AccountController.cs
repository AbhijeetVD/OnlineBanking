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
            try
            {
                var accounts = accountservice.GetAllAccounts();
                return Ok(accounts);
            }
            catch(Exception e) { 
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{accountNumber}")]
        public IActionResult GetAccountByAccountNumber(string accountNumber) {
            try
            {
                var account = accountservice.GetAccountByAccountNumber(accountNumber);
                if(account == null)
                {
                    return NotFound();
                }
                return Ok(account);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public IActionResult AddAccount(AccountDTO account)
        {
            try
            {
                accountservice.AddAccount(account);
                return CreatedAtAction(nameof(GetAccountByAccountNumber), new { accountNumber = account.AccountNumber }, account);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public IActionResult UpdateAccount(AccountDTO account)
        {
            try
            {
                accountservice.UpdateAccount(account);
                return Ok(account);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{accountNumber}")]
        public IActionResult DeleteAccount(string accountNumber)
        {
            try
            {
                accountservice.DeleteAccount(accountNumber);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{balance}")]
        public IActionResult GetAccountBalance(decimal balance)
        {
            try
            {
                accountservice.GetBalance(balance);
                return Ok(balance);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
