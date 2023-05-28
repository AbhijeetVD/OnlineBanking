using OnlineBankingManagementSystem.BLL.DTOs;
using OnlineBankingManagementSystem.DAL.Repositories;

namespace OnlineBankingManagementSystem.BLL.Services
{
    public class TransactionService : ITransactionService
    {
        public readonly TransactionRepo transactionrepo;
        public TransactionService(TransactionRepo _transactionrepo)
        {
            this.transactionrepo = _transactionrepo;
        }
        public void AddTransaction(TransactionDTO transaction)
        {
            transactionrepo.Add(transaction);
        }

        public IEnumerable<TransactionDTO> GetAllTransactions()
        {
            return transactionrepo.GetAll();
        }

        public TransactionDTO GetTransactionByAccountNumber(string accountNumber)
        {
            return transactionrepo.GetByAccountNumber(accountNumber);
        }
    }
}
