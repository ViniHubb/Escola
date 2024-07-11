using Microsoft.EntityFrameworkCore;
using Escola.Data;
using Escola.Models;
using System.Text.RegularExpressions;
using Escola.DTOs;

namespace Escola.Repositories
{
    public class UserRepository
    {
        private readonly SchoolDBContext _dbContext;
        public UserRepository(SchoolDBContext schoolDBContext)
        {
            _dbContext = schoolDBContext;
        }

        public async Task<List<Result>> GetAllUsers()
        {
            Result result;
            List<Result> resultados = new List<Result>();
            List<UserModel> users = await _dbContext.Users.ToListAsync();
            foreach (UserModel user in users)
            {
                result = new Result();
                result.Success = true;
                result.User = user;
                resultados.Add(result);
            }
            return resultados;
        }

        public async Task<Result> GetUser(string name)
        {
            Result result = new Result();
            UserModel? user = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == name);
            if (user == null)
            {
                result.Success = false;
                result.Error = "O usuario de nome: " + name + " não foi encontrado";
            }
            else
            {
                result.Success = true;
                result.User = user;
            }
            return result;
        }

        public async Task<Result> CreatUser(string name, string password)
        {
            Result result = new Result();
            const string nameRegex = @"^[A-Za-uÀ-Úá-ú]+$";

            if (!Regex.IsMatch(name, nameRegex))
            {
                result.Success = false;
                result.Error = "Nome invalido";
            }
            else {
                result = await GetUser(name);
                if (result.Success)
                {
                    result.Success = false;
                    result.Error = "O usuario de nome: " + name + "  ja existe";
                }
                else
                {
                    UserModel user = new UserModel(name, password, "");
                    await _dbContext.Users.AddAsync(user);
                    await _dbContext.SaveChangesAsync();
                    result.User = user;
                    result.Success = true;
                }
            }
            return result;
        }
    }
}
