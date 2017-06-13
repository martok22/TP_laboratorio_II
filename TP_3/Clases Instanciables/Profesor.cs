using System;
using EntidadesAbstractas;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        private static Random _random;
        private Queue<Universidad.EClases> _clasesDelDia;

        public Profesor():base() { }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, dni, nacionalidad, apellido, id)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        static Profesor()
        {
            Profesor._random = new Random();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder bloque = new StringBuilder();
            bloque.AppendLine("CLASES DEL DIA: ");
            bloque.AppendLine("" + this._clasesDelDia.ElementAt(0));
            bloque.Append("" + this._clasesDelDia.ElementAt(1));           
            return bloque.ToString();
        }

        public void _randomClases()
        {
            this._clasesDelDia.Enqueue((Universidad.EClases)Profesor._random.Next(0, 6));
            this._clasesDelDia.Enqueue((Universidad.EClases)Profesor._random.Next(0, 6));
        }

        public override string ToString()
        {
            StringBuilder bloque = new StringBuilder();
            bloque.AppendLine(base.ToString());
            bloque.AppendLine(ParticiparEnClase());
            return bloque.ToString();
        }
    }
}
