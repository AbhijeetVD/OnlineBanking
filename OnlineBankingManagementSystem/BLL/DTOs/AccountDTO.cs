using OnlineBankingManagementSystem.DAL.Models;

namespace OnlineBankingManagementSystem.BLL.DTOs
{
    public class AccountDTO
    {
        public string AccountNumber { get; set; }
        public string FullName { get; set; }
        public decimal Balance { get; set; }
        public int UserId { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public User User { get; set; }
        public static explicit operator Account(AccountDTO accountDTO)
        {
            if (accountDTO == null) return null;
            return new Account
            {
                AccountNumber = accountDTO.AccountNumber,
                Balance = accountDTO.Balance,
                User = accountDTO.User,
            };
        }
        public static implicit operator AccountDTO(Account account)
        {
            if (account == null) return null;
            return new AccountDTO
            {
                AccountNumber = account.AccountNumber,
                Balance = account.Balance,
                User = account.User,
            };
        }
    }
}
