using AutoMapper;
using GestaoDePessoas.Dominio;
using Microsoft.AspNetCore.Mvc;
using GestaoDePessoas.API.V1.Base;
using GestaoDePessoas.Dominio.MarcaRoot;
using GestaoDePessoas.Application.Notificacoes;
using GestaoDePessoas.Application.ViewModels.Marca;
using GestaoDePessoas.Dominio.MarcaRoot.Validation;
using GestaoDePessoas.Dominio.MarcaRoot.Repository;
using GestaoDePessoas.Application.Interfaces.Marcas;
using GestaoDePessoas.Application.ViewModels.Cliente;
using GestaoDePessoas.Dominio.ClienteRoot;

namespace GestaoDePessoas.API.V1.Controllers.Marcas
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/marca")]
    [ApiController]
    public class MarcaController : BaseCadastroController<Marca,
        MarcaViewModel,
        MarcaAdicionarViewModel,
        MarcaAtualizarViewModel,
        MarcaValidation>
    {
        private readonly IMarcaService _appService;
        private readonly IMarcaRepository _repository;

        public MarcaController(INotificador notificador,
                                IMapper mapper,
                                IMarcaService appService,
                                IMarcaRepository repository)
       : base("marca", "Marca", notificador, mapper,
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
        /// Cadastra nova Marca.
        /// </summary>
        /// <param name="viewmodel">View Model de Marca.</param>
        /// <returns>Resultado da operação.</returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     POST /api/v1/marca
        ///     {
        ///       "nome": "Louis Vuitton"
        ///     }
        ///     
        ///     nome -> Deve ter no mínimo 1 e no máximo 250 caracteres (É obrigatório);   
        ///    
        ///     A aplicação impõe uma restrição que permite o cadastro do nome da marca uma única vez. 
        ///     Isso garante a unicidade dos registros e impede duplicações no sistema.
        /// </remarks>
        /// <response code="201">Novo registro de Marca criado.</response>
        /// <response code="400">Não foi possível criar o registro de Marca.</response>
        /// 
        [HttpPost]
        [ProducesResponseType(typeof(MarcaViewModel), 201)]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public async override Task<IActionResult> Post([FromBody] MarcaAdicionarViewModel viewmodel)
        {
            return await base.Post(viewmodel);
        }

        /// <summary>
        /// Atualiza registro Marca. 
        /// </summary>
        /// <param name="id">Id do registro.</param>
        /// <param name="viewmodel">View Model de Marca.</param>
        /// <returns></returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     PUT /api/v1/marca/00000000-0000-0000-0000-000000000000
        ///     {
        ///       "id" : "00000000-0000-0000-0000-000000000000",
        ///       "ativo": true,
        ///       "nome": "Louis Vuitton"
        ///     }
        ///     
        ///     id -> É obrigatório;
        ///     nome -> Deve ter no mínimo 1 e no máximo 250 caracteres (É obrigatório);
        ///
        ///     Obs: O valor do campo "id" deve coincidir com o valor fornecido na consulta.
        /// </remarks>
        /// <response code="200">Registro de Marca atualizado.</response>
        /// <response code="400">Não foi possível atualizar o registro de Marca.</response>
        /// 
        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(MarcaViewModel), 200)]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public async override Task<IActionResult> Put(Guid id, [FromBody] MarcaAtualizarViewModel viewmodel)
        {
            return await base.Put(id, viewmodel);
        }

        /// <summary>
        /// Exclui registro de Marca.
        /// </summary>
        /// <param name="id">Identificador (guid) do registro de Marca.</param>
        /// <returns></returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     DELETE /api/v1/marca/00000000-0000-0000-0000-000000000000
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
            Marca model = _repository.Buscar(m => m.ID.Equals(id)).Result.FirstOrDefault();

            if (model == null)
                return NotFound();

            MarcaAtualizarViewModel viewmodel = new()
            {
                ID = model.ID,
                ATIVO = false
            };

            await _appService.Atualizar(viewmodel);

            if (!_notificador.TemNotificacao())
            {
                return CustomResponse(new { Mensagem = string.Format("{0} excluída com sucesso.", _NomeCompletoController) });
            }

            return CustomResponse();
        }

        /// <summary>
        /// Retorna Marca especifico por Id (guid).
        /// </summary>
        /// <param name="id">Identificador (guid) do registro de Marca.</param>
        /// <returns></returns>
        /// <response code="200">Registro de Marca correspondente ao Id.</response>
        /// <response code="400">Não foi possível localizar o registro de Marca.</response>
        ///
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(MarcaViewModel), 200)]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public async override Task<IActionResult> Get(Guid id)
        {
            return await base.Get(id);
        }

        /// <summary>
        /// Retorna lista paginada de Marcas.
        /// </summary>
        /// <returns></returns>
        /// <param name="nome">Nome.</param>
        /// <param name="pagina">Página da lista de item.</param>
        /// <param name="tamanhoPagina">Total de itens por página.</param>
        /// <param name="ordem">Ordenação: Id, Nome, DataCadastro.</param>
        /// <response code="200">O recurso solicitado foi processado e retornado com sucesso.</response>
        ///
        [HttpGet]
        [ProducesResponseType(typeof(SucessRetorno<ListaPaginada<MarcaViewModel>>), 200)]
        public async Task<IActionResult> GetPorTodosOsFiltros([FromQuery] string nome,
            [FromQuery] bool? ativo,
            [FromQuery] int? pagina,
            [FromQuery] int? tamanhoPagina,
            [FromQuery] string ordem)
        {
            var models = await _repository.ObterPorTodosFiltros(nome, ativo, pagina, tamanhoPagina, ordem);

            ListaPaginada<MarcaViewModel> retorno = new ListaPaginada<MarcaViewModel>(
                _mapper.Map<List<MarcaViewModel>>(models.ListaRetorno),
                models.PaginaAtual,
                models.TotalPaginas,
                models.TamanhoPagina,
                models.TotalItens);

            return CustomResponse(retorno);
        }
    }
}
