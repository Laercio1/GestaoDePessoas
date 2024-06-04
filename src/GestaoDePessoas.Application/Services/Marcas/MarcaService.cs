using AutoMapper;
using GestaoDePessoas.Dominio.MarcaRoot;
using GestaoDePessoas.Application.Notificacoes;
using GestaoDePessoas.Application.Services.Base;
using GestaoDePessoas.Dominio.MarcaRoot.Validation;
using GestaoDePessoas.Dominio.MarcaRoot.Repository;
using GestaoDePessoas.Application.ViewModels.Marca;
using GestaoDePessoas.Application.Interfaces.Marcas;
using GestaoDePessoas.Application.ViewModels.FormaPagamento;
using GestaoDePessoas.Dominio.FormaPagamentoRoot;

namespace GestaoDePessoas.Application.Services.Marcas
{
    public class MarcaService : BaseCadastroService<Marca,
        MarcaViewModel,
        MarcaAdicionarViewModel,
        MarcaAtualizarViewModel,
        MarcaValidation>,
        IMarcaService
    {

        private readonly IMarcaRepository _repository;

        public MarcaService(INotificador notificador,
                                    IMarcaRepository repository,
                                    IMapper mapper)
            : base("Marca", notificador, repository, mapper)
        {
            _repository = repository;
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

        public virtual async Task<bool> Atualizar(MarcaAtualizarViewModel viewmodel)
        {
            if (!_repository.DominioExiste(viewmodel.ID))
            {
                Notificar("{0} não existe.", _NomeDominio);
                return false;
            }

            Marca model = await _repository.ObterPorId(viewmodel.ID);

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

        public override bool ValidarAdicionarModel(Marca model)
        {
            if (_repository.EExisteCadastroMesmoNOME(model) > 0)
            {
                Notificar("Já existe uma {0} com o mesmo nome cadastrado.", _NomeDominio);
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
