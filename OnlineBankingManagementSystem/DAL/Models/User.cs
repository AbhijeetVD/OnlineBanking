using System.Security.Principal;

namespace OnlineBankingManagementSystem.DAL.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public Account Account { get; set; }
        public string AccountNumber { get; set; }
    }
}
