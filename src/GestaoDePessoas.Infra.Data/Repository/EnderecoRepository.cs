using GestaoDePessoas.Dominio;
using Microsoft.EntityFrameworkCore;
using GestaoDePessoas.Infra.Data.Context;
using GestaoDePessoas.Dominio.EnderecoRoot;
using GestaoDePessoas.Infra.Data.Repository.Base;
using GestaoDePessoas.Dominio.EnderecoRoot.Repository;

namespace GestaoDePessoas.Infra.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(GestaoDePessoasContext context) : base(context)
        {

        }

        public async Task<Endereco> ObterPorId(Guid? id)
        {
            IQueryable<Endereco> _consulta = Db.Endereco;

            _consulta = _consulta.Where(fp => fp.ID.Equals(id));
            _consulta = _consulta.OrderBy(e => e.ID);

            return _consulta.LastOrDefault();
        }

        public async Task<Guid>? ObterId(string cep)
        {
            IQueryable<Endereco> _consulta = Db.Endereco.AsQueryable();

            _consulta = _consulta.Where(fp => fp.CEP.Equals(cep));

            var consulta = _consulta.Where(c => EF.Functions.Like(c.CEP, cep.ToScape()) ||
                EF.Functions.Like(c.CEP.Replace(".", "").Replace("-", "").Replace("/", ""), cep.ToScape())).FirstOrDefault();

            return consulta.ID;
        }

        public async Task<ListaPaginada<Endereco>> ObterPorTodosFiltros(Guid? idCliente, string cep, string rua, string bairro, 
            string numero, string codigoPostal, bool? ativo, int? pagina, int? tamanhoPagina, string order)
        {
            IQueryable<Endereco> _consulta = Db.Endereco;

            if (idCliente.HasValue) _consulta = _consulta.Where(p => p.clienteID == idCliente.Value);

            if (!string.IsNullOrEmpty(cep))
                _consulta = _consulta.Where(c => EF.Functions.Like(c.CEP, cep.ToScape()) ||
                EF.Functions.Like(c.CEP.Replace(".", "").Replace("-", "").Replace("/", ""), cep.ToScape()));

            if (!string.IsNullOrEmpty(rua)) _consulta = _consulta.Where(c => EF.Functions.Like(c.RUA, rua.ToScape()));

            if (!string.IsNullOrEmpty(bairro)) _consulta = _consulta.Where(c => EF.Functions.Like(c.BAIRRO, bairro.ToScape()));

            if (!string.IsNullOrEmpty(numero)) _consulta = _consulta.Where(c => EF.Functions.Like(c.NUMERO, numero.ToScape()));

            if (!string.IsNullOrEmpty(codigoPostal)) _consulta = _consulta.Where(c => EF.Functions.Like(c.CODIGOPOSTAL, codigoPostal.ToScape()));

            if (ativo.HasValue) _consulta = _consulta.Where(e => e.ATIVO == ativo.Value);

            _consulta = _consulta.OrderBy(e => e.ID);
            _consulta = _consulta.OrderByNew(order);

            _paginated = await ReturnPaginatedList(_consulta, pagina, tamanhoPagina);

            return new ListaPaginada<Endereco>(_paginated, _paginated.PageIndex, _paginated.TotalPages, _paginated.PageSize, _paginated.TotalItens);
        }
    }
}
