using Microsoft.AspNetCore.Mvc;
using BackendSR.Domain.Entities;
using BackendSR.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using BackendSR.Application.Service;
using BackendSR.Application.DTOs.Response;
using BackendSR.Domain.Exceptions;
using BackendSR.Validation;

namespace BackendSR.Application.UseCase
{
    public class RegisterUseCase
    {
        private readonly DataContext _context;
        private readonly TokenService _tokenService;

        public RegisterUseCase(DataContext context, TokenService token)
        {
            _context = context;
            _tokenService = token;
        }
        public async Task<ActionResult<AuthResponse>> executeRegister(User user)
        {
            var validator = new RegisterValidator();
            var result = validator.Validate(user);

            if(!result.IsValid)
            {
                throw new UnauthorizedException("Dados informados não estão em um formato valido!");
            }

            var ExistingUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == user.Email.ToLower().Trim());

            if (ExistingUser != null)
            {
                throw new UnauthorizedException("Error: Usuario já cadastrado");
            };

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

            }catch(Exception ex)
            {
                throw new Exception("Erro ao salvar no banco de dados!", ex);
            };

            var accessToken = _tokenService.GenerateToken(user);

            return new AuthResponse("Sucess: Cadastro Efetuado!", accessToken);

        }
    }
}
