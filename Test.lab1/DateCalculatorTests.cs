using NUnit.Framework;
using System;
using lab1.Calculations;
using lab1.Exception;

namespace Tests.lab1
{
	[TestFixture]
	public class DateCalculatorTests
	{
		// Проверяем как вычисляются дни

		[Test]
		public void CalculateOverlapDays_RangesDoNotOverlap_ReturnsZero()
		{
			var start1 = new DateTime(2023, 1, 1);
			var end1 = new DateTime(2023, 1, 5);
			var start2 = new DateTime(2023, 1, 10);
			var end2 = new DateTime(2023, 1, 15);

			int result = DateCalculator.CalculateOverlapDays(start1, end1, start2, end2);
			
			Assert.AreEqual(0, result);
		}

		[Test]
		public void CalculateOverlapDays_RangesOverlap_ReturnsCorrectDays()
		{
			// Диапазон 1: с 1-го по 10-е
			// Диапазон 2: с 5-го по 15-е
			// Пересечение: 5-е, 6-е, 7-е, 8-е, 9-е, 10-е = 6 дней
			var start1 = new DateTime(2023, 1, 1);
			var end1 = new DateTime(2023, 1, 10);
			var start2 = new DateTime(2023, 1, 5);
			var end2 = new DateTime(2023, 1, 15);

			int result = DateCalculator.CalculateOverlapDays(start1, end1, start2, end2);

			Assert.AreEqual(6, result);
		}

		// Проверка на исключения

		[Test]
		public void CalculateOverlapDays_InvalidFirstRange_ThrowsValidationException()
		{
			var start = new DateTime(2023, 1, 10);
			var end = new DateTime(2023, 1, 5); // Меньше начальной

			var ex = Assert.Throws<ValidationException>(() => 
				DateCalculator.CalculateOverlapDays(start, end, DateTime.Now, DateTime.Now.AddDays(1)));

			Assert.That(ex!.Message, Does.Contain("First start date cannot be after first end date"));
		}

		[Test]
		public void CalculateOverlapDays_InvalidSecondRange_ThrowsValidationException()
		{
			var start = new DateTime(2023, 1, 1);
			var end = new DateTime(2023, 1, 5);
			var start2 = new DateTime(2023, 1, 10);
			var end2 = new DateTime(2023, 1, 5); // Меньше начальной

			var ex = Assert.Throws<ValidationException>(() =>
				DateCalculator.CalculateOverlapDays(start, end, start2, end2));

			Assert.That(ex!.Message, Does.Contain("Second start date cannot be after second end date"));
		}

		// Проверка рекурсии

		[Test]
		public void CalculateNaturalSum_PositiveNumber_ReturnsSum()
		{
			// Sum of 1 to 5 = 15
			long result = DateCalculator.CalculateNaturalSum(5);
			Assert.AreEqual(15, result);
		}

		[Test]
		public void CalculateNaturalSum_Zero_ReturnsZero()
		{
			long result = DateCalculator.CalculateNaturalSum(0);
			Assert.AreEqual(0, result);
		}

		[Test]
		public void CalculateNaturalSum_NegativeNumber_ThrowsValidationException()
		{
			var ex = Assert.Throws<ValidationException>(() => DateCalculator.CalculateNaturalSum(-5));
			Assert.That(ex!.Message, Is.EqualTo("Number cannot be negative for natural sum"));
		}

		[Test]
		public void CalculateNaturalSum_TooLargeNumber_ThrowsCalculationException()
		{
			// Проверка источника: при числе > 10000 выбрасывается CalculationException
			var ex = Assert.Throws<CalculationException>(() => DateCalculator.CalculateNaturalSum(10001));
			Assert.That(ex!.Message, Is.EqualTo("Number too large for recursive calculation"));
		}
	}
}