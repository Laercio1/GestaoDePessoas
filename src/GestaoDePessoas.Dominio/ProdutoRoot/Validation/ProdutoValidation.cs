using FluentValidation;

namespace GestaoDePessoas.Dominio.ProdutoRoot.Validation
{
    public class ProdutoValidation : AbstractValidator<Produto>
    {
        public ProdutoValidation()
        {
            RuleFor(c => c.ID)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");

            RuleFor(c => c.MarcaID)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");

            RuleFor(c => c.CategoriaID)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");

            RuleFor(c => c.PRECOUNITARIO)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");

            RuleFor(c => c.CBARRA)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(1, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => c.UNIDADE)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(1, 10).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => c.NOME)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(1, 250).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}
