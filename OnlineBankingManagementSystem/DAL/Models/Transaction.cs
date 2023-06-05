using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBankingManagementSystem.DAL.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        [ForeignKey(nameof(Account))]
        public int AccountNumber { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public int ReceiverAccountNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public virtual Account Account { get; set; }
        
    }
}
