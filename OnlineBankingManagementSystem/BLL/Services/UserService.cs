using OnlineBankingManagementSystem.BLL.DTOs;
using OnlineBankingManagementSystem.DAL.Repositories;
using OnlineBankingManagementSystem.DAL.Models;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Security.Cryptography;

namespace OnlineBankingManagementSystem.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userrepo;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepo userrepo, IConfiguration configuration)
        {
            this._userrepo = userrepo;
            _configuration = configuration;
        }
        public IEnumerable<UserDTO> GetAllUsers()
        {
            try
            {
                var users = _userrepo.GetAll();
                return users.Select(u => new UserDTO
                {
                    UserId = u.UserId,
                    Username = u.Username,
                    FullName = u.FullName,
                    Email = u.Email,
                    AccountNumber = u.AccountNumber,
                });
            }
            catch(Exception e) { 
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public UserDTO GetUserByAccountNumber(int accountNumber)
        {
            try
            {
                var user = _userrepo.GetByAccountNumber(accountNumber);
                if(user == null)
                {
                    throw new Exception("User not found!");
                }
                return new UserDTO {
                    UserId = user.UserId,
                    Username = user.Username,
                    FullName = user.FullName,
                    Email = user.Email,
                    AccountNumber = accountNumber,
                };
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public UserDTO GetUserByEmail(string email)
        {
            try
            {
                var user = _userrepo.GetByEmail(email);
                if(user == null)
                {
                    throw new Exception("User not found!");
                }
                return new UserDTO
                {
                    UserId = user.UserId,
                    Email = user.Email,
                    Username = user.Username,
                    FullName = user.FullName,
                    AccountNumber = user.AccountNumber,
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public UserDTO GetUserByUserId(int userId)
        {
            try
            {
                var user = _userrepo.GetByUserId(userId);
                if (user == null)
                {
                    throw new Exception("User not found!");
                }
                return new UserDTO { 
                    UserId = user.UserId, 
                    Email = user.Email, 
                    Username = user.Username, 
                    FullName = user.FullName, 
                    AccountNumber = user.AccountNumber 
                };
            }
            catch (Exception e) { 
                Console.WriteLine(e.Message); 
                throw; 
            }    
        }
        public UserDTO GetUserByUsername(string username)
        {
            try
            {
                var user = _userrepo.GetByUsername(username);
                if( user == null)
                {
                    throw new Exception("User not found!");
                }
                return new UserDTO
                {
                    UserId = user.UserId,
                    Email = user.Email,
                    Username = user.Username,
                    FullName = user.FullName,
                    AccountNumber = user.AccountNumber
                };
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public UserDTO RegisterUser(RegisterDTO register)
        {
            var user = new User
            {
                Username = register.Username,
                Email = register.Email,
                Password = register.Password,
                FullName = register.FullName
            };
            _userrepo.Add(user);
            return new UserDTO
            {
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                FullName = user.FullName
            };
        }
        public void SignUp(UserDTO user)
        {
            if (_userrepo.GetByEmail(user.Email) != null)
            {
                throw new Exception("E-mail already taken!");
            }
            if (_userrepo.GetByUsername(user.Username) != null)
            {
                throw new Exception("Username already taken!");
            }
            var hashedPassword = HashPassword(user.Password);
            var users = new User
            {
                Username = user.Username,
                Email = user.Email,
                Password = hashedPassword,
                FullName = user.FullName,
                ConfirmPassword = user.Password
            };
        }
        public UserDTO LoginUser(LoginDTO login)
        {
            var user = _userrepo.GetByUsername(login.Username);
            if (user == null)
            {
                throw new Exception("Username doesn't exist!");
            }
            var hashedPassword = HashPassword(login.Password);
            if (user.Password != hashedPassword)
            {
                throw new Exception("Invalid password!");
            }
            return new UserDTO
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                Password = hashedPassword,
                FullName = user.FullName,
                ConfirmPassword = user.ConfirmPassword
            };
        }
        public string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
        public void UpdateUser(int userId, UserDTO user)
        {
            var update = _userrepo.GetByUserId(userId);
            if(user == null)
            {
                throw new Exception("User id not found");
            }
            user.Username = update.Username ?? user.Username;
            user.Email = update.Email ?? user.Email;
            user.FullName = update.FullName ?? user.FullName;
            user.Password = update.Password ?? user.Password;
            _userrepo.Update(update);
        }
        public void DeleteUser(int userId)
        {
            var delete = _userrepo.GetByUserId(userId);
            if(delete == null)
            {
                throw new Exception("Unable to delete user!");
            }
            _userrepo.Delete(delete);
        }
    }
}
