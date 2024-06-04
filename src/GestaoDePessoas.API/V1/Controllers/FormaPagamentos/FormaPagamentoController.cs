using AutoMapper;
using GestaoDePessoas.Dominio;
using Microsoft.AspNetCore.Mvc;
using GestaoDePessoas.API.V1.Base;
using GestaoDePessoas.Application.Notificacoes;
using GestaoDePessoas.Dominio.FormaPagamentoRoot;
using GestaoDePessoas.Application.ViewModels.FormaPagamento;
using GestaoDePessoas.Dominio.FormaPagamentoRoot.Validation;
using GestaoDePessoas.Dominio.FormaPagamentoRoot.Repository;
using GestaoDePessoas.Application.Interfaces.FormaPagamentos;
using GestaoDePessoas.Dominio.ClienteRoot;
using GestaoDePessoas.Application.ViewModels.Cliente;

namespace GestaoDePessoas.API.V1.Controllers.FormaPagamentos
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/forma-pagamento")]
    [ApiController]
    public class FormaPagamentoController : BaseCadastroController<FormaPagamento,
        FormaPagamentoViewModel,
        FormaPagamentoAdicionarViewModel,
        FormaPagamentoAtualizarViewModel,
        FormaPagamentoValidation>
    {
        private readonly IFormaPagamentoService _appService;
        private readonly IFormaPagamentoRepository _repository;

        public FormaPagamentoController(INotificador notificador,
                                IMapper mapper,
                                IFormaPagamentoService appService,
                                IFormaPagamentoRepository repository)
       : base("formaPagamento", "FormaPagamento", notificador, mapper,
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
        /// Cadastra nova Forma de Pagamento.
        /// </summary>
        /// <param name="viewmodel">View Model de Forma de Pagamento.</param>
        /// <returns>Resultado da operação.</returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     POST /api/v1/forma-pagamento
        ///     {
        ///       "taxa": 2.5,
        ///       "nome": "Cartão de Crédito",
        ///       "descricao": "Forma de pagamento para pagamentos no cartão de crédito."
        ///     }
        ///     
        ///     taxa -> É opcional;
        ///     nome -> Deve ter no mínimo 1 e no máximo 250 caracteres (É obrigatório); 
        ///     descricao -> Deve ter no mínimo 1 e no máximo 250 caracteres (É opcional);
        ///    
        ///     A aplicação impõe uma restrição que permite o cadastro do nome da forma de pagamento uma única vez. 
        ///     
        ///     Isso garante a unicidade dos registros e impede duplicações no sistema.
        ///     
        /// </remarks>
        /// <response code="201">Novo registro de Forma de Pagamento criado.</response>
        /// <response code="400">Não foi possível criar o registro de Forma de Pagamento.</response>
        /// 
        [HttpPost]
        [ProducesResponseType(typeof(FormaPagamentoViewModel), 201)]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public async override Task<IActionResult> Post([FromBody] FormaPagamentoAdicionarViewModel viewmodel)
        {
            return await base.Post(viewmodel);
        }

        /// <summary>
        /// Atualiza registro Forma de Pagamento. 
        /// </summary>
        /// <param name="id">Id do registro.</param>
        /// <param name="viewmodel">View Model de Forma de Pagamento.</param>
        /// <returns></returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     PUT /api/v1/forma-pagamento/00000000-0000-0000-0000-000000000000
        ///     {
        ///       "id" : "00000000-0000-0000-0000-000000000000",
        ///       "ativo": true,
        ///       "taxa": 2.5,
        ///       "nome": "Cartão de Crédito",
        ///       "descricao": "Forma de pagamento para pagamentos no cartão de crédito."
        ///     }
        ///     
        ///     id -> É obrigatório;
        ///     taxa -> É opcional;
        ///     nome -> Deve ter no mínimo 1 e no máximo 250 caracteres (É obrigatório);
        ///     descricao -> Deve ter no mínimo 1 e no máximo 250 caracteres (É opcional);
        ///
        ///     Obs: O valor do campo "id" deve coincidir com o valor fornecido na consulta.
        ///     
        /// </remarks>
        /// <response code="200">Registro de Forma de Pagamento atualizado.</response>
        /// <response code="400">Não foi possível atualizar o registro de Forma de Pagamento.</response>
        /// 
        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(FormaPagamentoViewModel), 200)]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public async override Task<IActionResult> Put(Guid id, [FromBody] FormaPagamentoAtualizarViewModel viewmodel)
        {
            return await base.Put(id, viewmodel);
        }

        /// <summary>
        /// Exclui registro de Forma de Pagamento.
        /// </summary>
        /// <param name="id">Identificador (guid) do registro de Forma de Pagamento.</param>
        /// <returns></returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     DELETE /api/v1/forma-pagamento/00000000-0000-0000-0000-000000000000
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
            FormaPagamento model = _repository.Buscar(m => m.ID.Equals(id)).Result.FirstOrDefault();

            if (model == null)
                return NotFound();

            FormaPagamentoAtualizarViewModel viewmodel = new()
            {
                ID = model.ID,
                ATIVO = false,
                TAXA = model.TAXA
            };

            await _appService.Atualizar(viewmodel);

            if (!_notificador.TemNotificacao())
            {
                return CustomResponse(new { Mensagem = string.Format("{0} excluída com sucesso.", _NomeCompletoController) });
            }

            return CustomResponse();
        }

        /// <summary>
        /// Retorna Forma de Pagamento especifico por Id (guid).
        /// </summary>
        /// <param name="id">Identificador (guid) do registro de Forma de Pagamento.</param>
        /// <returns></returns>
        /// <response code="200">Registro de Forma de Pagamento correspondente ao Id.</response>
        /// <response code="400">Não foi possível localizar o registro de Forma de Pagamento.</response>
        ///
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(FormaPagamentoViewModel), 200)]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public async override Task<IActionResult> Get(Guid id)
        {
            return await base.Get(id);
        }

        /// <summary>
        /// Retorna lista paginada de Formas de Pagamentos.
        /// </summary>
        /// <returns></returns>
        /// <param name="nome">Nome.</param>
        /// <param name="descricao">Descrição.</param>
        /// <param name="pagina">Página da lista de item.</param>
        /// <param name="tamanhoPagina">Total de itens por página.</param>
        /// <param name="ordem">Ordenação: Id, Nome, Descricao, DataCadastro.</param>
        /// <response code="200">O recurso solicitado foi processado e retornado com sucesso.</response>
        ///
        [HttpGet]
        [ProducesResponseType(typeof(SucessRetorno<ListaPaginada<FormaPagamentoViewModel>>), 200)]
        public async Task<IActionResult> GetPorTodosOsFiltros([FromQuery] string nome,
            [FromQuery] string descricao,
            [FromQuery] bool? ativo,
            [FromQuery] int? pagina,
            [FromQuery] int? tamanhoPagina,
            [FromQuery] string ordem)
        {
            var models = await _repository.ObterPorTodosFiltros(nome, descricao, ativo, pagina, tamanhoPagina, ordem);

            ListaPaginada<FormaPagamentoViewModel> retorno = new ListaPaginada<FormaPagamentoViewModel>(
                _mapper.Map<List<FormaPagamentoViewModel>>(models.ListaRetorno),
                models.PaginaAtual,
                models.TotalPaginas,
                models.TamanhoPagina,
                models.TotalItens);

            return CustomResponse(retorno);
        }
    }
}
