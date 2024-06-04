using AutoMapper;
using GestaoDePessoas.Dominio.PedidoRoot;
using GestaoDePessoas.Application.Notificacoes;
using GestaoDePessoas.Application.Services.Base;
using GestaoDePessoas.Application.ViewModels.Pedido;
using GestaoDePessoas.Dominio.PedidoRoot.Validation;
using GestaoDePessoas.Dominio.PedidoRoot.Repository;
using GestaoDePessoas.Application.Interfaces.Pedidos;
using GestaoDePessoas.Application.ViewModels.Categoria;
using GestaoDePessoas.Dominio.CategoriaRoot;

namespace GestaoDePessoas.Application.Services.Pedidos
{
    public class PedidoService : BaseCadastroService<Pedido,
        PedidoViewModel,
        PedidoAdicionarViewModel,
        PedidoAtualizarViewModel,
        PedidoValidation>,
        IPedidoService
    {

        private readonly IPedidoRepository _repository;

        public PedidoService(INotificador notificador,
                                    IPedidoRepository repository,
                                    IMapper mapper)
            : base("Pedido", notificador, repository, mapper)
        {
            _repository = repository;
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

        public virtual async Task<bool> Atualizar(PedidoAtualizarViewModel viewmodel)
        {
            if (!_repository.DominioExiste(viewmodel.ID))
            {
                Notificar("{0} não existe.", _NomeDominio);
                return false;
            }

            Pedido model = await _repository.ObterPorId(viewmodel.ID);

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

        public override bool ValidarAdicionarModel(Pedido model)
        {
            if (ValidaProdutoModel(model))
            {
                Notificar("ID do produto fornecido não encontrado na base de dados.", _NomeDominio);
                return false;
            }
            else if (_repository.EExisteCadastroPedidoStatus(model) == 0)
            {
                Notificar("ID do pedido status fornecido não encontrado na base de dados.", _NomeDominio);
                return false;
            }
            else if (_repository.EExisteCadastroCliente(model) == 0)
            {
                Notificar("ID do cliente fornecido não encontrado na base de dados.", _NomeDominio);
                return false;
            }
            else if (_repository.EExisteCadastroFormaPagamento(model) == 0)
            {
                Notificar("ID da forma de pagamento não encontrado na base de dados.", _NomeDominio);
                return false;
            }
            else return true;
        }

        public bool ValidaProdutoModel(Pedido model)
        {
            for (int i = 0; i < model.PedidoItens.Count; i++)
                if (_repository.EExisteCadastroProduto(model.PedidoItens[i].ProdutoID) == 0)
                    return true;

            return false;
        }

        public void LimparListaNotificacao()
        {
            _notificador.LimparNotificacao();
        }
    }
}
