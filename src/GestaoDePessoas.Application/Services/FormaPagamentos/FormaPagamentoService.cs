using AutoMapper;
using GestaoDePessoas.Application.Notificacoes;
using GestaoDePessoas.Application.Services.Base;
using GestaoDePessoas.Dominio.FormaPagamentoRoot;
using GestaoDePessoas.Application.ViewModels.FormaPagamento;
using GestaoDePessoas.Dominio.FormaPagamentoRoot.Validation;
using GestaoDePessoas.Dominio.FormaPagamentoRoot.Repository;
using GestaoDePessoas.Application.Interfaces.FormaPagamentos;
using GestaoDePessoas.Application.ViewModels.Categoria;
using GestaoDePessoas.Dominio.CategoriaRoot;

namespace GestaoDePessoas.Application.Services.FormaPagamentos
{
    public class FormaPagamentoService : BaseCadastroService<FormaPagamento,
        FormaPagamentoViewModel,
        FormaPagamentoAdicionarViewModel,
        FormaPagamentoAtualizarViewModel,
        FormaPagamentoValidation>,
        IFormaPagamentoService
    {

        private readonly IFormaPagamentoRepository _repository;

        public FormaPagamentoService(INotificador notificador,
                                    IFormaPagamentoRepository repository,
                                    IMapper mapper)
            : base("FormaPagamento", notificador, repository, mapper)
        {
            _repository = repository;
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

        public virtual async Task<bool> Atualizar(FormaPagamentoAtualizarViewModel viewmodel)
        {
            if (!_repository.DominioExiste(viewmodel.ID))
            {
                Notificar("{0} não existe.", _NomeDominio);
                return false;
            }

            FormaPagamento model = await _repository.ObterPorId(viewmodel.ID);

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

        public override bool ValidarAdicionarModel(FormaPagamento model)
        {
            if (_repository.EExisteCadastroMesmoNome(model) > 0)
            {
                Notificar("Já existe uma {0} com o mesmo nome cadastrada.", _NomeDominio);
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
