using AutoMapper;
using GestaoDePessoas.Dominio.PedidoStatusRoot;
using GestaoDePessoas.Application.Notificacoes;
using GestaoDePessoas.Application.Services.Base;
using GestaoDePessoas.Application.ViewModels.PedidoStatus;
using GestaoDePessoas.Dominio.PedidoStatusRoot.Validation;
using GestaoDePessoas.Dominio.PedidoStatusRoot.Repository;
using GestaoDePessoas.Application.Interfaces.PedidosStatus;

namespace GestaoDePessoas.Application.Services.PedidosStatus
{
    public class PedidoStatusService : BaseCadastroService<PedidoStatus,
        PedidoStatusViewModel,
        PedidoStatusAdicionarViewModel,
        PedidoStatusAtualizarViewModel,
        PedidoStatusValidation>,
        IPedidoStatusService
    {

        private readonly IPedidoStatusRepository _repository;

        public PedidoStatusService(INotificador notificador,
                                    IPedidoStatusRepository repository,
                                    IMapper mapper)
            : base("PedidoStatus", notificador, repository, mapper)
        {
            _repository = repository;
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

        public virtual async Task<bool> Atualizar(PedidoStatusAtualizarViewModel viewmodel)
        {
            if (!_repository.DominioExiste(viewmodel.ID))
            {
                Notificar("{0} não existe.", _NomeDominio);
                return false;
            }

            PedidoStatus model = await _repository.ObterPorId(viewmodel.ID);

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

        public override bool ValidarAdicionarModel(PedidoStatus model)
        {
            if (_repository.EExisteCadastroMesmaDescricao(model) > 0)
            {
                Notificar("Já existe uma {0} com a mesma descrição cadastrado.", _NomeDominio);
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
