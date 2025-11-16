using System;

namespace lab1.Exception;

public abstract class AppException : System.Exception
{
	protected AppException(string message) : base(message) {}
}

public class ValidationException : AppException
{
	public ValidationException(string message) : base(message) {}
}

public class CalculationException : AppException
{
	public CalculationException(string message) : base(message) {}
}

public class InputExcrption : AppException
{
	public InputExcrption(string message) : base(message) {}
}