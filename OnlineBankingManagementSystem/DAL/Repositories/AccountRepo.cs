using OnlineBankingManagementSystem.BLL.DTOs;
using OnlineBankingManagementSystem.DAL.Models;

namespace OnlineBankingManagementSystem.DAL.Repositories
{
    public class AccountRepo : IAccountRepo
    {
        private readonly AppDbContext _context;
        public AccountRepo(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Account account)
        {
                _context.Accounts.Add(account);
                _context.SaveChanges();
        }

        public void Delete(int accountNumber)
        {
                var account = GetByAccountNumber(accountNumber);
                _context.Accounts.Remove(account);
                _context.SaveChanges();
        }

        public Account GetByAccountNumber(int accountNumber)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if(account == null)
            {
                throw new Exception("No account found!");
            }
            return account;
        }


        public IEnumerable<Account> GetAll()
        {
            return _context.Accounts.ToList();
        }

        public void Update(Account account)
        {
            _context.Entry(account).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
