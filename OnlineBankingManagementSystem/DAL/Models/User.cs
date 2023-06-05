using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace OnlineBankingManagementSystem.DAL.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string ConfirmPassword { get; set; } = null!;
        [Required]
        public string FullName { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        public IEnumerable<Account> Accounts { get; set; }
        
        public int AccountNumber { get; set; }
    }
}
