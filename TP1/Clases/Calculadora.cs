using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Calculadora
    {

        /// <summary>
        /// Realiza una operacion sobre los numeros pasados como parámetro, según el operando pasado como tercer parametro.
        /// Valida que el operador sea correcto. Retorna el resultado. En caso de ser división por 0, retorna 0.
        /// </summary>
        /// <param name="num1">Primer operando</param>
        /// <param name="num2">Segundo operando</param>
        /// <param name="operador">Operador. Suma, resta, multiplicación o división.</param>
        /// <returns>Resultado de la operacion</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno = 0;
            operador = ValidarOperador(operador);
            if (operador == "+") retorno = num1.GetNumero() + num2.GetNumero();
            if (operador == "-") retorno = num1.GetNumero() - num2.GetNumero();
            if (operador == "*") retorno = num1.GetNumero() * num2.GetNumero();
            if (operador == "/")
                if (num2.GetNumero()==0) return 0;
                else
                    retorno = num1.GetNumero() / num2.GetNumero();
            return retorno;
        }
        /// <summary>
        /// Valida que el operador sea suma, resta, división, o multiplicación. Si no lo es, retorna el operador suma '+'.
        /// </summary>
        /// <param name="operadorString">Operador a validar</param>
        /// <returns>El mismo operador si es valido, u operador suma si no lo es.</returns>
        public static string ValidarOperador(string operadorString)
        {
            if (operadorString == "+" || operadorString == "-" || operadorString == "*" || operadorString == "/") 
                return operadorString;
            else
                return "+";
        }
    }
}
