using System;
using System.Globalization;
using lab1.Exception;


namespace lab1.Helpers;
public static class InputHelper
{
	public static int SafeReadInteger(string preffix, Func<int, bool>? validator = null)
	{
		while (true)
		{
			try
			{
				if (!string.IsNullOrEmpty(preffix))
				{
					Console.Write(preffix + " ");
				}

				string sValue = Console.ReadLine() ?? ""; // Либо текст с консоли либо пустая строка.
				if (Int32.TryParse(sValue, out int iValue))
				{
					// Встраиваем наш валидатор для проверки нашего числа.
					// Invoke - это вызов делегата (функции передаваемого объекта)
					if (validator?.Invoke(iValue) == false)
					{
						throw new ValidationException("Value validation failed");
					}

					return iValue;
				}
				throw new InputExcrption("Invalid integer format");
			} 
			catch (AppException ex)
			{
				Console.WriteLine($"Error: {ex.Message}. Please try again.");
			}
		}
	}

	public static double SafeReadDouble(string preffix, Func<double, bool>? validator = null)
	{
		while (true)
		{
			try
			{
				if (!string.IsNullOrEmpty(preffix))
				{
					Console.Write(preffix + " ");
				}

				string sValue = Console.ReadLine() ?? "";
				if (Double.TryParse(sValue, out double fValue))
				{
					if (validator?.Invoke(fValue) == false)
					{
						throw new ValidationException("Value validation failed");
					}

					return fValue;
				}
				throw new InputExcrption("Invalid number format");
			}
			catch (AppException ex)
			{
				Console.WriteLine($"Error: {ex.Message}. Please try again.");
			}
		}
	}

	public static DateTime SafeReadDate(string preffix, Func<DateTime, bool>? validator = null)
	{
		while (true)
		{
			try
			{
				Console.Write(preffix + " (DD.MM.YYYY): ");
				string sValue = Console.ReadLine() ?? "";

				if (DateTime.TryParseExact(sValue, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dtValue))
				{
					if (validator?.Invoke(dtValue) == false)
					{
						throw new ValidationException("Date validation failed");
					}

					return dtValue;
				}
				throw new InputExcrption("Invalid date format");
			}
			catch (AppException ex)
			{
				Console.WriteLine($"Error: {ex.Message}. Please try again.");
			}
		}
	}

	public static string SafeReadString(string? preffix = "", Func<string, bool>? validator = null)
	{
		while (true)
		{
			try
			{
				if (!string.IsNullOrEmpty(preffix))
				{
					Console.Write(preffix + " ");
				}

				string sValue = Console.ReadLine() ?? "";

				if (validator?.Invoke(sValue) == false)
				{
					throw new ValidationException("String validation failed");
				}

				return sValue;
			}
			catch (AppException ex)
			{
				Console.WriteLine($"Error: {ex.Message}. Please try again.");
			}
		}
	}

}