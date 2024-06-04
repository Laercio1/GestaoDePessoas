using GestaoDePessoas.Dominio.Core.Models;
using GestaoDePessoas.Dominio.Core.Annotations;

namespace GestaoDePessoas.Dominio.PedidoStatusRoot
{
    [Table("PEDIDOSTATUS")]
    public class PedidoStatus : Entity
    {
        public PedidoStatus()
        {
            FINALIZADO = false;
            CANCELADO = false;
            ATIVO = true;
        }

        public bool ATIVO { get; set; }
        public bool? CANCELADO { get; set; }
        public bool? FINALIZADO { get; set; }
        public string DESCRICAO { get; set; }
        public DateTime DATAHORACADASTRO { get; set; }
    }
}
