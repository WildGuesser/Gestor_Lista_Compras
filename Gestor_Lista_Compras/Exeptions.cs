using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_Lista_Compras
{
    public class TextoInvalidoExeption : ApplicationException
    {
        public TextoInvalidoExeption(string msg)
            : base(msg)
        {


        }
    }
}
