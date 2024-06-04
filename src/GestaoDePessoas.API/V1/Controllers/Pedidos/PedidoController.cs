using AutoMapper;
using GestaoDePessoas.Dominio;
using Microsoft.AspNetCore.Mvc;
using GestaoDePessoas.API.V1.Base;
using GestaoDePessoas.Dominio.PedidoRoot;
using GestaoDePessoas.Application.Notificacoes;
using GestaoDePessoas.Application.ViewModels.Pedido;
using GestaoDePessoas.Dominio.PedidoRoot.Repository;
using GestaoDePessoas.Dominio.PedidoRoot.Validation;
using GestaoDePessoas.Application.Interfaces.Pedidos;

namespace GestaoDePessoas.API.V1.Controllers.Pedidos
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/pedido")]
    [ApiController]
    public class PedidoController : BaseCadastroController<Pedido,
        PedidoViewModel,
        PedidoAdicionarViewModel,
        PedidoAtualizarViewModel,
        PedidoValidation>
    {
        private readonly IPedidoService _appService;
        private readonly IPedidoRepository _repository;

        public PedidoController(INotificador notificador,
                                IMapper mapper,
                                IPedidoService appService,
                                IPedidoRepository repository)
       : base("pedido", "Pedido", notificador, mapper,
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
        /// Cadastra novo Pedido.
        /// </summary>
        /// <param name="viewmodel">View Model de Pedido.</param>
        /// <returns>Resultado da operação.</returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     POST /api/v1/pedido
        ///     {
        ///       "desconto": 19.99,
        ///       "clienteID": "00000000-0000-0000-0000-000000000000",
        ///       "formaPagamentoID": "00000000-0000-0000-0000-000000000000",
        ///       "pedidoStatusID": "00000000-0000-0000-0000-000000000000",
        ///       "valortotal": 59.75,
        ///       "valorfinal": 39.76,
        ///       "numeropedido": 157486,
        ///       "quantidadeitens": 3,
        ///       "pedidoItens": [
        ///         {
        ///             "produtoID": "00000000-0000-0000-0000-000000000000",
        ///             "quantidade": 3
        ///         }
        ///       ]
        ///     }
        ///     
        ///     desconto -> É obrigatório;
        ///     clienteID -> É obrigatório;
        ///     formaPagamentoID -> É obrigatório;
        ///     pedidoStatusID -> É obrigatório;
        ///     valortotal -> É obrigatório;
        ///     valorfinal -> É obrigatório;
        ///     numeropedido -> É obrigatório;
        ///     quantidadeitens -> É obrigatório;
        ///     
        ///     pedidoItens -> produtoID -> É obrigatório;   
        ///                    quantidade -> É obrigatório;   
        ///     
        /// 
        /// </remarks>
        /// <response code="201">Novo registro de Pedido criado.</response>
        /// <response code="400">Não foi possível criar o registro de Pedido.</response>
        /// 
        [HttpPost]
        [ProducesResponseType(typeof(PedidoViewModel), 201)]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public async override Task<IActionResult> Post([FromBody] PedidoAdicionarViewModel viewmodel)
        {
            return await base.Post(viewmodel);
        }

        /// <summary>
        /// Atualiza registro Pedido. 
        /// </summary>
        /// <param name="id">Id do registro.</param>
        /// <param name="viewmodel">View Model de Pedido.</param>
        /// <returns></returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     PUT /api/v1/pedido/00000000-0000-0000-0000-000000000000
        ///     {
        ///       "id" : "00000000-0000-0000-0000-000000000000",
        ///       "desconto": 19.99,
        ///       "clienteID": "00000000-0000-0000-0000-000000000000",
        ///       "formaPagamentoID": "00000000-0000-0000-0000-000000000000",
        ///       "pedidoStatusID": "00000000-0000-0000-0000-000000000000",
        ///       "valortotal": 59.75,
        ///       "valorfinal": 39.76,
        ///       "numeropedido": 157486,
        ///       "quantidadeitens": 3
        ///     }
        ///     
        ///     id -> É obrigatório;
        ///     desconto -> É obrigatório;
        ///     clienteID -> É obrigatório;
        ///     formaPagamentoID -> É obrigatório;
        ///     pedidoStatusID -> É obrigatório;
        ///     valortotal -> É obrigatório;
        ///     valorfinal -> É obrigatório;
        ///     numeropedido -> É obrigatório;
        ///     quantidadeitens -> É obrigatório;  
        ///
        ///     Obs: O valor do campo "id" deve coincidir com o valor fornecido na consulta.
        /// </remarks>
        /// <response code="200">Registro de Pedido atualizado.</response>
        /// <response code="400">Não foi possível atualizar o registro de Pedido.</response>
        /// 
        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(PedidoViewModel), 200)]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public async override Task<IActionResult> Put(Guid id, [FromBody] PedidoAtualizarViewModel viewmodel)
        {
            return await base.Put(id, viewmodel);
        }

        /// <summary>
        /// Exclui registro de Pedido.
        /// </summary>
        /// <param name="id">Identificador (guid) do registro de Pedido.</param>
        /// <returns></returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     DELETE /api/v1/pedido/00000000-0000-0000-0000-000000000000
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
            Pedido model = _repository.Buscar(m => m.ID.Equals(id)).Result.FirstOrDefault();

            if (model == null)
                return NotFound();

            PedidoAtualizarViewModel viewmodel = new()
            {
                ID = model.ID,
                ATIVO = false,
                DESCONTO = model.DESCONTO,
                VALORTOTAL = model.VALORTOTAL,
                VALORFINAL = model.VALORFINAL,
                NUMEROPEDIDO = model.NUMEROPEDIDO,
                QUANTIDADEITENS = model.QUANTIDADEITENS,
                ClienteID = model.ClienteID,
                FormaPagamentoID = model.FormaPagamentoID,
                PedidoStatusID = model.PedidoStatusID
            };

            await _appService.Atualizar(viewmodel);

            if (!_notificador.TemNotificacao())
            {
                return CustomResponse(new { Mensagem = string.Format("{0} excluído com sucesso.", _NomeCompletoController) });
            }

            return CustomResponse();
        }

        /// <summary>
        /// Retorna Pedido especifico por Id (guid).
        /// </summary>
        /// <param name="id">Identificador (guid) do registro de Pedido.</param>
        /// <returns></returns>
        /// <response code="200">Registro de Pedido correspondente ao Id.</response>
        /// <response code="400">Não foi possível localizar o registro de Pedido.</response>
        ///
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(PedidoViewModel), 200)]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public async override Task<IActionResult> Get(Guid id)
        {
            var models = await _repository.ObterPorId(id);

            var retorno = _mapper.Map<PedidoViewModel>(models);

            return CustomResponse(retorno);
        }

        /// <summary>
        /// Retorna lista paginada de Pedidos.
        /// </summary>
        /// <returns></returns>
        /// <param name="numero">Número do Pedido.</param>
        /// <param name="pagina">Página da lista de item.</param>
        /// <param name="tamanhoPagina">Total de itens por página.</param>
        /// <param name="ordem">Ordenação: Id, NumeroPedido, DataCadastro.</param>
        /// <response code="200">O recurso solicitado foi processado e retornado com sucesso.</response>
        ///
        [HttpGet]
        [ProducesResponseType(typeof(SucessRetorno<ListaPaginada<PedidoViewModel>>), 200)]
        public async Task<IActionResult> GetPorTodosOsFiltros([FromQuery] Guid? idCliente, [FromQuery] Guid? idFormaPagamento,
            [FromQuery] Guid? idPedidoStatus,
            [FromQuery] string numero,
            [FromQuery] bool? ativo,
            [FromQuery] int? pagina,
            [FromQuery] int? tamanhoPagina,
            [FromQuery] string ordem)
        {
            var models = await _repository.ObterPorTodosFiltros(idCliente, idFormaPagamento, idPedidoStatus, numero, ativo, pagina, tamanhoPagina, ordem);

            ListaPaginada<PedidoViewModel> retorno = new ListaPaginada<PedidoViewModel>(
                _mapper.Map<List<PedidoViewModel>>(models.ListaRetorno),
                models.PaginaAtual,
                models.TotalPaginas,
                models.TamanhoPagina,
                models.TotalItens);

            return CustomResponse(retorno);
        }
    }
}
