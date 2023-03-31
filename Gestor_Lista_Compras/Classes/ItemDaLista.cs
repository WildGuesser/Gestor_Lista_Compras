using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_Lista_Compras
{
    public class ItemDaLista
    {

       
         
        public string NomeItem { get; set; }
        public string Quantidade { get; set; }
        public string Categoria { get; set; }

        public bool Comprado { get; set; }


        //metodos

        public ItemDaLista(string nome, string quantidade, string categoria)
        {
        
            NomeItem = nome;
            Quantidade = quantidade;
            Categoria = categoria;
            Comprado = false;
        }


    }

}
