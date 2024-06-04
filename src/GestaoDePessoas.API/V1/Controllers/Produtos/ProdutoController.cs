using AutoMapper;
using GestaoDePessoas.Dominio;
using Microsoft.AspNetCore.Mvc;
using GestaoDePessoas.API.V1.Base;
using GestaoDePessoas.Dominio.ProdutoRoot;
using GestaoDePessoas.Application.Notificacoes;
using GestaoDePessoas.Application.ViewModels.Produto;
using GestaoDePessoas.Dominio.ProdutoRoot.Validation;
using GestaoDePessoas.Dominio.ProdutoRoot.Repository;
using GestaoDePessoas.Application.Interfaces.Produtos;

namespace GestaoDePessoas.API.V1.Controllers.Produtos
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/produto")]
    [ApiController]
    public class ProdutoController : BaseCadastroController<Produto,
        ProdutoViewModel,
        ProdutoAdicionarViewModel,
        ProdutoAtualizarViewModel,
        ProdutoValidation>
    {
        private readonly IProdutoService _appService;
        private readonly IProdutoRepository _repository;

        public ProdutoController(INotificador notificador,
                                IMapper mapper,
                                IProdutoService appService,
                                IProdutoRepository repository)
       : base("produto", "Produto", notificador, mapper,
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
        /// Cadastra novo Produto.
        /// </summary>
        /// <param name="viewmodel">View Model de Produto.</param>
        /// <returns>Resultado da operação.</returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     POST /api/v1/produto
        ///     {
        ///       "marcaID": "00000000-0000-0000-0000-000000000000",
        ///       "categoriaID": "00000000-0000-0000-0000-000000000000",
        ///       "precoUnitario": 15.99,
        ///       "unidade": "UN",
        ///       "cbarra": "1774",
        ///       "nome": "Bolo de brigadeiro"
        ///     }
        ///     
        ///     marcaID -> É obrigatório;
        ///     categoriaID -> É obrigatório;
        ///     precoUnitario -> É obrigatório;
        ///     unidade -> Deve ter no mínimo 1 e no máximo 10 caracteres (É obrigatório);
        ///     cbarra -> Deve ter no mínimo 1 e no máximo 50 caracteres (É obrigatório);
        ///     nome -> Deve ter no mínimo 1 e no máximo 250 caracteres (É obrigatório);   
        ///     
        ///     A aplicação impõe uma restrição que permite o cadastro do nome do produto uma única vez. 
        ///     
        ///     Isso garante a unicidade dos registros e impede duplicações no sistema.
        ///     
        /// </remarks>
        /// <response code="201">Novo registro de Produto criado.</response>
        /// <response code="400">Não foi possível criar o registro de Produto.</response>
        /// 
        [HttpPost]
        [ProducesResponseType(typeof(ProdutoViewModel), 201)]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public async override Task<IActionResult> Post([FromBody] ProdutoAdicionarViewModel viewmodel)
        {
            return await base.Post(viewmodel);
        }

        /// <summary>
        /// Atualiza registro Produto. 
        /// </summary>
        /// <param name="id">Id do registro.</param>
        /// <param name="viewmodel">View Model de Produto.</param>
        /// <returns></returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     PUT /api/v1/produto/00000000-0000-0000-0000-000000000000
        ///     {
        ///       "id" : "00000000-0000-0000-0000-000000000000",
        ///       "marcaID": "00000000-0000-0000-0000-000000000000",
        ///       "categoriaID": "00000000-0000-0000-0000-000000000000",
        ///       "precoUnitario": 15.99,
        ///       "cbarra": "1774",
        ///       "unidade": "UN",
        ///       "nome": "Bolo de brigadeiro"
        ///     }
        ///     
        ///     id -> É obrigatório;
        ///     marcaID -> É obrigatório;
        ///     categoriaID -> É obrigatório;
        ///     precoUnitario -> É obrigatório;
        ///     cbarra -> Deve ter no mínimo 1 e no máximo 50 caracteres (É obrigatório);
        ///     unidade -> Deve ter no mínimo 1 e no máximo 10 caracteres (É obrigatório);
        ///     nome -> Deve ter no mínimo 1 e no máximo 250 caracteres (É obrigatório);   
        ///
        ///     Obs: O valor do campo "id" deve coincidir com o valor fornecido na consulta.
        ///     
        /// </remarks>
        /// <response code="200">Registro de Produto atualizado.</response>
        /// <response code="400">Não foi possível atualizar o registro de Produto.</response>
        /// 
        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(ProdutoViewModel), 200)]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public async override Task<IActionResult> Put(Guid id, [FromBody] ProdutoAtualizarViewModel viewmodel)
        {
            return await base.Put(id, viewmodel);
        }

        /// <summary>
        /// Exclui registro de Produto.
        /// </summary>
        /// <param name="id">Identificador (guid) do registro de Produto.</param>
        /// <returns></returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     DELETE /api/v1/produto/00000000-0000-0000-0000-000000000000
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
            return await base.Delete(id);
        }

        /// <summary>
        /// Retorna Produto especifico por Id (guid).
        /// </summary>
        /// <param name="id">Identificador (guid) do registro de Produto.</param>
        /// <returns></returns>
        /// <response code="200">Registro de Produto correspondente ao Id.</response>
        /// <response code="400">Não foi possível localizar o registro de Produto.</response>
        ///
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ProdutoViewModel), 200)]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public async override Task<IActionResult> Get(Guid id)
        {
            var models = await _repository.ObterPorId(id);

            var retorno = _mapper.Map<ProdutoViewModel>(models);

            return CustomResponse(retorno);
        }

        /// <summary>
        /// Retorna lista paginada de Produtos.
        /// </summary>
        /// <returns></returns>
        /// <param name="nome">Nome.</param>
        /// <param name="idMarca">Id Marca.</param>
        /// <param name="idCategoria">Id Categoria.</param>
        /// <param name="cbarra">Código de barra.</param>
        /// <param name="unidade">Unidade.</param>
        /// <param name="pagina">Página da lista de item.</param>
        /// <param name="tamanhoPagina">Total de itens por página.</param>
        /// <param name="ordem">Ordenação: Id, Nome, Marca, Cbarra, Unidade, DataCadastro.</param>
        /// <response code="200">O recurso solicitado foi processado e retornado com sucesso.</response>
        ///
        [HttpGet]
        [ProducesResponseType(typeof(SucessRetorno<ListaPaginada<ProdutoViewModel>>), 200)]
        public async Task<IActionResult> GetPorTodosOsFiltros([FromQuery] string nome, [FromQuery] Guid? idMarca,
            [FromQuery] Guid? idCategoria,
            [FromQuery] string cbarra,
            [FromQuery] string unidade,
            [FromQuery] bool? ativo,
            [FromQuery] int? pagina,
            [FromQuery] int? tamanhoPagina,
            [FromQuery] string ordem)
        {
            var models = await _repository.ObterPorTodosFiltros(nome, idMarca, idCategoria, cbarra, unidade, ativo, pagina, tamanhoPagina, ordem);

            ListaPaginada<ProdutoViewModel> retorno = new ListaPaginada<ProdutoViewModel>(
                _mapper.Map<List<ProdutoViewModel>>(models.ListaRetorno),
                models.PaginaAtual,
                models.TotalPaginas,
                models.TamanhoPagina,
                models.TotalItens);

            return CustomResponse(retorno);
        }
    }
}
