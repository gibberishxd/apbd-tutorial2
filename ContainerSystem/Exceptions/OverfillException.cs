namespace ContainerSystem.Exceptions;

public class OverfillException : Exception
{
    public OverfillException()
    {
        Console.WriteLine("Container is overfilled!");
    }

    public OverfillException(string? message) : base(message)
    {
    }

    public OverfillException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}