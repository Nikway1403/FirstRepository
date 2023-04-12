namespace Isu.Extra.Exceptions;

public class IsuExeption : Exception
{
    public IsuExeption() { }

    public IsuExeption(string message)
    {
    }

    public IsuExeption(string message, Exception newExeption)
        : base(message, newExeption)
    {
    }
}