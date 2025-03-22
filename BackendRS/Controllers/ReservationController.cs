using BackendRS.Application.UseCase.ReservationUseCase;
using BackendRS.Application.Service;
using BackendRS.Domain.Entities;
using BackendRS.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using BackendRS.Application.UseCase.Auth;


namespace BackendRS.Controllers
{
    [ApiController]
    [Route("api/sr")]
    public class ReservationController : ControllerBase
    {
        private readonly DataContext _context;

        public ReservationController(DataContext context, TokenService token)
        {
            _context = context;
        }

        [HttpPost]
        [Route("createreservation")]
        public async Task<ActionResult> CreateReservation([FromBody] Reservation reservation)
        {
            var useCase = new CreateReservationUseCase(_context);
            var responseCreateReservation = await useCase.executeReservation(reservation);

            return Created(string.Empty, responseCreateReservation.Value);
        }

        [HttpDelete]
        [Route("deletereservation/{id}")]
        public async Task<ActionResult> DeleteReservation(Guid id, string token)
        {
            var useCase = new DeleteReservationUseCase(_context);
            var responseDeleteReservation = await useCase.executeDelete(id, token);
            return Ok(responseDeleteReservation.Value);
        }
    }
}
