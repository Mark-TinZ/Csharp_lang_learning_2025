// StringTask.cs
using System;
using System.Text.RegularExpressions;
using System.Xml.XPath;
using lab1.Helpers;

namespace lab1.Tasks;

public class ValidationException : Exception
{
	public ValidationException(string message) : base(message) {}
}

public class StringTask : Task
{
	public override string Name => "String Operations";
	public override string Description => "Perform various string operations and validations";

	public override void execute()
	{
		DisplayHeader();

		try
		{
			string str1 = InputHelper.SafeReadString("Enter first string");
			string str2 = InputHelper.SafeReadString("Enter second string");

			// Вызываем нашу мульти функцию с проверками
			ProcessStringValidations(str1, str2);
		}
		catch (ValidationException ex)
		{
			Console.WriteLine("Validation Error: ", ex.Message);
		}
		catch (Exception ex)
		{
			Console.WriteLine("Unexpected Error: ", ex.Message);
		}
	}

	private void ProcessStringValidations(string str1, string str2)
	{
		try
		{
			// 1. Проверка совпадения по символьно
			bool exactMatch = CheckExactMatch(str1, str2);
			Console.WriteLine($"Exact match: {exactMatch}");
		}
		catch (ValidationException ex)
		{
			Console.WriteLine("Exact math validation failed: ", ex.Message);
		}

		try
		{
			// 2. Привести к одному регистру удалить пробелы в начале и в конце + дублированные пробелы
			bool normelizedMatch = CheckNormalizedMatch(str1, str2);
			Console.WriteLine($"Normalized match: {normelizedMatch}");
		}
		catch (ValidationException ex)
		{
			Console.WriteLine("Normalized math validation failed: ", ex.Message);
		}

		try
		{
			// 3. Является ли 1 строка перевертышем другой
			bool isReversed = CheckReversed(str1, str2);
			Console.WriteLine($"Is reversed: {isReversed}");

			Console.WriteLine(); // прочто чтобы было лучше читаемо
		}
		catch (ValidationException ex)
		{
			Console.WriteLine("Reversed check failed: ", ex.Message);
		}
		
		// 4. Являются ли строки  email, номером, ip-адремом
		Console.WriteLine($"First string \"{str1}\" patterns:");
		CheckStringPatterns(str1);

		Console.WriteLine($"Second string \"{str2}\" patterns:");
		CheckStringPatterns(str2);
	}

	private bool CheckExactMatch(string str1, string str2)
	{
		bool res = str1 == str2;

		if (!res)
		{
			throw new ValidationException("String do not match exacly character by charachter");
		}

		return res;
	}

	private bool CheckNormalizedMatch(string str1, string str2)
	{
		string normalized1 = NormalizeString(str1);
		string normalized2 = NormalizeString(str2);
		bool res = normalized1 == normalized2;

		if (!res)
		{
			throw new ValidationException("Строки не совпадают после нормализации");
		}

		return res;
	}

	private string NormalizeString(string str)
	{
		if (string.IsNullOrEmpty(str))
		{
			return str;
		}

		str = str.ToLower();
		str = str.Trim();
		str = Regex.Replace(str, @"\s+", " "); // @ это литеральная страка (не экранировать спец символы)
		return str;
	}

	private bool CheckReversed(string str1, string str2)
	{
		if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
		{
			throw new ValidationException("One or both strings are empty");
		}

		char[] charArray = str2.ToCharArray();
		Array.Reverse(charArray);
		string reversedStr2 = new string(charArray);

		// Сравнение идет по порядковым значением символа. Мы не учитываем регистр
		bool res = str1.Equals(reversedStr2, StringComparison.OrdinalIgnoreCase);

		if (!res)
		{
			throw new ValidationException("Strings are not reverses of each other");
		}

		return res;
	}

	private bool IsEmail(string str)
	{
		if (string.IsNullOrEmpty(str)) { return false; }

		return Regex.IsMatch(str, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
	}

	private bool IsPhone(string str)
	{
		if (string.IsNullOrEmpty(str)) { return false; }

		return Regex.IsMatch(str, @"^(\+7|7|8)?[\s\s\-]?\(?[489][0-9]{2}\)?[\s\s\-]?[0-9]{3}[\s\-]?");
	}

	private bool IsIP(string str)
	{
		if (string.IsNullOrEmpty(str)) { return false; }

		return Regex.IsMatch(str, @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");
	}

	private void CheckStringPatterns(string str)
	{
		try
		{
			// Проверка emale
			bool isEmail = IsEmail(str);
			Console.WriteLine($"Email: {isEmail}");

			// Проверка на номер телефона
			bool isPhone = IsPhone(str);
			Console.WriteLine($"Phone: {isPhone}");

			// Проверка IP-адреса
			bool isIP = IsIP(str);
			Console.WriteLine($"IP: {isIP}");

			if (!isEmail && !isPhone && !isIP)
			{
				throw new ValidationException("Строка не является ни поччтой, нни номером телефона, ни ip-адресом");
			}
		}
		catch (ValidationException ex)
		{
			Console.WriteLine("Pattern validation: ", ex.Message);
		}
	}
}