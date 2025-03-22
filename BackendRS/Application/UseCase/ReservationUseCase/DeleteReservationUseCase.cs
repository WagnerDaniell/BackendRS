using BackendRS.Application.DTOs.Response;
using BackendRS.Application.Service;
using BackendRS.Domain.Exceptions;
using BackendRS.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace BackendRS.Application.UseCase.ReservationUseCase
{
    public class DeleteReservation
    {
        private readonly DataContext _context;

        public DeleteReservation(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<MessageResponse>> executeDelete (Guid id, string token)
        {
            var validateToken = new ValidateTokenRole();
            var isAuthorized = validateToken.ValidateRole(token);

            if (!isAuthorized)
            {
                throw new Exception("Error: Não autorizado!");
            }

            var reservation = await _context.Reservations.FindAsync(id);

            if (reservation == null)
            {
                throw new NotFoundException("Reserva não encontrada!");
            }

            try
            {
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao deletar a reserva!", ex);
            }

            return new MessageResponse("Reserva deletada com sucesso!");
        }
    }
}
