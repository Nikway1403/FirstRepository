namespace Isu.Exceptions;

public class AddToGroupException : Exception
{
    public AddToGroupException() { }

    public AddToGroupException(string groupname)

        : base($"Invalid group name ")
    {
    }

    public AddToGroupException(string message, Exception z)
        : base(message, z)
    {
    }
}