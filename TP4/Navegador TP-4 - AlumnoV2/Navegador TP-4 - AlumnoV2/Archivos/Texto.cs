using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string _archivoLoc;

        public Texto(string archivo)
        {
            this._archivoLoc = archivo;
        }

        public bool guardar(string datos)
        {
            using (StreamWriter escritor = File.AppendText(this._archivoLoc))
            {
                escritor.WriteLine(datos);
                return true;
            }
        }

        public bool leer(out List<string> datos)
        {
            datos = new List<string>();
            using (StreamReader lector = new StreamReader(this._archivoLoc))
            {
                string linea = "a";
                while (linea != null)
                {
                    linea = lector.ReadLine();
                    datos.Add(linea);
                }
                return true;
            }

        }
    }
}
