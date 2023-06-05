using System.ComponentModel.DataAnnotations;

namespace OnlineBankingManagementSystem.BLL.DTOs
{
    public class RegisterDTO
    {
        public int UserId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [StringLength (100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="Password doesnot match")]
        public string ConfirmPassword { get; set; }
    }
}
