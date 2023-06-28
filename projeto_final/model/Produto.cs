using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_final.model
{
    public class Produto
    {
        public int Cod { get; set; }
        public string Descricao { get; set; }
        public string CodigoBarras { get; set; }
        public string Marca { get; set; }
        public double Peso { get; set; }
        public double Largura { get; set; }
        public double Altura { get; set; }
        public double Profundidade { get; set; }
        public bool Situacao { get; set; }
        public bool Condicao { get; set; }
        public double PrecoVenda { get; set; }
        public double QuantidadeEstoque { get; set; }
        public DateTime DataCadastro { get; set; }

        public Produto() { }
    }
}
