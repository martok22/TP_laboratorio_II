using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

    namespace EntidadesAbstractas
    {
        public abstract class Universitario : Persona
        {
            private int legajo;

            public Universitario() { }

            public Universitario(string nombre, string dni, ENacionalidad nacionalidad, string apellido, int legajo) : base(nombre, apellido, dni, nacionalidad)
            {
                this.legajo = legajo;
            }

            public override bool Equals(object obj)
            {
                if (obj is Universitario)
                    return true;
                return false;
            }

            protected virtual string MostrarDatos()
            {
            StringBuilder bloque = new StringBuilder();
            bloque.AppendLine(base.ToString());
            bloque.AppendLine("\nLEGAJO NUMERO: " + this.legajo);
            return bloque.ToString();
            }

            public static bool operator ==(Universitario pg1, Universitario pg2)
            {
                if (pg1 is null && pg2 is null) return true;
                if (pg1 is null || pg2 is null) return false;
                if (pg1.GetType() == pg2.GetType())
                    if (pg1.Dni == pg2.Dni || pg1.legajo == pg2.legajo)
                        return true;
                return false;
            }

            public static bool operator !=(Universitario pg1, Universitario pg2)
            {
                return !(pg1 == pg2);
            }

            protected abstract string ParticiparEnClase();

            public override string ToString()
            {
                StringBuilder bloque = new StringBuilder();
                bloque.AppendLine(base.ToString());
                bloque.AppendLine();
                bloque.AppendLine("LEGAJO NUMERO: "+this.legajo);
                return bloque.ToString();
            }

        }
    }

