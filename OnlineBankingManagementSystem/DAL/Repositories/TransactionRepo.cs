using OnlineBankingManagementSystem.DAL.Models;

namespace OnlineBankingManagementSystem.DAL.Repositories
{
    public class TransactionRepo : ITransactionRepo
    {

        private readonly AppDbContext context;
        public TransactionRepo(AppDbContext _context)
        {
            context = _context;
        }
        public void Add(Transaction transaction)
        {
            context.Transactions.Add(transaction);
            context.SaveChanges();
        }

        public IEnumerable<Transaction> GetAll()
        {
            return context.Transactions.ToList();
        }
        public IEnumerable<Transaction> GetByAccountNumber(string accountNumber)
        {
            return (IEnumerable<Transaction>)context.Transactions.Select(a => a.AccountNumber == accountNumber).ToList();

        }
        public Transaction GetById(int transactionId)
        {
            return context.Transactions.Find(transactionId);
        }
    }
}
