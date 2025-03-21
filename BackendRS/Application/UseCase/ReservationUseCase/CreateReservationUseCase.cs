using BackendRS.Domain.Entities;
using BackendRS.Application.DTOs.Response;
using BackendRS.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendRS.Domain.Exceptions;
using BackendRS.Validation;

namespace BackendRS.Application.UseCase.ReservationUseCase
{
    public class CreateReservationUseCase
    {
        private readonly DataContext _context;

        public CreateReservationUseCase(DataContext context)
        {
            _context = context;
        }   
        
        public async Task<ActionResult<MessageResponse>> executeReservation(Reservation reservation)
        {
            var validator = new ReservationValidator();
            var resultValidator = validator.Validate(reservation);

            if (!resultValidator.IsValid)
            {
                throw new Exception("Error: Dados informados estão mal formatados!");
            }

            var existingReservation = await _context.Reservations.FirstOrDefaultAsync(x => x.Id == reservation.Id);

            if (existingReservation != null)
            {
                throw new UnauthorizedException("Error: Reserva já cadastrada");
            }

            try 
            { 
                await _context.Reservations.AddAsync(reservation);
                await _context.SaveChangesAsync();

            }catch(Exception ex)
            {
                throw new Exception("Erro ao criar a reserva!", ex);
            }

            return new MessageResponse("Reserva Criada com sucesso!");
        }  
    }
}
