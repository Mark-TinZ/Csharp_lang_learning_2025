using System;
using System.Globalization;


namespace lab1.Helpers;
public static class InputHelper
{
	public static int SafeReadInteger(string preffix)
	{
		while (true)
		{
			if (!string.IsNullOrEmpty(preffix))
			{
				Console.Write(preffix + " ");
			}

			string sValue = Console.ReadLine();
			if (Int32.TryParse(sValue, out int iValue))
			{
				return iValue;
			}
			Console.WriteLine("Parse error. Please enter a valid integer.");
		}
	}

	public static double SafeReadDouble(string preffix)
	{
		while (true)
		{
			if (!string.IsNullOrEmpty(preffix))
			{
				Console.Write(preffix + " ");
			}

			string sValue = Console.ReadLine();
			if (Double.TryParse(sValue, out double fValue))
			{
				return fValue;
			}
			Console.WriteLine("Parse error. Please enter a valid number.");
		}
	}

	public static DateTime SafeReadDate(string preffix)
	{
		while (true)
		{
			Console.Write(preffix + " (DD.MM.YYYY): ");
			string sValue = Console.ReadLine();

			if (DateTime.TryParseExact(sValue, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dtValue))
			{
				return dtValue;
			}
			Console.WriteLine("Parse error. Please enter a valid date");
		}
	}

	public static string SafeReadString(string preffix)
	{
		Console.Write(preffix + ": ");
		return Console.ReadLine();
	}

}