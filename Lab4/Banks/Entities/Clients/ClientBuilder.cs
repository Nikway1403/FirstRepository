using Banks.Tools;

namespace Banks.Entities.Clients;

public class ClientBuilder
{
    private Client _client = new Client();
    public void BuildId(int id)
    {
        _client.Id = id;
    }

    public ClientBuilder BuildFirstname(string firstname)
    {
        if (string.IsNullOrEmpty(firstname))
            throw new BankException("Name cannot be empty");
        _client.FirstName = firstname;
        return this;
    }

    public ClientBuilder BuildSecondname(string secondname)
    {
        if (string.IsNullOrEmpty(secondname))
            throw new BankException("Name cannot be empty");
        _client.SecondName = secondname;
        return this;
    }

    public ClientBuilder BuildAddress(string? adress)
    {
        _client.Adress = adress;
        return this;
    }

    public ClientBuilder BuildPassport(int passportInfo)
    {
        _client.PassportInfo = passportInfo;
        return this;
    }

    public ClientBuilder BuildPassword(int password)
    {
        _client.ChangePassword(password);
        return this;
    }

    public Client CreateClient()
    {
        Client result = _client;
        return result;
    }
}