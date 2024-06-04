using AutoMapper;
using GestaoDePessoas.Dominio.CategoriaRoot;
using GestaoDePessoas.Application.Notificacoes;
using GestaoDePessoas.Application.Services.Base;
using GestaoDePessoas.Application.ViewModels.Categoria;
using GestaoDePessoas.Dominio.CategoriaRoot.Validation;
using GestaoDePessoas.Dominio.CategoriaRoot.Repository;
using GestaoDePessoas.Application.Interfaces.Categorias;
using GestaoDePessoas.Application.ViewModels.Contato;
using GestaoDePessoas.Dominio.ContatoRoot;

namespace GestaoDePessoas.Application.Services.Categorias
{
    public class CategoriaService : BaseCadastroService<Categoria,
        CategoriaViewModel,
        CategoriaAdicionarViewModel,
        CategoriaAtualizarViewModel,
        CategoriaValidation>,
        ICategoriaService
    {

        private readonly ICategoriaRepository _repository;

        public CategoriaService(INotificador notificador,
                                    ICategoriaRepository repository,
                                    IMapper mapper)
            : base("Categoria", notificador, repository, mapper)
        {
            _repository = repository;
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

        public virtual async Task<bool> Atualizar(CategoriaAtualizarViewModel viewmodel)
        {
            if (!_repository.DominioExiste(viewmodel.ID))
            {
                Notificar("{0} não existe.", _NomeDominio);
                return false;
            }

            Categoria model = await _repository.ObterPorId(viewmodel.ID);

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

        public override bool ValidarAdicionarModel(Categoria model)
        {
            if (_repository.EExisteCadastroMesmoNOME(model) > 0)
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
