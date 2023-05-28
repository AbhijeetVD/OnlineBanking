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

        public Transaction GetByAccountNumber(string accountNumber)
        {
            return context.Transactions.Find(accountNumber);
        }
    }
}
