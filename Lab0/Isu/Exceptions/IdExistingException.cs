namespace Isu.Exceptions;

public class IdExistingException : Exception
{
    public IdExistingException() { }

    public IdExistingException(int id)

        : base($"Id not exist")
    {
    }

    public IdExistingException(string message, Exception z)
        : base(message, z)
    {
    }
}
