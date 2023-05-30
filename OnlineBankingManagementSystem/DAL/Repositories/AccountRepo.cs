using OnlineBankingManagementSystem.BLL.DTOs;
using OnlineBankingManagementSystem.DAL.Models;

namespace OnlineBankingManagementSystem.DAL.Repositories
{
    public class AccountRepo : IAccountRepo
    {
        private readonly AppDbContext context;
        public AccountRepo(AppDbContext _context)
        {
            context = _context;
        }
        public void Add(Account account)
        {
            context.Accounts.Add(account);
            context.SaveChanges();
        }

        public void Delete(string accountNumber)
        {
            var account = GetByAccountNumber(accountNumber);
            context.Accounts.Remove(account);
            context.SaveChanges();
        }

        public Account GetByAccountNumber(string accountNumber)
        {
            return context.Accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
        }


        public IEnumerable<Account> GetAll()
        {
            return context.Accounts.ToList();
        }

        public void Update(Account account)
        {
            context.Accounts.Update(account);
            context.SaveChanges();
        }
    }
}
