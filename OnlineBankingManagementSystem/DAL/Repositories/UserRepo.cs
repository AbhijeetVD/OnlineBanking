using OnlineBankingManagementSystem.DAL.Models;

namespace OnlineBankingManagementSystem.DAL.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext context;
        public UserRepo(AppDbContext _context)
        {
            context = _context;
        }

        public void Add(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users.ToList();
        }

        public User GetByAccountNumber(string accountNumber)
        {
            return context.Users.Find(accountNumber);
        }
    }
}
