using OnlineBankingManagementSystem.BLL.DTOs;

namespace OnlineBankingManagementSystem.BLL.Services
{
    public interface ITransactionService
    {
        public IEnumerable<TransactionDTO> GetAllTransactions();
        public IEnumerable<TransactionDTO> GetTransactionByAccountNumber(int accountNumber);
        public TransactionDTO GetTransactionById(int transactionId);
        public TransactionDTO AddTransaction(TransactionDTO transactionDTO);
    }
}
