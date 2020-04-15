using FluentValidation;
using ProjetoBase.Domain.Messages;

namespace ProjetoBase.Domain.Commands.Usuarios
{
    public class InserirUsuarioValidator : AbstractValidator<InserirUsuarioCommand>
    {
        public InserirUsuarioValidator()
        {
            RuleFor(u => u.Nome)
                .NotEmpty().WithMessage(ValidationMessages.RequiredField)
                .MinimumLength(3).WithMessage(ValidationMessages.MinLength);
        }
    }
}
