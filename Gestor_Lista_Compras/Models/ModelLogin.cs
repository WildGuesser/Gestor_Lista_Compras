using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_Lista_Compras
{
    public class ModelLogin
    {
        public event MetodosSemParametros LoginFeito;
        public ModelSignUp SignUp;

        public ModelLogin()
        {

            SignUp = new ModelSignUp();
        }
        public void CheckLogin(string userCheck, string password)
        {
            //LINQ
            string result = string.Empty;
            var result2 = (from user in SignUp.utilizadores
                             where user.NomeUser == userCheck && user.Password == password
                             select user.NomeUser);



            if ( result != userCheck)
            {
                LoginFeito();
            }
            else
            {
                throw new LoginInvalidoExemption("Login Invalido");
            }

        }

       
    }
}
