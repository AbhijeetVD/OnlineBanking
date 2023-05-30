using OnlineBankingManagementSystem.BLL.DTOs;
using OnlineBankingManagementSystem.DAL.Repositories;
using OnlineBankingManagementSystem.DAL.Models;

namespace OnlineBankingManagementSystem.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepo userrepo;
        public UserService(UserRepo _userrepo)
        {
            this.userrepo = _userrepo;
        }

        public void AddUser(UserDTO user)
        {
            userrepo.Add((User)user);
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            return (IEnumerable<UserDTO>)userrepo.GetAll();
        }

        public UserDTO GetUserByAccountNumber(string accountNumber)
        {
            return userrepo.GetByAccountNumber(accountNumber);
        }
        public UserDTO GetUserByUserId(int userId)
        {
            return userrepo.GetByUserId(userId);    
        }
    }
}
