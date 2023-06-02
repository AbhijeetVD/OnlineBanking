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

        public User GetByEmail(string email)
        {
            return context.Users.Find(email);
        }

        public User GetByUserId(int userId)
        {
            return context.Users.Find(userId);
        }

        public User GetByUsername(string username)
        {
            return context.Users.Find(username);
        }
        public void Register(string username, string password, string email, string fullname)
        {
            User user = new User();
            user.Username = username;
            user.Password = password;
            user.Email = email;
            user.FullName = fullname;
            context.Users.Add(user);
            context.SaveChanges();
        }
        public User Login(string username, string password)
        {
            return context.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
