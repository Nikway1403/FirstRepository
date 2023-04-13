namespace Banks.Tools;

public class BankException : Exception
{
    public BankException() { }

    /*public BankException(string message)

        : base($"You catch Exception")
    {
    }*/

    public BankException(string message)
        : base(message)
    {
    }
}
