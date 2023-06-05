using System.ComponentModel.DataAnnotations;

namespace OnlineBankingManagementSystem.BLL.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
