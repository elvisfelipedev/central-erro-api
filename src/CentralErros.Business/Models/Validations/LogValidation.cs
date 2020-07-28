using FluentValidation;

namespace CentralErros.Business.Models.Validations
{
    public class LogValidation : AbstractValidator<Log>
    {
        public LogValidation()
        {
            RuleFor(l => l.Origem)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser informado.");

            RuleFor(l => l.Titulo)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser informado.");

            RuleFor(l => l.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser informado.");

            RuleFor(l => l.Ambiente)
                .GreaterThan(0).WithMessage("É necessário escolher um {PropertyName}.");

            RuleFor(l => l.Level)
                .GreaterThan(0).WithMessage("É necessário escolher um {PropertyName}.");

            RuleFor(l => l.Evento)
                .GreaterThan(0).WithMessage("É necessário escolher um {PropertyName}.");
        }
    }
}
