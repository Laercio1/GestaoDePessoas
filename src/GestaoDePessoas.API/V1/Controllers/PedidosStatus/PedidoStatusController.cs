using AutoMapper;
using GestaoDePessoas.Dominio;
using Microsoft.AspNetCore.Mvc;
using GestaoDePessoas.API.V1.Base;
using GestaoDePessoas.Application.Notificacoes;
using GestaoDePessoas.Dominio.PedidoStatusRoot;
using GestaoDePessoas.Application.ViewModels.PedidoStatus;
using GestaoDePessoas.Dominio.PedidoStatusRoot.Validation;
using GestaoDePessoas.Dominio.PedidoStatusRoot.Repository;
using GestaoDePessoas.Application.Interfaces.PedidosStatus;

namespace GestaoDePessoas.API.V1.Controllers.PedidosStatus
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/pedido-status")]
    [ApiController]
    public class PedidoStatusController : BaseCadastroController<PedidoStatus,
        PedidoStatusViewModel,
        PedidoStatusAdicionarViewModel,
        PedidoStatusAtualizarViewModel,
        PedidoStatusValidation>
    {
        private readonly IPedidoStatusService _appService;
        private readonly IPedidoStatusRepository _repository;

        public PedidoStatusController(INotificador notificador,
                                IMapper mapper,
                                IPedidoStatusService appService,
                                IPedidoStatusRepository repository)
       : base("pedidoStatus", "PedidoStatus", notificador, mapper,
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
        /// Cadastra novo Pedido Status.
        /// </summary>
        /// <param name="viewmodel">View Model de Pedido Status.</param>
        /// <returns>Resultado da operação.</returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     POST /api/v1/pedido-status
        ///     {
        ///       "cancelado": true,
        ///       "finalizado": true,
        ///       "descricao": "Aguardando"
        ///     }
        ///     
        ///     cancelado -> É opcional;
        ///     finalizado -> É opcional; 
        ///     descricao -> Deve ter no mínimo 1 e no máximo 250 caracteres (É obrigatório);
        ///    
        ///     A aplicação impõe uma restrição que permite o cadastro da descrição do pedido status uma única vez. 
        ///     
        ///     Isso garante a unicidade dos registros e impede duplicações no sistema.
        ///     
        /// </remarks>
        /// <response code="201">Novo registro de Pedido Status criado.</response>
        /// <response code="400">Não foi possível criar o registro de Pedido Status.</response>
        /// 
        [HttpPost]
        [ProducesResponseType(typeof(PedidoStatusViewModel), 201)]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public async override Task<IActionResult> Post([FromBody] PedidoStatusAdicionarViewModel viewmodel)
        {
            return await base.Post(viewmodel);
        }

        /// <summary>
        /// Atualiza registro Pedido Status. 
        /// </summary>
        /// <param name="id">Id do registro.</param>
        /// <param name="viewmodel">View Model de Pedido Status.</param>
        /// <returns></returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     PUT /api/v1/pedido-status/00000000-0000-0000-0000-000000000000
        ///     {
        ///       "id" : "00000000-0000-0000-0000-000000000000",
        ///       "ativo": true,
        ///       "cancelado": true,
        ///       "finalizado": true,
        ///       "descricao": "Aguardando"
        ///     }
        ///     
        ///     id -> É obrigatório;
        ///     cancelado -> É opcional;
        ///     finalizado -> É opcional;
        ///     descricao -> Deve ter no mínimo 1 e no máximo 250 caracteres (É obrigatório);
        ///
        ///     Obs: O valor do campo "id" deve coincidir com o valor fornecido na consulta.
        ///     
        /// </remarks>
        /// <response code="200">Registro de Pedido Status atualizado.</response>
        /// <response code="400">Não foi possível atualizar o registro de Pedido Status.</response>
        /// 
        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(PedidoStatusViewModel), 200)]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public async override Task<IActionResult> Put(Guid id, [FromBody] PedidoStatusAtualizarViewModel viewmodel)
        {
            return await base.Put(id, viewmodel);
        }

        /// <summary>
        /// Exclui registro de Pedido Status.
        /// </summary>
        /// <param name="id">Identificador (guid) do registro de Pedido Status.</param>
        /// <returns></returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     DELETE /api/v1/pedido-status/00000000-0000-0000-0000-000000000000
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
        /// Retorna Pedido Status especifico por Id (guid).
        /// </summary>
        /// <param name="id">Identificador (guid) do registro de Pedido Status.</param>
        /// <returns></returns>
        /// <response code="200">Registro de Pedido Status correspondente ao Id.</response>
        /// <response code="400">Não foi possível localizar o registro de Pedido Status.</response>
        ///
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(PedidoStatusViewModel), 200)]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public async override Task<IActionResult> Get(Guid id)
        {
            return await base.Get(id);
        }

        /// <summary>
        /// Retorna lista paginada de Pedido Status.
        /// </summary>
        /// <returns></returns>
        /// <param name="descricao">Descrição.</param>
        /// <param name="pagina">Página da lista de item.</param>
        /// <param name="tamanhoPagina">Total de itens por página.</param>
        /// <param name="ordem">Ordenação: Id, Descricao, DataCadastro.</param>
        /// <response code="200">O recurso solicitado foi processado e retornado com sucesso.</response>
        ///
        [HttpGet]
        [ProducesResponseType(typeof(SucessRetorno<ListaPaginada<PedidoStatusViewModel>>), 200)]
        public async Task<IActionResult> GetPorTodosOsFiltros([FromQuery] string descricao,
            [FromQuery] bool? ativo,
            [FromQuery] int? pagina,
            [FromQuery] int? tamanhoPagina,
            [FromQuery] string ordem)
        {
            var models = await _repository.ObterPorTodosFiltros(descricao, ativo, pagina, tamanhoPagina, ordem);

            ListaPaginada<PedidoStatusViewModel> retorno = new ListaPaginada<PedidoStatusViewModel>(
                _mapper.Map<List<PedidoStatusViewModel>>(models.ListaRetorno),
                models.PaginaAtual,
                models.TotalPaginas,
                models.TamanhoPagina,
                models.TotalItens);

            return CustomResponse(retorno);
        }
    }
}
