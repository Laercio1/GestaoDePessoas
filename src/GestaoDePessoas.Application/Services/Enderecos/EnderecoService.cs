using AutoMapper;
using GestaoDePessoas.Dominio.EnderecoRoot;
using GestaoDePessoas.Application.Notificacoes;
using GestaoDePessoas.Application.Services.Base;
using GestaoDePessoas.Application.ViewModels.Endereco;
using GestaoDePessoas.Dominio.EnderecoRoot.Validation;
using GestaoDePessoas.Dominio.EnderecoRoot.Repository;
using GestaoDePessoas.Application.Interfaces.Enderecos;

namespace GestaoDePessoas.Application.Services.Enderecos
{
    public class EnderecoService : BaseCadastroService<Endereco,
        EnderecoViewModel,
        EnderecoAdicionarViewModel,
        EnderecoAtualizarViewModel,
        EnderecoValidation>,
        IEnderecoService
    {

        private readonly IEnderecoRepository _repository;

        public EnderecoService(INotificador notificador,
                                    IEnderecoRepository repository,
                                    IMapper mapper)
            : base("Endereco", notificador, repository, mapper)
        {
            _repository = repository;
        }

        public virtual async Task<bool> Adicionar(Endereco model)
        {
            if (!ValidarModel(model))
                return false;

            if (!ValidarAdicionarModel(model))
                return false;

            try
            {
                await _repository.Adicionar(model);
            }
            catch (Exception ex)
            {
                Notificar("Não é possível adicionar {0}. Motivo: {1}.", _NomeDominio, ex.InnerException.Message);
                return false;
            }

            return true;
        }

        public virtual async Task<bool> Atualizar(EnderecoAtualizarViewModel viewmodel)
        {
            if (!_repository.DominioExiste(viewmodel.ID))
            {
                Notificar("{0} não existe.", _NomeDominio);
                return false;
            }

            Endereco model = await _repository.ObterPorId(viewmodel.ID);

            bool temAtualizacao = MapearAtualizacoes(model, viewmodel);

            if (!temAtualizacao)
            {
                Notificar("Não há alterações no registro de {0}.", _NomeDominio);
                return false;
            }

            if (!ValidarModel(model))
                return false;

            try
            {
                await _repository.Atualizar(model);
                return true;
            }
            catch (Exception ex)
            {
                Notificar("Não foi possível atualizar o registro de {0}. Motivo: {1}", _NomeDominio, ex.InnerException);
                return false;
            }
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

        public void LimparListaNotificacao()
        {
            _notificador.LimparNotificacao();
        }
    }
}
