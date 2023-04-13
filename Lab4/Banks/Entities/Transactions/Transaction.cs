namespace Banks.Entities.Transactions;

public abstract class Transaction
{
    private int _id;

    public Transaction(double money)
    {
        TransactionMoney = money;
        _id = IdTransactionGenerator();
        TransactionStatus = true;
    }

    public bool TransactionStatus { get; protected set; }

    public double TransactionMoney { get; }
    public int GetId() { return _id; }
    public abstract void CancelingTransaction();

    private int IdTransactionGenerator()
    {
        int id = 1;
        id = id++;
        return id;
    }
}
