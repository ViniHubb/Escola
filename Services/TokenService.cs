using Escola.DTOs;
using Escola.Models;
using Escola.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Escola.Services
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;
        private readonly UserRepository _userRepository;

        public TokenService(UserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<Result> GerateToken(LoginDTO login)
        {
            Result loginDataBase = await _userRepository.GetUser(login.UserName);
            if (!loginDataBase.Success)
            {
                return loginDataBase;
            }
            else if (loginDataBase.User.Password != login.Password)
            {
                loginDataBase.Error = "Senha incorreta";
                loginDataBase.Success = false;
                return loginDataBase;
            }
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? string.Empty));
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];

            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: new[]
                {
                    new Claim(type: ClaimTypes.Name, loginDataBase.User.UserName),
                    new Claim(type: ClaimTypes.Role, loginDataBase.User.Role),
                },
                expires: DateTime.Now.AddHours(1),
                signingCredentials: signinCredentials
            );

            string token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            loginDataBase.Token = token;
            loginDataBase.Success = true;

            return loginDataBase;
        }
    }
}