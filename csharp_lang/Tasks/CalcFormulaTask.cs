using System;
using lab1.Helpers;


namespace lab1.Tasks;
public class CalcFormulaTask : Task
{
	public override string Name => "Calculate Formula";
	public override string Description => "Calculate formula: (X+Y)/Z+sqrt(X)";

	public override void execute()
	{
		DisplayHeader();

		double fX = ReadX();
		double fY = InputHelper.SafeReadDouble("Y = ");
		double fZ = ReadZ();

		double res = CalculateFormula(fX, fY, fZ);
		Console.WriteLine($"{res:F3}");
	}

	private double ReadX()
	{
		while (true)
		{
			double fX = InputHelper.SafeReadDouble("X = ");
			if (fX < 0)
			{
				Console.WriteLine("Error: X can't be < 0");
				continue;
			}
			return fX;
		}
	}

	private double ReadZ()
	{
		while (true)
		{
			double fZ = InputHelper.SafeReadDouble("Z = ");
			if (fZ == 0)
			{
				Console.WriteLine("Error: Z can't be == 0");
				continue;
			}
			return fZ;
		}
	}

	private double CalculateFormula(double fX, double fY, double fZ)
	{
		return (fX + fY) / fZ + Math.Sqrt(fX);
	}
}