using NUnit.Framework;
using System;
using lab1.Calculations;
using lab1.Exception;

namespace Tests.lab1
{
	[TestFixture]
	public class FormulaCalculatorTests
	{
		[Test]
		public void Calculate_ValidInputs_ReturnsCorrectResult()
		{
			// Formula: (x + y) / z + sqrt(x)
			// Let x=4, y=6, z=2
			// (4+6)/2 + sqrt(4) = 10/2 + 2 = 5 + 2 = 7
			
			double x = 4;
			double y = 6;
			double z = 2;

			double result = FormulaCalculator.Calculate(x, y, z);
			
			// Для дробного значения использую проверки приблизительно с погрешностью.
			Assert.AreEqual(7, result, 0.001);
		}

		[Test]
		public void Calculate_NegativeX_ThrowsValidationException()
		{
			// X не может быть отрицательным
			double x = -1;
			
			var ex = Assert.Throws<ValidationException>(() => FormulaCalculator.Calculate(x, 10, 5));
			Assert.That(ex!.Message, Is.EqualTo("X cannot be negative"));
		}

		[Test]
		public void Calculate_ZeroZ_ThrowsValidationException()
		{
			// Проверка деления на ноль
			double x = 4;
			double z = 0;

			var ex = Assert.Throws<ValidationException>(() => FormulaCalculator.Calculate(x, 10, z));
			Assert.That(ex!.Message, Is.EqualTo("Z cannot be zero"));
		}
	}
}