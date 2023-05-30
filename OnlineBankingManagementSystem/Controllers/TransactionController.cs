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
            transactionservice.AddTransaction(transaction);
            return CreatedAtAction(nameof(GetTransactionById), new { id = transaction.TransactionId }, transaction);
        }
        [HttpGet]
        public IActionResult GetAllTransactions()
        {
            var transactions = transactionservice.GetAllTransactions();
            return Ok(transactions);
        }
        [HttpGet("{accountNumber}")]
        public IActionResult GetTransactionByAccountNumber(string accountNumber) {
            var transactions = transactionservice.GetTransactionByAccountNumber(accountNumber);
            if(transactions == null)
            {
                return NotFound();
            }
            return Ok(transactions);
        }
        [HttpGet("{transactionId}")]
        public IActionResult GetTransactionById(int transactionId)
        {
            var transaction = transactionservice.GetTransactionById(transactionId);
            if(transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }
    }
}
