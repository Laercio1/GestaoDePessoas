//using GestaoDePessoas.Dominio.Core.Models;
//using GestaoDePessoas.Dominio.EnderecoRoot;
//using GestaoDePessoas.Dominio.Core.Annotations;
//using GestaoDePessoas.Dominio.ContatoRoot;

//namespace GestaoDePessoas.Dominio.PessoaRoot
//{
//    [Table("PESSOA")]
//    public class Pessoa : Entity
//    {
//        public Pessoa()
//        {
//            ATIVO = true;
//            Contatos = new List<Contato>();
//            Enderecos = new List<Endereco>();
//        }

//        public bool ATIVO { get; set; }
//        public string CNPJ_CPF { get; set; }
//        public string NOMECOMPLETO { get; set; }
//        public DateTime DATAHORACADASTRO { get; set; }
//        public List<Contato> Contatos { get; set; }
//        public List<Endereco> Enderecos { get; set; }
//    }
//}
