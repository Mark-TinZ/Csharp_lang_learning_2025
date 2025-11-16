using System;
using System.Data.Common;
using lab1.Exception;

namespace lab1.Calculations;

public static class FormulaCalculator
{
	public static double Calculate(double x, double y, double z)
	{
		if (x < 0)
		{
			throw new ValidationException("X cannot be negative");
		}
		if (z == 0)
		{
			throw new ValidationException("Z cannot be zero");
		}

		return (x + y) / z + Math.Sqrt(x);
	}
}