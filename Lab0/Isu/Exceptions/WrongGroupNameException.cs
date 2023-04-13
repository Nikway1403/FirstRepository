namespace Isu.Exceptions;

public class WrongGroupNameException : Exception
{
    public WrongGroupNameException() { }

    public WrongGroupNameException(string groupname)

        : base($"Invalid group name ")
    {
    }

    public WrongGroupNameException(string message, Exception z)
        : base(message, z)
    {
    }
}