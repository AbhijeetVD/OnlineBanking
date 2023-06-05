using OnlineBankingManagementSystem.BLL.DTOs;

namespace OnlineBankingManagementSystem.BLL.Services
{
    public interface IAccountService
    {
        public IEnumerable<AccountDTO> GetAllAccounts();
        public AccountDTO GetAccountByAccountNumber(int accountNumber);
        public AccountDTO AddAccount(CreateAccountDTO createaccountdto);
        public bool DeleteAccount(int accountNumber);
        public AccountDTO UpdateAccount(int accountNumber, UpdateAccountDTO account);
    }
}
