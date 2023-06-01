using OnlineBankingManagementSystem.BLL.DTOs;

namespace OnlineBankingManagementSystem.BLL.Services
{
    public interface IAuthService
    {
        string LoginUser(LoginDTO login);
        void RegisterUser(RegisterDTO register);
    }
}
