using OnlineBankingManagementSystem.DAL.Models;

namespace OnlineBankingManagementSystem.DAL.Repositories
{
    public interface ITransactionRepo
    {
        public IEnumerable<Transaction> GetAll();
        public Transaction GetByAccountNumber(string accountNumber);
        public void Add(Transaction transaction);
    }
}
