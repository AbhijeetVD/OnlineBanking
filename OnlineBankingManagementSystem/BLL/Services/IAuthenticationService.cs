using OnlineBankingManagementSystem.DAL.Repositories;

namespace OnlineBankingManagementSystem.BLL.Services
{
    public class IAuthenticationService
    {
        private readonly IUserRepo userrepo;
        private readonly IConfiguration configuration;
        public IAuthenticationService(IUserRepo _userrepo, IConfiguration _configuration)
        {
            this.userrepo = _userrepo;
            this.configuration = _configuration;
        }
    }
}
