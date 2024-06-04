using GestaoDePessoas.Dominio.MarcaRoot;
using GestaoDePessoas.Dominio.Core.Models;
using GestaoDePessoas.Dominio.Core.Annotations;
using GestaoDePessoas.Dominio.CategoriaRoot;

namespace GestaoDePessoas.Dominio.ProdutoRoot
{
    [Table("PRODUTO")]
    public class Produto : Entity
    {
        public Produto()
        {
            ATIVO = true;
        }

        public bool ATIVO { get; set; }
        public string NOME { get; set; }
        public Guid MarcaID { get; set; }
        public string CBARRA { get; set; }
        public string UNIDADE { get; set; }
        public Guid CategoriaID { get; set; }
        public virtual Marca Marca { get; set; }
        public decimal PRECOUNITARIO { get; set; }
        public DateTime DATAHORACADASTRO { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
