using AutoMapper;
using GestaoDePessoas.Application.Services.Base;
using GestaoDePessoas.Application.ViewModels.Pessoa;
using GestaoDePessoas.Application.Notificacoes;
using GestaoDePessoas.Dominio.PessoaRoot.Repository;
using GestaoDePessoas.Dominio.PessoaRoot.Validation;
using GestaoDePessoas.Dominio.PessoaRoot;
using GestaoDePessoas.Dominio.Core.Utils.StringUtils;
using GestaoDePessoas.Application.Interfaces.Pessoas;

namespace GestaoDePessoas.Application.Services.Pessoas
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
            if (!StringUtils.ValidaCNPJouCPF(model.CNPJ_CPF))
            {
                Notificar("O CNPJ/CPF da {0} informado é inválido.", _NomeDominio);
                return false;
            }
            else if (_repository.EExisteCadastroMesmoCPFCNPJ(model) > 0)
            {
                Notificar("Já existe uma {0} com o mesmo número de CPF/CNPJ cadastrado.", _NomeDominio);
                return false;
            }
            else return true;
        }

        public void LimparListaNotificacao()
        {
            _notificador.LimparNotificacao();
        }
    }
}
