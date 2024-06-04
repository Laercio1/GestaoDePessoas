using FluentValidation;

namespace GestaoDePessoas.Dominio.EnderecoRoot.Validation
{
    public class EnderecoValidation : AbstractValidator<Endereco>
    {
        public EnderecoValidation()
        {
            RuleFor(c => c.ID)
                   .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");

            RuleFor(c => c.CEP)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(8, 9).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => c.ESTADO)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(1, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => c.CIDADE)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(1, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => c.BAIRRO)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(1, 150).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => c.RUA)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(1, 150).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}
