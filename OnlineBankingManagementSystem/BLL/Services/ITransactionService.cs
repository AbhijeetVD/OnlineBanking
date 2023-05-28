using OnlineBankingManagementSystem.BLL.DTOs;

namespace OnlineBankingManagementSystem.BLL.Services
{
    public interface ITransactionService
    {
        public IEnumerable<TransactionDTO> GetAllTransactions();
        public TransactionDTO GetTransactionByAccountNumber(string accountNumber);
        public void AddTransaction(TransactionDTO transaction);
    }
}
