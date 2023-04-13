using Banks.Entities;
using Banks.Entities.BankSystem;

namespace Banks.ConsoleSetings;

public class CentralBankMode
{
    private static CentralBankMode _mode = null!;
    private readonly CentralBank _centralBank = CentralBank.GetCentralBank();
    private int _password;

    private CentralBankMode()
    {
        _password = 000000;
        Password = _password;
    }

    public int Password { get; private set; }

    public static CentralBankMode GetCentralBankMode()
    {
        if (_mode == null)
            _mode = new CentralBankMode();
        return _mode;
    }

    public void CentralBankMenu()
    {
        Console.WriteLine("Now you're in Central bank menu");
        Console.WriteLine("Choose action to do");
        Console.WriteLine("1)Change default settings (for creating new bank with default settings)");
        Console.WriteLine("2)Create new bank");
        Console.WriteLine("3)Increase datetime (Time rewind function)");
        Console.WriteLine("4)Change password");
        Console.WriteLine("Press any number to redirect to start menu");
        int answer = Convert.ToInt32(Console.ReadLine());
        switch (answer)
        {
            case 1:
                Console.WriteLine("Now you're changing default setting");
                Console.WriteLine("Enter new operations limit");
                double changedLimits = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Deposit percent");
                double changedDepositPercent = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Credit commissions");
                double changedCreditCommissions = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Credit limit");
                double changedCreditLimit = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Debet percent");
                double changedDebetPercent = Convert.ToDouble(Console.ReadLine());
                _centralBank.SetRecommendedParameter(changedLimits, changedDepositPercent, changedCreditCommissions, changedCreditLimit, changedDebetPercent);
                Console.WriteLine("Default settings were changed");
                break;
            case 2:
                Console.WriteLine("You're now in the bank creation menu");
                Console.WriteLine("Choose type of bank");
                Console.WriteLine("1)Default");
                Console.WriteLine("2)Custom settings");
                Console.WriteLine("3)Redirect to Central bank menu");
                int type = Convert.ToInt32(Console.ReadLine());
                if (type == 1)
                {
                    Console.WriteLine("Enter bank name");
                    string? name = Console.ReadLine();
                    if (name == null)
                    {
                        Console.WriteLine("You made a mistake. Now you returned to CentralBankMode");
                        CentralBankMenu();
                    }
                    else
                    {
                        var newBank = new Bank(name);
                        _centralBank.GetBanksList().Add(newBank);
                        Console.WriteLine("Bank was successfully created");
                        CentralBankMenu();
                    }
                }

                if (type == 2)
                {
                    Console.WriteLine("Custom bank creating");
                    Console.WriteLine("Enter bank name");
                    string? name = Console.ReadLine();
                    if (name == null)
                    {
                        Console.WriteLine("You made a mistake. Now you returned to CentralBankMode");
                        CentralBankMenu();
                    }
                    else
                    {
                        Console.WriteLine("Enter new operations limit");
                        double operetionLimits = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Deposit percent");
                        double depositPercent = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Credit commissions");
                        double creditCommissions = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Credit limit");
                        double creditLimit = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Debet percent");
                        double debetPercent = Convert.ToDouble(Console.ReadLine());
                        _centralBank.CreatingNewBank(name, operetionLimits, depositPercent, creditCommissions, creditLimit, debetPercent);
                        Console.WriteLine("Bank was successfully created");
                        CentralBankMenu();
                    }
                }
                else
                {
                    CentralBankMenu();
                }

                break;
            case 3:
                Console.WriteLine("Time rewind function");
                Console.WriteLine("Enter number of days you want to rewind");
                int days = Convert.ToInt32(Console.ReadLine());
                foreach (Bank bank in _centralBank.GetBanksList())
                {
                    bank.AccrualOfInterest(days);
                }

                Console.WriteLine("Time has been changed");
                Console.WriteLine("Redirection to Central bank menu");
                CentralBankMenu();
                break;
            case 4:
                Console.WriteLine("You're changing password. Enter new password (it must contained 6 numbers");
                ChangePassword(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("You successfully changed password. Redirect to Start menu");
                ConsoleSettings.GetConsoleSettings();
                break;
            default: ConsoleSettings.GetConsoleSettings();
                break;
        }
    }

    private void ChangePassword(int newPassword)
    {
        Password = newPassword;
    }
}