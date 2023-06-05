using OnlineBankingManagementSystem.DAL.Models;

namespace OnlineBankingManagementSystem.DAL.Repositories
{
    public interface ITransactionRepo
    {
        public IEnumerable<Transaction> GetAll();
        public IEnumerable<Transaction> GetByAccountNumber(int accountNumber);
        public Transaction GetById(int transactionId);
        public void Add(Transaction transaction);
    }
}
