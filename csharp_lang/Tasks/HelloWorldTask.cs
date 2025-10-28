using System;

namespace lab1.Tasks;
public class HelloWorldTask : Task
{
	public override string Name => "Hello World";
	public override string Description => "Print console: Hello world";

	public override void execute()
	{
		DisplayHeader();
		Console.WriteLine("Hello World!");
	}
}