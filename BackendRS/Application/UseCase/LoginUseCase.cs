using Microsoft.AspNetCore.Mvc;
using BackendSR.Application.DTOs.Request;
using BackendSR.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using BackendSR.Application.DTOs.Response;
using BackendSR.Application.Service;
using BackendSR.Domain.Exceptions;

namespace BackendSR.Application.UseCase
{
    public class LoginUseCase
    {
        private readonly DataContext _context;
        private readonly TokenService _tokenService;

        public LoginUseCase(DataContext context, TokenService token)
        {
            _context = context;
            _tokenService = token;
        }
        public async Task<ActionResult<AuthResponse>> executeLogin (LoginRequest loginRequest)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == loginRequest.Email.ToLower().Trim());

            if (user == null)
            {
                throw new NotFoundException("Error: Usuario não encontrado");
            }

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password);

            if (!isPasswordValid)
            {
                throw new UnauthorizedException("Error: Senha incorreta");
            }

            var accessToken = _tokenService.GenerateToken(user);

            return new AuthResponse("Sucess: Login Efetuado!", accessToken);
        }
    }
}
