using AutoMapper;
using GestaoDePessoas.Dominio.PedidoItemRoot;
using GestaoDePessoas.Application.Notificacoes;
using GestaoDePessoas.Application.Services.Base;
using GestaoDePessoas.Application.ViewModels.PedidoItem;
using GestaoDePessoas.Dominio.PedidoItemRoot.Validation;
using GestaoDePessoas.Dominio.PedidoItemRoot.Repository;
using GestaoDePessoas.Application.Interfaces.PedidoItens;

namespace GestaoDePessoas.Application.Services.PedidoItens
{
    public class PedidoItemService : BaseCadastroService<PedidoItem,
        PedidoItemViewModel,
        PedidoItemAddViewModel,
        PedidoItemAtualizarViewModel,
        PedidoItemValidation>,
        IPedidoItemService
    {

        private readonly IPedidoItemRepository _repository;

        public PedidoItemService(INotificador notificador,
                                    IPedidoItemRepository repository,
                                    IMapper mapper)
            : base("PedidoItem", notificador, repository, mapper)
        {
            _repository = repository;
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

        public override bool ValidarAdicionarModel(PedidoItem model)
        {
            if (_repository.EExisteCadastroPedido(model) == 0)
            {
                Notificar("ID do pedido fornecido não encontrado na base de dados.", _NomeDominio);
                return false;
            }
            else if (_repository.EExisteCadastroProduto(model) == 0)
            {
                Notificar("ID do produto fornecido não encontrado na base de dados.", _NomeDominio);
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
