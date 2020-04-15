using FluentValidation;
using ProjetoBase.Domain.Messages;

namespace ProjetoBase.Domain.Commands.Usuarios
{
    public class AlterarUsuarioValidator : AbstractValidator<AlterarUsuarioCommand>
    {
        public AlterarUsuarioValidator()
        {
            RuleFor(u => u.Id)
                .NotEmpty().WithMessage(ValidationMessages.RequiredField);
            RuleFor(u => u.Nome)
                .NotEmpty().WithMessage(ValidationMessages.RequiredField)
                .MinimumLength(3).WithMessage(ValidationMessages.MinLength);
        }
    }
}
