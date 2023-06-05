using OnlineBankingManagementSystem.DAL.Models;

namespace OnlineBankingManagementSystem.BLL.DTOs
{
    public class AccountDTO
    {
        public int AccountNumber { get; set; }
        public string FullName { get; set; } = null!;
        public string AccountType { get; set; } = null!;
        public decimal Balance { get; set; }
    }
}
