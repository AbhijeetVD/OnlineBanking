using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBankingManagementSystem.DAL.Models
{
    public class Account
    {
        [Key]
        public int AccountNumber { get; set; }
        [Required]
        public string FullName { get; set; } = null!;
        [Required]
        public string AccountType { get; set; } = null!;
        [Required]
        public decimal Balance { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        
        
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        
        
        public User User { get; set; }
    }
}
