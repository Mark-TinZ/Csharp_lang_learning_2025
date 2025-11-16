using System;
using lab1.Helpers;
using lab1.Calculations;
using lab1.Exception;


namespace lab1.Tasks;
public class CalcFormulaTask : Task
{
	public override int MenuOrder => 2;
	public override string Name => "Calculate Formula";
	public override string Description => "Calculate formula: (X+Y)/Z+sqrt(X)";

	public override void Execute()
	{
		DisplayHeader();

		try
		{
			double fX = InputHelper.SafeReadDouble("X =", ValidationX);
			double fY = InputHelper.SafeReadDouble("Y =");
			double fZ = InputHelper.SafeReadDouble("Z =", ValidationZ);

			double result = FormulaCalculator.Calculate(fX, fY, fZ);
			DisplayResult($"{result:F3}");
		}
		catch (AppException ex)
		{
			DisplayError(ex.Message);
		}
	}

	private bool ValidationX(double x) => x >= 0;
	private bool ValidationZ(double z) => z != 0;
}