namespace Isu.Exceptions;

public class GroupExistException : Exception
{
    public GroupExistException() { }

    public GroupExistException(string groupexist)

        : base($"Group already exist")
    {
    }

    public GroupExistException(string message, Exception z)
        : base(message, z)
    {
    }
}