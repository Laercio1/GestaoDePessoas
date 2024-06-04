using AutoMapper;
using GestaoDePessoas.Dominio.ContatoRoot;
using GestaoDePessoas.Application.Notificacoes;
using GestaoDePessoas.Application.Services.Base;
using GestaoDePessoas.Application.ViewModels.Contato;
using GestaoDePessoas.Dominio.ContatoRoot.Validation;
using GestaoDePessoas.Dominio.ContatoRoot.Repository;
using GestaoDePessoas.Application.Interfaces.Contatos;

namespace GestaoDePessoas.Application.Services.Contatos
{
    public class ContatoService : BaseCadastroService<Contato,
        ContatoViewModel,
        ContatoAdicionarViewModel,
        ContatoAtualizarViewModel,
        ContatoValidation>,
        IContatoService
    {

        private readonly IContatoRepository _repository;

        public ContatoService(INotificador notificador,
                                    IContatoRepository repository,
                                    IMapper mapper)
            : base("Contato", notificador, repository, mapper)
        {
            _repository = repository;
        }

        public virtual async Task<bool> Adicionar(Contato model)
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

        public virtual async Task<bool> Atualizar(ContatoAtualizarViewModel viewmodel)
        {
            if (!_repository.DominioExiste(viewmodel.ID))
            {
                Notificar("{0} não existe.", _NomeDominio);
                return false;
            }

            Contato model = await _repository.ObterPorId(viewmodel.ID);

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
