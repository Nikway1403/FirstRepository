using Banks.Entities;
using Banks.Entities.BankSystem;

namespace Banks.ConsoleSetings;

public class ConsoleSettings
{
    private static ConsoleSettings _console = null!;
    private readonly ClientMode _clientMode = new ClientMode();
    private readonly CentralBankMode _centralBankMode = CentralBankMode.GetCentralBankMode();
    private readonly BankMode _bankMode = new BankMode();
    private CentralBank _centralBank = CentralBank.GetCentralBank();
    private ConsoleSettings()
    {
        _centralBank.CreatingMainThereBanks();
        Greeting();
    }

    public static ConsoleSettings GetConsoleSettings()
    {
        if (_console == null)
            _console = new ConsoleSettings();
        return _console;
    }

    public void Greeting()
    {
        Console.WriteLine("Use numbers to move in console menu");
        Console.WriteLine("Welcome to Banks here you can manage the system!");
        Console.WriteLine("What do you want to do?");
        Console.WriteLine("1) Client mode");
        Console.WriteLine("2) Bank system mode");
        Console.WriteLine("3)Central bank mode");
        Console.WriteLine("If you want to exit enter any other symbol");
        int menuChoice = Convert.ToInt32(Console.ReadLine());
        if (menuChoice == 1)
        {
            _clientMode.ClientMenu();
        }

        if (menuChoice == 2)
        {
            _bankMode.BankMenu();
        }

        if (menuChoice == 3)
        {
            Console.WriteLine("Enter the password to continue.");
            int answerCode = Convert.ToInt32(Console.ReadLine());
            if (answerCode == _centralBankMode.Password)
            {
                _centralBankMode.CentralBankMenu();
            }
            else
            {
                Console.WriteLine("You entered wrong password you'll redirect to Start menu");
                Greeting();
            }
        }
        else
        {
            return;
        }
    }
}