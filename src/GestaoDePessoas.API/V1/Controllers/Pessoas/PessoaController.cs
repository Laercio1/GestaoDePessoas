using AutoMapper;
using GestaoDePessoas.API.V1.Base;
using GestaoDePessoas.Application.ViewModels.Pessoa;
using GestaoDePessoas.Dominio;
using Microsoft.AspNetCore.Mvc;
using GestaoDePessoas.Application.Notificacoes;
using GestaoDePessoas.Dominio.PessoaRoot;
using GestaoDePessoas.Dominio.PessoaRoot.Repository;
using GestaoDePessoas.Dominio.PessoaRoot.Validation;
using GestaoDePessoas.Application.Interfaces.Pessoas;

namespace GestaoDePessoas.API.V1.Controllers.Pessoas
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
        /// Cadastra nova Pessoa.
        /// </summary>
        /// <param name="viewmodel">View Model de Pessoa.</param>
        /// <returns>Resultado da operação.</returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     POST /api/v1/pessoa
        ///     {
        ///       "nomeCompleto": "Nome da pessoa",
        ///       "cnpJ_CPF": "00.000.000/0001-19",
        ///       "email": "gestaodepessoas@gmail.com",
        ///       "telefone": "6399999-5555",
        ///       "cep": "77800-000",
        ///       "estado": "TO",
        ///       "cidade": "Araguaína",
        ///       "bairro": "Centro",
        ///       "numero": "1234",
        ///       "logradouro": "Avenida"
        ///     }
        ///     
        ///     nomeCompleto -> Deve ter no mínimo 1 e no máximo 250 caracteres (É obrigatório);
        ///     cnpJ_CPF -> Deve ter no mínimo 11 e no máximo 18 caracteres (É obrigatório);
        ///     email -> É obrigatório;
        ///     telefone -> Deve ter no máximo 12 caracteres (É opcional);
        ///     cep -> Deve ter no mínimo 8 e no máximo 9 caracteres (É obrigatório);
        ///     estado -> Deve ter no mínimo 1 e no máximo 50 caracteres (É obrigatório);
        ///     cidade -> Deve ter no mínimo 1 e no máximo 100 caracteres (É obrigatório);
        ///     bairro -> Deve ter no mínimo 1 e no máximo 150 caracteres (É obrigatório);
        ///     numero -> Deve ter no máximo 50 caracteres (É opcional);
        ///     logradouro -> Deve ter no mínimo 1 e no máximo 150 caracteres (É obrigatório);    
        ///    
        ///     A aplicação impõe uma restrição que permite o cadastro de um número de CPF ou CNPJ uma única vez. 
        ///     Isso garante a unicidade dos registros e impede duplicações no sistema.
        ///     Obs: Certifique-se de inserir um número de CPF ou CNPJ válido e único para cada registro.
        /// </remarks>
        /// <response code="201">Novo registro de Pessoa criado.</response>
        /// <response code="400">Não foi possível criar o registro de Pessoa.</response>
        /// 
        [HttpPost]
        [ProducesResponseType(typeof(PessoaViewModel), 201)]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public async override Task<IActionResult> Post([FromBody] PessoaAdicionarViewModel viewmodel)
        {
            return await base.Post(viewmodel);
        }

        /// <summary>
        /// Atualiza registro Pessoa. 
        /// </summary>
        /// <param name="id">Id do registro.</param>
        /// <param name="viewmodel">View Model de Pessoa.</param>
        /// <returns></returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     PUT /api/v1/pessoa/00000000-0000-0000-0000-000000000000
        ///     {
        ///       "id" : "00000000-0000-0000-0000-000000000000",
        ///       "nomeCompleto": "Nome da pessoa",
        ///       "cnpJ_CPF": "00.000.000/0001-19",
        ///       "email": "gestaodepessoas@gmail.com",
        ///       "telefone": "6399999-5555",
        ///       "cep": "77800-000",
        ///       "estado": "TO",
        ///       "cidade": "Araguaína",
        ///       "bairro": "Centro",
        ///       "numero": "1234",
        ///       "logradouro": "Avenida",
        ///       "ativo": true
        ///     }
        ///     
        ///     id -> É obrigatório;
        ///     nomeCompleto -> Deve ter no mínimo 1 e no máximo 250 caracteres (É obrigatório);
        ///     cnpJ_CPF -> Deve ter no mínimo 11 e no máximo 18 caracteres (É obrigatório);
        ///     email -> É obrigatório;
        ///     telefone -> Deve ter no máximo 12 caracteres (É opcional);
        ///     cep -> Deve ter no mínimo 8 e no máximo 9 caracteres (É obrigatório);
        ///     estado -> Deve ter no mínimo 1 e no máximo 50 caracteres (É obrigatório);
        ///     cidade -> Deve ter no mínimo 1 e no máximo 100 caracteres (É obrigatório);
        ///     bairro -> Deve ter no mínimo 1 e no máximo 150 caracteres (É obrigatório);
        ///     numero -> Deve ter no máximo 50 caracteres (É opcional);
        ///     logradouro -> Deve ter no mínimo 1 e no máximo 150 caracteres (É obrigatório);
        ///
        ///     Obs: O valor do campo "id" deve coincidir com o valor fornecido na consulta.
        /// </remarks>
        /// <response code="200">Registro de Pessoa atualizado.</response>
        /// <response code="400">Não foi possível atualizar o registro de Pessoa.</response>
        /// 
        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(PessoaViewModel), 200)]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public async override Task<IActionResult> Put(Guid id, [FromBody] PessoaAtualizarViewModel viewmodel)
        {
            return await base.Put(id, viewmodel);
        }

        /// <summary>
        /// Exclui registro de Pessoa.
        /// </summary>
        /// <param name="id">Identificador (guid) do registro de Pessoa.</param>
        /// <returns></returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     DELETE /api/v1/pessoa/00000000-0000-0000-0000-000000000000
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
        /// Retorna Pessoa especifico por Id (guid).
        /// </summary>
        /// <param name="id">Identificador (guid) do registro de Pessoa.</param>
        /// <returns></returns>
        /// <response code="200">Registro de Pessoa correspondente ao Id.</response>
        /// <response code="400">Não foi possível localizar o registro de Pessoa.</response>
        ///
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(PessoaViewModel), 200)]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public async override Task<IActionResult> Get(Guid id)
        {
            return await base.Get(id);
        }

        /// <summary>
        /// Retorna lista paginada de Pessoas.
        /// </summary>
        /// <returns></returns>
        /// <param name="nomeCompleto">Nome Completo.</param>
        /// <param name="cnpJ_CPF">CPF ou CNPJ.</param>
        /// <param name="logradouro">Logradouro.</param>
        /// <param name="bairro">Bairro.</param>
        /// <param name="ativo">Status do registro Ativo ou Desativado.</param>
        /// <param name="pagina">Página da lista de item.</param>
        /// <param name="tamanhoPagina">Total de itens por página.</param>
        /// <param name="ordem">Ordenação: Id, NomeCompleto, CNPJ_CPF, Logradouro, Bairro, DataCadastro.</param>
        /// <response code="200">O recurso solicitado foi processado e retornado com sucesso.</response>
        ///
        [HttpGet]
        [ProducesResponseType(typeof(SucessRetorno<ListaPaginada<PessoaViewModel>>), 200)]
        public async Task<IActionResult> GetPorTodosOsFiltros([FromQuery] string nomeCompleto, [FromQuery] string cnpJ_CPF,
            [FromQuery] string logradouro,
            [FromQuery] string bairro,
            [FromQuery] bool? ativo,
            [FromQuery] int? pagina,
            [FromQuery] int? tamanhoPagina,
            [FromQuery] string ordem)
        {
            var models = await _repository.ObterPorTodosFiltros(nomeCompleto, cnpJ_CPF, logradouro, bairro,
                ativo, pagina, tamanhoPagina, ordem);

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
