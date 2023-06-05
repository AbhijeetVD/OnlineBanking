using OnlineBankingManagementSystem.DAL.Models;

namespace OnlineBankingManagementSystem.DAL.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _context;
        public UserRepo(AppDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetByAccountNumber(int accountNumber)
        {
            var user = _context.Users.Find(accountNumber);
            if (user == null)
            {
                throw new Exception("No user available for this account number!");
            }
            return user;
        }

        public User GetByEmail(string email)
        {
            var user = _context.Users.Find(email);
            if (user == null)
            {
                throw new Exception("No user available for this Email!");
            }
            return user;
        }
        public User GetByUserId(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                throw new Exception("No user available for this ID!");
            }
            return user;
        }

        public User GetByUsername(string username)
        {
            var user = _context.Users.Find(username);
            if (user == null)
            {
                throw new Exception("No user available for this Username!");
            }
            return user;
        }

        public void Update(User user)
        {
            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
