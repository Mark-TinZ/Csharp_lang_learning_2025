using System;

namespace lab1.Tasks;

// Задача: Выход из программы
public class ExitTask : Task
{
	public override int MenuOrder => 0;
	public override string Name => "Exit";
	public override string Description => "Exit application";

	public override void Execute()
	{
		Console.WriteLine("Exit");
		Environment.Exit(0);
	}
}