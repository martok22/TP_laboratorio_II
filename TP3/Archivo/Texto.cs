using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivo
{

    public class Texto : IArchivo<string>
    {

        /// <summary>
        /// Escribe en el PATH pasado como parametro (archivo), el string de datos pasado como parámetro.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                using (StreamWriter escritor = new StreamWriter(archivo))
                {
                    escritor.WriteLine(datos);
                }
                return true;
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }

        }
        /// <summary>
        /// Lee los datos del PATH pasado como parametro (archivo), y los retorna como una string en el parametro datos. 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            StringBuilder bloque = new StringBuilder();
            string linea = "";
            try
            {
                using (StreamReader lector = new StreamReader(archivo))
                {
                    while ((linea = lector.ReadLine()) != null)
                    {
                        bloque.AppendLine(linea);
                    }
                    datos = bloque.ToString();
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
