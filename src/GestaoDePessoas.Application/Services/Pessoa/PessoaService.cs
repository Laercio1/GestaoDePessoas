using AutoMapper;
using GestaoDePessoas.Application.Services.Base;
using GestaoDePessoas.Application.ViewModels.Pessoa;
using GestaoDePessoas.Application.Interfaces.Produtos;
using GestaoDePessoas.Application.Notificacoes;
using GestaoDePessoas.Application.ViewModels.Produto;
using GestaoDePessoas.Dominio.PessoaRoot.Repository;
using GestaoDePessoas.Dominio.PessoaRoot.Validation;
using GestaoDePessoas.Dominio.PessoaRoot;

namespace GestaoDePessoas.Application.Services.Numeros
{
    public class PessoaService : BaseCadastroService<Pessoa,
        PessoaViewModel,
        PessoaAdicionarViewModel,
        PessoaAtualizarViewModel,
        PessoaValidation>,
        IPessoaService
    {

        private readonly IPessoaRepository _repository;

        public PessoaService(INotificador notificador,
                                    IPessoaRepository repository,
                                    IMapper mapper)
            : base("Pessoa", notificador, repository, mapper)
        {
            _repository = repository;
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

        public override bool ValidarAdicionarModel(Pessoa model)
        {
            //if (_repository.EExisteCadastroMesmoCPFCNPJ(model) != null)
            //    Notificar("Já existe {0} com o mesmo número de CPF/CNPJ cadastrado.", _NomeDominio);

            return true;
        }

        public void LimparListaNotificacao()
        {
            _notificador.LimparNotificacao();
        }
    }
}
