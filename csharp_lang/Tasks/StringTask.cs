using System;
using System.Text.RegularExpressions;
using lab1.Helpers;

namespace lab1.Tasks;
public class StringTask : Task
{
	public override string Name => "String Operations";
	public override string Description => "Perform various string operations and validations";

	public override void execute()
	{
		DisplayHeader();
		
		string str1 = InputHelper.SafeReadString("Enter first string");
		string str2 = InputHelper.SafeReadString("Enter second string");

		// 1. Проверка совпадения по символьно
		bool exactMatch = CheckExactMatch(str1, str2);
		Console.WriteLine($"Exact match: {exactMatch}");

		// 2. Привести к одному регистру удалить пробелы в начале и в конце + дублированные пробелы
		bool normelizedMatch = CheckNormalizedMatch(str1, str2);
		Console.WriteLine($"Normalized match: {normelizedMatch}");

		// 3. Является ли 1 строка перевертышем другой
		bool isReversed = CheckReversed(str1, str2);
		Console.WriteLine($"Is reversed: {isReversed}");

		Console.WriteLine(); // прочто чтобы было лучше читаемо

		// 4. Являются ли строки  email, номером, ip-адремом
		Console.WriteLine($"First string \"{str1}\" patterns:");
		CheckStringPatterns(str1);

		Console.WriteLine($"Second string \"{str2}\" patterns:");
		CheckStringPatterns(str2);
	}

	private bool CheckExactMatch(string str1, string str2)
	{
		return str1 == str2;
	}

	private bool CheckNormalizedMatch(string str1, string str2)
	{
		string normalized1 = NormalizeString(str1);
		string normalized2 = NormalizeString(str2);
		return normalized1 == normalized2;
	}

	private string NormalizeString(string str)
	{
		str = str.ToLower();
		str = str.Trim();
		str = Regex.Replace(str, @"\s+", " "); // @ это литеральная страка (не экранировать спец символы)
		return str;
	}

	private bool CheckReversed(string str1, string str2)
	{
		char[] charArray = str2.ToCharArray();
		Array.Reverse(charArray);
		string reversedStr2 = new string(charArray);

		// Сравнение идет по порядковым значением символа. Мы не учитываем регистр
		return str1.Equals(reversedStr2, StringComparison.OrdinalIgnoreCase);
	}

	private void CheckStringPatterns(string str)
	{
		// Проверка emale
		bool isEmail = Regex.IsMatch(str, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
		Console.WriteLine($"Email: {isEmail}");

		// Проверка на номер телефона
		bool isPhone = Regex.IsMatch(str, @"^(\+7|7|8)?[\s\s\-]?\(?[489][0-9]{2}\)?[\s\s\-]?[0-9]{3}[\s\-]?");
		Console.WriteLine($"Phone: {isPhone}");

		// Проверка IP-адреса
		bool isIP = Regex.IsMatch(str, @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");
		Console.WriteLine($"IP: {isIP}");
	}
}