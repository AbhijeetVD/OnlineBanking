using Microsoft.AspNetCore.Mvc;
using OnlineBankingManagementSystem.BLL.DTOs;
using OnlineBankingManagementSystem.BLL.Services;

namespace OnlineBankingManagementSystem.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService transactionservice;
        public TransactionController(ITransactionService _transactionservice)
        {
            this.transactionservice = _transactionservice;
        }
        [HttpPost]
        public IActionResult AddTransaction(TransactionDTO transaction)
        {
            try
            {
                transactionservice.AddTransaction(transaction);
                return CreatedAtAction(nameof(GetTransactionById), new { id = transaction.TransactionId }, transaction);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        public IActionResult GetAllTransactions()
        {
            try
            {
                var transactions = transactionservice.GetAllTransactions();
                return Ok(transactions);
            }
            catch (Exception e) { 
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{accountNumber}")]
        public IActionResult GetTransactionByAccountNumber(string accountNumber) {
            try
            {
                var transactions = transactionservice.GetTransactionByAccountNumber(accountNumber);
                if(transactions == null)
                {
                    return NotFound();
                }
                return Ok(transactions);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{transactionId}")]
        public IActionResult GetTransactionById(int transactionId)
        {
            try
            {
                var transaction = transactionservice.GetTransactionById(transactionId);
                if(transaction == null)
                {
                    return NotFound();
                }
                return Ok(transaction);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
