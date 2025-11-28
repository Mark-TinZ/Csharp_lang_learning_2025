using System;
using System.Collections.Generic;
using System.Linq;
using lab1.Tasks;
using lab1.Exception;

namespace lab1.Helpers;
internal class ApplicationRunner
{
	private static List<Tasks.Task> _tasks = new()
	{
		new ExitTask(),
		new HelloWorldTask(),
		new CalcFormulaTask(),
		new RecursionDateTask(),
		new StringTask()
	};

	public void run(string[] args)
	{
		if (args.Length > 0)
		{
			Console.WriteLine("Start application (Console mode)\n");
			ExecuteTaskConsoleLine(args);
		}
		else
		{
			Console.WriteLine("Start application (Interaction mode)\n");
			RunInteractive();
		}
	}

	private void RunInteractive()
	{
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

	private static void ExecuteTaskConsoleLine(string[] args)
	{
		try
		{
			var parsedArgs = ParseArguments(args);

			if (!parsedArgs.TryGetValue("-mi", out string menuIndexStr) || !int.TryParse(menuIndexStr, out int menuIndex))
			{
				Console.WriteLine("Error: Missing or invalid -mi argument.");
				return;
			}

			var task = _tasks.FirstOrDefault(t => t.MenuOrder == menuIndex);
			if (task == null)
			{
				Console.WriteLine($"Error: invalide menu item -mi {menuIndex}.");
				return;
			}

			task.Execute(parsedArgs);
		}
		catch (ValidationException ex)
		{
			Console.WriteLine($"Error: calculation task?.Name: {ex.Message}");
			Environment.Exit(1);
		}
		catch (InputExcrption ex)
		{
			Console.WriteLine($"Error parsing input for task?.Name: {ex.Message}");
			Environment.Exit(1);
		}
		catch (System.Exception ex)
		{
			Console.WriteLine($"Unexpected error: {ex.Message}");
			Environment.Exit(1);
		}
	}

	private static Dictionary<string, string> ParseArguments(string[] args)
	{
		var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

		for (int i = 0; i < args.Length; i++)
		{
			string arg = args[i];
			if (arg.StartsWith("-"))
			{
				if (i + 1 < args.Length && !args[i + 1].StartsWith("-"))
				{
					dict[arg] = args[i+1];
					i++; 	
				}
			}
		}

		return dict;
	}
}
