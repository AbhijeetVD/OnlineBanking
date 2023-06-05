using OnlineBankingManagementSystem.DAL.Models;

namespace OnlineBankingManagementSystem.DAL.Repositories
{
    public class TransactionRepo : ITransactionRepo
    {

        private readonly AppDbContext _context;
        public TransactionRepo(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }

        public IEnumerable<Transaction> GetAll()
        {
            return _context.Transactions.ToList();
        }
        public IEnumerable<Transaction> GetByAccountNumber(int accountNumber)
        {
            var transactions = (IEnumerable<Transaction>)_context.Transactions.Select(a => a.AccountNumber == accountNumber).ToList();
            if(transactions == null)
            {
                throw new Exception("No transactions available!");
            }
            return transactions;
        }
        public Transaction GetById(int transactionId)
        {
            var transaction = _context.Transactions.Find(transactionId);
            if(transaction == null)
            {
                throw new Exception("No transaction available for this ID!");
            }
            return transaction;
        }
    }
}
