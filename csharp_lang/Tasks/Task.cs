using System;

namespace lab1.Tasks;

public abstract class Task
{
	public abstract string Name { get; }
	public abstract string Description { get; }

	public abstract void execute();

	public virtual void DisplayHeader()
	{
		Console.WriteLine($"=== {Name} ===");
		Console.WriteLine(Description);
		Console.WriteLine();
	}
}