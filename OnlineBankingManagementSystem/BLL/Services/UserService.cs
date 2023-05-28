using OnlineBankingManagementSystem.BLL.DTOs;
using OnlineBankingManagementSystem.DAL.Repositories;

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
            userrepo.Add(user);
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            return userrepo.GetAll();
        }

        public UserDTO GetUserByAccountNumber(string accountNumber)
        {
            return userrepo.GetByAccountNumber(accountNumber);
        }
    }
}
