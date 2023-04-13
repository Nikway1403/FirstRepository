using Banks.Entities.Accounts;
using Banks.Services.Observer;
using Banks.Tools;

namespace Banks.Entities.BankSystem;

public class Bank : IObservable
{
    private int _id = 1;
    private CentralBank _centralBank = CentralBank.GetCentralBank();
    private List<Client> _clientsList = new List<Client>();
    private List<Account> _accountsList = new List<Account>();
    private List<IObservable> _subscribes = new List<IObservable>();
    public Bank(string name, double operationLimits, double depositPercents, double creditComission, double creditLimit, double debetPercents)
    {
        Id = _id++;
        Name = name;
        OperationLimits = operationLimits;
        DepositPercents = depositPercents;
        CreditComission = creditComission;
        DebetPercents = debetPercents;
        CreditLimit = creditLimit;
    }

    public Bank(string name)
    {
        Id = _id++;
        Name = name;
        OperationLimits = _centralBank.GetCentralBankOperationLimits();
        DebetPercents = _centralBank.GetCentralBankDebetPercent();
        DepositPercents = _centralBank.GetCentralBankDepositPercents();
        CreditComission = _centralBank.GetCentralBankCreditCommission();
        CreditLimit = _centralBank.GetCentralBankCreditLimit();
    }

    public int Id { get; }
    public string Name { get; }
    public double OperationLimits { get; private set; }
    public double DepositPercents { get; private set; }
    public double CreditComission { get; private set; }
    public double DebetPercents { get; private set; }
    public double CreditLimit { get; private set; }

    public void ChangeDepositPercents(double newProcent) { DepositPercents = newProcent; }

    public void ChangeOperationLimits(double newLimit) { OperationLimits = newLimit; }

    public void ChangeCreditPercent(double newPercent) { CreditComission = newPercent; }

    public void ChangeDebetPercents(double newPercent) { DebetPercents = newPercent; }

    public void ChangeCreditLimit(double newLimit) { CreditLimit = newLimit; }

    public List<Client> GetClientList()
    {
        return _clientsList;
    }

    public void AccrualOfInterest(int days)
    {
        foreach (var account in _accountsList)
        {
            account.AddPercentsToAccount(days);
        }
    }

    public void SubscribeObserver(IObserver observer)
    {
        foreach (var client in _clientsList.Where(client => client == observer))
        {
            client.SetSubscribe();
        }
    }

    public void UnsubscribeObserver(IObserver observer)
    {
        foreach (var client in _clientsList.Where(client => client == observer))
        {
            client.Subscribe = false;
        }
    }

    public void NotifyObservers()
    {
        foreach (var client in _clientsList.Where(client => client.Subscribe == true))
        {
            client.Update("You have new notification");
        }
    }

    public Client FindBySecondName(string? secondName)
    {
        foreach (Client client in _clientsList.Where(client => client.SecondName == secondName))
        {
            return client;
        }

        throw new BankException("There is no persons with this surname");
    }

    public Account CreatingDepositAccount(Client client)
    {
        var account = new DepositAcc(0, client, DateTime.Now, this);
        _clientsList.Add(client);
        _accountsList.Add(account);
        client.AccountAdd(account);
        return account;
    }

    public Account CreatingDebetAccount(Client client)
    {
        var account = new DebetAcc(0, client, this);
        _clientsList.Add(client);
        _accountsList.Add(account);
        client.AccountAdd(account);
        return account;
    }

    public Account CreatingCreditAccount(Client client)
    {
        var account = new CreditAcc(0, client, this);
        _clientsList.Add(client);
        _accountsList.Add(account);
        client.AccountAdd(account);
        return account;
    }
}