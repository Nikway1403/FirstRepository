using Banks.Entities.BankSystem;
using Banks.Tools;

namespace Banks.Entities.Accounts;

public class DebetAcc : Account
{
    public DebetAcc(double money, Client newClient, Bank myBank)
        : base(money, newClient, myBank)
    {
    }

    public override void TakeMoneyFromAccount(double amountOfMoneyToTake)
    {
        if (Money < amountOfMoneyToTake)
            throw new BankException("You cannot take more money then you have");
        DecreaseMoney(amountOfMoneyToTake);
        GenerateTakeMoneyTransaction(amountOfMoneyToTake, this);
    }

    public override void ReciveMoney(double money)
    {
        AddMoney(money);
        AddTransactionToHistory(GenerateDepositTransaction(money, this));
    }

    public override void SendMoney(double amountToSend, Account accountReciver)
    {
        if (Money < amountToSend)
            throw new BankException("You cannot send more money then you have");
        DecreaseMoney(amountToSend);
        accountReciver.AddMoney(amountToSend);
        AddTransactionToHistory(GenerateTransferTransaction(amountToSend, this, accountReciver));
    }

    public override void AddPercentsToAccount(int days)
    {
        for (int i = 0; i < days; i++)
        {
            AddMoney(Money * (GetBank.DebetPercents / 100 / 365));
        }
    }
}