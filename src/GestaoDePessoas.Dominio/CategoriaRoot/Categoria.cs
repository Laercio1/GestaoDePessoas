using GestaoDePessoas.Dominio.Core.Models;
using GestaoDePessoas.Dominio.Core.Annotations;

namespace GestaoDePessoas.Dominio.CategoriaRoot
{
    [Table("CATEGORIA")]
    public class Categoria : Entity
    {
        public Categoria()
        {
            ATIVO = true;
        }

        public bool ATIVO { get; set; }
        public string NOME { get; set; }
        public DateTime DATAHORACADASTRO { get; set; }
    }
}
