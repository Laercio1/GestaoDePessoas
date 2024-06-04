using GestaoDePessoas.Dominio.Core.Models;
using GestaoDePessoas.Dominio.Core.Annotations;

namespace GestaoDePessoas.Dominio.FormaPagamentoRoot
{
    [Table("FORMAPAGAMENTO")]
    public class FormaPagamento : Entity
    {
        public FormaPagamento()
        {
            ATIVO = true;
        }

        public bool ATIVO { get; set; }
        public string NOME { get; set; }
        public double TAXA { get; set; }
        public string DESCRICAO { get; set; }
        public DateTime DATAHORACADASTRO { get; set; }
    }
}
