using Microsoft.AspNetCore.Mvc;
using Escola.DTOs;
using Escola.Services;
using Escola.Models;

namespace Escola.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly TokenService _tokenService;
        public AuthenticationController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<ActionResult<string>> GerateToken(LoginDTO login)
        {
            Result result = await _tokenService.GerateToken(login);

            if (!result.Success) 
            { 
                return Unauthorized(result.Error);
            }
            return Ok(result.Token);
        }
    }
}
