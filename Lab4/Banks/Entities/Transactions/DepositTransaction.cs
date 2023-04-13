using Banks.Entities.Accounts;

namespace Banks.Entities.Transactions;

public class DepositTransaction : Transaction
{
    public DepositTransaction(double money, Account acoount)
        : base(money)
    {
        Account = acoount;
    }

    public Account Account { get; }

    public override void CancelingTransaction()
    {
        Account.ChangeMoneyMinus(TransactionMoney);
        TransactionStatus = false;
    }
}