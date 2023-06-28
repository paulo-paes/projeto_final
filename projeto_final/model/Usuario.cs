using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_final.model
{
    public class Usuario
    {
        public int Cod { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Situacao { get; set; }

        public Usuario() { }
    }
}
