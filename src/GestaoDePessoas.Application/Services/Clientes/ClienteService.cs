using AutoMapper;
using GestaoDePessoas.Dominio.ClienteRoot;
using GestaoDePessoas.Application.Notificacoes;
using GestaoDePessoas.Application.Services.Base;
using GestaoDePessoas.Dominio.Core.Utils.StringUtils;
using GestaoDePessoas.Dominio.ClienteRoot.Validation;
using GestaoDePessoas.Dominio.ClienteRoot.Repository;
using GestaoDePessoas.Application.ViewModels.Cliente;
using GestaoDePessoas.Application.Interfaces.Clientes;
using GestaoDePessoas.Application.ViewModels.Endereco;
using GestaoDePessoas.Dominio.EnderecoRoot;

namespace GestaoDePessoas.Application.Services.Clientes
{
    public class ClienteService : BaseCadastroService<Cliente,
        ClienteViewModel,
        ClienteAdicionarViewModel,
        ClienteAtualizarViewModel,
        ClienteValidation>,
        IClienteService
    {

        private readonly IClienteRepository _repository;

        public ClienteService(INotificador notificador,
                                    IClienteRepository repository,
                                    IMapper mapper)
            : base("Cliente", notificador, repository, mapper)
        {
            _repository = repository;
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

        public virtual async Task<bool> Atualizar(ClienteAtualizarViewModel viewmodel)
        {
            if (!_repository.DominioExiste(viewmodel.ID))
            {
                Notificar("{0} não existe.", _NomeDominio);
                return false;
            }

            Cliente model = await _repository.ObterPorId(viewmodel.ID);

            bool temAtualizacao = MapearAtualizacoes(model, viewmodel);

            if (!temAtualizacao)
            {
                Notificar("Não há alterações no registro de {0}.", _NomeDominio);
                return false;
            }

            if (!ValidarModel(model))
                return false;

            try
            {
                await _repository.Atualizar(model);
                return true;
            }
            catch (Exception ex)
            {
                Notificar("Não foi possível atualizar o registro de {0}. Motivo: {1}", _NomeDominio, ex.InnerException);
                return false;
            }
        }

        public override bool ValidarAdicionarModel(Cliente model)
        {
            if (ValidaTipoContatoModel(model))
            {
                Notificar("Tipo de Contato informado não é válido. Por favor, informe o número válido!", _NomeDominio);
                return false;
            }
            else if (!StringUtils.ValidaCNPJouCPF(model.CNPJ_CPF))
            {
                Notificar("O CNPJ/CPF da {0} informado é inválido.", _NomeDominio);
                return false;
            }
            else if (_repository.EExisteCadastroMesmoCPFCNPJ(model) > 0)
            {
                Notificar("Já existe uma {0} com o mesmo número de CPF/CNPJ cadastrado.", _NomeDominio);
                return false;
            }
            else return true;
        }

        public bool ValidaTipoContatoModel(Cliente model)
        {
            if (model.Contatos.Count > 0) 
                for (int i = 0; i < model.Contatos.Count; i++) 
                    if (model.Contatos[i].TIPOCONTATO != 1 && model.Contatos[i].TIPOCONTATO != 2) 
                        return true;

            return false;
        }

        public void LimparListaNotificacao()
        {
            _notificador.LimparNotificacao();
        }
    }
}
