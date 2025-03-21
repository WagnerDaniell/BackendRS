using BackendRS.Domain.Entities;
using FluentValidation;

namespace BackendRS.Validation
{
    public class TableValidator : AbstractValidator<Table>
    {
        public TableValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Capacity).NotEmpty();
            RuleFor(x => x.Status).NotEmpty();

        }
    }
}
