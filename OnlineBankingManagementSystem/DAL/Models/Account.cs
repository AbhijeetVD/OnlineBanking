namespace OnlineBankingManagementSystem.DAL.Models
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public string FullName { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public User User { get; set; }
    }
}
