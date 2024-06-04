using FluentValidation;

namespace GestaoDePessoas.Dominio.PedidoItemRoot.Validation
{
    public class PedidoItemValidation : AbstractValidator<PedidoItem>
    {
        public PedidoItemValidation()
        {
            RuleFor(c => c.ID)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");

            RuleFor(c => c.ProdutoID)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");

            RuleFor(c => c.QUANTIDADE)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");
        }
    }
}
