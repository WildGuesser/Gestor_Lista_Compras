using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_Lista_Compras
{
    public class Utilizador
    {
        
        public string NomeUser { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Pais { get; set; }


        public Utilizador(string nomeUser, string email, string password, string pais)
        {
           
            NomeUser = nomeUser;
            Email = email;
            Password = password;
            Pais = pais;

        }

     

    }
}
