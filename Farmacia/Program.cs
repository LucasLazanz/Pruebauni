/*
 * Created by SharpDevelop.
 * User: Lucas
 * Date: 12/11/2020
 * Time: 11:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace Farmacia
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Creando farmacia");
			Empleado Emp1=new Empleado();
			Emp1.Nombre="jose";
			Emp1.Apellido="zarate";
			Emp1.Codigo=000;
			Empleado Emp2=new Empleado();
			Emp2.Nombre="mario";
			Emp2.Apellido="gonzalez";
			Emp2.Codigo=001;
			Empleado Emp3=new Empleado();
			Emp3.Nombre="andres";
			Emp3.Apellido="inigues";
			Emp3.Codigo=002;
			Empleado Emp4=new Empleado();
			Emp4.Nombre="maria";
			Emp4.Apellido="zoraya";
			Emp4.Codigo=003;
			Empleado Emp5=new Empleado();
			Emp5.Nombre="ana";
			Emp5.Apellido="toroja";
			Emp5.Codigo=004;

			Farmacia farm=new Farmacia();
			farm.agregarEmpleado(Emp1);
			farm.agregarEmpleado(Emp2);
			farm.agregarEmpleado(Emp3);
			farm.agregarEmpleado(Emp4);
			farm.agregarEmpleado(Emp5);
			
			while (true)
			{
				Console.WriteLine("Elija una opcion; ");
				Console.WriteLine("1)Agregar venta");
				Console.WriteLine("2)Ver datos de empleado; ");
				Console.WriteLine("3)Eliminar venta");
				Console.WriteLine("4)Porsentaje de venta de la quincena por OS ");
				Console.WriteLine("5)Listar venta de medicamentos por droga dada y plan determinado");
				Console.WriteLine("6)Empleado con mayor monto final vendido");
				Console.WriteLine("0)Salir");
				Console.WriteLine("-------------");
				int opcion=int.Parse(Console.ReadLine());
				if((opcion>=1)&(opcion<=6)){
					switch (opcion)
					{
					case 1:
							while(true)
							{
								Venta vent=new Venta();
								Console.WriteLine("--Nombre comercial");
								vent.NombreComercial=Console.ReadLine();
								Console.WriteLine("--Droga");
								vent.Droga=Console.ReadLine();
								Console.WriteLine("--ObraSocial");
								vent.ObraSocial=Console.ReadLine();
								Console.WriteLine("--Plan");
								vent.Plan=Console.ReadLine();
								Console.WriteLine("--Codigo Empleado");
								vent.CodigoEmpleado=int.Parse(Console.ReadLine());
								Console.WriteLine("--Numero de factura");
								vent.NumFactura=int.Parse(Console.ReadLine());
								Console.WriteLine("--Importe");
								vent.Importe=double.Parse(Console.ReadLine());
								farm.agregarVenta(vent);
								ArrayList empd=farm.todoEmpleados;
								foreach(Empleado em in empd)
								{
									if (vent.CodigoEmpleado == em.Codigo)
									{
										em.SumaImporte=vent.Importe;
									}
								}
								Console.WriteLine("Agregar otra venta? S/N");
								string otro=Console.ReadLine();
								if (otro!="s")
									break;
							}
							break;
					
					case 2:
							Console.WriteLine("----Lista de empleados----");
						ArrayList emps=farm.todoEmpleados;
						foreach(Empleado em in emps)
						{
							Console.WriteLine("Nombre:{0} , Apellido:{1}, Codigo:{2}, Importe Total:{3} $",em.Nombre,
							em.Apellido,em.Codigo,
							em.SumaImporte);
							Console.WriteLine("--------");
						}
						break;
						
					case 3:
						try{
						Console.WriteLine("----Eliminar Venta----");
						Console.WriteLine("Ingrese numero de ticket");
						int numt=int.Parse(Console.ReadLine());
						farm.eliminarVenta(numt);
						Console.WriteLine("Venta eliminada");
						}
						catch(TicketInvalido){
							Console.WriteLine("El numero del ticket no existe");}
						break;
					
					case 4:
						int con=0;
						foreach(Venta v in farm.verVentas)
						{
							string tipo=(string)v.ObraSocial;
							if(tipo != "")
							{
								con++;Console.WriteLine("{0},{1}",tipo,con);
							}
							
						}
						porcentaje(farm.cantidadVentas,con);
						break;
					case 5:
						foreach(Venta v in farm.verVentas)
						{
							Console.WriteLine("NombreC {0},Droga{1},NumFactura{2},Fecha y hora{3},Importe{4}",v.NombreComercial,v.Droga,v.NumFactura,v.FechaHora,v.Importe);
						}
						break;
					default:
						Console.WriteLine("programa terminado");
						break;
					}
				}
				else{
					break;
				}
				
			}
		
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		public static void porcentaje(int total,int os)
		{
			double	obso=(double)os*(100/total);
			Console.WriteLine("EL porcentaje de ventas de la quincena por Obra Social {0} %",obso);
		}
		
	}
}