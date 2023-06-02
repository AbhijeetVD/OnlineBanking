using OnlineBankingManagementSystem.BLL.DTOs;
using OnlineBankingManagementSystem.DAL.Repositories;
using OnlineBankingManagementSystem.DAL.Models;
using System.Security.Cryptography.X509Certificates;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

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
            var user = userrepo.Login(login.Username, login.Password);
            if(user == null)
            {
                throw new ApplicationException("Invalid Username or Password");
            }
            var jwtToken = GenerateJwtToken(user);
            return jwtToken;
        }

        public void RegisterUser(RegisterDTO register)
        {
            if(userrepo.GetByUsername(register.Username)!=null)
            {
                throw new ApplicationException("Username already in use!");
            }
            if(userrepo.GetByEmail(register.Email)!=null)
            {
                throw new ApplicationException("E-mail already in use!");
            }
            userrepo.Register(register.Username, register.Password, register.Email, register.FullName);
            userrepo.SaveChanges();
        }
        private string GenerateJwtToken(User user)
        {
            var key = Encoding.ASCII.GetBytes(configuration["Jwt:key"]);
            var claim = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claim),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
