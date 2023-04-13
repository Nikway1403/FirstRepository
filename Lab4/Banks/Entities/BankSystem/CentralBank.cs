using Banks.Entities.BankSystem;
using Banks.Tools;

namespace Banks.Entities;

public class CentralBank
{
    private const int Month = 30;
    private static CentralBank _centralBank = null!;
    private List<Bank> _bankList = new List<Bank>();
    private double _recommendedLimits;
    private double _recommendedDepositPercents;
    private double _recommendedCreditComission;
    private double _recommendedCreditLimits;
    private double _recommendedDebetPercents;

    private CentralBank() { }

    public static CentralBank GetCentralBank()
    {
        if (_centralBank == null)
            _centralBank = new CentralBank();
        return _centralBank;
    }

    public void SetRecommendedParameter(double newRecommendedLimits, double newDepositPercent, double newCreditCommission, double newCreditLimits, double newDebetPercent)
    {
        _recommendedLimits = newRecommendedLimits;
        _recommendedDepositPercents = newDepositPercent;
        _recommendedCreditComission = newCreditCommission;
        _recommendedCreditLimits = newCreditLimits;
        _recommendedDebetPercents = newDebetPercent;
    }

    public double GetCentralBankOperationLimits() { return _recommendedLimits; }

    public double GetCentralBankDepositPercents() { return _recommendedDepositPercents; }
    public double GetCentralBankCreditCommission() { return _recommendedCreditComission; }
    public double GetCentralBankCreditLimit() { return _recommendedCreditLimits; }
    public double GetCentralBankDebetPercent() { return _recommendedDebetPercents; }

    public Bank CreatingNewBank(string name, double operationLimits, double depositPercents, double creditComission, double creditLimit, double debetPercents)
    {
        var newBank = new Bank(name, operationLimits, depositPercents, creditComission, creditLimit, debetPercents);
        _bankList.Add(newBank);
        return newBank;
    }

    public Bank CreatingNewBank(string name)
    {
        var newBank = new Bank(name);
        _bankList.Add(newBank);
        return newBank;
    }

    public List<Bank> GetBanksList()
    {
        return _bankList;
    }

    public void NotificationBanksAboutInterest()
    {
        foreach (var bank in _bankList)
        {
            bank.AccrualOfInterest(Month);
        }
    }

    public Bank GetBankFromListByName(string? bankName)
    {
        Bank? foundedBank = null;
        foreach (Bank bank in _bankList)
        {
            if (bank.Name == bankName)
                foundedBank = bank;
        }

        if (foundedBank == null)
            throw new BankException("Bank doesn't exist");

        return foundedBank;
    }

    public void CreatingMainThereBanks()
    {
        Bank sberbank = _centralBank.CreatingNewBank("Sberbank");
        Bank vtb = _centralBank.CreatingNewBank("VTB");
        Bank tinkoff = _centralBank.CreatingNewBank("Tinkoff");
    }
}