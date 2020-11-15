using System;
using System.Collections;

namespace Farmacia
{
	/// <summary>
	/// Description of Farmacia.
	/// </summary>
	class Empleado
	{
		string nombre,apellido;
		int codigo;
		double sumaimporte;
		DateTime fechahora;
		public Empleado()
		{
			nombre=" ";
			apellido=" ";
			codigo=0;
			sumaimporte=0;
		}
		
		public string Nombre
		{
			set{
				nombre=value;
			}
			get{
				return nombre;
			}
		}
		
		public string Apellido
		{
			set{
				apellido=value;
			}
			get{
				return apellido;
			}
		}
	
		public int Codigo
		{
			set{
				codigo=value;
			}
			get{
				return codigo;
			}
		}
		
		public double SumaImporte
		{
			set{
				sumaimporte+=value;
			}
			get{
				return sumaimporte;
			}
		}
	}
}