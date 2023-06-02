using OnlineBankingManagementSystem.DAL.Models;

namespace OnlineBankingManagementSystem.DAL.Repositories
{
    public interface IAccountRepo
    {
        public IEnumerable<Account> GetAll();
        public Account GetByAccountNumber(string accountNumber);
        public void Add(Account account);
        public void Update(Account account);
        public void Delete(string accountNumber);
        public void GetBalance(decimal balance);
    }
}
