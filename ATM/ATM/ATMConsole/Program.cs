using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using ATMLib;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;




Bank bank = new Bank(1);
AutomatedTellerMachine atm = new AutomatedTellerMachine();
int menuChoise = 0;
Account account = new Account();
bool isLogin = false;
atm.AuthentificatinEvent += ShowMessage;

do
{
    Console.WriteLine("Enter number of your card:");
    string numCard = Console.ReadLine();
    Console.WriteLine("Enter pin code:");
    string pin = Console.ReadLine();
    isLogin = atm.Login(numCard, pin);
    if (isLogin)
    {
        string login = $"You are login at {DateTime.Now}";
        atm.UserCardNum = numCard;
        atm.atmId = bank.Id;
        atm.GetBalance(numCard);
        atm.BalaceEvent += ShowMessage;
        atm.SendMoneyEvent += ShowMessage;
        atm.AddMoneyEvent += ShowMessage;
        atm.WithdrawMoneyEvent += ShowMessage;
        atm.EmailNotice(login);

    }
} while (!isLogin);
do
{
    Menu();
    int.TryParse(Console.ReadLine(), out menuChoise);
    switch (menuChoise)
    {
        case 0:
            break;
        case 1:
            {
                atm.CheckBalance();
                break;
            }
        case 2:
            {
                Console.WriteLine("Enter the sum which you want to add");
                int.TryParse(Console.ReadLine(), out int sum);
                atm.AddMoney(sum);
                break;
            }
        case 3:
            {
                Console.WriteLine("Enter number card which you want to send money");
                string distCard = Console.ReadLine();
                Console.WriteLine("Enter the sum which you want to send");
                double.TryParse(Console.ReadLine(), out double sum);
                atm.SendMoneyTo(sum, distCard);
                break;
            }
        case 4:
            {
                Console.WriteLine("Enter the sum which you want to withdraw");
                int.TryParse(Console.ReadLine(), out int sum);
                atm.WithdrawMoney(sum);
                break;
            }
        case 5:
            {
                SettingsMenu();
                int choise;
                do
                {
                    int.TryParse(Console.ReadLine(), out choise);
                    if (choise == 1)
                    {
                        atm.BalaceEvent -= ShowMessage;
                    }
                    if (choise == 2)
                    {
                        atm.AddMoneyEvent -= ShowMessage;
                    }
                    if (choise == 3)
                    {
                        atm.SendMoneyEvent -= ShowMessage;
                    }
                    if (choise == 4)
                    {
                        atm.WithdrawMoneyEvent -= ShowMessage;
                    }
                    if (choise == 5)
                    {
                        atm.AuthentificatinEvent -= ShowMessage;
                    }
                } while (choise != 0);
                break;
            }
    }

} while (menuChoise != 0);




static void ShowMessage(object sender, Event e)
{
    Console.WriteLine(e.Message);
}
static void SettingsMenu()
{
    Console.WriteLine("Choose which notification to remove");
    Console.WriteLine("1)Off balance notification\n2)Off add money notification\n3)Off send money notification\n4)Off Withdraw notification\n5)Off Authentification notification\n0)Save changes");
}
static void Menu()
{
    Console.WriteLine("Select the menu item:");
    Console.WriteLine("1)Check the balance\n2)Add money\n3)Send money to another card\n4)Withdraw money\n5)Settings\n0)Exit");
}