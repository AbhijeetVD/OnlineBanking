using OnlineBankingManagementSystem.DAL.Models;

namespace OnlineBankingManagementSystem.DAL.Repositories
{
    public interface IUserRepo
    {
        public IEnumerable<User> GetAll();
        public User GetByAccountNumber(string accountNumber);
        public void Add(User user);
        public User GetByUserId(int userId);
    }
}
