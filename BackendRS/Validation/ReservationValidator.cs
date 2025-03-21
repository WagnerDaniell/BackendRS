using FluentValidation;
using BackendRS.Domain.Entities;
using System.Data;

namespace BackendRS.Validation
{
    public class ReservationValidator : AbstractValidator<Reservation>
    {
        public ReservationValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("userId é obrigatório");
            RuleFor(x => x.TableId).NotEmpty().WithMessage("tableId é obrigatório");
            RuleFor(x => x.dateReservation).NotEmpty().WithMessage("dateReservation é obrigatório");
            RuleFor(x => x.status).NotEmpty().WithMessage("status é obrigatório");
        }
    }
}
