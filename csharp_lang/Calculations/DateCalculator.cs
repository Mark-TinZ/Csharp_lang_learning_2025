using System;
using System.Data;
using lab1.Exception;

namespace lab1.Calculations;

public static class DateCalculator
{
	public static int CalculateOverlapDays(DateTime firstStart, DateTime firstEnd, DateTime secondStart, DateTime secondEnd)
	{
		if (firstStart > firstEnd)
		{
			throw new ValidationException("First start date cannot be after first end date");
		}
		if (secondStart > secondEnd)
		{
			throw new ValidationException("Second start date cannot be after second end date");
		}

		DateTime overlapStart = firstStart > secondStart ? firstStart : secondStart;
		DateTime overlapEnd = firstEnd < secondEnd ? firstEnd : secondEnd;

		if (overlapStart > overlapEnd)
		{
			return 0;
		}

		return (overlapEnd - overlapStart).Days + 1;
	}

	public static long CalculateNaturalSum(int number)
	{
		if (number < 0)
		{
			throw new ValidationException("Number cannot be negative for natural sum");
		}
		if (number > 10000)
		{
			throw new CalculationException("Number too large for recursive calculation");
		}

		return CalculateNaturalSumRecursive(number);
	}

	private static long CalculateNaturalSumRecursive(int number)
	{
		if (number <= 0)
		{
			return 0;
		}
		return number + CalculateNaturalSumRecursive(number - 1);
	}
}