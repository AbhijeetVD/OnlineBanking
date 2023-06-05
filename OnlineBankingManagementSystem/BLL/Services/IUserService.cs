using OnlineBankingManagementSystem.BLL.DTOs;

namespace OnlineBankingManagementSystem.BLL.Services
{
    public interface IUserService
    {
        public IEnumerable<UserDTO> GetAllUsers();
        public UserDTO GetUserByAccountNumber(int accountNumber);
        public UserDTO GetUserByUserId(int userId);
        public UserDTO GetUserByUsername(string username);
        public UserDTO GetUserByEmail(string email);
        UserDTO LoginUser(LoginDTO login);
        UserDTO RegisterUser(RegisterDTO register);
        void SignUp(UserDTO user);
        string HashPassword(string password);
        void DeleteUser(int userId);
        void UpdateUser(int userId, UserDTO user);
    }
}
