﻿using FluentValidation;

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
                .Length(1, 250).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => c.CNPJ_CPF)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(11, 14).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => c.Email)
                .EmailAddress().WithMessage("E-mail inválido.");

            RuleFor(c => c.Telefone)
                .MaximumLength(12).WithMessage("O campo {PropertyName} deve ter menos de {MaxLength} caracteres.");

            RuleFor(c => c.CEP)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(8, 9).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => c.Estado)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(1, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => c.Cidade)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(1, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => c.Bairro)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(1, 150).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => c.Numero)
                .MaximumLength(50).WithMessage("O campo {PropertyName} deve ter menos de {MaxLength} caracteres.");

            RuleFor(c => c.Logradouro)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(1, 150).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}
