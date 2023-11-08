using FluentValidation;
using GestaoDePessoas.Dominio.Core.Utils.StringUtils;

namespace GestaoDePessoas.Dominio.PessoaRoot.Validation
{
    public class PessoaValidation : AbstractValidator<Pessoa>
    {
        public PessoaValidation()
        {
            RuleFor(c => c.Id)
                   .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");

            RuleFor(c => c.NomeCompleto)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(5, 250).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => StringUtils.ApenasNumeros(c.CNPJ_CPF))
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(11, 14).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => c.Email)
                .EmailAddress().WithMessage("E-mail inválido.");

            RuleFor(c => StringUtils.ApenasNumeros(c.Telefone))
                .MaximumLength(12).WithMessage("O campo {PropertyName} deve ter menos de {MaxLength} caracteres.");

            RuleFor(c => StringUtils.ApenasNumeros(c.CEP))
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(8).WithMessage("O campo {PropertyName} deve ter {ExactLength} caractere(s).");

            RuleFor(c => c.Estado)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(3, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => c.Cidade)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(3, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => c.Bairro)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(3, 150).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => c.Logradouro)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(3, 150).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}
