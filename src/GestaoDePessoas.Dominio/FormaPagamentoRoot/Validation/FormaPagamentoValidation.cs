using FluentValidation;

namespace GestaoDePessoas.Dominio.FormaPagamentoRoot.Validation
{
    public class FormaPagamentoValidation : AbstractValidator<FormaPagamento>
    {
        public FormaPagamentoValidation()
        {
            RuleFor(c => c.ID)
                   .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");

            RuleFor(c => c.NOME)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(1, 250).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}
