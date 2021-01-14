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
			
			

			Farmacia farm=new Farmacia();
			farm = asignandoEmpleados(farm);
			Menu(farm);
	
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		public static void Menu(Farmacia farm)
		{
			
			while (true)
			{	
				Console.Clear();
				Console.WriteLine("************************");
				Console.WriteLine("***     farmacia     ***");
				Console.WriteLine("************************\n");
				
				Console.WriteLine("Elija una opcion\n");
				Console.WriteLine("1- Agregar venta");
				Console.WriteLine("2- Ver datos de empleado");
				Console.WriteLine("3- Eliminar venta");
				Console.WriteLine("4- Porsentaje de venta de la quincena por OS ");
				Console.WriteLine("5- Listar venta de medicamentos por droga dada y plan determinado");
				Console.WriteLine("6- Empleado con mayor monto final vendido");
				Console.WriteLine("7- Lista de Ventas");
				Console.WriteLine("0- Salir");
				Console.WriteLine("-------------");
				string opcion=Console.ReadLine();
				 
					switch (opcion)
					{
						case "1":
							agregarVenta(farm);
							Console.ReadKey(true);
							break;
					
						case "2":
							Console.Clear();
							Console.WriteLine("**************************");
							Console.WriteLine("*** Lista de empleados ***");
							Console.WriteLine("**************************\n");
							
							verEmpleados(farm.todoEmpleados,0,farm.cantidadEmpleados);
							Console.ReadKey(true);
							break;
						
						case "3":
							eliminarVenta(farm);
							Console.ReadKey(true);
							break;
					
						case "4":
						
							porcentajeVentasOS(farm.verVentas);
							Console.ReadKey(true);
							break;
						case "5":
//							foreach(Venta v in farm.verVentas)
//							{
//								Console.WriteLine("NombreC {0}, Droga: {1}, NumFactura: {2}, Fecha y hora: {3}, Importe: {4}, ObraSocial: {5}",v.NombreComercial,v.Droga,v.NumFactura,v.FechaHora,v.Importe,v.ObraSocial);
//								
//							}
							Console.Clear();
							Console.WriteLine("************************");
							Console.WriteLine("***  Ventas buscadas ***");
							Console.WriteLine("************************\n");
							ventaPorDrogaPlan(farm);
							Console.ReadKey(true);
							break;
						case "6":
							mayormonto(farm);
							Console.ReadKey(true);
							break;
						case "7":
							Console.Clear();
							Console.WriteLine("************************");
							Console.WriteLine("*** Lista de Ventas ***");
							Console.WriteLine("************************\n");
							listaDeVentas(farm);
							Console.ReadKey(true);
							break;
						default:
							Console.WriteLine("programa terminado");
							break;
						}
				
					if((opcion =="0")){
					break;
					}
				
			}
		}
		
		
		public static Farmacia asignandoEmpleados(Farmacia farm)
		{
			Empleado Emp1=new Empleado();
			Emp1.Nombre="jose";
			Emp1.Apellido="zarate";
			Emp1.Codigo=100;
			Empleado Emp2=new Empleado();
			Emp2.Nombre="mario";
			Emp2.Apellido="gonzalez";
			Emp2.Codigo=101;
			Empleado Emp3=new Empleado();
			Emp3.Nombre="andres";
			Emp3.Apellido="inigues";
			Emp3.Codigo=102;
			Empleado Emp4=new Empleado();
			Emp4.Nombre="maria";
			Emp4.Apellido="zoraya";
			Emp4.Codigo=103;
			Empleado Emp5=new Empleado();
			Emp5.Nombre="ana";
			Emp5.Apellido="toroja";
			Emp5.Codigo=104;
			
			farm.agregarEmpleado(Emp1);
			farm.agregarEmpleado(Emp2);
			farm.agregarEmpleado(Emp3);
			farm.agregarEmpleado(Emp4);
			farm.agregarEmpleado(Emp5);
			return farm;
		}
		
		public static void agregarVenta(Farmacia farm)
		{
			
			
			while(true)
			{	
				
				Console.Clear();
				Console.WriteLine("************************");
				Console.WriteLine("***   Agregar Venta  ***");
				Console.WriteLine("************************\n");
				
				Venta vent=new Venta();
				Console.Write("--Nombre comercial: ");
				vent.NombreComercial=Console.ReadLine();
				
				Console.Write("--Droga: ");
				vent.Droga=Console.ReadLine();
				
				Console.Write("--ObraSocial: ");
				vent.ObraSocial=elijoOS();
				
				Console.Write("--Plan: ");
				vent.Plan=Console.ReadLine();
				
				Console.Write("--Numero de factura: ");
				vent.NumFactura=generaTicket(farm);
				//int.Parse(Console.ReadLine());
				
				Console.Write("--Importe: ");
				vent.Importe=double.Parse(Console.ReadLine());
				
				farm.agregarVenta(vent);
				Console.Clear();
				Console.WriteLine("--Codigo Empleado");
				agregarVentaEmpleado(farm,vent);
				
				Console.WriteLine("Agregar otra venta? S/N");
				string otro=Console.ReadLine().ToLower();
				if (otro != "s")
				{
					break;
				}
			}
		}
		
		public static string elijoOS()
		{
			
			while(true)
			{   
				Console.Clear();
			    Console.WriteLine("*** Elejir Obra Social ***\n");
				try
				{
					string [] OS=new string[]{"OSPA","OCCAC","PAMI","PARTICULAR"};
			
					for(int x =0; x<OS.Length;x++)
					{
						Console.WriteLine("{0}- {1}",x+1,OS[x]);
					}
			
					string opcion = OS[int.Parse(Console.ReadLine())-1];
					return opcion;
				}
				catch(IndexOutOfRangeException)
				{
					Console.Clear();
					Console.WriteLine("Opcion incorrecta");
					Console.ReadKey(true);
					
				}
				catch(FormatException)
				{
					Console.Clear();
					Console.WriteLine("No ingresos un numero");
					Console.ReadKey(true);
				}
			}
		}
		
		public static void agregarVentaEmpleado(Farmacia farm, Venta vent)
		{
			bool var=true;
			while(var){
				Console.Clear();
				Console.WriteLine("*** Empleado que realizo la venta ***\n");
				try
				{
					ArrayList empd=farm.todoEmpleados;
					verEmpleados(empd,0,empd.Count);
					vent.CodigoEmpleado=farm.verEmpleado(int.Parse(Console.ReadLine())-1).Codigo;
					foreach(Empleado em in empd)
					{
						if (vent.CodigoEmpleado == em.Codigo)
						{
							em.SumaImporte=vent.Importe;
							var=false;
						}
					}
				}
				catch(FormatException)
				{
					Console.WriteLine("No ingreso un numero");
				}
				catch(IndexOutOfRangeException)
				{
					Console.WriteLine("Opcion incorrecta");
				}
				catch(ArgumentOutOfRangeException)
				{
					Console.WriteLine("Opcion incorrecta");
				}
			}
		}
		
		public static void eliminarVenta(Farmacia farm)
		{
//			
				try
				{
	
					Console.Clear();
					Console.WriteLine("************************");
					Console.WriteLine("***  Eliminar Venta  ***");
					Console.WriteLine("************************\n");
					
					if(farm.cantidadVentas==0)
					{
						Console.WriteLine("No existen ventas registradas");
//						
					}
					else
					{
						Console.Write("Ingrese numero de ticket: ");
						int numt=int.Parse(Console.ReadLine());
						farm.eliminarVenta(numt);
						Console.Clear();
						Console.WriteLine("Venta eliminada");
						Console.ReadKey(true);
//						var=false;
					}
				}
				catch(TicketInvalido)
				{
					Console.Clear();
					Console.WriteLine("El numero del ticket no existe");
					Console.ReadKey(true);
				}
				catch(FormatException)
				{
					Console.Clear();
					Console.WriteLine("No ingreso un numero");
					Console.ReadKey(true);
				}
//			}
			
		}
		
		public static void porcentajeVentasOS(ArrayList ven)
		{
			try{
			Console.Clear();
			int Os=0;
			int total=ven.Count;
			foreach(Venta v in ven){
				
				DateTime hoy= DateTime.Now;
				if((v.ObraSocial != "")&(comparofechas(hoy,v.FechaHora,-15)==true))
				{
					Os++;	
				}	
			}
			double	obso=(double)Os*(100/total);
			Console.WriteLine("");
			
			Console.WriteLine("EL porcentaje de ventas de la quincena por Obra Social {0} %",obso);
			}
			catch(DivideByZeroException)
			{
				Console.WriteLine("No se encuentran ventas registradas");
			}
		}
		
		public static void ventaPorDrogaPlan(Farmacia farm)
		{

			
			ArrayList ventas = farm.verVentas;
			Console.Write("Droga: ");
			string droga = Console.ReadLine();
			Console.Write("Plan: ");
			string plan =Console.ReadLine();
			Console.Clear();
			int cont =0;
			foreach(Venta v in ventas)
			{
				if(droga == v.Droga & plan == v.Plan)
				{
					Console.WriteLine("\nVenta {0}.\nMarca: {1}\nDroga: {2}\nImporte: {3}\nFactura: {4}\n",cont+1,v.NombreComercial,v.Droga,v.Importe,v.NumFactura);
					cont++;
				}
			}
			if(cont==0)
			{
				Console.Write("No se encontraron ventas de esas caracteristicas");
			}
		}
		
		public static void mayormonto(Farmacia farm)	
		{
			Console.Clear();
			ArrayList empleados =farm.todoEmpleados;
			if(farm.cantidadVentas == 0)
			{
				Console.WriteLine("No hay ventas registradas");
			}
			else
			{
				int v =0;
				Empleado empleado = null;
			
				foreach(Empleado e in empleados)
				{
					if(e.SumaImporte > v)
					{
						v =(int)e.SumaImporte;
						empleado=e;
					}
				}
					Console.Write("El empleado con mayor monto vendido:\n\n{0} {1}\nMonto: {2}",empleado.Nombre,empleado.Apellido,empleado.SumaImporte);
			}
		}
		
		public static int generaTicket(Farmacia farm)
		{
			  
			
				if(farm.cantidadVentas == 0)
				{
					
					Console.WriteLine("500");
					int nroTicket = 500;
					return nroTicket;
					
				}
				else{
					
						Venta ultimaVenta=(Venta)farm.verVenta(farm.cantidadVentas-1);
					
						int ticketUltimaVent=(int)ultimaVenta.NumFactura;
					
						int nroTicket=ticketUltimaVent+1;
					
						Console.WriteLine("{0}",ticketUltimaVent+1);
						
						return nroTicket;
				}
			
		}
		
		public static bool comparofechas(DateTime hy,DateTime comp,int quin)
		{	
			DateTime feant=hy.AddDays(quin);
			int comparar=DateTime.Compare(feant,comp);
			if (quin<=0){
				if (comparar <= 0)
				{
					return true;
				}
				else{
					return comparofechas(hy,comp,quin+1);
				}	
			}
			else
			{
				return false;
			}
			
		}
		public static void listaDeVentas(Farmacia farm)
		{	int cont=0;
			foreach(Venta v in farm.verVentas)
			{
				Console.WriteLine("\nVenta {0}.\nMarca: {1}\nDroga: {2}\nImporte: {3}\nFactura: {4}\n",cont+1,v.NombreComercial,v.Droga,v.Importe,v.NumFactura);
			}
		}
		
		public static void verEmpleados(ArrayList empl,int pod,int tam)
		{	
			
			if(pod<tam)
			{	Empleado emp = (Empleado)empl[pod];
				Console.WriteLine("{0}- {1} {2} Codigo: {3}",pod+1,emp.Nombre,emp.Apellido,emp.Codigo);
				verEmpleados(empl,pod+1,tam);
			}
		}
	}
}