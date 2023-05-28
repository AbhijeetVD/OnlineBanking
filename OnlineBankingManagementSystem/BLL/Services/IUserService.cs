using OnlineBankingManagementSystem.BLL.DTOs;

namespace OnlineBankingManagementSystem.BLL.Services
{
    public interface IUserService
    {
        public IEnumerable<UserDTO> GetAllUsers();
        public UserDTO GetUserByAccountNumber(string accountNumber);
        public void AddUser(UserDTO user);
    }
}
