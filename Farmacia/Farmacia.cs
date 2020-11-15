/*
 * Creado por SharpDevelop.
 * Usuario: Lucas
 * Fecha: 10/11/2020
 * Hora: 22:36
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections;

namespace Farmacia
{
	/// <summary>
	/// Description of Farmacia.
	/// </summary>
	class Farmacia
	{
		ArrayList ventas, empleados;
		public Farmacia()
		{
			ventas=new ArrayList();
			empleados=new ArrayList();
		}
		
		public void agregarVenta(Venta unaV)
		{
			ventas.Add(unaV);
		}
		
		public void eliminarVenta(int nticket)
		{
			for(int x=0;x<ventas.Count;x++)
			{
				Venta v=(Venta)ventas[x];
				if(v.NumFactura == nticket)
				{
					foreach(Empleado e in empleados)
					{
						if(v.CodigoEmpleado==e.Codigo)
						{
							e.SumaImporte=-v.Importe;
						}
					}
					ventas.Remove(v);
				}
				else{
					throw new TicketInvalido();}
			}
			
		}
		
		public Venta verVenta(int i)
		{
			Venta v= (Venta) ventas[i];
			return v;
		}
		
		public ArrayList verVentas
		{
			get{
				return ventas;
			}
		}
		public int cantidadVentas
		{
			get{
				return ventas.Count;
			}
		}
		
		public void agregarEmpleado(Empleado em)
		{
			empleados.Add(em);
		}
		
		public void eliminarEmpleado(Empleado em)
		{
			empleados.Remove(em);
		}
		
		public Empleado verEmpleado(int i)
		{
			Empleado em=(Empleado) empleados[i];
			return em;
		}
		
		public ArrayList todoEmpleados
		{
			get{
				return empleados;
			}
		}
		
		public int cantidadEmpleados
		{
			get{
				return empleados.Count;
			}
		}
	}
}
