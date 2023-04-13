using Banks.Entities.Accounts;

namespace Banks.Entities.Transactions;

public class TransferTransaction : Transaction
{
    public TransferTransaction(double money, Account accountSender, Account accountReciver)
    : base(money)
    {
        AccountSender = accountSender;
        AccountReciver = accountReciver;
    }

    public Account AccountSender { get; }
    public Account AccountReciver { get; }
    public override void CancelingTransaction()
    {
        AccountSender.ChangeMoneyPlus(TransactionMoney);
        AccountReciver.ChangeMoneyMinus(TransactionMoney);
        TransactionStatus = false;
    }
}