//using FluentValidation;

//namespace GestaoDePessoas.Dominio.PessoaRoot.Validation
//{
//    public class PessoaValidation : AbstractValidator<Pessoa>
//    {
//        public PessoaValidation()
//        {
//            RuleFor(c => c.ID)
//                   .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");

//            RuleFor(c => c.NOMECOMPLETO)
//                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
//                .Length(1, 250).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

//            RuleFor(c => c.CNPJ_CPF)
//                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
//                .Length(11, 18).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
//        }
//    }
//}
