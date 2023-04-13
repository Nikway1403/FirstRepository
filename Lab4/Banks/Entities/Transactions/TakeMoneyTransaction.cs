using Banks.Entities.Accounts;
using Banks.Tools;

namespace Banks.Entities.Transactions;

public class TakeMoneyTransaction : Transaction
{
    public TakeMoneyTransaction(double money, Account account)
        : base(money)
    {
        Account = account;
    }

    public Account Account { get; }
    public override void CancelingTransaction()
    {
        throw new BankException("You cannot cancel this type transaction");
    }
}