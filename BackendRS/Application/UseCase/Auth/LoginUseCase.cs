using Microsoft.AspNetCore.Mvc;
using BackendRS.Application.DTOs.Request;
using BackendRS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using BackendRS.Application.DTOs.Response;
using BackendRS.Application.Service;
using BackendRS.Domain.Exceptions;

namespace BackendRS.Application.UseCase.Auth
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
        public async Task<ActionResult<AuthResponse>> executeLogin(LoginRequest loginRequest)
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
