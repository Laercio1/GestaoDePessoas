using AutoMapper;
using GestaoDePessoas.API.V1.Base;
using GestaoDePessoas.Application.Interfaces.Categorias;
using GestaoDePessoas.Application.Notificacoes;
using GestaoDePessoas.Application.ViewModels.Categoria;
using GestaoDePessoas.Dominio;
using GestaoDePessoas.Dominio.CategoriaRoot;
using GestaoDePessoas.Dominio.CategoriaRoot.Repository;
using GestaoDePessoas.Dominio.CategoriaRoot.Validation;
using GestaoDePessoas.Dominio.ClienteRoot;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDePessoas.API.V1.Controllers.Categorias
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/categoria")]
    [ApiController]
    public class CategoriaController : BaseCadastroController<Categoria,
        CategoriaViewModel,
        CategoriaAdicionarViewModel,
        CategoriaAtualizarViewModel,
        CategoriaValidation>
    {
        private readonly ICategoriaService _appService;
        private readonly ICategoriaRepository _repository;

        public CategoriaController(INotificador notificador,
                                IMapper mapper,
                                ICategoriaService appService,
                                ICategoriaRepository repository)
       : base("categoria", "Categoria", notificador, mapper,
             appService, repository)
        {
            _appService = appService;
            _repository = repository;
        }

        protected override void Dispose(bool disposing)
        {
            _appService?.Dispose();
            _repository?.Dispose();
        }

        /// <summary>
        /// Cadastra nova Categoria.
        /// </summary>
        /// <param name="viewmodel">View Model de Categoria.</param>
        /// <returns>Resultado da operação.</returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     POST /api/v1/categoria
        ///     {
        ///       "nome": "Doces"
        ///     }
        ///     
        ///     nome -> Deve ter no mínimo 1 e no máximo 250 caracteres (É obrigatório);   
        ///    
        ///     A aplicação impõe uma restrição que permite o cadastro do nome da categoria uma única vez. 
        ///     
        ///     Isso garante a unicidade dos registros e impede duplicações no sistema.
        ///     
        /// </remarks>
        /// <response code="201">Novo registro de Categoria criado.</response>
        /// <response code="400">Não foi possível criar o registro de Categoria.</response>
        /// 
        [HttpPost]
        [ProducesResponseType(typeof(CategoriaViewModel), 201)]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public async override Task<IActionResult> Post([FromBody] CategoriaAdicionarViewModel viewmodel)
        {
            return await base.Post(viewmodel);
        }

        /// <summary>
        /// Atualiza registro Categoria. 
        /// </summary>
        /// <param name="id">Id do registro.</param>
        /// <param name="viewmodel">View Model de Categoria.</param>
        /// <returns></returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     PUT /api/v1/categoria/00000000-0000-0000-0000-000000000000
        ///     {
        ///       "id" : "00000000-0000-0000-0000-000000000000",
        ///       "ativo": true,
        ///       "nome": "Doces"
        ///     }
        ///     
        ///     id -> É obrigatório;
        ///     nome -> Deve ter no mínimo 1 e no máximo 250 caracteres (É obrigatório);
        ///
        ///     Obs: O valor do campo "id" deve coincidir com o valor fornecido na consulta.
        ///     
        /// </remarks>
        /// <response code="200">Registro de Categoria atualizado.</response>
        /// <response code="400">Não foi possível atualizar o registro de Categoria.</response>
        /// 
        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(CategoriaViewModel), 200)]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public async override Task<IActionResult> Put(Guid id, [FromBody] CategoriaAtualizarViewModel viewmodel)
        {
            return await base.Put(id, viewmodel);
        }

        /// <summary>
        /// Exclui registro de Categoria.
        /// </summary>
        /// <param name="id">Identificador (guid) do registro de Categoria.</param>
        /// <returns></returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     DELETE /api/v1/categoria/00000000-0000-0000-0000-000000000000
        ///     {
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Registro excluído com sucesso.</response>
        /// <response code="400">Não foi possível excluir o registro.</response>
        ///
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public async override Task<IActionResult> Delete(Guid id)
        {
            Categoria model = _repository.Buscar(m => m.ID.Equals(id)).Result.FirstOrDefault();

            if (model == null)
                return NotFound();

            CategoriaAtualizarViewModel viewmodel = new()
            {
                ID = id,
                ATIVO = false
            };

            await _appService.Atualizar(viewmodel);


            if (!_notificador.TemNotificacao())
            {
                return CustomResponse(new { Mensagem = string.Format("{0} excluído com sucesso.", _NomeCompletoController) });
            }

            return CustomResponse();
        }

        /// <summary>
        /// Retorna Categoria especifico por Id (guid).
        /// </summary>
        /// <param name="id">Identificador (guid) do registro de Categoria.</param>
        /// <returns></returns>
        /// <response code="200">Registro de Categoria correspondente ao Id.</response>
        /// <response code="400">Não foi possível localizar o registro de Categoria.</response>
        ///
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(CategoriaViewModel), 200)]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public async override Task<IActionResult> Get(Guid id)
        {
            return await base.Get(id);
        }

        /// <summary>
        /// Retorna lista paginada de Categorias.
        /// </summary>
        /// <returns></returns>
        /// <param name="nome">Nome.</param>
        /// <param name="pagina">Página da lista de item.</param>
        /// <param name="tamanhoPagina">Total de itens por página.</param>
        /// <param name="ordem">Ordenação: Id, Nome, DataCadastro.</param>
        /// <response code="200">O recurso solicitado foi processado e retornado com sucesso.</response>
        ///
        [HttpGet]
        [ProducesResponseType(typeof(SucessRetorno<ListaPaginada<CategoriaViewModel>>), 200)]
        public async Task<IActionResult> GetPorTodosOsFiltros([FromQuery] string nome,
            [FromQuery] bool? ativo,
            [FromQuery] int? pagina,
            [FromQuery] int? tamanhoPagina,
            [FromQuery] string ordem)
        {
            var models = await _repository.ObterPorTodosFiltros(nome, ativo, pagina, tamanhoPagina, ordem);

            ListaPaginada<CategoriaViewModel> retorno = new ListaPaginada<CategoriaViewModel>(
                _mapper.Map<List<CategoriaViewModel>>(models.ListaRetorno),
                models.PaginaAtual,
                models.TotalPaginas,
                models.TamanhoPagina,
                models.TotalItens);

            return CustomResponse(retorno);
        }
    }
}
