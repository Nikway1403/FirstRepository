namespace Isu.Exceptions;

public class IdException : Exception
{
    public IdException() { }

    public IdException(int studId)

        : base($"Invalid isu Id number")
    {
    }

    public IdException(string message, Exception z)
        : base(message, z)
    {
    }
}