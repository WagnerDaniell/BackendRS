using BackendRS.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using BackendRS.Application.DTOs.Response;
using BackendRS.Domain.Exceptions;

namespace BackendRS.Application.UseCase.ManagerTables
{
    public class UpdateTablesUseCase
    {
        private readonly DataContext _context;

        public UpdateTablesUseCase(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<MessageResponse>> executeUpdate(Guid Id, string name, string status, string capacity)
        {
            var table = await _context.Tables.FindAsync(Id);

            if (table == null)
            {
                throw new UnauthorizedException("Essa Mesa não existe!");
            }

            try
            {
                table.Name = name;
                table.Status = status;
                table.Capacity = capacity;

                await _context.SaveChangesAsync();

            }
            catch (Exception error)
            {
                throw new Exception("Erro na hora de salvar a alteração", error);
            }

            return new MessageResponse("Mesa atualizada com sucesso!");

        }
    }
}
