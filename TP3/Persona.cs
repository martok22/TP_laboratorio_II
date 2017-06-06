using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Clases
{
	public abstract class Persona
	{
		private string _apellido;
		public string Apellido
		{
			set { this._apellido = ValidarNombreApellido(value); }
			get { return this._apellido; }
		}
		
		private int _dni;
		public int Dni
		{
			set { this._dni = ValidarDni(value); }
			get { return this._dni; }
		}
		private ENacionalidad _nacionalidad;
		public ENacionalidad Nacionalidad
		{
			set { this._nacionalidad = value; }
			get { return this._nacionalidad;}
		}
		private string _nombre;
		public string Nombre
		{
			set { this._nombre = ValidarNombreApellido(value); }
			get { return this._nombre; }
		}
		
		public string StringToDni
		{
			set 
			{
				int auxDni;
				if (Int.TryParse(value, out auxDni)) 
				{
					
				}
			}
		}
		
		public Persona(){}
		
		public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
		{
			this._nombre = nombre;
			this._apellido = apellido;
			this._nacionalidad = nacionalidad;
		}
		
		public Persona (string nombre, string apellido, int dni, ENacionalidad nacionalidad)
		:this(nombre,apellido,nacionaldiad)
		{
			this._dni = dni;
		}
		
		public Persona (string nombre, string apellido, string dni, ENacionalidad nacionalidad):
		this(nombre,apellido,nacionaldiad)
		{
			this._dni = Int.Parse(dni);
		}
		
		public override string ToString()
		{
			StringBuilder bloque = new StringBuilder();
			bloque.AppendLine("Nombre: ", this.Nombre);
			bloque.AppendLine("Dni: ", this.Dni);
			bloque.AppendLine("Nacionalidad: ", this.Nacionalidad);
			bloque.AppendLine("Apellido: ", this.Apellido);
			return bloque.ToString();
		}
		
		private int ValidarDni(ENacionalidad nacionalidad, int dato)
		{
			if (dato > 0 && dato < 9999999 && nacionalidad == ENacionalidad.Argentino)
				return dato;
			else 
				throw New DniInvalidoException();
		}
		
		private int ValidarDni(ENacionalidad nacionalidad, string dato)
		{
			int auxDato = StringToDni(dato);
			if (auxDato > 0 && dato < 9999999 && nacionalidad == ENacionalidad.Argentino)
				return auxDato;
			else
				throw New DniInvalidoException();
		}
		
		private string ValidarNombreApellido(string dato)
		{
			char aux = '';
			for (int contador = 0; contador < dato.length(); contador++)
			{
				if ( dato[contador] > 39 || dato[contador] <52 )
				{
					return "0";
				}
			}
			return dato;
		}
	}
}