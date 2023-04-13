using Banks.Entities;
using Banks.Entities.BankSystem;
using Banks.Entities.Clients;
using Xunit;
namespace Banks.Test;

public class BanksTest
{
    private CentralBank _centralBank = CentralBank.GetCentralBank();
    [Fact]
    public void CreatingBank()
    {
        Bank newbank = _centralBank.CreatingNewBank("PochtaBank", 50000, 9.5, 200, 150000, 3);
        Assert.Contains(newbank, _centralBank.GetBanksList());
    }

    [Fact]
    public void TransferMoney()
    {
        var newBank = _centralBank.CreatingNewBank("VTB", 5000, 7.5, 100, 10000, 4);
        var builder = new ClientBuilder();
        var client = builder.BuildFirstname("Sasha").BuildSecondname("Horoshev").BuildPassport(999666)
            .BuildAddress("Komendantsci square 111").CreateClient();
        var account1 = newBank.CreatingDebetAccount(client);
        var account2 = newBank.CreatingDebetAccount(client);
        account1.ReciveMoney(10000);
        account1.SendMoney(1000, account2);
        Assert.Equal(1000, account2.Money);
        Assert.Equal(9000, account1.Money);
    }

    [Fact]
    public void RecivePerccents()
    {
        var newBank = _centralBank.CreatingNewBank("VTB", 5000, 10, 100, 10000, 10);
        var builder = new ClientBuilder();
        var client = builder.BuildFirstname("Sasha").BuildSecondname("Horoshev").BuildPassport(999666)
            .BuildAddress("Komendantsci square 111").CreateClient();
        var account1 = newBank.CreatingDebetAccount(client);
        account1.ReciveMoney(10000);
        account1.AddPercentsToAccount(365);
        Assert.Equal(11052, Convert.ToInt32(account1.Money));
    }

    [Fact]
    public void FindBankByName()
    {
        Bank sberbank = _centralBank.CreatingNewBank("Sberbank", _centralBank.GetCentralBankOperationLimits(), _centralBank.GetCentralBankDepositPercents(), _centralBank.GetCentralBankCreditCommission(), _centralBank.GetCentralBankCreditLimit(), _centralBank
            .GetCentralBankDebetPercent());
        Bank vtb = _centralBank.CreatingNewBank("VTB", _centralBank.GetCentralBankOperationLimits(), _centralBank.GetCentralBankDepositPercents(), _centralBank.GetCentralBankCreditCommission(), _centralBank.GetCentralBankCreditLimit(), _centralBank
            .GetCentralBankDebetPercent());
        Bank tinkoff = _centralBank.CreatingNewBank("Tinkoff", _centralBank.GetCentralBankOperationLimits(), _centralBank.GetCentralBankDepositPercents(), _centralBank.GetCentralBankCreditCommission(), _centralBank.GetCentralBankCreditLimit(), _centralBank
            .GetCentralBankDebetPercent());
        Bank banktofind = _centralBank.GetBankFromListByName("Sberbank");
        Assert.Equal(sberbank, banktofind);
    }

    [Fact]
    public void FindClientByName()
    {
        var newBank = _centralBank.CreatingNewBank("VTB", 5000, 7.5, 100, 10000, 4);
        var builder = new ClientBuilder();
        var client = builder.BuildFirstname("Sasha").BuildSecondname("Horoshev").BuildPassport(999666)
            .BuildAddress("Komendantsci square 111").CreateClient();
        newBank.CreatingDebetAccount(client);
        Client clientToFind = newBank.FindBySecondName("Horoshev");
        Assert.Equal("Horoshev", clientToFind.SecondName);
    }
}