using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        private Universidad.EClases _clasesQueToma;
        private EEstadoCuenta _estadoCuenta;

        public Alumno():base() { }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clase)
            : base(nombre, dni, nacionalidad, apellido, id) { }


        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clase, EEstadoCuenta EstadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, clase)
        {
            this._estadoCuenta = EstadoCuenta;
            this._clasesQueToma = clase;
        }

        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }

        public static bool operator == (Alumno a, Universidad.EClases clase)
        {
            return (a._clasesQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor);
        }

        public static bool operator != (Alumno a, Universidad.EClases clase)
        {
            return (a._clasesQueToma != clase);
        }

        protected override string MostrarDatos()
        {
            return this.ToString();
        }

        public override string ToString()
        {
            StringBuilder bloque = new StringBuilder();
            bloque.AppendLine(base.ToString());
            bloque.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta);
            bloque.AppendLine(ParticiparEnClase());
            return bloque.ToString();
        }

        protected override string ParticiparEnClase()
        {
            return String.Format("TOMA CLASE DE {0}", this._clasesQueToma);
        }


    }
}
