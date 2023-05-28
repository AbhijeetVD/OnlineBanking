using OnlineBankingManagementSystem.BLL.DTOs;
using OnlineBankingManagementSystem.DAL.Repositories;
using OnlineBankingManagementSystem.DAL.Models;

namespace OnlineBankingManagementSystem.BLL.Services
{
    public class AccountService : IAccountService
    {
        public readonly AccountRepo accountrepo;
        public AccountService(AccountRepo _accountrepo)
        {
            this.accountrepo = _accountrepo;
        }
        public void AddAccount(AccountDTO account)
        {
            accountrepo.Add(account);
        }
        public void DeleteAccount(string accountNumber)
        {
            accountrepo.Delete(accountNumber);
        }

        public AccountDTO GetAccountByAccountNumber(string accountNumber)
        {
            return accountrepo.GetByAccountNumber(accountNumber);
        }

        public IEnumerable<AccountDTO> GetAllAccounts()
        {
            return (IEnumerable<AccountDTO>)accountrepo.GetAll();
        }

        public void UpdateAccount(AccountDTO account)
        {
            accountrepo.Update(account);
        }
    }
}
