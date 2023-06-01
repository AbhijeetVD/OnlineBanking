using OnlineBankingManagementSystem.BLL.DTOs;
using OnlineBankingManagementSystem.DAL.Repositories;
using OnlineBankingManagementSystem.DAL.Models;

namespace OnlineBankingManagementSystem.BLL.Services
{
    public class AuthService : IAuthService
    {
        public readonly IUserRepo userrepo;
        public readonly IConfiguration configuration;
        public AuthService(IUserRepo _userrepo, IConfiguration _configuration)
        {
            userrepo = _userrepo;
            configuration = _configuration;
        }

        public string LoginUser(LoginDTO login)
        {
            throw new NotImplementedException();
        }

        public void RegisterUser(RegisterDTO register)
        {
            throw new NotImplementedException();
        }
    }
}
