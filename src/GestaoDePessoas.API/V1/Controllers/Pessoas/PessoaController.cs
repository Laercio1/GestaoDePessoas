using AutoMapper;
using GestaoDePessoas.API.V1.Base;
using GestaoDePessoas.Application.ViewModels.Pessoa;
using GestaoDePessoas.Dominio;
using Microsoft.AspNetCore.Mvc;
using GestaoDePessoas.Application.Interfaces.Produtos;
using GestaoDePessoas.Application.Notificacoes;
using GestaoDePessoas.Application.ViewModels.Produto;
using GestaoDePessoas.Dominio.PessoaRoot;
using GestaoDePessoas.Dominio.PessoaRoot.Repository;
using GestaoDePessoas.Dominio.PessoaRoot.Validation;

namespace GestaoDePessoas.API.V1.Controllers.Numeros
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/pessoa")]
    [ApiController]
    public class PessoaController : BaseCadastroController<Pessoa,
        PessoaViewModel,
        PessoaAdicionarViewModel,
        PessoaAtualizarViewModel,
        PessoaValidation>
    {
        private readonly IPessoaService _appService;
        private readonly IPessoaRepository _repository;

        public PessoaController(INotificador notificador,
                                        IMapper mapper,
                                        IPessoaService appService,
                                        IPessoaRepository repository)
               : base("pessoa", "Pessoa", notificador, mapper,
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
        /// Cadastra nova Pessoa
        /// </summary>
        /// <param name="viewmodel">Dto para o post</param>
        /// <returns></returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     POST /api/v1/pessoa
        ///     {
        ///       "nomeCompleto": "string",
        ///       "cnpJ_CPF": "string",
        ///       "email": "string",
        ///       "telefone": "string",
        ///       "cep": "string",
        ///       "estado": "string",
        ///       "cidade": "string",
        ///       "bairro": "string",
        ///       "numero": "string",
        ///       "logradouro": "string",
        ///       "ativo": true
        ///     }
        ///     
        ///     nomeCompleto -> Deve ter no mínimo 5 e no máximo 250 caracteres (É obrigatório);
        ///     cnpJ_CPF -> Deve ter no mínimo 11 e no máximo 14 caracteres (É obrigatório);
        ///     email -> É obrigatório;
        ///     telefone -> Deve ter no máximo 12 caracteres (É opcional);
        ///     cep -> É obrigatório;
        ///     estado -> Deve ter no mínimo 3 e no máximo 50 caracteres (É obrigatório);
        ///     cidade -> Deve ter no mínimo 3 e no máximo 100 caracteres (É obrigatório);
        ///     bairro -> Deve ter no mínimo 3 e no máximo 150 caracteres (É obrigatório);
        ///     logradouro -> Deve ter no mínimo 3 e no máximo 150 caracteres (É obrigatório);    
        ///    
        ///     A aplicação impõe uma restrição que permite o cadastro de um número de CPF ou CNPJ uma única vez. Isso garante a unicidade dos registros e impede duplicações no sistema.
        ///     Obs: Certifique-se de inserir um número de CPF ou CNPJ válido e único para cada registro.
        /// </remarks>
        /// <response code="200">Cadastro realizado com sucesso.</response>
        /// <response code="400">Não foi possível realizar o cadastro com sucesso.</response>
        /// 
        [HttpPost]
        [ProducesResponseType(typeof(PessoaViewModel), 200)]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public async override Task<IActionResult> Post([FromBody] PessoaAdicionarViewModel viewmodel)
        {
            return await base.Post(viewmodel);
        }

        /// <summary>
        /// Atualiza o registro de Pessoa
        /// </summary>
        /// <param name="viewmodel">Dto para o put</param>
        /// <returns></returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     PUT /api/v1/pessoa
        ///     {
        ///       "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///       "nomeCompleto": "string",
        ///       "cnpJ_CPF": "string",
        ///       "email": "string",
        ///       "telefone": "string",
        ///       "cep": "string",
        ///       "estado": "string",
        ///       "cidade": "string",
        ///       "bairro": "string",
        ///       "numero": "string",
        ///       "logradouro": "string",
        ///       "ativo": true
        ///     }
        ///     
        ///     id -> É obrigatório;
        ///     nomeCompleto -> Deve ter no mínimo 5 e no máximo 250 caracteres (É obrigatório);
        ///     cnpJ_CPF -> Deve ter no mínimo 11 e no máximo 14 caracteres (É obrigatório);
        ///     email -> É obrigatório;
        ///     telefone -> Deve ter no máximo 12 caracteres (É opcional);
        ///     cep -> É obrigatório;
        ///     estado -> Deve ter no mínimo 3 e no máximo 50 caracteres (É obrigatório);
        ///     cidade -> Deve ter no mínimo 3 e no máximo 100 caracteres (É obrigatório);
        ///     bairro -> Deve ter no mínimo 3 e no máximo 150 caracteres (É obrigatório);
        ///     logradouro -> Deve ter no mínimo 3 e no máximo 150 caracteres (É obrigatório);
        ///
        ///     Obs: O valor do campo "id" deve coincidir com o valor fornecido na consulta.
        /// </remarks>
        /// <response code="200">Alteração realizada com sucesso.</response>
        /// <response code="400">Não foi possível realizar a alteração com sucesso.</response>
        /// 
        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(PessoaViewModel), 200)]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public async override Task<IActionResult> Put(Guid id, [FromBody] PessoaAtualizarViewModel viewmodel)
        {
            return await base.Put(id, viewmodel);
        }

        /// <summary>
        /// Remove o registro de Pessoa
        /// </summary>
        /// <returns></returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     DEL /api/v1/pessoa/00000000-0000-0000-0000-000000000000
        ///     {
        ///     }
        ///     
        ///     Campos obrigatórios: id.
        ///
        /// </remarks>
        /// <response code="200">O recurso solicitado foi processado e retornado com sucesso.</response>
        /// <response code="400">Bad Request - Não foi possível interpretar a requisição. Verifique a sintaxe das informações enviadas</response>
        ///
        [HttpDelete("{id:guid}")]
        public async override Task<IActionResult> Delete(Guid id)
        {
            return await base.Delete(id);
        }

        /// <summary>
        /// Retorna registro de Pessoa por Id (guid)
        /// </summary>
        /// <returns></returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     GET /api/v1/pessoa/00000000-0000-0000-0000-000000000000
        ///     {
        ///     }
        ///     
        ///     Campos obrigatórios: id.
        ///
        /// </remarks>
        /// <response code="200">O recurso solicitado foi processado e retornado com sucesso.</response>
        /// <response code="400">Bad Request - Não foi possível interpretar a requisição. Verifique a sintaxe das informações enviadas</response>
        ///
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(PessoaViewModel), 200)]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public async override Task<IActionResult> Get(Guid id)
        {
            return await base.Get(id);
        }

        /// <summary>
        /// Retorna lista paginada de Pessoas
        /// </summary>
        /// <returns></returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     GET /api/v1/pessoa
        ///     {
        ///     }    
        ///
        ///     Filtro de Consulta:
        ///     É possível realizar consultas de registros de pessoas com base nos seguintes campos: Nome Completo, CPF/CNPJ, Logradouro e Bairro.
        /// 
        /// </remarks>
        /// <param name="ativo">Status do registro Ativo ou Desativado.</param>
        /// <param name="pagina">Página da lista de item.</param>
        /// <param name="tamanhoPagina">Total de itens por página.</param>
        /// <param name="filtro">Filtro de acordo com os campos disponíveis.</param>
        /// <response code="200">O recurso solicitado foi processado e retornado com sucesso.</response>
        /// <response code="400">Bad Request - Não foi possível interpretar a requisição. Verifique a sintaxe das informações enviadas</response>
        ///
        [HttpGet]
        [ProducesResponseType(typeof(SucessRetorno<ListaPaginada<PessoaViewModel>>), 200)]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public async Task<IActionResult> GetPorTodosOsFiltros([FromQuery] bool? ativo,
            [FromQuery] int? pagina,
            [FromQuery] int? tamanhoPagina,
            [FromQuery] string filtro)
        {
            var models = await _repository.ObterPorTodosFiltros(ativo, pagina, tamanhoPagina, filtro);

            ListaPaginada<PessoaViewModel> retorno = new ListaPaginada<PessoaViewModel>(
                _mapper.Map<List<PessoaViewModel>>(models.ListaRetorno),
                models.PaginaAtual,
                models.TotalPaginas,
                models.TamanhoPagina,
                models.TotalItens);

            return CustomResponse(retorno);
        }
    }
}
