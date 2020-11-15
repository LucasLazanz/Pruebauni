using System;
using System.Collections;

namespace Farmacia
{
	/// <summary>
	/// Description of Farmacia.
	/// </summary>
	class Venta
	{
		string nombrecomercial,droga,obrasocila,plan;
		int codigoempleado,numfactura;
		double importe;
		DateTime fechahora;
		public Venta()
		{
			nombrecomercial=" ";
			droga=" ";
			obrasocila=" ";
			plan=" ";
			codigoempleado=0;
			fechahora=DateTime.Now;
			numfactura=0;
			importe=0;
		}
		
		public string NombreComercial
		{
			set{
				nombrecomercial=value;
			}
			get{
				return nombrecomercial;
			}
		}
		
		public string Droga
		{
			set{
				droga=value;
			}
			get{
				return droga;
			}
		}
		
		public string ObraSocial
		{
			set{
				obrasocila=value;
			}
			get{
				return obrasocila;
			}
		}
		
		public string Plan
		{
			set{
				plan=value;
			}
			get{
				return plan;
			}
		}
		
		public int CodigoEmpleado
		{
			set{
				codigoempleado=value;
			}
			get{
				return codigoempleado;
			}
		}
		public DateTime FechaHora
		{
			
			get{
				return fechahora;
			}
		}
		public int NumFactura
		{
			set{
				numfactura=value;
			}
			get{
				return numfactura;
			}
		}
		
		public double Importe
		{
			set{
				importe=value;
			}
			get{
				return importe;
			}
		}
	}
}