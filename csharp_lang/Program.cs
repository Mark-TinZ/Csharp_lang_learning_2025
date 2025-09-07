using System;

namespace lab1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				switch (getMenuItem())
				{
					case 0:
						Console.WriteLine("Exit");
						return;
					case 1:
						Console.WriteLine("Hello World!");
						break;
					case 2:
						formulaCalculation();
						break;
					default:
						Console.WriteLine("Error choise");
						break;
				}
			}
		}

		private static int getMenuItem()
		{
			Console.WriteLine("Menu item:");
			Console.WriteLine("[0] Exit");
			Console.WriteLine("[1] Hello World!");
			Console.WriteLine("[2] Calc: (X+Y)/Z+sqrt(X)");
			// int iMenu = Convert.ToInt32(Console.ReadLine());
			int iMenu = SafeReadInteger(">>");

			// TODO: Можно добавить дополнительную проверку на допустимые значения iMenu

			return iMenu;
		}

		private static void formulaCalculation()
		{
			// Console.WriteLine("(X+Y)/Z+sqrt(X)");
			// Инициализируем, для области видимости
			double fX, fY, fZ;

			// Проверка на недопустимые значения в формуле
			while (true)
			{
				fX = SafeReadDouble("X = ");
				if (fX < 0)
				{
					Console.WriteLine("Error: X can't be < 0");
					continue;
				}
				break;
			}
			fY = SafeReadDouble("Y = ");

			// Проверка на недопустимые значения в формуле
			while (true)
			{
				fZ = SafeReadDouble("Z = ");
				if (fZ == 0)
				{
					Console.WriteLine("Error: Z can't be == 0");
					continue;
				}
				break;
			}

			double dValue = (fX + fY) / fZ + Math.Sqrt(fX);

			Console.WriteLine($"{dValue:F3}");
		}

		private static int SafeReadInteger(string message)
		{
			while (true)
			{
				if (!string.IsNullOrEmpty(message)) { Console.Write(message + " "); }

				string sValue = Console.ReadLine();
				int iValue = 0;
				if (Int32.TryParse(sValue, out iValue))
				{
					return iValue;
				}

				Console.WriteLine("Parse error. Please enter a valid integer.");
			}
		}

		private static double SafeReadDouble(string message)
		{
			while (true)
			{
				if (!string.IsNullOrEmpty(message)) { Console.Write(message + " "); }

				string sValue = Console.ReadLine();
				double fValue = 0;
				if (Double.TryParse(sValue, out fValue))
				{
					return fValue;
				}

				Console.WriteLine("Parse error. Please enter a valid number.");
			}
		}
	}
}