using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_final.model
{
    public class Cliente
    {
        public int Cod { get; set; }
        public string Nome { get; set; }
        public bool Situacao { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Genero { get; set; }
        public DateTime DataNascimento { get; set; }
        public string EstadoCivil { get; set; }

        public string Profissao { get; set; }
        public string Nacionalidade { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public bool Whatsapp { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Cep { get; set; }
        public string Observacoes { get; set; }
        public DateTime DataCadastro { get; set; }

        public Cliente() { }


    }
}
