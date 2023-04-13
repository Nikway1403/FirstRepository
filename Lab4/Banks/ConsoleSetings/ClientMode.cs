using Banks.Entities;
using Banks.Entities.Accounts;
using Banks.Entities.BankSystem;
using Banks.Entities.Clients;

namespace Banks.ConsoleSetings;

public class ClientMode
{
    private CentralBank _centralBank = CentralBank.GetCentralBank();
    private bool flag = true;

    public void ClientMenu()
    {
        Console.WriteLine("Choose action");
        Console.WriteLine("1)Register new client");
        Console.WriteLine("2)Log in (in progress)");
        Console.WriteLine("Or just enter any symbol to back in start menu");
        int command = Convert.ToInt32(Console.ReadLine());

        // Client registration
        if (command == 1)
        {
            Console.WriteLine("Register new client");
            Console.WriteLine("Enter your Firstname");
            string? firstName = Console.ReadLine();
            Console.WriteLine("Enter your Secondname");
            string? secondname = Console.ReadLine();
            Console.WriteLine("Enter your adress or skip this step (if you skip this step you may have restrictions)");
            string? adress = Console.ReadLine();
            Console.WriteLine(
                "Enter you passport information or skip this step (if you skip this step you may have restrictions)");
            int passport = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your password (min 4 numbers && max 6 numbers");
            int password = Convert.ToInt32(Console.ReadLine());
            var builder = new ClientBuilder();
            Client client = builder.BuildFirstname(firstName!).BuildSecondname(secondname!).BuildAddress(adress)
                .BuildPassport(passport).BuildPassword(password).CreateClient();
            string secondname2 = "TestMan";
            Client client2 = builder.BuildFirstname(firstName!).BuildSecondname(secondname2!).BuildAddress(adress)
                .BuildPassport(passport).CreateClient();
            Console.WriteLine("Now let's make your account");
            Console.WriteLine("Choose bank name where you want to create account");
            foreach (var bank in _centralBank.GetBanksList())
            {
                Console.WriteLine(bank.Name);
            }

            string? chosenBankName = Console.ReadLine();
            Bank chosenBank = _centralBank.GetBankFromListByName(chosenBankName);
            Console.WriteLine("What type of account you want to create");
            Console.WriteLine("1) Debet account");
            Console.WriteLine("2) Credit account");
            Console.WriteLine("3) Deposit Account");
            int answer = Convert.ToInt32(Console.ReadLine());
            Account account = new DebetAcc(0, client, chosenBank);
            if (answer == 1)
            {
                Account clientAccount = _centralBank.GetBankFromListByName(chosenBankName).CreatingDebetAccount(client);
                account = clientAccount;
            }

            if (answer == 2)
            {
                Account clientAccount = chosenBank.CreatingCreditAccount(client);
                account = clientAccount;
            }

            if (answer == 3)
            {
                Account clientAccount = chosenBank.CreatingDepositAccount(client);
                account = clientAccount;
            }

            // Operations
            while (flag)
            {
                Console.WriteLine("Now let's make some transactions");
                Console.WriteLine("1)Take money from your account");
                Console.WriteLine("2)Send money");
                Console.WriteLine("3) Recive money");
                Console.WriteLine("4)Show balance");
                Console.WriteLine("5) Exit menu");
                answer = Convert.ToInt32(Console.ReadLine());
                if (answer == 1)
                {
                    Console.WriteLine("Enter amount to take");
                    account.TakeMoneyFromAccount(Convert.ToInt32(Console.ReadLine()));
                }

                if (answer == 2)
                {
                    Console.WriteLine("Enter amount to send");
                    account.SendMoney(
                        Convert.ToInt32(Console.ReadLine()),
                        new DebetAcc(0, client2, new Bank("Rosbank", 10000, 3, 100, 10000, 1)));
                }

                if (answer == 3)
                {
                    Console.WriteLine("Enter amount to take");
                    account.ReciveMoney(Convert.ToInt32(Console.ReadLine()));
                }

                if (answer == 4)
                {
                    Console.WriteLine(account.Money);
                }

                if (answer == 5)
                {
                    flag = false;
                    ClientMenu();
                }
            }
        }

        if (command == 2)
        {
            ConsoleSettings.GetConsoleSettings();
            Console.WriteLine("Enter bank you want to log in");
            string? enteredBank = Console.ReadLine();
            Bank workingBank = _centralBank.GetBankFromListByName(enteredBank);
            Console.WriteLine("Enter your surname (which you write when you registrated)");
            string? enteredSurname = Console.ReadLine();
            Client workingClient = workingBank.FindBySecondName(enteredSurname);
            int enteredPassword = Convert.ToInt32(Console.ReadLine());
            if (enteredPassword == workingClient.ClientPassword)
            {
                foreach (var account in workingClient.GetAccount())
                {
                    Console.WriteLine(account.GetId);
                }

                int enteredId = Convert.ToInt32(Console.ReadLine());
                Account workingAccount = workingClient.GetAccountById(enteredId);
                while (flag)
                {
                    Console.WriteLine("Now let's make some transactions");
                    Console.WriteLine("1)Take money from your account");
                    Console.WriteLine("2)Send money");
                    Console.WriteLine("3) Recive money");
                    Console.WriteLine("4)Show balance");
                    Console.WriteLine("5) Exit menu");
                    int currentAnswer = Convert.ToInt32(Console.ReadLine());
                    if (currentAnswer == 1)
                    {
                        Console.WriteLine("Enter amount to take");
                        workingAccount.TakeMoneyFromAccount(Convert.ToInt32(Console.ReadLine()));
                    }

                    if (currentAnswer == 2)
                    {
                        Console.WriteLine("Enter amount to send");
                        Client client2 = workingClient;
                        workingAccount.SendMoney(
                            Convert.ToInt32(Console.ReadLine()),
                            new DebetAcc(0, client2, _centralBank.GetBankFromListByName("VTB")));
                    }

                    if (currentAnswer == 3)
                    {
                        Console.WriteLine("Enter amount to take");
                        workingAccount.ReciveMoney(Convert.ToInt32(Console.ReadLine()));
                    }

                    if (currentAnswer == 4)
                    {
                        Console.WriteLine(workingAccount.Money);
                    }

                    if (currentAnswer == 5)
                    {
                        flag = false;
                    }
                }
            }
        }
        else
        {
            ConsoleSettings.GetConsoleSettings();
        }
    }
}