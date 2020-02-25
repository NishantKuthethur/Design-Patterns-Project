using System;

namespace kimursh
{
	public interface IMaintenance
	{
		string getDescription();
		double getCost();
	}
	public class HDD : IMaintenance
	{
		public string getDescription()
		{
			return "HDD";
		}
		public double getCost()
		{
			return 450000.0;
		}
	}
	public class Excav : IMaintenance
	{
		public string getDescription()
		{
			return "Excavation Machine";
		}
		public double getCost()
		{
			return 399999.0;
		}
	}
	public class Cranes : IMaintenance
	{
		public string getDescription()
		{
			return "Cranes";
		}
		public double getCost()
		{
			return 500000.0;
		}
	}

	public abstract class packages : IMaintenance
	{
		private IMaintenance _main;

		public packages(IMaintenance aAcc)
		{
			this._main = aAcc;
		}
		public virtual string getDescription()
		{
			return this._main.getDescription();
		}

		public virtual double getCost()
		{
			return this._main.getCost();
		}
	}

	public class Cleaning : packages
	{
		public Cleaning(IMaintenance aAcc)
		: base(aAcc)
		{

		}

		public override string getDescription()
		{
			return base.getDescription() + " ,Cleaning";

		}

		public override double getCost()
		{
			return base.getCost() + 2000.0;
		}
	}


	public class kim_maintenance
	{
		IMaintenance objHDD = new HDD();
		IMaintenance objExcav = new Excav();
		IMaintenance objCranes = new Cranes();

		public void maintenance()
		{
			int ch;
			Console.WriteLine("Maintenance is available for the following machines:");
			Console.WriteLine("1. HDD Machines");
			Console.WriteLine("2. Excavation Machines");
			Console.WriteLine("3. Cranes");
			ch = Convert.ToInt32(Console.ReadLine());

			switch (ch)
			{
				case 1:
					Console.WriteLine("If cleaning required press 1");
					String x = Console.ReadLine();
					if (x == "1")
					{
						packages objDecorator = new Cleaning(objHDD);
						Console.WriteLine("Description  " + objDecorator.getDescription());
						Console.WriteLine("\n\n");
						Console.Write("Total Price: " + objDecorator.getCost());
						Console.WriteLine("\n\n");
					}
					else
					{
						Console.WriteLine(objHDD.getDescription());
						Console.WriteLine("\n\n");
						Console.WriteLine(objHDD.getCost());
						Console.WriteLine("\n\n");

					}
					break;
				case 2:
					Console.WriteLine("If cleaning required press 1");
					String y = Console.ReadLine();
					if (y == "1")
					{
						packages objDecorator = new Cleaning(objExcav);
						Console.WriteLine("Description  " + objDecorator.getDescription());
						Console.WriteLine("\n\n");
						Console.Write("Total Price: " + objDecorator.getCost());
						Console.WriteLine("\n\n");

					}
					else
					{
						Console.WriteLine(objExcav.getDescription());
						Console.WriteLine("\n\n");
						Console.WriteLine(objExcav.getCost());
						Console.WriteLine("\n\n");

					}
					break;
				case 3:
					Console.WriteLine("If cleaning required press 1");
					String z = Console.ReadLine();
					if (z == "1")
					{
						packages objDecorator = new Cleaning(objCranes);
						Console.WriteLine("Description " + objDecorator.getDescription());
						Console.WriteLine("\n\n");
						Console.Write("Total Price: " + objDecorator.getCost());
						Console.WriteLine("\n\n");
					}
					else
					{
						Console.WriteLine(objCranes.getDescription());
						Console.WriteLine("\n\n");
						Console.WriteLine(objCranes.getCost());
						Console.WriteLine("\n\n");
					}
					break;

			}
		}

		public kim_maintenance()
		{
		}
	}

	public interface IServices
	{
		string getDescription();
		double getCost();
	}

	public interface IExtraTime
	{
		double getExtraCost();
	}
	public abstract class aServices : IServices, IExtraTime {
		public string desc;
		public int price;
		public aServices(string desc,int price) {
			this.desc = desc;
			this.price = price;
		}
		public abstract string getDescription();
		public abstract double getCost();
		public abstract double getExtraCost();

	}


public class PC : aServices
		{
		public PC(string desc,int price):base(desc,price) { }
			public override string getDescription()
			{
				return base.desc;
			}
			public override double getCost()
			{
				return base.price;
			}

			public override double getExtraCost()
			{ 
				int cost;
				Console.WriteLine("If consultant hired for more than 2 hours, Extra fee is charged");
				Console.WriteLine("Enter how long the consultant is required for in hours: ");
				int time = Convert.ToInt32(Console.ReadLine());
				if (time > 2){
					cost = 50000 + ((time - 2) * 10000);
					return cost;
				}
				else
				{
					cost = 50000;
					return cost;
				}

				
			}
		}
		public class CVA : IServices
		{
			public string getDescription()
			{
				return "Component Value Analysis";
			}
			public double getCost()
			{
				return 250000.0;
			}
		}

		public class kim_services
		{
			public void services()
			{
				aServices c = new PC("Professional Consultancy", 50000);
				IServices cva = new CVA(); 
				int ch;
				Console.WriteLine("We offer services in:");
				Console.WriteLine("1. Professional consulting");
				Console.WriteLine("2. Component-value analysis");
				ch = Convert.ToInt32(Console.ReadLine());
				switch (ch)
				{
					case 1:
						Console.WriteLine(c.getDescription());
						Console.WriteLine("\n");
						Console.WriteLine(c.getCost());
						Console.WriteLine("\n");
						Console.WriteLine(c.getExtraCost());
						Console.WriteLine('\n');
						break;
					case 2:
						Console.WriteLine(cva.getDescription());
						Console.WriteLine("\n");
						Console.WriteLine(cva.getCost());
						Console.WriteLine("\n");
						break;
				}
			}
		}

		public class kim_buy
		{
			public void buy()
			{
				Console.WriteLine("1. Gears - Rs. 200");
				Console.WriteLine("2. Spanner - Rs. 500");
				Console.WriteLine("3. Hammer - Rs. 100");
				int ch = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Enter the quantity");
				int quantity = Convert.ToInt32(Console.ReadLine());
				int price = 1;
				switch (ch)
				{
					case 1:
						price = 200 * quantity;
						break;
					case 2:
						price = 500 * quantity;
						break;
					case 3:
						price = 100 * quantity;
						break;
				}

				Console.WriteLine("You need to pay Rs. " + price + " through our portal");
			}
		}

		public class Program
		{
			public static void Main(string[] args)
			{
				int ch;
				Console.WriteLine("Welcome to KIMURSH!");
				while (true)
				{
					Console.WriteLine("1. Maintenance");
					Console.WriteLine("2. Services");
					Console.WriteLine("3. Purchase");
					ch = Convert.ToInt32(Console.ReadLine());
					switch (ch)
					{
						case 1:
							kim_maintenance km = new kim_maintenance();
							km.maintenance();
							break;
						case 2:
							kim_services ks = new kim_services();
							ks.services();
							break;
						case 3:
							kim_buy kb = new kim_buy();
							kb.buy();
							break;
			
					}
				}
			}
		}
	}
