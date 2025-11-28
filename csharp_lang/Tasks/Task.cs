using System;

namespace lab1.Tasks;

public abstract class Task
{
	public abstract int MenuOrder { get; }
	public abstract string Name { get; }
	public abstract string Description { get; }

	public abstract void Execute();

	public virtual void Execute(Dictionary<string, string> args)
	{
		throw new NotImplementedException($"Task {Name} does not support command line execution.");
	}

	protected virtual void DisplayHeader()
	{
		Console.WriteLine($"=== {Name} ===");
		Console.WriteLine(Description);
		Console.WriteLine();
	}

	protected void DisplayResult(string result)
	{
		Console.WriteLine();
		Console.WriteLine($"Result: {result}");
	}

	protected void DisplayError(string error)
	{
		Console.WriteLine();
		Console.WriteLine($"Error: {error}");
	}
}