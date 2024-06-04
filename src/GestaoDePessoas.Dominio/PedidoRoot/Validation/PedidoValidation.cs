using FluentValidation;

namespace GestaoDePessoas.Dominio.PedidoRoot.Validation
{
    public class PedidoValidation : AbstractValidator<Pedido>
    {
        public PedidoValidation()
        {
            RuleFor(c => c.ID)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");

            RuleFor(c => c.ClienteID)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");

            RuleFor(c => c.FormaPagamentoID)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");

            RuleFor(c => c.PedidoStatusID)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");

            RuleFor(c => c.VALORTOTAL)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");

            RuleFor(c => c.VALORFINAL)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");

            RuleFor(c => c.NUMEROPEDIDO)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");

            RuleFor(c => c.QUANTIDADEITENS)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");
        }
    }
}
