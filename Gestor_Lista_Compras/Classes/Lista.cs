using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_Lista_Compras
{
    public class Lista
    {
    
        public string NomeLista { get; set; }
        public List <ItemDaLista> itemDaListas;


        public Lista(string nomeLista)
        {
            NomeLista = nomeLista;
            itemDaListas = new List<ItemDaLista>();
        }
            

    }
}
