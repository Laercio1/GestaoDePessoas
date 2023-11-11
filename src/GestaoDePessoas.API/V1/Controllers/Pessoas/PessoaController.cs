using AutoMapper;
using GestaoDePessoas.API.V1.Base;
using GestaoDePessoas.Application.ViewModels.Pessoa;
using GestaoDePessoas.Dominio;
using Microsoft.AspNetCore.Mvc;
using GestaoDePessoas.Application.Notificacoes;
using GestaoDePessoas.Dominio.PessoaRoot;
using GestaoDePessoas.Dominio.PessoaRoot.Repository;
using GestaoDePessoas.Dominio.PessoaRoot.Validation;
using GestaoDePessoas.Dominio.Core.Utils.StringUtils;
using GestaoDePessoas.Application.Interfaces.Pessoas;

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
        ///       "nomeCompleto": "Nome da pessoa",
        ///       "cnpJ_CPF": "00.000.000/0001-19",
        ///       "email": "gestaodepessoas@gmail.com",
        ///       "telefone": "6399999-5555",
        ///       "cep": "77800-000",
        ///       "estado": "Tocantins",
        ///       "cidade": "Araguaína",
        ///       "bairro": "Centro",
        ///       "numero": "1234",
        ///       "logradouro": "Avenida"
        ///     }
        ///     
        ///     nomeCompleto -> Deve ter no mínimo 1 e no máximo 250 caracteres (É obrigatório);
        ///     cnpJ_CPF -> Deve ter no mínimo 11 e no máximo 14 caracteres (É obrigatório);
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
        /// <response code="201">O recurso solicitado foi processado e retornado com sucesso.</response>
        /// <response code="400">Bad Request - Não foi possível interpretar a requisição. Verifique a sintaxe das informações enviadas</response>
        /// 
        [HttpPost]
        [ProducesResponseType(typeof(PessoaViewModel), 201)]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public async override Task<IActionResult> Post([FromBody] PessoaAdicionarViewModel viewmodel)
        {
            viewmodel = await EValidoPessoaViewModel(viewmodel);

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
        ///     PUT /api/v1/pessoa/00000000-0000-0000-0000-000000000000
        ///     {
        ///       "nomeCompleto": "Nome da pessoa",
        ///       "cnpJ_CPF": "00.000.000/0001-19",
        ///       "email": "gestaodepessoas@gmail.com",
        ///       "telefone": "6399999-5555",
        ///       "cep": "77800-000",
        ///       "estado": "Tocantins",
        ///       "cidade": "Araguaína",
        ///       "bairro": "Centro",
        ///       "numero": "1234",
        ///       "logradouro": "Avenida",
        ///       "ativo": true
        ///     }
        ///     
        ///     id -> É obrigatório;
        ///     nomeCompleto -> Deve ter no mínimo 1 e no máximo 250 caracteres (É obrigatório);
        ///     cnpJ_CPF -> Deve ter no mínimo 11 e no máximo 14 caracteres (É obrigatório);
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
        /// <response code="200">O recurso solicitado foi processado e retornado com sucesso.</response>
        /// <response code="400">Bad Request - Não foi possível interpretar a requisição. Verifique a sintaxe das informações enviadas</response>
        /// 
        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(PessoaViewModel), 200)]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public async override Task<IActionResult> Put(Guid id, [FromBody] PessoaAtualizarViewModel viewmodel)
        {
            viewmodel = await EValidoPessoaViewModel(viewmodel);

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
        ///     id -> É obrigatório;
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
        ///     id -> É obrigatório;
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
        ///     ativo -> É opcional;
        ///     pagina -> Deve ser informado apenas valor númerico (É opcional);
        ///     tamanhoPagina -> Deve ser informado apenas valor númerico (É opcional);
        ///     filtro -> É opcional;
        ///
        ///     Filtro de Consulta:
        ///     Realize consultas precisas de registros de pessoas por meio de diversos campos. 
        ///     Utilize o Nome Completo, CPF/CNPJ, Logradouro e Bairro para refinar sua busca e obter informações específicas.
        ///
        ///     Exemplos de uso:
        ///     - Consultar por Nome Completo: "João Vicente"
        ///     - Consultar por CPF/CNPJ: "474.978.470-23" ou "02.514.450/0001-28"
        ///     - Consultar por Logradouro: "Rua Principal"
        ///     - Consultar por Bairro: "Centro"
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

        private async Task<TViewModel> EValidoPessoaViewModel<TViewModel>(TViewModel viewmodel) where TViewModel : class
        {
            var cnpjCpfProperty = viewmodel.GetType().GetProperty("CNPJ_CPF");
            if (cnpjCpfProperty != null)
            {
                var cnpjCpf = (string)cnpjCpfProperty.GetValue(viewmodel, null);

                if (!string.IsNullOrEmpty(cnpjCpf))
                    cnpjCpfProperty.SetValue(viewmodel, StringUtils.ApenasNumeros(cnpjCpf));
            }
            return viewmodel;
        }
    }
}
