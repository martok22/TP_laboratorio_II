using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private static string mensajeBase = "Dni repetido";

        public DniInvalidoException() : base() { }

        public DniInvalidoException(string mensaje) : base(mensaje) { }

        public DniInvalidoException(Exception e) : base(mensajeBase,e){ }

        public DniInvalidoException(string mensaje, Exception e):this(mensaje) { }

    }
}
