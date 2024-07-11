using Microsoft.AspNetCore.Mvc;
using Escola.Repositories;
using Escola.Models;
using Microsoft.AspNetCore.Authorization;

namespace Escola.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<UserModel>>> GetAllUsers()
        {
            List<Result> resultados = await _userRepository.GetAllUsers();
            List<UserModel> users = new List<UserModel>();
            foreach (Result result in resultados)
            {
                if (result.Success)
                {
                    users.Add(result.User);
                }
                else
                {
                    return Problem(result.Error);
                }
            }
            return Ok(users);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<List<UserModel>>> GetUser(string name = "")
        {
            Result result = await _userRepository.GetUser(name);
            if (!result.Success)
            {
                return NotFound(result.Error);
            }
            return Ok(result.User);
        }

        [HttpPost]
        public async Task<ActionResult<List<UserModel>>> CreatUser(string userName, string password)
        {
            Result result = await _userRepository.CreatUser(userName, password);
            if (!result.Success)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.User);
        }
    }
}
