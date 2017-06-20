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
            /// Si no es null, asigna el valor al atributo
            /// </summary>
            public string Apellido
            {
                set
                {
                if (ValidarNombreApellido(value) != null)
                    this._apellido = value;
                else
                    this._apellido = "a";
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
                else
                    this._nombre = "a";
                }
                get { return this._nombre; }
            }

            public string StringToDni
            {
                set
                {
                    if(value!= null)
                    {
                        this._dni = ValidarDni(this.Nacionalidad, value);
                    }
                }
            }

            public Persona() { }

            public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            {
                if (nombre is null || apellido is null)
                    throw new ArgumentNullException("El nombre o el apellido son nulos");
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
                if (dni is null)
                    throw new ArgumentNullException("El dni es nulo.");
                this.StringToDni = dni;
            }

            public override string ToString()
            {
                StringBuilder bloque = new StringBuilder();
                bloque.AppendFormat("NOMBRE COMPLETO: {0}, {1}", this.Apellido, this.Nombre);
                bloque.AppendLine();
                bloque.AppendFormat("NACIONALIDAD: {0}", this.Nacionalidad);
                return bloque.ToString();
            }

            /// <summary>
            /// Retorna dni si fue validado. Caso contrario lanza excepcion de tipo nacionalidad invalida
            /// o dni invalido.
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
            /// Indica si la string pasada como parámetro posee solo caractéres no alfanuméricos.
            /// Si la string es no nula 
            /// </summary>
            /// <param name="dato"></param>
            /// <returns></returns>

            private string ValidarNombreApellido(string dato)
            {
                if(dato != null)
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

