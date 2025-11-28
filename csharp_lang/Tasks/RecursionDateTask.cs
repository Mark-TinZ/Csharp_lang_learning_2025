using System;
using System.Security.Cryptography.X509Certificates;
using lab1.Calculations;
using lab1.Exception;
using lab1.Helpers;

namespace lab1.Tasks;
public class RecursionDateTask : Task
{
	public override int MenuOrder => 3;
	public override string Name => "Recursion Date";
	public override string Description => "Calculate date overlap and natural number sum";

	public override void Execute()
	{
		DisplayHeader();

		try
		{
			DateTime firstStart = InputHelper.SafeReadDate("Enter first start date");
			DateTime firstEnd = InputHelper.SafeReadDate("Enter first end date", end => end >= firstStart);
			DateTime secondStart = InputHelper.SafeReadDate("Enter second start date");
			DateTime secondEnd = InputHelper.SafeReadDate("Enter second end date", end => end >= secondStart);

			int overlapDays = DateCalculator.CalculateOverlapDays(firstStart, firstEnd, secondStart, secondEnd);

			Console.WriteLine($"Overlap days: {overlapDays}");

			if (overlapDays > 0)
			{
				long sum = DateCalculator.CalculateNaturalSum(overlapDays);
				DisplayResult($"Sum of natural numbers up to {overlapDays} is {sum}");
			}
			else
			{
				DisplayResult("No overlap between date ranges");
			}
		}
		catch (AppException ex)
		{
			DisplayError(ex.Message);
		}
	}

	public override void Execute(Dictionary<string, string> args)
	{
		DisplayHeader();

		DateTime firstStart = InputHelper.SafeReadDateArgs(args, "-d1st");
		DateTime firstEnd = InputHelper.SafeReadDateArgs(args, "-d1end", end => end >= firstStart);
		DateTime secondStart = InputHelper.SafeReadDateArgs(args, "-d2st");
		DateTime secondEnd = InputHelper.SafeReadDateArgs(args, "-d2end", end => end >= secondStart);

		int overlapDays = DateCalculator.CalculateOverlapDays(firstStart, firstEnd, secondStart, secondEnd);

		if (overlapDays > 0)
		{
			long sum = DateCalculator.CalculateNaturalSum(overlapDays);
			DisplayResult($"Sum of natural numbers up to {overlapDays} is {sum}");
		}
		else
		{
			DisplayResult("No overlap between date ranges");
		}	
	}
}