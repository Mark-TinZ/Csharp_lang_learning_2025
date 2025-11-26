using NUnit.Framework;
using lab1.Calculations;

namespace Tests.lab1
{
	[TestFixture]
	public class StringAnalyzerTests
	{
		// Проверка на совпадение

		[Test]
		public void CheckExactMatch_IdenticalStrings_ReturnsTrue()
		{
			bool result = StringAnalyzer.CheckExactMatch("Hello", "Hello");
			Assert.IsTrue(result);
		}

		[Test]
		public void CheckExactMatch_DifferentCase_ReturnsFalse()
		{
			bool result = StringAnalyzer.CheckExactMatch("Hello", "hello");
			Assert.IsFalse(result);
		}

		[Test]
		public void CheckNormalizedMatch_DifferentCaseAndSpaces_ReturnsTrue()
		{
			// Logic in source: trims and lowers string, replaces multiple spaces with single space
			string s1 = "  Hello   World  ";
			string s2 = "hello world";
			
			bool result = StringAnalyzer.CheckNormalizedMatch(s1, s2);
			Assert.IsTrue(result);
		}

		// Проверка на обратные

		[Test]
		public void CheckReversed_ValidPalindromeLogic_ReturnsTrue()
		{
			// Logic in source: Reverses str2 and compares ordinal ignore case
			string s1 = "ABC";
			string s2 = "cba";

			bool result = StringAnalyzer.CheckReversed(s1, s2);
			Assert.IsTrue(result);
		}

		[Test]
		public void CheckReversed_NonReversedStrings_ReturnsFalse()
		{
			string s1 = "ABC";
			string s2 = "ABC";

			bool result = StringAnalyzer.CheckReversed(s1, s2);
			Assert.IsFalse(result);
		}

		// Проверка на патерны

		[Test]
		public void AnalyzerStringPatterns_ValidEmail_DetectsEmail()
		{
			string input = "test@example.com";
			var result = StringAnalyzer.AnalyzerStringPatterns(input);

			// Можно проверять отдельно взяв функции напрямую
			// Но я взял целеком функцию потому что возвращаю ссылки на значения
			Assert.IsTrue(result.IsEmail, "Should be identified as Email");
			Assert.IsFalse(result.IsPhone, "Should not be number phone");
			Assert.IsFalse(result.IsIP, "Should not be IP");
			Assert.IsTrue(result.IsAnyValid);
		}

		[Test]
		public void AnalyzerStringPatterns_InvalidEmail_ReturnsFalse()
		{
			string input = "testexample.com"; // Без @
			var result = StringAnalyzer.AnalyzerStringPatterns(input);

			Assert.IsFalse(result.IsEmail);
			Assert.IsFalse(result.IsAnyValid);
		}

		[Test]
		public void AnalyzerStringPatterns_ValidIP_DetectsIP()
		{
			string input = "192.168.1.1";
			var result = StringAnalyzer.AnalyzerStringPatterns(input);

			Assert.IsTrue(result.IsIP, "Should be identified as IP");
			Assert.IsFalse(result.IsEmail, "Should not be Email");
			Assert.IsFalse(result.IsPhone, "Should not be number phone");
			Assert.IsTrue(result.IsAnyValid);
		}

		[Test]
		public void AnalyzerStringPatterns_InvalidIP_ReturnsFalse()
		{
			string input = "999.999.999.999"; // Проверка на соответсвие диапазона
			var result = StringAnalyzer.AnalyzerStringPatterns(input);

			Assert.IsFalse(result.IsIP);
			Assert.IsFalse(result.IsAnyValid);
		}

		[Test]
		public void AnalyzerStringPatterns_ValidPhone_DetectsPhone()
		{
			string phone = "89001232312"; 
			
			var result = StringAnalyzer.AnalyzerStringPatterns(phone);
			Assert.IsTrue(result.IsPhone, "Should be identified as Phone");
			Assert.IsFalse(result.IsEmail, "Should not be Email");
			Assert.IsFalse(result.IsIP, "Should not be IP");
			Assert.IsTrue(result.IsAnyValid);
		}

		// TODO: Можно сделать списки проверяемых данных и сделать в виде цикла для проверки \
		// так можно будет проверить сразу пачку различных сложных ситуаций. \
		// Для полуавтоматизации создания сложных и качественных данных для тестов можно использовать AI-агентов.
	}
}