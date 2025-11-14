using System;
using System.Collections.Generic;
using lab1.Tasks;
using lab1.Helpers;

namespace lab1;
internal class Program
{

	private static List<Tasks.Task> tasks = new List<Tasks.Task>
	{
		new ExitTask(),
		new HelloWorldTask(),
		new CalcFormulaTask(),
		new RecursionDateTask(),
		new StringTask()
	};

	static void Main(string[] args)
	{
		while (true)
		{

			int menuItem = GetMenuItem();

			if (menuItem < 0 || menuItem >= tasks.Count)
			{
				Console.WriteLine("Error choice");
				continue;
			}

			tasks[menuItem].execute();
			Console.WriteLine();
		}
	}

	private static int GetMenuItem()
	{
		Console.WriteLine("Menu item:");
		Console.WriteLine("[0] Exit");
		Console.WriteLine("[1] Hello World!");
		Console.WriteLine("[2] Calc: (X+Y)/Z+sqrt(X)");
		Console.WriteLine("[3] Recursion date");
		Console.WriteLine("[4] String");

		// int iMenu = Convert.ToInt32(Console.ReadLine());
		return InputHelper.SafeReadInteger(">>");
	}
}
