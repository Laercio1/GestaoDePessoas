using FluentValidation;

namespace GestaoDePessoas.Dominio.CategoriaRoot.Validation
{
    public class CategoriaValidation : AbstractValidator<Categoria>
    {
        public CategoriaValidation()
        {
            RuleFor(c => c.ID)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");

            RuleFor(c => c.NOME)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(1, 250).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}
