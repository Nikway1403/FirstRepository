using Banks.Entities;
using Banks.Entities.BankSystem;

namespace Banks.ConsoleSetings;

public class BankMode
{
    private CentralBank _centralBank = CentralBank.GetCentralBank();
    public void BankMenu()
    {
        Console.WriteLine("Now you're in Bank mode");
        Console.WriteLine("Which bank you want to work with (enter the name)");
        foreach (Bank bank in _centralBank.GetBanksList())
        {
            Console.WriteLine(bank.Name);
        }

        Bank workingBank = _centralBank.GetBankFromListByName(Console.ReadLine());
        Console.WriteLine($"You're working with {workingBank.Name}. Choose your action");
        Console.WriteLine("1)Show bank settings");
        Console.WriteLine("2)Change banks settings");
        Console.WriteLine("Or press any number to back to Start menu");
        int command = Convert.ToInt32(Console.ReadLine());
        switch (command)
        {
            case 1:
                Console.WriteLine("Bank name:" + workingBank.Name);
                Console.WriteLine("Bank debet account percent:" + workingBank.DebetPercents);
                Console.WriteLine("Bank operations limit" + workingBank.OperationLimits);
                Console.WriteLine("Bank Credit limit" + workingBank.CreditLimit);
                Console.WriteLine("Bank credit commissions" + workingBank.CreditComission);
                Console.WriteLine("Bank deposit percent" + workingBank.DepositPercents);
                BankMenu();
                break;
            case 2:
                Console.WriteLine("Choose what parameter do you want to change");
                Console.WriteLine("1)Debet account percent\n2)Operations limit\n3)Credit limit\n4)Credit commissions\n5)Deposit percent");
                int answer = Convert.ToInt32(Console.ReadLine());
                if (answer == 1)
                {
                    Console.WriteLine("Enter new debet account percent");
                    workingBank.ChangeDebetPercents(Convert.ToDouble(Console.ReadLine()));
                    BankMenu();
                }

                if (answer == 2)
                {
                    Console.WriteLine("Enter new operation limit");
                    workingBank.ChangeOperationLimits(Convert.ToDouble(Console.ReadLine()));
                    BankMenu();
                }

                if (answer == 3)
                {
                    Console.WriteLine("Enter new credit limit");
                    workingBank.ChangeCreditLimit(Convert.ToDouble(Console.ReadLine()));
                    BankMenu();
                }

                if (answer == 4)
                {
                    Console.WriteLine("Enter new credit commissions");
                    workingBank.ChangeCreditPercent(Convert.ToDouble(Console.ReadLine()));
                    BankMenu();
                }

                if (answer == 5)
                {
                    Console.WriteLine("Enter new deposit account percent");
                    workingBank.ChangeDepositPercents(Convert.ToDouble(Console.ReadLine()));
                    BankMenu();
                }

                break;
            default:
                ConsoleSettings.GetConsoleSettings();
                break;
        }
    }
}