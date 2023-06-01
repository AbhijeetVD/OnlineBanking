using OnlineBankingManagementSystem.DAL.Models;

namespace OnlineBankingManagementSystem.DAL.Repositories
{
    public interface IUserRepo
    {
        public IEnumerable<User> GetAll();
        public User GetByAccountNumber(string accountNumber);
        public User GetByUserId(int userId);
        public User GetByUsername(string username);
        public User GetByEmail(string email);
        public void Add(User user);
    }
}
