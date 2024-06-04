using GestaoDePessoas.Dominio.Core.Models;
using GestaoDePessoas.Dominio.ContatoRoot;
using GestaoDePessoas.Dominio.EnderecoRoot;
using GestaoDePessoas.Dominio.Core.Annotations;

namespace GestaoDePessoas.Dominio.ClienteRoot
{
    [Table("CLIENTE")]
    public class Cliente : Entity
    {
        public Cliente()
        {
            ATIVO = true;
            Contatos = new List<Contato>();
            Enderecos = new List<Endereco>();
        }

        public bool ATIVO { get; set; }
        public string NOME { get; set; }
        public string RAZAO { get; set; }
        public string CNPJ_CPF { get; set; }
        public DateTime DATAHORACADASTRO { get; set; }
        public List<Contato> Contatos { get; set; }
        public List<Endereco> Enderecos { get; set; }
    }
}
