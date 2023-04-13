using Banks.Entities.BankSystem;
using Banks.Tools;

namespace Banks.Entities.Accounts;

public class CreditAcc : Account
{
    public CreditAcc(double money, Client newClient, Bank myBank)
        : base(money, newClient, myBank)
    {
    }

    public override void TakeMoneyFromAccount(double amountOfMoneyToTake)
    {
        if (Money - amountOfMoneyToTake < GetBank.CreditLimit)
            throw new BankException("You reach the credit limit");
        DecreaseMoney(amountOfMoneyToTake);
        GenerateTakeMoneyTransaction(amountOfMoneyToTake, this);
    }

    public override void SendMoney(double amountToSend, Account accountReciver)
    {
        if (Money - amountToSend < GetBank.CreditLimit)
            throw new BankException("You reach the credit limit");
        DecreaseMoney(amountToSend);
        accountReciver.AddMoney(amountToSend);
        AddTransactionToHistory(GenerateTransferTransaction(amountToSend, this, accountReciver));
    }

    public override void ReciveMoney(double money)
    {
        AddMoney(money);
        AddTransactionToHistory(GenerateDepositTransaction(money, this));
    }

    public override void AddPercentsToAccount(int days) { }

    public void TakeCommision(int days)
    {
        for (int i = 0; i < days; i++)
        {
            DecreaseMoney(GetBank.CreditComission);
        }
    }
}