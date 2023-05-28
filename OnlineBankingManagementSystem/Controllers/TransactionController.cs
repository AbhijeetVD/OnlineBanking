using Microsoft.AspNetCore.Mvc;
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
    }
}
