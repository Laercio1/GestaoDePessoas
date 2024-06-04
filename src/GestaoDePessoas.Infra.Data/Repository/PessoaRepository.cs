//using GestaoDePessoas.Dominio;
//using Microsoft.EntityFrameworkCore;
//using GestaoDePessoas.Dominio.PessoaRoot;
//using GestaoDePessoas.Infra.Data.Context;
//using GestaoDePessoas.Infra.Data.Repository.Base;
//using GestaoDePessoas.Dominio.PessoaRoot.Repository;

//namespace GestaoDePessoas.Infra.Data.Repository
//{
//    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
//    {
//        public PessoaRepository(GestaoDePessoasContext context) : base(context)
//        {

//        }

//        public async Task<Pessoa> ObterPorId(Guid id)
//        {
//            IQueryable<Pessoa> _consulta = Db.Pessoa.Include(x => x.Contatos)
//                                                    .Include(x => x.Enderecos);

//            _consulta = _consulta.Where(fp => fp.ID.Equals(id));
//            _consulta = _consulta.OrderBy(e => e.ID);

//            return _consulta.LastOrDefault();
//        }

//        public int EExisteCadastroMesmoCPFCNPJ(Pessoa model)
//        {
//            var _consulta = ReturnIQueryable();

//            var consulta = _consulta.Where(c => EF.Functions.Like(c.CNPJ_CPF, model.CNPJ_CPF.ToScape()) ||
//                EF.Functions.Like(c.CNPJ_CPF.Replace(".", "").Replace("-", "").Replace("/", ""), 
//                model.CNPJ_CPF.Replace(".", "").Replace("-", "").Replace("/", "").ToScape())).ToList();

//            return consulta.Count;
//        }

//        public async Task<ListaPaginada<Pessoa>> ObterPorTodosFiltros(string nomeCompleto, string cnpJ_CPF, bool? ativo, int? pagina, int? tamanhoPagina, string order)
//        {
//            IQueryable<Pessoa> _consulta = Db.Pessoa.Include(x => x.Contatos)
//                                                    .Include(x => x.Enderecos);

//            if (!string.IsNullOrEmpty(nomeCompleto)) _consulta = _consulta.Where(c => EF.Functions.Like(c.NOMECOMPLETO, nomeCompleto.ToScape()));

//            if (!string.IsNullOrEmpty(cnpJ_CPF))
//                _consulta = _consulta.Where(c => EF.Functions.Like(c.CNPJ_CPF, cnpJ_CPF.ToScape()) ||
//                EF.Functions.Like(c.CNPJ_CPF.Replace(".", "").Replace("-", "").Replace("/", ""), cnpJ_CPF.ToScape()));

//            if (ativo.HasValue) _consulta = _consulta.Where(e => e.ATIVO == ativo.Value);

//            _consulta = _consulta.OrderBy(e => e.ID);
//            _consulta = _consulta.OrderByNew(order);

//            _paginated = await ReturnPaginatedList(_consulta, pagina, tamanhoPagina);

//            return new ListaPaginada<Pessoa>(_paginated, _paginated.PageIndex, _paginated.TotalPages, _paginated.PageSize, _paginated.TotalItens);
//        }
//    }
//}
