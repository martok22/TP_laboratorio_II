using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Clases
{
	public abstract class Universitario : Persona
	{
		private int legajo;
		
		public Universitario()
		{
			
		}
		
		public Universitario(string nombre, int dni, ENacionalidad nacionalidad, string apellido, int legajo):base(nombre,dni,nacionalidad,apellido)
		{
			this.legajo=legajo;
		}
		
		public override bool Equals (object obj)
		{
			if (obj is Universitario)
				return true;
			return false;
		}
		
		protected virtual string MostrarDatos()
		{
			return this.ToString();
		}
		
		public static bool operator == (Universitario pg1, Universitario pg2)
		{
			if (pg1.Equals(pg2)
				if(pg1.Dni == pg2.Dni || pg1.legajo == pg2.legajo)
					return true;
			return false;
		}
		
		public static bool operator != (Universitario pg1, Universitario pg2)
		{
			if !(pg1==pg2) return true;
			return false;
		}
		
		protected virtual ParticiparEnClase()
		{
			
		}
	}
}