using OnlineBankingManagementSystem.BLL.DTOs;

namespace OnlineBankingManagementSystem.BLL.Services
{
    public interface IAccountService
    {
        public IEnumerable<AccountDTO> GetAllAccounts();
        public AccountDTO GetAccountByAccountNumber(string accountNumber);
        public void AddAccount(AccountDTO accountDTO);
        public void DeleteAccount(string accountNumber);
        public void UpdateAccount(AccountDTO account);
        public void GetBalance(decimal balance);
    }
}
