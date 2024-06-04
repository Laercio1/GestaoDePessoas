//using AutoMapper;
//using GestaoDePessoas.Dominio;
//using Microsoft.AspNetCore.Mvc;
//using GestaoDePessoas.API.V1.Base;
//using GestaoDePessoas.Dominio.PedidoItemRoot;
//using GestaoDePessoas.Application.Notificacoes;
//using GestaoDePessoas.Application.ViewModels.PedidoItem;
//using GestaoDePessoas.Dominio.PedidoItemRoot.Repository;
//using GestaoDePessoas.Dominio.PedidoItemRoot.Validation;
//using GestaoDePessoas.Application.Interfaces.PedidoItens;

//namespace GestaoDePessoas.API.V1.Controllers.PedidoItens
//{
//    [ApiVersion("1.0")]
//    [Route("api/v{version:apiVersion}/pedido-item")]
//    [ApiController]
//    public class PedidoItemController : BaseCadastroController<PedidoItem,
//        PedidoItemViewModel,
//        PedidoItemAddViewModel,
//        PedidoItemAtualizarViewModel,
//        PedidoItemValidation>
//    {
//        private readonly IPedidoItemService _appService;
//        private readonly IPedidoItemRepository _repository;

//        public PedidoItemController(INotificador notificador,
//                                IMapper mapper,
//                                IPedidoItemService appService,
//                                IPedidoItemRepository repository)
//       : base("pedidoItem", "PedidoItem", notificador, mapper,
//             appService, repository)
//        {
//            _appService = appService;
//            _repository = repository;
//        }

//        protected override void Dispose(bool disposing)
//        {
//            _appService?.Dispose();
//            _repository?.Dispose();
//        }

//        /// <summary>
//        /// Cadastra novo Pedido Item.
//        /// </summary>
//        /// <param name="viewmodel">View Model de Pedido Item.</param>
//        /// <returns>Resultado da operação.</returns>
//        /// /// <remarks>
//        /// Exemplo de requisição
//        ///
//        ///     POST /api/v1/pedido-item
//        ///     {
//        ///       "idpedido": "00000000-0000-0000-0000-000000000000",
//        ///       "idproduto": "00000000-0000-0000-0000-000000000000",
//        ///       "quantidade": 1,
//        ///       "valorunitario": 59.75
//        ///     }
//        ///     
//        ///     idpedido -> É obrigatório;
//        ///     idproduto -> É obrigatório;   
//        ///     quantidade -> É obrigatório;   
//        ///     valorunitario -> É obrigatório;    
//        /// 
//        /// </remarks>
//        /// <response code="201">Novo registro de Pedido Item criado.</response>
//        /// <response code="400">Não foi possível criar o registro de Pedido Item.</response>
//        /// 
//        [HttpPost]
//        [ProducesResponseType(typeof(PedidoItemViewModel), 201)]
//        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
//        public async override Task<IActionResult> Post([FromBody] PedidoItemAddViewModel viewmodel)
//        {
//            return await base.Post(viewmodel);
//        }

//        /// <summary>
//        /// Atualiza registro Pedido Item. 
//        /// </summary>
//        /// <param name="id">Id do registro.</param>
//        /// <param name="viewmodel">View Model de Pedido Item.</param>
//        /// <returns></returns>
//        /// /// <remarks>
//        /// Exemplo de requisição
//        ///
//        ///     PUT /api/v1/pedido-item/00000000-0000-0000-0000-000000000000
//        ///     {
//        ///       "id" : "00000000-0000-0000-0000-000000000000",
//        ///       "idpedido": "00000000-0000-0000-0000-000000000000",
//        ///       "idproduto": "00000000-0000-0000-0000-000000000000",
//        ///       "quantidade": 1,
//        ///       "valorunitario": 59.75
//        ///     }
//        ///     
//        ///     id -> É obrigatório;
//        ///     idpedido -> É obrigatório;
//        ///     idproduto -> É obrigatório;   
//        ///     quantidade -> É obrigatório;   
//        ///     valorunitario -> É obrigatório;   
//        ///
//        ///     Obs: O valor do campo "id" deve coincidir com o valor fornecido na consulta.
//        /// </remarks>
//        /// <response code="200">Registro de Pedido Item atualizado.</response>
//        /// <response code="400">Não foi possível atualizar o registro de Pedido Item.</response>
//        /// 
//        [HttpPut("{id:guid}")]
//        [ProducesResponseType(typeof(PedidoItemViewModel), 200)]
//        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
//        public async override Task<IActionResult> Put(Guid id, [FromBody] PedidoItemAtualizarViewModel viewmodel)
//        {
//            return await base.Put(id, viewmodel);
//        }

//        /// <summary>
//        /// Exclui registro de Pedido Item.
//        /// </summary>
//        /// <param name="id">Identificador (guid) do registro de Pedido Item.</param>
//        /// <returns></returns>
//        /// /// <remarks>
//        /// Exemplo de requisição
//        ///
//        ///     DELETE /api/v1/pedido-item/00000000-0000-0000-0000-000000000000
//        ///     {
//        ///     }
//        ///
//        /// </remarks>
//        /// <response code="200">Registro excluído com sucesso.</response>
//        /// <response code="400">Não foi possível excluir o registro.</response>
//        ///
//        [HttpDelete("{id:guid}")]
//        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
//        public async override Task<IActionResult> Delete(Guid id)
//        {
//            return await base.Delete(id);
//        }

//        /// <summary>
//        /// Retorna Pedido Item especifico por Id (guid).
//        /// </summary>
//        /// <param name="id">Identificador (guid) do registro de Pedido Item.</param>
//        /// <returns></returns>
//        /// <response code="200">Registro de Pedido Item correspondente ao Id.</response>
//        /// <response code="400">Não foi possível localizar o registro de Pedido Item.</response>
//        ///
//        [HttpGet("{id:guid}")]
//        [ProducesResponseType(typeof(PedidoItemViewModel), 200)]
//        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
//        public async override Task<IActionResult> Get(Guid id)
//        {
//            return await base.Get(id);
//        }
//    }
//}
