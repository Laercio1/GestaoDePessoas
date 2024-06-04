using FluentValidation;

namespace GestaoDePessoas.Dominio.ClienteRoot.Validation
{
    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(c => c.ID)
                   .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");

            RuleFor(c => c.NOME)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(1, 250).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => c.RAZAO)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(1, 250).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => c.CNPJ_CPF)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(11, 18).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}
