using GestaoDePessoas.Dominio.Core.Annotations;
using GestaoDePessoas.Dominio.Core.Models;

namespace GestaoDePessoas.Dominio.ContatoRoot
{
    [Table("CONTATO")]
    public class Contato : Entity
    {
        public Contato()
        {
            ATIVO = true;
        }

        public bool ATIVO { get; set; }
        public Guid clienteID { get; set; }
        public string? DESCRICAO { get; set; }
        public double TIPOCONTATO { get; set; }
        public string VALORCONTATO { get; set; }
        public DateTime DATAHORACADASTRO { get; set; }
    }
}
