using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace EntidadesAbstractas
{
        public abstract class Persona
        {
            private string _apellido;

            /// <summary>
            /// Llama al método ValidarNombreApellido pasandole el parametro 'value'. El 
            /// método ValidarNombreApellido retorna la misma cadena string si no posee ningún 
            /// caracter alfanumérico en su composición. Retorna null caso contrario.
            /// 
            /// La propiedad Apellido asigna 'value' al atributo si ValidarNombreApellido no 
            /// devuelve null. Caso contrario no asigna.
            /// </summary>
            public string Apellido
            {
                set
                {
                    if (ValidarNombreApellido(value) != null)
                        this._apellido = value;
                }
                get { return this._apellido; }
            }

            private int _dni;
            public int Dni
            {
                set { this._dni = ValidarDni(this.Nacionalidad,value); }
                get { return this._dni; }
            }
            private ENacionalidad _nacionalidad;
            public ENacionalidad Nacionalidad
            {
                set { this._nacionalidad = value; }
                get { return this._nacionalidad; }
            }
            private string _nombre;

            /// <summary>
            /// Si no es null, asigna el valor al atributo
            /// </summary>
            public string Nombre
            {
                set
                {
                    if (ValidarNombreApellido(value) != null)
                        this._nombre = value;
                }
                get { return this._nombre; }
            }
            /// <summary>
            /// Asigna al atributo _dni el retorno de ValidarDni.
            /// </summary>
            public string StringToDni
            {
                set
                {
                     this._dni = ValidarDni(this.Nacionalidad, value);
                }
            }

            public Persona() { }

            public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            {
                this.Nombre = nombre;
                this.Apellido = apellido;
                this.Nacionalidad = nacionalidad;
            }

            public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
            {
                this.Dni = dni;
            }

            public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) :
            this(nombre, apellido, nacionalidad)
            {
                this.StringToDni = dni;
            }
            
            /// <summary>
            /// Muestra por consola el valor de las propiedades Nombre, Apellido, Nacionalidad 
            /// según el ejemplo de consola específicado en el enunciado.
            /// </summary>
            public override string ToString()
            {
                StringBuilder bloque = new StringBuilder();
                bloque.AppendFormat("NOMBRE COMPLETO: {0}, {1}", this.Apellido, this.Nombre);
                bloque.AppendLine();
                bloque.AppendFormat("NACIONALIDAD: {0}", this.Nacionalidad);
                return bloque.ToString();
            }

            /// <summary>
            /// Retorna dni como entero si es correcto, caso contrario lanza excepción de NacionalidadInvalida
            /// o DniInvalido.
            /// </summary>
            /// <param name="nacionalidad"></param>
            /// <param name="dato"></param>
            /// <returns></returns>

            private int ValidarDni(ENacionalidad nacionalidad, int dato)
            {
            if (dato > 0 && dato < 90000000)
                if (nacionalidad == ENacionalidad.Argentino)
                    return dato;
                else
                    throw new NacionalidadInvalidaException();

            else if (dato < 100000000 && dato >= 90000000)
                if (nacionalidad == ENacionalidad.Extranjero)
                    return dato;
                else
                    throw new NacionalidadInvalidaException();

            else
                throw new DniInvalidoException();
            }

            /// <summary>
            /// Parsea el dni a entero con int.TryParse, y llama al metodo ValidarDni con el entero parseado. 
            /// En caso de fallar el TryParse, ValidarDni con entero tirará error de tipo dni invalido.
            /// </summary>
            /// <param name="nacionalidad"></param>
            /// <param name="dato"></param>
            /// <returns></returns>

            private int ValidarDni(ENacionalidad nacionalidad, string dato)
            {
                int datoParseado;
                int.TryParse(dato, out datoParseado);
                datoParseado = ValidarDni(nacionalidad, datoParseado);
                return datoParseado;
            }
            /// <summary>
            /// Itera sobre una string no nula, devuelve la misma string si posee solo caracteres 
            /// no-alfanuméricos. Retorna null caso contrario. No chequea que reciba null.
            /// </summary>
            /// <param name="dato"></param>
            /// <returns></returns>

            private string ValidarNombreApellido(string dato)
            {
                foreach (Char c in dato)
                     if (!Char.IsLetter(c))
                         return null;
                return dato;
            }

            public enum ENacionalidad
            {
                Argentino, Extranjero
            }
        }
}

