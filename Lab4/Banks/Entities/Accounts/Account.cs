using Banks.Entities.BankSystem;
using Banks.Entities.Transactions;
using Banks.Tools;

namespace Banks.Entities.Accounts;

public abstract class Account
{
    private List<Transaction> _transactionsList = new List<Transaction>();
    private bool _verification = false;
    private int _id;
    public Account(double money, Client newClient, Bank myBank)
    {
        GetClient = newClient;
        Money = money;
        GetBank = myBank;
        GetId = _id++;
        bool verification = _verification;
    }

    public Client GetClient { get;  }
    public double Money { get; private set; }
    public Bank GetBank { get; }
    public int GetId { get; }
    public List<Transaction> GetTransactionList() { return _transactionsList; }

    public abstract void TakeMoneyFromAccount(double amountOfMoneyToTake);
    public abstract void SendMoney(double amountToSend, Account accountReciver);
    public abstract void ReciveMoney(double money);
    public abstract void AddPercentsToAccount(int days);

    public void AddTransactionToHistory(Transaction newTransaction)
    {
        if (GetTransactionList().Contains(newTransaction))
            throw new BankException("Transaction error");
        GetTransactionList().Add(newTransaction);
    }

    public TransferTransaction GenerateTransferTransaction(double money, Account accountSender, Account accountReciver)
    {
        var newTransaction = new TransferTransaction(money, accountSender, accountReciver);
        return newTransaction;
    }

    public DepositTransaction GenerateDepositTransaction(double money, Account account)
    {
        var newDeposiTransaction = new DepositTransaction(money, account);
        return newDeposiTransaction;
    }

    public TakeMoneyTransaction GenerateTakeMoneyTransaction(double money, Account account)
    {
        var newTakeMoneyTransaction = new TakeMoneyTransaction(money, account);
        return newTakeMoneyTransaction;
    }

    public void VerificationConfirmited()
    {
        _verification = true;
    }

    // For transaction canceling
    public void ChangeMoneyMinus(double amount) { DecreaseMoney(amount); }
    public void ChangeMoneyPlus(double amount) { AddMoney(amount); }

    // For operations
    protected internal void AddMoney(double amount) { Money += amount; }

    protected void DecreaseMoney(double amount) { Money -= amount; }
}