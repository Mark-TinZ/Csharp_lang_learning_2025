using System;
using System.Diagnostics;

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
						CalcFormula();
						break;
					case 3:
						RecursionDate();
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
			Console.WriteLine("[3] Recursion date");
			// int iMenu = Convert.ToInt32(Console.ReadLine());
			int iMenu = SafeReadInteger(">>");

			// TODO: Можно добавить дополнительную проверку на допустимые значения iMenu

			return iMenu;
		}

		private static void CalcFormula()
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

		private static void RecursionDate()
		{
			DateTime dtFirstStart = SafeReadDate("Enter first start date");
			DateTime dtFirstEnd = SafeReadDate("Enter first end date");

			if (dtFirstStart > dtFirstEnd)
			{
				Console.WriteLine("error: first date > end date");
				return;
			}

			DateTime dtSecondStart = SafeReadDate("Enter second start date");
			DateTime dtSecondEnd = SafeReadDate("Enter second end date");

			if (dtSecondStart > dtSecondEnd)
			{
				Console.WriteLine("error: first date > end date");
				return;
			}

			int iOverlapDays = CalculateOverlapDays(dtFirstStart, dtFirstEnd, dtSecondStart, dtSecondEnd);
			Console.WriteLine("N = " + iOverlapDays);

			if (iOverlapDays > 10000)
			{
				Console.WriteLine("Что с дубу рухнулся " + iOverlapDays + " считать?");
				return;
			}

			if (iOverlapDays < 0)
			{
				Console.WriteLine("Error: N can't be negative");
			}

			long lSum = CalculateNaturalSum(iOverlapDays);
			Console.WriteLine("Sum natural number to " + iOverlapDays + " is " + lSum);
		}

		private static int CalculateOverlapDays(DateTime dtFirstStart, DateTime dtFirstEnd, DateTime dtSecondStart, DateTime dtSecondEnd)
		{
			DateTime dtOverlapStart = dtFirstStart > dtSecondStart ? dtFirstStart : dtSecondStart;
			DateTime dtOverlapEnd = dtFirstEnd < dtSecondEnd ? dtFirstEnd : dtSecondEnd;

			if (dtOverlapStart > dtOverlapEnd)
				{return 0;}

			return (dtOverlapEnd - dtOverlapStart).Days + 1;
		}

		private static long CalculateNaturalSum(int iNum)
		{
			if (iNum <= 0)
				{return 0;}

			return iNum + CalculateNaturalSum(iNum - 1);
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

		private static DateTime SafeReadDate(string message)
		{
			while (true)
			{
				Console.Write(message + " (DD.MM.YYYY): ");
				string sValue = Console.ReadLine();

				if (DateTime.TryParseExact(sValue, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dtValue))
					return dtValue;

				Console.WriteLine("Parse error.");
			}
		}
	}
}