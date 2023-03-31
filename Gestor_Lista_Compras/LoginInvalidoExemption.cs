using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_Lista_Compras
{
    public class LoginInvalidoExemption : ApplicationException
    {

        public LoginInvalidoExemption(string msg)
            : base(msg)
        {


        }
    }
}
