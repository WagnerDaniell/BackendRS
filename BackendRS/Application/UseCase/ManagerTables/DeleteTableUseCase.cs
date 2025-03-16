using BackendRS.Application.DTOs.Response;
using BackendRS.Domain.Exceptions;
using BackendRS.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace BackendRS.Application.UseCase.ManagerTables
{
    public class DeleteTableUseCase
    {
        private readonly DataContext _context;

        public DeleteTableUseCase(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<MessageResponse>> executeDeleteTable(Guid id)
        {
            var table = await _context.Tables.FindAsync(id);

            if ( table == null )
            {
                throw new NotFoundException("Mesa não encontrada!");
            }

            try
            {
                _context.Tables.Remove(table);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar a mesa!", ex);
            }

            return new MessageResponse("Mesa deletada com sucesso!");
        }
    }
}
