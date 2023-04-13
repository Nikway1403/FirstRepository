namespace Isu.Exceptions;

public class MaximumStudException : Exception
{
    public MaximumStudException() { }

    public MaximumStudException(string groupname)

        : base($"There is maximum students in group ")
    {
    }

    public MaximumStudException(string message, Exception z)
        : base(message, z)
    {
    }
}