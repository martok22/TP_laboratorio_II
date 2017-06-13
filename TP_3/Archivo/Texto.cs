using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivo
{
    public class Texto : IArchivo<string>
    {
        public IEnumerator<string> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Guardar(string archivo, string datos)
        {
            using (StreamWriter escritor = new StreamWriter(archivo))
            {
                escritor.WriteLine(datos);
            }
            return true;

        }

        public bool Leer(string archivo, out string datos)
        {
            StringBuilder bloque = new StringBuilder();
            string linea;
            using (StreamReader lector = new StreamReader(archivo))
            {
               while((linea = lector.ReadLine())!=null)
                {
                    bloque.AppendLine(linea);
                }
                datos = bloque.ToString();
            }
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
