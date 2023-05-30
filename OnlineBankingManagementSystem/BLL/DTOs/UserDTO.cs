using OnlineBankingManagementSystem.DAL.Models;

namespace OnlineBankingManagementSystem.BLL.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public Account Account { get; set; }

        public string AccountNumber { get; set; }
        public static explicit operator User(UserDTO userDTO)
        {
            if (userDTO == null) return null;
            return new User
            {
                UserId = userDTO.UserId,
                Username = userDTO.Username,
                Password = userDTO.Password,
                FullName = userDTO.FullName,
                Account = userDTO.Account,
                AccountNumber = userDTO.AccountNumber,
                Email = userDTO.Email
                
            };
        }
        public static implicit operator UserDTO(User user)
        {
            if (user == null) return null;
            return new UserDTO
            {
                UserId = user.UserId,
                Username = user.Username,
                Password = user.Password,
                FullName = user.FullName,
                Account = user.Account,
                AccountNumber = user.AccountNumber,
                Email = user.Email
            };
        }
    }
}
