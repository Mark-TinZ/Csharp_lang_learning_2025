using System;
using lab1.Helpers;

namespace lab1.Tasks;
public class RecursionDateTask : Task
{
	public override string Name => "Recursion Date";
	public override string Description => "Calculate date overlap and natural number sum";

	public override void execute()
	{
		DisplayHeader();

		DateTime dtFirstStart = InputHelper.SafeReadDate("Enter first start date");
		DateTime dtFirstEnd = InputHelper.SafeReadDate("Enter first end date");

		if (dtFirstStart > dtFirstEnd)
		{
			Console.WriteLine("Error: first start date > first end date");
			return;
		}

		DateTime dtSecondStart = InputHelper.SafeReadDate("Enter second start date");
		DateTime dtSecondEnd = InputHelper.SafeReadDate("Enter second end date");

		if (dtSecondStart > dtSecondEnd)
		{
			Console.WriteLine("Error: second start date > second end date");
			return;
		}

		int iOverlapDays = CalculateOverLapDays(dtFirstStart, dtFirstEnd, dtSecondStart, dtSecondEnd);
		Console.WriteLine("N = " + iOverlapDays);

		if (iOverlapDays > 10000)
		{
			Console.WriteLine("Error: stack over flov");
			return;
		}

		if (iOverlapDays < 0)
		{
			Console.WriteLine("Error: N can't be negative");
		}

		long lSum = CalculateNaturalSum(iOverlapDays);
		Console.WriteLine("Sum natural number to " + iOverlapDays + " is " + lSum);
	}

	private int CalculateOverLapDays(DateTime dtFirstStart, DateTime dtFirstEnd, DateTime dtSecondStart, DateTime dtSecondEnd)
	{
		DateTime dtOverlapStart = dtFirstStart > dtSecondStart ? dtFirstStart : dtSecondStart;
		DateTime dtOverlapEnd = dtFirstEnd < dtSecondEnd ? dtFirstEnd : dtSecondEnd;

		if (dtOverlapStart > dtOverlapEnd) return 0;

		return (dtOverlapEnd - dtOverlapStart).Days + 1;
	}

	private long CalculateNaturalSum(int iNum)
	{
		if (iNum <= 0) return 0;
		return iNum + CalculateNaturalSum(iNum - 1);
	}
}