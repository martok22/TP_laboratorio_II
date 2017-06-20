using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Excepciones;

namespace Archivo
{
    public class Xml<T> : IArchivo<T>
    {

        /// <summary>
        /// Escribe el objeto de tipo T pasado como parametro (datos) a un archivo pasado como parámetro (archivo).
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(T));
                using (StreamWriter escritor = new StreamWriter(archivo))
                {
                    serializador.Serialize(escritor, datos);
                    return true;
                }
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
            

        }

        /// <summary>
        /// Lee los datos de un archivo pasado como parámetro, y los devuelve como un objeto del tipo T en el parámetro out datos.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {

            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(T));
                using (StreamReader lector = new StreamReader(archivo))
                {
                    datos = (T)serializador.Deserialize(lector);
                    return true;
                }
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
            
        }


    }
}
