using BackendRS.Application.DTOs.Response;
using BackendSR.Domain.Entities;
using BackendSR.Domain.Exceptions;
using BackendSR.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendRS.Application.UseCase.ManagerTables
{
    public class CreateTableUseCase
    {
        private readonly DataContext _context;

        public CreateTableUseCase(DataContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<MessageResponse>> executeCreateTable(Table table)
        {
            //Passar por um validate

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
