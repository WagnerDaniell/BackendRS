using BackendRS.Application.DTOs.Response;
using BackendRS.Application.Service;
using BackendRS.Domain.Entities;
using BackendRS.Domain.Exceptions;
using BackendRS.Infrastructure.Data;
using BackendRS.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BackendRS.Application.UseCase.ManagerTables
{
    public class CreateTableUseCase
    {
        private readonly DataContext _context;

        public CreateTableUseCase(DataContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<MessageResponse>> executeCreateTable(Table table, string token)
        {
            var validator = new TableValidator();
            var resultValidator = validator.Validate(table);

            var validateTokenRole = new ValidateTokenRole();
            var isAuthorized = validateTokenRole.ValidateRole(token);

            if (!isAuthorized)
            {
                throw new UnauthorizedException("Error: Não Autorizado");
            };
            

            var Existingtable = await _context.Tables.FirstOrDefaultAsync(x => x.Id == table.Id);

            if (Existingtable != null)
            {
                throw new UnauthorizedException("Error: Mesa já cadastrada");
            };

            try
            {
                await _context.Tables.AddAsync(table);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar a mesa!", ex);
            };

            return new MessageResponse("Mesa Criada com sucesso!");
        }
    }
}
