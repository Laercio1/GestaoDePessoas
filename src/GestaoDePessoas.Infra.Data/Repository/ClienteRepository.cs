using GestaoDePessoas.Dominio;
using Microsoft.EntityFrameworkCore;
using GestaoDePessoas.Infra.Data.Context;
using GestaoDePessoas.Dominio.ClienteRoot;
using GestaoDePessoas.Infra.Data.Repository.Base;
using GestaoDePessoas.Dominio.ClienteRoot.Repository;

namespace GestaoDePessoas.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(GestaoDePessoasContext context) : base(context)
        {

        }

        public async Task<Cliente> ObterPorId(Guid id)
        {
            IQueryable<Cliente> _consulta = Db.Cliente.Include(x => x.Contatos.Where(c => c.ATIVO))
                                                      .Include(x => x.Enderecos.Where(e => e.ATIVO));

            _consulta = _consulta.Where(fp => fp.ID.Equals(id));
            _consulta = _consulta.OrderBy(e => e.ID);

            return _consulta.LastOrDefault();
        }

        public int EExisteCadastroMesmoCPFCNPJ(Cliente model)
        {
            var _consulta = ReturnIQueryable();

            var consulta = _consulta.Where(c => EF.Functions.Like(c.CNPJ_CPF, model.CNPJ_CPF.ToScape()) ||
                EF.Functions.Like(c.CNPJ_CPF.Replace(".", "").Replace("-", "").Replace("/", ""),
                model.CNPJ_CPF.Replace(".", "").Replace("-", "").Replace("/", "").ToScape())).ToList();

            return consulta.Count;
        }

        public async Task<ListaPaginada<Cliente>> ObterPorTodosFiltros(string nome, string cnpJ_CPF, bool? ativo, int? pagina, int? tamanhoPagina, string order)
        {
            IQueryable<Cliente> _consulta = Db.Cliente.Include(x => x.Contatos.Where(c => c.ATIVO))
                                                      .Include(x => x.Enderecos.Where(e => e.ATIVO));

            if (!string.IsNullOrEmpty(nome)) _consulta = _consulta.Where(c => EF.Functions.Like(c.NOME, nome.ToScape()));

            if (!string.IsNullOrEmpty(cnpJ_CPF))
                _consulta = _consulta.Where(c => EF.Functions.Like(c.CNPJ_CPF, cnpJ_CPF.ToScape()) ||
                EF.Functions.Like(c.CNPJ_CPF.Replace(".", "").Replace("-", "").Replace("/", ""), cnpJ_CPF.ToScape()));

            if (ativo.HasValue) _consulta = _consulta.Where(e => e.ATIVO == ativo.Value);
            else _consulta = _consulta.Where(e => e.ATIVO);

            _consulta = _consulta.OrderBy(e => e.ID);
            _consulta = _consulta.OrderByNew(order);

            _paginated = await ReturnPaginatedList(_consulta, pagina, tamanhoPagina);

            return new ListaPaginada<Cliente>(_paginated, _paginated.PageIndex, _paginated.TotalPages, _paginated.PageSize, _paginated.TotalItens);
        }
    }
}
