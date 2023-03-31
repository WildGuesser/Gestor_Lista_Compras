using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_Lista_Compras
{
    public class Categoria
    {
        public string Nome_Categoria { get; set; }
        public bool fixa { get; set; }

        public Categoria(string nome)
        {
            Nome_Categoria = nome;  
            fixa = false;
        }
    }
}
