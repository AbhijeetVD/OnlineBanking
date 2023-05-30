namespace OnlineBankingManagementSystem.DAL.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public virtual Account Account { get; set; }
    }
}
