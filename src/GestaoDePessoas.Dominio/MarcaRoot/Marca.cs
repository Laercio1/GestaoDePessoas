using GestaoDePessoas.Dominio.Core.Models;
using GestaoDePessoas.Dominio.Core.Annotations;

namespace GestaoDePessoas.Dominio.MarcaRoot
{
    [Table("MARCA")]
    public class Marca : Entity
    {
        public Marca()
        {
            ATIVO = true;
        }

        public bool ATIVO { get; set; }
        public string NOME { get; set; }
        public DateTime DATAHORACADASTRO { get; set; }
    }
}
