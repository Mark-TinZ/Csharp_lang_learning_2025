using System;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using lab1.Exception;

namespace lab1.Calculations;

public class StringAnalyzer
{
	public static bool CheckExactMatch(string str1, string str2)
	{
		return str1 == str2;
	}

	public static bool CheckNormalizedMatch(string str1, string str2)
	{
		string normalized1 = NormalizeString(str1);
		string normalized2 = NormalizeString(str2);

		return normalized1 == normalized2;
	}

	public static bool CheckReversed(string str1, string str2)
	{
		if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
		{
			return false;
		}

		char[] charArray = str2.ToCharArray();
		Array.Reverse(charArray);
		string reversedStr2 = new string(charArray);

		return str1.Equals(reversedStr2, StringComparison.OrdinalIgnoreCase);
	}

	public static StringAnalysisResult AnalyzerStringPatterns(string str)
	{
		return new StringAnalysisResult
		{
			IsEmail = IsEmail(str),
			IsPhone = IsPhone(str),
			IsIP = IsIP(str)
		};
	}
	private static string NormalizeString(string str)
	{
		if (string.IsNullOrEmpty(str))
		{
			return str;
		}

		return Regex.Replace(str.ToLower().Trim(), @"\s+", " ");
	}

	private static bool IsEmail(string str)
	{
		if (string.IsNullOrEmpty(str)) { return false; }

		return Regex.IsMatch(str, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
	}

	private static bool IsPhone(string str)
	{
		if (string.IsNullOrEmpty(str)) { return false; }

		return Regex.IsMatch(str, @"^(\+7|7|8)?[\s\s\-]?\(?[489][0-9]{2}\)?[\s\s\-]?[0-9]{3}[\s\-]?");
	}

	private static bool IsIP(string str)
	{
		if (string.IsNullOrEmpty(str)) { return false; }

		return Regex.IsMatch(str, @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");
	}

	public record StringAnalysisResult
	{
		public bool IsEmail { get; init; }
		public bool IsPhone { get; init; }
		public bool IsIP { get; init; }
		public bool IsAnyValid => IsEmail || IsPhone || IsIP;
	}
}