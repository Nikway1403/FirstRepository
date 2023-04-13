using Banks.Entities.Accounts;
using Banks.Entities.BankSystem;
using Banks.Tools;

namespace Banks.Entities;

public class DepositAcc : Account
{
    public DepositAcc(double money, Client newClient, DateTime dateTime, Bank myBank)
        : base(money, newClient, myBank)
    {
        DepositTime = dateTime;
    }

    public DateTime DepositTime { get; }

    public override void TakeMoneyFromAccount(double amountOfMoneyToTake)
    {
        if (DateTime.Today < DepositTime)
            throw new BankException("You cannot take money from this time account til the deposit time run out");
        DecreaseMoney(amountOfMoneyToTake);
        GenerateTakeMoneyTransaction(amountOfMoneyToTake, this);
    }

    public override void SendMoney(double amountToSend, Account accountReciver)
    {
        if (DateTime.Today < DepositTime)
            throw new BankException("You cannot send money from this time account til the deposit time run out");
        DecreaseMoney(amountToSend);
        accountReciver.AddMoney(amountToSend);
        AddTransactionToHistory(GenerateTransferTransaction(amountToSend, this, accountReciver));
    }

    public override void ReciveMoney(double money)
    {
        AddMoney(money);
        AddTransactionToHistory(GenerateDepositTransaction(money, this));
    }

    public override void AddPercentsToAccount(int days)
    {
        for (int i = 0; i < days; i++)
        {
            AddMoney(Money * (GetBank.DepositPercents / 100 / 365));
        }
    }
}