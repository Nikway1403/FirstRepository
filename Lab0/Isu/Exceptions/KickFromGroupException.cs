namespace Isu.Exceptions;

public class KickFromGroupException : Exception
{
    public KickFromGroupException() { }

    public KickFromGroupException(string groupname)

        : base($"Invalid group name ") { }

    public KickFromGroupException(string message, Exception z)
        : base(message, z) { }
}