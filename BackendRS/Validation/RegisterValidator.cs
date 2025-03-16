using FluentValidation;
using BackendRS.Domain.Entities;

namespace BackendRS.Validation
{
    public class RegisterValidator : AbstractValidator<User>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome é obrigatório");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email é obrigatório")
                .EmailAddress().WithMessage("Email inválido");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Senha é obrigatória")
                .MinimumLength(6).WithMessage("Senha deve ter no mínimo 6 caracteres");
            RuleFor(x => x.Role).NotEmpty().WithMessage("Role é obrigatória");
        }
    }
}