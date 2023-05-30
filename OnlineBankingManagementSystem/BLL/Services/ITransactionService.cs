using OnlineBankingManagementSystem.BLL.DTOs;

namespace OnlineBankingManagementSystem.BLL.Services
{
    public interface ITransactionService
    {
        public IEnumerable<TransactionDTO> GetAllTransactions();
        public IEnumerable<TransactionDTO> GetTransactionByAccountNumber(string accountNumber);
        public TransactionDTO GetTransactionById(int transactionId);
        public void AddTransaction(TransactionDTO transactionDTO);
    }
}
