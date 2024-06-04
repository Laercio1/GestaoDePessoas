using FluentValidation;

namespace GestaoDePessoas.Dominio.ContatoRoot.Validation
{
    public class ContatoValidation : AbstractValidator<Contato>
    {
        public ContatoValidation()
        {
            RuleFor(c => c.ID)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");

            RuleFor(c => c.VALORCONTATO)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");

            RuleFor(c => c.TIPOCONTATO)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");
        }
    }
}
