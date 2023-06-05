using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OnlineBankingManagementSystem.BLL.DTOs;
using OnlineBankingManagementSystem.BLL.Services;

namespace OnlineBankingManagementSystem.Controllers
{
    [ApiController]
    [Route("CtsBank/transactions")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionservice;
        public TransactionController(ITransactionService transactionservice)
        {
            this._transactionservice = transactionservice;
        }
        [HttpPost]
        [EnableCors("AllowLocalhost")]
        public ActionResult<IEnumerable<TransactionDTO>> AddTransaction(TransactionDTO transaction)
        {
            try
            {
                var add = _transactionservice.AddTransaction(transaction);
                return Ok(add);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet]
        [EnableCors("AllowLocalhost")]
        public ActionResult<IEnumerable<TransactionDTO>> GetAllTransactions()
        {
            try
            {
                return Ok(_transactionservice.GetAllTransactions());
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("getTransactionByAccountNumber/{accountNumber}")]
        [EnableCors("AllowLocalhost")]
        public ActionResult<IEnumerable<TransactionDTO>> GetTransactionByAccountNumber(int accountNumber) {
            try
            {
                return Ok(_transactionservice.GetTransactionByAccountNumber(accountNumber));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("getTransactionById/{transactionId}")]
        [EnableCors("AllowLocalhost")]
        public IActionResult GetTransactionById(int transactionId)
        {
            try
            {
                return Ok(_transactionservice.GetTransactionById(transactionId));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
