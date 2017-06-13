using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Clases_Instanciables
{

    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

        public List<Alumno> Alumnos { get => _alumnos; set => _alumnos = value; }
        public Universidad.EClases Clase { get => _clase; set => _clase = value; }
        public Profesor Instructor { get => _instructor; set => _instructor = value; }

        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor):this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }

        public static bool Guardar(Jornada jornada)
        {
            Archivo.Texto textoParaGuardar = new Archivo.Texto();
            return textoParaGuardar.Guardar("Jornada.txt", jornada.ToString());
        }

        public static string Leer()
        {
            string retorno;
            Archivo.Texto textoParaLeer = new Archivo.Texto();
            textoParaLeer.Leer("Jornada.txt", out retorno);
            return retorno;
        }

        public override string ToString()
        {
            StringBuilder bloque = new StringBuilder();
            bloque.AppendLine("JORNADA: ");
            bloque.AppendLine("CLASE DE " + this.Clase + " POR "+this.Instructor.ToString());
            bloque.AppendLine("ALUMNOS: ");
            foreach(Alumno a in this.Alumnos)
            {
                bloque.AppendLine(a.ToString());
            }
            bloque.AppendLine("< ----------------------------------------------------------->");
            return bloque.ToString();
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j!=a)
                j.Alumnos.Add(a);
            return j;
        }

        public static bool operator == (Jornada j, Alumno a)
        {
            foreach(Alumno item in j.Alumnos)
            {
                if (item == a) return true;
            }
            return false;
        }

        public static bool operator != (Jornada j, Alumno a)
        {
            if (!(j == a)) return true;
            return false;
        }


    }
}
