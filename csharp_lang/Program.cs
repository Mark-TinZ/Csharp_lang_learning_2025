using System;
using System.Collections.Generic;
using System.Linq;
using lab1.Tasks;
using lab1.Helpers;
using System.Xml.Linq;

namespace lab1;
internal class Program
{
	private static List<Tasks.Task> _tasks = new()
	{
		new ExitTask(),
		new HelloWorldTask(),
		new CalcFormulaTask(),
		new RecursionDateTask(),
		new StringTask()
	};

	static void Main(string[] args)
	{
		Console.WriteLine("C# lab application");
		Console.WriteLine();

		while (true)
		{
			try
			{
				DisplayMenu();
				int choice = GetMenuChoice();
				ExecuteTask(choice);
			}
			catch (System.Exception ex)
			{
				Console.WriteLine($"Unexpected error: {ex.Message}");
				Console.WriteLine();
			}
		}
	}

	private static void DisplayMenu()
	{
		Console.WriteLine("Menu:");
		foreach (var task in _tasks.OrderBy(t => t.MenuOrder))
		{
			Console.WriteLine($"[{task.MenuOrder}] {task.Name}");
		}
	}

	private static int GetMenuChoice()
	{
		return InputHelper.SafeReadInteger(">>", choice => choice >= 0 && choice < _tasks.Count);
	}

	private static void ExecuteTask(int choice)
	{
		var task = _tasks.FirstOrDefault(t => t.MenuOrder == choice);
		if (task != null)
		{
			Console.WriteLine();
			task.Execute();
			Console.WriteLine();
		}
	}
}
