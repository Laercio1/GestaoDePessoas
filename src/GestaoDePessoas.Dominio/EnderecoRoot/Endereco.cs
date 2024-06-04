using GestaoDePessoas.Dominio.Core.Models;
using GestaoDePessoas.Dominio.Core.Annotations;

namespace GestaoDePessoas.Dominio.EnderecoRoot
{
    [Table("ENDERECO")]
    public class Endereco : Entity
    {
        public Endereco()
        {
            ATIVO = true;
        }

        public bool ATIVO { get; set; }
        public string RUA { get; set; }
        public string CEP { get; set; }
        public string ESTADO { get; set; }
        public string CIDADE { get; set; }
        public string BAIRRO { get; set; }
        public Guid clienteID { get; set; }
        public double? NUMERO { get; set; }
        public double? CODIGOPOSTAL { get; set; }
        public DateTime DATAHORACADASTRO { get; set; }
    }
}
