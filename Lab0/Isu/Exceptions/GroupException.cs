namespace Isu.Exceptions;

public class GroupException : Exception
{
    public GroupException() { }
    public GroupException(string groupmax)
        : base($"Group is full")
    {
    }

    public GroupException(string message, Exception exp)
        : base(message, exp)
    {
    }
}