using FluentValidation;

namespace GestaoDePessoas.Dominio.PedidoStatusRoot.Validation
{
    public class PedidoStatusValidation : AbstractValidator<PedidoStatus>
    {
        public PedidoStatusValidation()
        {
            RuleFor(c => c.ID)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");

            RuleFor(c => c.DESCRICAO)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(1, 250).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}
