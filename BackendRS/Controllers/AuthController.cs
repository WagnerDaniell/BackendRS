using BackendSR.Application.DTOs.Request;
using BackendSR.Application.DTOs.Response;
using BackendSR.Application.Service;
using BackendRS.Application.UseCase.Auth;
using BackendSR.Domain.Entities;
using BackendSR.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace BackendSR.Controllers
{
    [ApiController]
    [Route("api/sr")]
    public class AuthController : ControllerBase
    {

        private readonly DataContext _context;
        private readonly TokenService _tokenService;

        public AuthController(DataContext context, TokenService token)
        {
            _context = context;
            _tokenService = token;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] User user)
        {
            var useCase = new RegisterUseCase(_context, _tokenService);

            var responseRegister = await useCase.executeRegister(user);

            return Created(string.Empty, responseRegister.Value);
        }

        [HttpPost]
        [Route("login")]

        public async Task<ActionResult> Login([FromBody] LoginRequest login)
        {
            var useCase = new LoginUseCase(_context, _tokenService);
            var responseLogin = await useCase.executeLogin(login);

            return Ok(responseLogin.Value);
        }
    }
}
