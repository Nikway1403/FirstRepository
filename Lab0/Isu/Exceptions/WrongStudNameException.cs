namespace Isu.Exceptions;

public class WrongStudNameException : Exception
{
    public WrongStudNameException() { }

    public WrongStudNameException(string name)

        : base($"Invalid name ")
    {
    }

    public WrongStudNameException(string message, Exception z)
        : base(message, z)
    {
    }
}