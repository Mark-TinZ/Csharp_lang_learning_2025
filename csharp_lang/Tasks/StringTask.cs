// StringTask.cs
using System;
using System.Text.RegularExpressions;
using System.Xml.XPath;
using lab1.Calculations;
using lab1.Exception;
using lab1.Helpers;

namespace lab1.Tasks;

public class StringTask : Task
{
	public override int MenuOrder => 4;
	public override string Name => "String Operations";
	public override string Description => "Perform various string operations and validations";

	public override void Execute()
	{
		DisplayHeader();

		try
		{
			string str1 = InputHelper.SafeReadString("Enter first string", ValidateString);
			string str2 = InputHelper.SafeReadString("Enter second string", ValidateString);

			// Вызываем нашу мульти функцию с проверками
			ProcessStringValidations(str1, str2);
		}
		catch (AppException ex)
		{
			DisplayError(ex.Message);
		}
	}

	public override void Execute(Dictionary<string, string> args)
	{
		DisplayHeader();

		string str1 = InputHelper.SafeReadStringArgs(args, "-s1", ValidateString);
		string str2 = InputHelper.SafeReadStringArgs(args, "-s2", ValidateString);

		// Вызываем нашу мульти функцию с проверками
			ProcessStringValidations(str1, str2);
	}

	private void ProcessStringValidations(string str1, string str2)
	{
		Console.WriteLine("Exact match: " + StringAnalyzer.CheckExactMatch(str1, str2));
		Console.WriteLine("Normalized match: " + StringAnalyzer.CheckNormalizedMatch(str1, str2));
		Console.WriteLine("Is reversed: " + StringAnalyzer.CheckReversed(str1, str2));
		Console.WriteLine();

		AnalyzeStringPatterns(str1, "First string");
		AnalyzeStringPatterns(str2, "Second string");
	}

	private void AnalyzeStringPatterns(string str, string label)
	{
		Console.WriteLine($"{label} analysis: ");
		var analysis = StringAnalyzer.AnalyzerStringPatterns(str);

		Console.WriteLine($"	Email: {analysis.IsEmail}");
		Console.WriteLine($"	Phone: {analysis.IsPhone}");
		Console.WriteLine($"	IP: {analysis.IsIP}");
		Console.WriteLine($"	Any pattern matched: {analysis.IsAnyValid}");
		Console.WriteLine();
	}

	private bool ValidateString(string str) => !string.IsNullOrWhiteSpace(str);
}