using FluentValidation;

namespace GestaoDePessoas.Dominio.MarcaRoot.Validation
{
    public class MarcaValidation : AbstractValidator<Marca>
    {
        public MarcaValidation()
        {
            RuleFor(c => c.ID)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");

            RuleFor(c => c.NOME)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(1, 250).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}
