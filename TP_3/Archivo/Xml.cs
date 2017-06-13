using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Archivo
{
    public class Xml<T> : IArchivo<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Guardar(string archivo, T datos)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(T));
            using (StreamWriter escritor = new StreamWriter(archivo))
            {
                serializador.Serialize(escritor, datos);
                return true;
            }

        }

        public bool Leer(string archivo, out T datos)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(T));
            using (StreamReader lector = new StreamReader(archivo))
            {
                datos = (T)serializador.Deserialize(lector);
                return true;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
