using OnlineBankingManagementSystem.BLL.DTOs;
using OnlineBankingManagementSystem.DAL.Repositories;
using OnlineBankingManagementSystem.DAL.Models;

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
            transactionrepo.Add((Transaction)transaction);
        }

        public IEnumerable<TransactionDTO> GetAllTransactions()
        {
            return (IEnumerable<TransactionDTO>)transactionrepo.GetAll();
        }

        public IEnumerable<TransactionDTO> GetTransactionByAccountNumber(string accountNumber)
        {
            return (IEnumerable<TransactionDTO>)transactionrepo.GetByAccountNumber(accountNumber);
        }
        public TransactionDTO GetTransactionById(int transactionId)
        {
            return transactionrepo.GetById(transactionId);
        }
    }
}
