using Banks.Entities.Accounts;
using Banks.Services.Observer;
using Banks.Tools;

namespace Banks.Entities;

public class Client : IObserver
{
    private List<Account> _accountsList = new List<Account>();
    private List<string> _clientNotifications = new List<string>();

    public string? FirstName { get; internal set; }
    public string? SecondName { get; internal set; }
    public string? Adress { get; internal set; } = null;
    public int PassportInfo { get; internal set; } = 0;
    public bool StatusOfVerification { get; private set; }
    public int Id { get; internal set; }
    public bool Subscribe { get; internal set; }
    public int ClientPassword { get; private set; }

    public List<Account> GetAccount()
    {
        return _accountsList;
    }

    public void AccountAdd(Account newAccount)
    {
        if (_accountsList.Capacity < 4)
            _accountsList.Add(newAccount);
    }

    public void SetAddress(string newAdress)
    {
        Adress = newAdress;
        ConfirmOfVerification();
    }

    public void Update(string messege)
    {
        _clientNotifications.Add(messege);
    }

    public void SetPassport(int passportNumber)
    {
        if (PassportInfo != 0)
            throw new BankException("Passport number already added");
        PassportInfo = passportNumber;
        ConfirmOfVerification();
    }

    public void SetSubscribe()
    {
        Subscribe = true;
    }

    public void ChangePassword(int newPassword)
    {
        ClientPassword = newPassword;
    }

    public Account GetAccountById(int enteredId)
    {
        foreach (var account in _accountsList.Where(account => account.GetId == enteredId))
        {
            return account;
        }

        throw new BankException("There is no account with this id");
    }

    private void ConfirmOfVerification()
    {
        bool confirmation = Adress != null && PassportInfo != 0;
        if (confirmation)
        {
            foreach (var account in _accountsList)
            {
                account.VerificationConfirmited();
            }
        }
    }
}