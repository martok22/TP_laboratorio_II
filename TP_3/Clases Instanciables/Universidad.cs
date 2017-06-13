using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Excepciones;

using EntidadesAbstractas;
using System.Xml.Serialization;

namespace Clases_Instanciables
{
    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Profesor))]
    [XmlInclude(typeof(Universitario))]
    [XmlInclude(typeof(Persona))]

    public class Universidad
    {
        private List<Alumno> _alumnos;
        private List<Profesor> _profesores;
        private List<Jornada> _jornadas;

        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Jornadas = new List<Jornada>();
            this.Profesores = new List<Profesor>();
        }

        public List<Alumno> Alumnos { get => _alumnos; set => _alumnos = value; }
        public List<Profesor> Profesores { get => _profesores; set => _profesores = value; }
        public List<Jornada> Jornadas { get => _jornadas; set => _jornadas = value; }

        public Jornada this[int i]
        {
            get
            {
                return this.Jornadas.ElementAt(i);
            }
            set
            {
                if (i < this.Jornadas.Count) // Si el indice es menor, agrega, para no sobreescribir
                    this.Jornadas.Add(value);
                else
                    this[i] = value;
            }
        }

        public enum EClases
        {
            Natacion, Laboratorio, Pilates, Legislacion, SPD, Programacion
        }

        public static bool operator ==(Universidad u, Alumno a)
        {
            return estaUniversitario(u, a);
        }

        public static bool operator ==(Universidad u, Profesor i)
        {
            return estaUniversitario(u, i);
        }

/// <summary>
/// Si la clase esta como substring del ToString del Profesor, retorna al profesor. Caso contrario lanza excepcion
/// </summary>
/// <param name="u"></param>
/// <param name="clases"></param>
/// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clases)
        {
            if (u.Profesores.Count!=0)
            {
                foreach (Profesor p in u.Profesores)
                {
                    if (p.ToString().Contains("" + clases))
                        return p;
                }
            }
            throw new SinProfesorException();
        }

        public static bool operator !=(Universidad u, Alumno a)
        {
            return !(u == a);
        }

        /// <summary>
        /// Retorna el primer profesor cuya clase no está contenida en el ToString del mismo. Caso contrario excepcion
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clases"></param>
        /// <returns></returns>

        public static Profesor operator !=(Universidad u, EClases clases)
        {
            if (u.Profesores.Count != 0)
            {
                foreach (Profesor p in u.Profesores)
                {
                    if (!p.ToString().Contains("" + clases))
                        return p;
                }
            }
            throw new SinProfesorException();
        }

        public static bool operator !=(Universidad u, Profesor i)
        {
            return !(u == i);
        }

        /// <summary>
        /// Devuelve true si el universitario está en la lista de profesores o alumnos, false caso contrario.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="u"></param>
        /// <returns></returns>

        public static bool estaUniversitario(Universidad g, Universitario u)
        {
            if (u is Profesor)
            {
                foreach (Profesor item in g.Profesores)
                    if ((Universitario)u == (Universitario)item) return true;
            }
            if (u is Alumno)
            {
                foreach (Alumno item in g.Alumnos)
                    if ((Universitario)u == (Universitario)item) return true;
            }
            return false;
        }

        public static Universidad operator + (Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
                return u;
            }
            throw new AlumnoRepetidoException();
        }

        public static Universidad operator + (Universidad u, Profesor p)
        {
            if (u != p)
                u.Profesores.Add(p);
            return u;
        }

        /// <summary>
        /// Busca profesor que tenga la clase en su lista de clases. Si no encuentra, retorna la universidad.
        /// Caso contrario, crea jornada, añade jornada a la lista de jornadas, y los alumnos que coincidan con la clase
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>

        public static Universidad operator +(Universidad u, EClases clase)
        {
            Profesor auxProfesor = new Profesor();
            auxProfesor = (u == clase);
            if (auxProfesor == null)
                return u;
            Jornada jornada = new Jornada(clase, auxProfesor);
            u.Jornadas.Add(jornada);
            foreach (Alumno a in u.Alumnos)
            {
                if (a==clase)
                    jornada.Alumnos.Add(a);
            }
            return u;
        }

        public override string ToString()
        {
            StringBuilder bloque = new StringBuilder();
            foreach(Jornada j in this.Jornadas)
            {
                bloque.AppendLine(j.ToString()); 
            }
            return bloque.ToString();
        }

        public static bool Guardar(Universidad gim)
        {
            Archivo.Xml<Universidad> XmlParaGuardar = new Archivo.Xml<Universidad>();
            return XmlParaGuardar.Guardar("Universidad.xml", gim);
        }

        public string Leer(Universidad gim)
        {
            Universidad retorno;
            Archivo.Xml<Universidad> XmlParaLeer = new Archivo.Xml<Universidad>();
            XmlParaLeer.Leer("Universidad.txt", out retorno);
            return retorno.ToString();
        }
    }
}

