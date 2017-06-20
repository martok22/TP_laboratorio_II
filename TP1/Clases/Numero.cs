using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Instancia un objeto de la clase Numero. Asigna al atributo de numero el valor de 0.
        /// </summary>

        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Instancia un objeto de la clase Numero. Asigna el parametro double al atributo de la clase.
        /// </summary>
        /// <param name="num">Parametro a asignar </param>

        public Numero(double num)
        {
            this.numero = num;
        }

        /// <summary>
        /// Instancia un objeto de la clase Numero. Pasa el parametro al método SetNumero.
        /// </summary>
        /// <param name="num">Parametro a ser pasado al método SetNumero</param>

        public Numero(string num)
        {
            this.SetNumero(num);
        }

        /// <summary>
        /// Valida que la string pasada sea numero. Retorna el número como double, o 0 si no es numerico.
        /// </summary>
        /// <param name="numString">String a validar que sea numérica</param>
        /// <returns>número como double si es válido. Si no es numérico o el número es 0, retorna 0.</returns>

        private double ValidarNumero(string numString)
        {
            double retorno;
            double.TryParse(numString, out retorno);
            return retorno;
        }

        /// <summary>
        /// Pasa como parametro un string al metodo ValidarNumero, y asigna su retorno al atributo de la clase.
        /// </summary>
        /// <param name="numString">String a validar</param>

        private void SetNumero(string numString)
        {
            this.numero = ValidarNumero(numString);
        }

        /// <summary>
        /// Devuelve el valor del atributo de la clase.
        /// </summary>
        /// <returns>El atributo de la clase</returns>

        public double GetNumero()
        {
            return this.numero;
        }
    }
}
