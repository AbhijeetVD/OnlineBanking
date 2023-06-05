using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OnlineBankingManagementSystem.BLL.DTOs;
using OnlineBankingManagementSystem.BLL.Services;

namespace OnlineBankingManagementSystem.Controllers
{
    [ApiController]
    [Route("CtsBank/accounts")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountservice;
        public AccountController(IAccountService accountservice)
        {
            this._accountservice = accountservice;
        }
        [HttpGet]
        [EnableCors("AllowLocalhost")]
        public ActionResult<IEnumerable<AccountDTO>> GetAllAccounts() {
            try
            {
                return Ok(_accountservice.GetAllAccounts());
            }
            catch(Exception e) { 
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("getAccountByAccountNumber/{accountNumber}")]
        [EnableCors("AllowLocalhost")]
        public ActionResult<IEnumerable<AccountDTO>> GetAccountByAccountNumber(int accountNumber) {
            try
            {
                return Ok(_accountservice.GetAccountByAccountNumber(accountNumber));
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpPost]
        [EnableCors("AllowLocalhost")]
        public ActionResult<IEnumerable<AccountDTO>> AddAccount(CreateAccountDTO account)
        {
            try
            {
                var add = _accountservice.AddAccount(account);
                return Ok(add);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.InnerException);
            }
        }
        [HttpPut("updateAccount/{accountNumber}")]
        [EnableCors("AllowLocalHost")]
        public ActionResult<IEnumerable<AccountDTO>> UpdateAccount(int accountNumber, UpdateAccountDTO account)
        {
            try
            {
                _accountservice.UpdateAccount(accountNumber, account);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpDelete("deleteAccount/{accountNumber}")]
        [EnableCors("AllowLocalhost")]
        public ActionResult<IEnumerable<AccountDTO>> DeleteAccount(int accountNumber)
        {
            try
            {
                _accountservice.DeleteAccount(accountNumber);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
