using AutoMapper;
using GestaoDePessoas.Dominio;
using Microsoft.AspNetCore.Mvc;
using GestaoDePessoas.API.V1.Base;
using GestaoDePessoas.Dominio.ClienteRoot;
using GestaoDePessoas.Dominio.EnderecoRoot;
using GestaoDePessoas.Application.Notificacoes;
using GestaoDePessoas.Application.ViewModels.Cliente;
using GestaoDePessoas.Dominio.ClienteRoot.Repository;
using GestaoDePessoas.Dominio.ClienteRoot.Validation;
using GestaoDePessoas.Application.Interfaces.Clientes;
using GestaoDePessoas.Application.ViewModels.Endereco;
using GestaoDePessoas.Dominio.EnderecoRoot.Repository;
using GestaoDePessoas.Application.Interfaces.Enderecos;
using GestaoDePessoas.Dominio.ContatoRoot.Repository;
using GestaoDePessoas.Application.Interfaces.Contatos;
using GestaoDePessoas.Application.ViewModels.Contato;
using GestaoDePessoas.Dominio.ContatoRoot;

namespace GestaoDePessoas.API.V1.Controllers.Clientes
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/cliente")]
    [ApiController]
    public class ClienteController : BaseCadastroController<Cliente,
        ClienteViewModel,
        ClienteAdicionarViewModel,
        ClienteAtualizarViewModel,
        ClienteValidation>
    {
        private readonly IClienteService _appService;
        private readonly IClienteRepository _repository;

        private readonly IEnderecoService _appServiceEndereco;
        private readonly IEnderecoRepository _repositoryEndereco;

        private readonly IContatoService _appServiceContato;
        private readonly IContatoRepository _repositoryContato;

        public ClienteController(INotificador notificador,
                                        IMapper mapper,
                                        IClienteService appService,
                                        IEnderecoService appServiceEndereco,
                                        IClienteRepository repository,
                                        IEnderecoRepository repositoryEndereco,
                                        IContatoService appServiceContato,
                                        IContatoRepository repositoryContato)
               : base("cliente", "Cliente", notificador, mapper,
                     appService, repository)
        {
            _appService = appService;
            _repository = repository;
            _appServiceEndereco = appServiceEndereco;
            _repositoryEndereco = repositoryEndereco;
            _repositoryContato = repositoryContato;
            _appServiceContato = appServiceContato;
        }

        protected override void Dispose(bool disposing)
        {
            _appService?.Dispose();
            _repository?.Dispose();
            _appServiceEndereco?.Dispose();
            _repositoryEndereco?.Dispose();
            _appServiceContato?.Dispose();
            _repositoryContato?.Dispose();
        }


        /// <summary>
        /// Cadastra novo Cliente.
        /// </summary>
        /// <param name="viewmodel">View Model de Cliente.</param>
        /// <returns>Resultado da operação.</returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     POST /api/v1/cliente
        ///     {
        ///       "nome": "João Pedro Lima",
        ///       "razao": "João Pedro",
        ///       "cnpJ_CPF": "00.000.000/0001-19",
        ///       "contatos": [
        ///         {
        ///             "tipocontato": 1,
        ///             "valorcontato": "63992548563",
        ///             "descricao": "Meu telefone."
        ///         },
        ///         {
        ///             "tipocontato": 2,
        ///             "valorcontato": "joaopedro@gmail.com",
        ///             "descricao": "Meu e-mail."
        ///         }
        ///       ],
        ///       "enderecos": [
        ///         {
        ///             "numero": 914,
        ///             "codigopostal": 1462,
        ///             "cep": "77790000",
        ///             "estado": "TO",
        ///             "cidade": "Araguaína",
        ///             "bairro": "Centro",
        ///             "rua": "Rua Sadoc Correia"
        ///         }
        ///       ]
        ///     }
        ///     
        ///     nome -> Deve ter no mínimo 1 e no máximo 250 caracteres (É obrigatório);
        ///     razao -> Deve ter no mínimo 1 e no máximo 250 caracteres (É obrigatório);
        ///     cnpJ_CPF -> Deve ter no mínimo 11 e no máximo 18 caracteres (É obrigatório);
        ///     
        ///     contatos -> tipocontato -> É obrigatório ([1] Para Telefone | [2] Para E-mail);
        ///                 valorcontato > Deve ter no mínimo 1 e no máximo 150 caracteres (É obrigatório);
        ///                 descricao -> Deve ter no mínimo 1 e no máximo 50 caracteres (É opcional);
        ///                 
        ///     enderecos -> numero -> Deve ter no máximo 50 caracteres (É opcional);
        ///                  codigopostal -> Deve ter no máximo 50 caracteres (É opcional);  
        ///                  cep -> Deve ter no mínimo 8 e no máximo 9 caracteres (É obrigatório);
        ///                  estado -> Deve ter no mínimo 1 e no máximo 50 caracteres (É obrigatório);
        ///                  cidade -> Deve ter no mínimo 1 e no máximo 100 caracteres (É obrigatório);
        ///                  bairro -> Deve ter no mínimo 1 e no máximo 150 caracteres (É obrigatório);
        ///                  rua -> Deve ter no mínimo 1 e no máximo 150 caracteres (É obrigatório);
        ///    
        ///     A aplicação impõe uma restrição que permite o cadastro de um número de CPF ou CNPJ uma única vez. 
        ///     Isso garante a unicidade dos registros e impede duplicações no sistema.
        ///     
        ///     Obs: Certifique-se de inserir um número de CPF ou CNPJ válido e único para cada registro.
        ///     
        /// </remarks>
        /// <response code="201">Novo registro de Cliente criado.</response>
        /// <response code="400">Não foi possível criar o registro de Cliente.</response>
        /// 
        [HttpPost]
        [ProducesResponseType(typeof(ClienteViewModel), 201)]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public async override Task<IActionResult> Post([FromBody] ClienteAdicionarViewModel viewmodel)
        {
            return await base.Post(viewmodel);
        }

        /// <summary>
        /// Cadastra novo Endereço Cliente.
        /// </summary>
        /// <param name="viewmodel">View Model de Endereço Cliente.</param>
        /// <returns>Resultado da operação.</returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     POST /api/v1/cliente/cliente-endereco
        ///     {
        ///       "clienteID" : "00000000-0000-0000-0000-000000000000",
        ///       "numero": 914,
        ///       "codigopostal": 1462,
        ///       "cep": "77790000",
        ///       "estado": "TO",
        ///       "cidade": "Araguaína",
        ///       "bairro": "Centro",
        ///       "rua": "Rua Sadoc Correia"
        ///     } 
        ///     
        ///     clienteID -> É obrigatório;
        ///     numero -> Deve ter no máximo 50 caracteres (É opcional);
        ///     codigopostal -> Deve ter no máximo 50 caracteres (É opcional);  
        ///     cep -> Deve ter no mínimo 8 e no máximo 9 caracteres (É obrigatório);
        ///     estado -> Deve ter no mínimo 1 e no máximo 50 caracteres (É obrigatório);
        ///     cidade -> Deve ter no mínimo 1 e no máximo 100 caracteres (É obrigatório);
        ///     bairro -> Deve ter no mínimo 1 e no máximo 150 caracteres (É obrigatório);
        ///     rua -> Deve ter no mínimo 1 e no máximo 150 caracteres (É obrigatório);
        ///     
        /// </remarks>
        /// <response code="201">Novo registro de Endereço Cliente criado.</response>
        /// <response code="400">Não foi possível criar o registro de Endereço Cliente.</response>
        /// 
        [HttpPost("cliente-endereco")]
        [ProducesResponseType(typeof(EnderecoViewModel), 201)]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public virtual async Task<IActionResult> Post([FromBody] EnderecoAdicionarViewModel viewmodel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            Endereco model = _appServiceEndereco.MapearDominio(viewmodel);

            await _appServiceEndereco.Adicionar(model);

            if (!_notificador.TemNotificacao())
            {
                Endereco modelRetorno = await _repositoryEndereco.ObterPorId(model.ID);
                EnderecoViewModel retorno = _mapper.Map<EnderecoViewModel>(modelRetorno);
                return CustomResponseAdd(string.Format("api/v1/{0}/{1}", _NomeController, retorno.ID), retorno);
            }

            return CustomResponse();
        }

        /// <summary>
        /// Cadastra novo Contato Cliente.
        /// </summary>
        /// <param name="viewmodel">View Model de Contato Cliente.</param>
        /// <returns>Resultado da operação.</returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     POST /api/v1/cliente/cliente-contato
        ///     {
        ///       "clienteID" : "00000000-0000-0000-0000-000000000000",
        ///       "tipocontato": 1,
        ///       "valorcontato": "63992548563",
        ///       "descricao": "Meu telefone."
        ///     } 
        ///     
        ///     clienteID -> É obrigatório;
        ///     tipocontato -> É obrigatório ([1] Para Telefone | [2] Para E-mail);
        ///     valorcontato > Deve ter no mínimo 1 e no máximo 150 caracteres (É obrigatório);
        ///     descricao -> Deve ter no mínimo 1 e no máximo 50 caracteres (É opcional);
        ///     
        /// </remarks>
        /// <response code="201">Novo registro de Contato Cliente criado.</response>
        /// <response code="400">Não foi possível criar o registro de Contato Cliente.</response>
        /// 
        [HttpPost("cliente-contato")]
        [ProducesResponseType(typeof(ContatoViewModel), 201)]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public virtual async Task<IActionResult> Post([FromBody] ContatoAdicionarViewModel viewmodel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            Contato model = _appServiceContato.MapearDominio(viewmodel);

            await _appServiceContato.Adicionar(model);

            if (!_notificador.TemNotificacao())
            {
                Contato modelRetorno = await _repositoryContato.ObterPorId(model.ID);
                ContatoViewModel retorno = _mapper.Map<ContatoViewModel>(modelRetorno);
                return CustomResponseAdd(string.Format("api/v1/{0}/{1}", _NomeController, retorno.ID), retorno);
            }

            return CustomResponse();
        }

        /// <summary>
        /// Atualiza registro Cliente. 
        /// </summary>
        /// <param name="id">Id do registro.</param>
        /// <param name="viewmodel">View Model de Cliente.</param>
        /// <returns></returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     PUT /api/v1/cliente/00000000-0000-0000-0000-000000000000
        ///     {
        ///       "id" : "00000000-0000-0000-0000-000000000000",
        ///       "ativo": true
        ///       "nome": "João Pedro Lima",
        ///       "razao": "João Pedro",
        ///       "cnpJ_CPF": "00.000.000/0001-19"
        ///     }
        ///     
        ///     id -> É obrigatório;
        ///     nome -> Deve ter no mínimo 1 e no máximo 250 caracteres (É obrigatório);
        ///     razao -> Deve ter no mínimo 1 e no máximo 250 caracteres (É obrigatório); 
        ///     cnpJ_CPF -> Deve ter no mínimo 11 e no máximo 18 caracteres (É obrigatório);
        ///
        ///     Obs: O valor do campo "id" deve coincidir com o valor fornecido na consulta.
        ///     
        /// </remarks>
        /// <response code="200">Registro de Cliente atualizado.</response>
        /// <response code="400">Não foi possível atualizar o registro de Cliente.</response>
        /// 
        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(ClienteViewModel), 200)]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public async override Task<IActionResult> Put(Guid id, [FromBody] ClienteAtualizarViewModel viewmodel)
        {
            return await base.Put(id, viewmodel);
        }

        /// <summary>
        /// Atualiza registro Endereço Cliente. 
        /// </summary>
        /// <param name="id">Id do registro.</param>
        /// <param name="viewmodel">View Model de Endereço Cliente.</param>
        /// <returns></returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     PUT /api/v1/cliente/cliente-endereco/00000000-0000-0000-0000-000000000000
        ///     {
        ///       "id" : "00000000-0000-0000-0000-000000000000",
        ///       "ativo": true
        ///       "numero": 914,
        ///       "codigopostal": 1462,
        ///       "cep": "77790000",
        ///       "estado": "TO",
        ///       "cidade": "Araguaína",
        ///       "bairro": "Centro",
        ///       "rua": "Rua Sadoc Correia"
        ///     }
        ///     
        ///     id -> É obrigatório;
        ///     numero -> Deve ter no máximo 50 caracteres (É opcional);
        ///     codigopostal -> Deve ter no máximo 50 caracteres (É opcional);  
        ///     cep -> Deve ter no mínimo 8 e no máximo 9 caracteres (É obrigatório);
        ///     estado -> Deve ter no mínimo 1 e no máximo 50 caracteres (É obrigatório);
        ///     cidade -> Deve ter no mínimo 1 e no máximo 100 caracteres (É obrigatório);
        ///     bairro -> Deve ter no mínimo 1 e no máximo 150 caracteres (É obrigatório);
        ///     rua -> Deve ter no mínimo 1 e no máximo 150 caracteres (É obrigatório);
        ///
        ///     Obs: O valor do campo "id" deve coincidir com o valor fornecido na consulta.
        ///     
        /// </remarks>
        /// <response code="200">Registro de Endereço Cliente atualizado.</response>
        /// <response code="400">Não foi possível atualizar o registro de Endereço Cliente.</response>
        /// 
        [HttpPut("cliente-endereco/{id:guid}")]
        [ProducesResponseType(typeof(EnderecoViewModel), 200)]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public virtual async Task<IActionResult> Put(Guid id, [FromBody] EnderecoAtualizarViewModel viewmodel)
        {
            if (id != viewmodel.ID)
            {
                NotificarErro("O ID informado não é o mesmo que foi passado na query");
                return CustomResponse(viewmodel);
            }

            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _appServiceEndereco.Atualizar(viewmodel);

            EnderecoViewModel retorno = _mapper.Map<EnderecoViewModel>(_repositoryEndereco.Buscar(m => m.ID.Equals(viewmodel.ID)).Result.FirstOrDefault());

            if (!_notificador.TemNotificacao())
            {
                return CustomResponse(retorno);
            }

            return CustomResponse(retorno);
        }

        /// <summary>
        /// Atualiza registro Contato Cliente. 
        /// </summary>
        /// <param name="id">Id do registro.</param>
        /// <param name="viewmodel">View Model de Contato Cliente.</param>
        /// <returns></returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     PUT /api/v1/cliente/cliente-contato/00000000-0000-0000-0000-000000000000
        ///     {
        ///       "id" : "00000000-0000-0000-0000-000000000000",
        ///       "ativo": true
        ///       "tipocontato": 1,
        ///       "valorcontato": "63992548563",
        ///       "descricao": "Meu telefone."
        ///     }
        ///     
        ///     id -> É obrigatório;
        ///     tipocontato -> É obrigatório ([1] Para Telefone | [2] Para E-mail);
        ///     valorcontato > Deve ter no mínimo 1 e no máximo 150 caracteres (É obrigatório);
        ///     descricao -> Deve ter no mínimo 1 e no máximo 50 caracteres (É opcional);
        ///
        ///     Obs: O valor do campo "id" deve coincidir com o valor fornecido na consulta.
        ///     
        /// </remarks>
        /// <response code="200">Registro de Contato Cliente atualizado.</response>
        /// <response code="400">Não foi possível atualizar o registro de Contato Cliente.</response>
        /// 
        [HttpPut("cliente-contato/{id:guid}")]
        [ProducesResponseType(typeof(ContatoViewModel), 200)]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public virtual async Task<IActionResult> Put(Guid id, [FromBody] ContatoAtualizarViewModel viewmodel)
        {
            if (id != viewmodel.ID)
            {
                NotificarErro("O ID informado não é o mesmo que foi passado na query");
                return CustomResponse(viewmodel);
            }

            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _appServiceContato.Atualizar(viewmodel);

            ContatoViewModel retorno = _mapper.Map<ContatoViewModel>(_repositoryContato.Buscar(m => m.ID.Equals(viewmodel.ID)).Result.FirstOrDefault());

            if (!_notificador.TemNotificacao())
            {
                return CustomResponse(retorno);
            }

            return CustomResponse(retorno);
        }

        /// <summary>
        /// Exclui registro de Cliente.
        /// </summary>
        /// <param name="id">Identificador (guid) do registro de Cliente.</param>
        /// <returns></returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     DELETE /api/v1/cliente/00000000-0000-0000-0000-000000000000
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
            Cliente model = _repository.Buscar(m => m.ID.Equals(id)).Result.FirstOrDefault();

            if (model == null)
                return NotFound();

            ClienteAtualizarViewModel viewmodel = new()
            {
                ID = model.ID,
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
        /// Exclui registro de Endereço Cliente.
        /// </summary>
        /// <param name="id">Identificador (guid) do registro de Endereço Cliente.</param>
        /// <returns></returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     DELETE /api/v1/cliente/cliente-endereco/00000000-0000-0000-0000-000000000000
        ///     {
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Registro excluído com sucesso.</response>
        /// <response code="400">Não foi possível excluir o registro.</response>
        ///
        [HttpDelete("cliente-endereco/{id:guid}")]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public virtual async Task<IActionResult> DeleteEndereco(Guid id)
        {
            Endereco model = _repositoryEndereco.Buscar(m => m.ID.Equals(id)).Result.FirstOrDefault();

            if (model == null)
                return NotFound();

            EnderecoAtualizarViewModel viewmodel = new()
            {
                ID = id,
                ATIVO = false
            };

            await _appServiceEndereco.Atualizar(viewmodel);

            if (!_notificador.TemNotificacao())
            {
                return CustomResponse(new { Mensagem = string.Format("Endereço excluído com sucesso.") });
            }

            return CustomResponse();
        }

        /// <summary>
        /// Exclui registro de Contato Cliente.
        /// </summary>
        /// <param name="id">Identificador (guid) do registro de Contato Cliente.</param>
        /// <returns></returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     DELETE /api/v1/cliente/cliente-contato/00000000-0000-0000-0000-000000000000
        ///     {
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Registro excluído com sucesso.</response>
        /// <response code="400">Não foi possível excluir o registro.</response>
        ///
        [HttpDelete("cliente-contato/{id:guid}")]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public virtual async Task<IActionResult> DeleteContato(Guid id)
        {
            Contato model = _repositoryContato.Buscar(m => m.ID.Equals(id)).Result.FirstOrDefault();

            if (model == null)
                return NotFound();

            ContatoAtualizarViewModel viewmodel = new()
            {
                ID = model.ID,
                ATIVO = false,
                DESCRICAO = model.DESCRICAO,
                TIPOCONTATO = model.TIPOCONTATO,
                VALORCONTATO = model.VALORCONTATO
            };

            await _appServiceContato.Atualizar(viewmodel);

            if (!_notificador.TemNotificacao())
            {
                return CustomResponse(new { Mensagem = string.Format("Contato excluído com sucesso.") });
            }

            return CustomResponse();
        }

        /// <summary>
        /// Retorna Cliente especifico por Id (guid).
        /// </summary>
        /// <param name="id">Identificador (guid) do registro de Cliente.</param>
        /// <returns></returns>
        /// <response code="200">Registro de Cliente correspondente ao Id.</response>
        /// <response code="400">Não foi possível localizar o registro de Cliente.</response>
        ///
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ClienteViewModel), 200)]
        [ProducesResponseType(typeof(BadRequestRetorno), 400)]
        public async override Task<IActionResult> Get(Guid id)
        {
            var models = await _repository.ObterPorId(id);

            var retorno = _mapper.Map<ClienteViewModel>(models);

            return CustomResponse(retorno);
        }

        /// <summary>
        /// Retorna lista paginada de Clientes.
        /// </summary>
        /// <returns></returns>
        /// <param name="nome">Nome.</param>
        /// <param name="cnpJ_CPF">CPF ou CNPJ.</param>
        /// <param name="ativo">Status do registro Ativo ou Desativado.</param>
        /// <param name="pagina">Página da lista de item.</param>
        /// <param name="tamanhoPagina">Total de itens por página.</param>
        /// <param name="ordem">Ordenação: Id, Nome, CNPJ_CPF, Endereco, Bairro, DataCadastro.</param>
        /// <response code="200">O recurso solicitado foi processado e retornado com sucesso.</response>
        ///
        [HttpGet]
        [ProducesResponseType(typeof(SucessRetorno<ListaPaginada<ClienteViewModel>>), 200)]
        public async Task<IActionResult> GetPorTodosOsFiltros([FromQuery] string nome, [FromQuery] string cnpJ_CPF,
            [FromQuery] bool? ativo,
            [FromQuery] int? pagina,
            [FromQuery] int? tamanhoPagina,
            [FromQuery] string ordem)
        {
            var models = await _repository.ObterPorTodosFiltros(nome, cnpJ_CPF,
                ativo, pagina, tamanhoPagina, ordem);

            ListaPaginada<ClienteViewModel> retorno = new ListaPaginada<ClienteViewModel>(
                _mapper.Map<List<ClienteViewModel>>(models.ListaRetorno),
                models.PaginaAtual,
                models.TotalPaginas,
                models.TamanhoPagina,
                models.TotalItens);

            return CustomResponse(retorno);
        }

        /// <summary>
        /// Retorna Endereço Cliente especifico por Id (guid).
        /// </summary>
        /// <param name="id">Identificador (guid) do registro de Endereço Cliente.</param>
        /// <returns></returns>
        /// <response code="200">Registro de Endereço Cliente correspondente ao Id.</response>
        /// <response code="400">Não foi possível localizar o registro de Endereço Cliente.</response>
        ///
        //[HttpGet("cliente-endereco/{id:guid}")]
        //[ProducesResponseType(typeof(EnderecoViewModel), 200)]
        //[ProducesResponseType(typeof(BadRequestRetorno), 400)]
        //public async Task<IActionResult> GetEnderecoCliente(Guid id)
        //{
        //    var models = await _repositoryEndereco.ObterPorId(id);

        //    var retorno = _mapper.Map<EnderecoViewModel>(models);

        //    return CustomResponse(retorno);
        //}

        /// <summary>
        /// Retorna lista paginada de Endereços Cliente.
        /// </summary>
        /// <returns></returns>
        /// <param name="id">Id do Cliente.</param>
        /// <param name="cep">CEP.</param>
        /// <param name="rua">Rua.</param>
        /// <param name="bairro">Bairro.</param>
        /// <param name="numero">Número.</param>
        /// <param name="codigoPostal">Código Postal.</param>
        /// <param name="ativo">Status do registro Ativo ou Desativado.</param>
        /// <param name="pagina">Página da lista de item.</param>
        /// <param name="tamanhoPagina">Total de itens por página.</param>
        /// <param name="ordem">Ordenação: Id, Cep, Rua, Bairro, Numero, CodigoPostal, DataCadastro.</param>
        /// <response code="200">O recurso solicitado foi processado e retornado com sucesso.</response>
        ///
        //[HttpGet("cliente-enderecos/{id:guid}")]
        //[ProducesResponseType(typeof(SucessRetorno<ListaPaginada<EnderecoViewModel>>), 200)]
        //public async Task<IActionResult> GetEnderecosCliente(Guid id,
        //    [FromQuery] string cep,
        //    [FromQuery] string rua,
        //    [FromQuery] string bairro,
        //    [FromQuery] string numero,
        //    [FromQuery] string codigoPostal,
        //    [FromQuery] bool? ativo,
        //    [FromQuery] int? pagina,
        //    [FromQuery] int? tamanhoPagina,
        //    [FromQuery] string ordem)
        //{
        //    var models = await _repositoryEndereco.ObterPorTodosFiltros(id, cep, rua, bairro, numero, codigoPostal,
        //        ativo, pagina, tamanhoPagina, ordem);

        //    ListaPaginada<EnderecoViewModel> retorno = new ListaPaginada<EnderecoViewModel>(
        //        _mapper.Map<List<EnderecoViewModel>>(models.ListaRetorno),
        //        models.PaginaAtual,
        //        models.TotalPaginas,
        //        models.TamanhoPagina,
        //        models.TotalItens);

        //    return CustomResponse(retorno);
        //}
    }
}
