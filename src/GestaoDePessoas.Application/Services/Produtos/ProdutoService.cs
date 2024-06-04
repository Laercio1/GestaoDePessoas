using AutoMapper;
using GestaoDePessoas.Dominio.ProdutoRoot;
using GestaoDePessoas.Application.Notificacoes;
using GestaoDePessoas.Application.Services.Base;
using GestaoDePessoas.Application.ViewModels.Produto;
using GestaoDePessoas.Dominio.ProdutoRoot.Validation;
using GestaoDePessoas.Dominio.ProdutoRoot.Repository;
using GestaoDePessoas.Application.Interfaces.Produtos;
using GestaoDePessoas.Application.ViewModels.Pedido;
using GestaoDePessoas.Dominio.PedidoRoot;

namespace GestaoDePessoas.Application.Services.Produtos
{
    public class ProdutoService : BaseCadastroService<Produto,
        ProdutoViewModel,
        ProdutoAdicionarViewModel,
        ProdutoAtualizarViewModel,
        ProdutoValidation>,
        IProdutoService
    {

        private readonly IProdutoRepository _repository;

        public ProdutoService(INotificador notificador,
                                    IProdutoRepository repository,
                                    IMapper mapper)
            : base("Produto", notificador, repository, mapper)
        {
            _repository = repository;
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

        public virtual async Task<bool> Atualizar(ProdutoAtualizarViewModel viewmodel)
        {
            if (!_repository.DominioExiste(viewmodel.ID))
            {
                Notificar("{0} não existe.", _NomeDominio);
                return false;
            }

            Produto model = await _repository.ObterPorId(viewmodel.ID);

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

        public override bool ValidarAdicionarModel(Produto model)
        {
            if (_repository.EExisteCadastroMesmoNOME(model) > 0)
            {
                Notificar("Já existe um {0} com o mesmo nome cadastrado.", _NomeDominio);
                return false;
            }
            else if (_repository.EExisteCadastroMarca(model) == 0)
            {
                Notificar("ID da marca fornecida não encontrado na base de dados.", _NomeDominio);
                return false;
            }
            else if (_repository.EExisteCadastroCategoria(model) == 0)
            {
                Notificar("ID da categoria fornecida não encontrado na base de dados.", _NomeDominio);
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
