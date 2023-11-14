namespace BankApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var accountInstans = new Account();
            var account = accountInstans.CreateAccount();
            while (true)
            {
                Console.Clear();
                DisplayMenu();
                var answer = Console.ReadLine();
                UserChoice(account, answer);
            }
        }

        private static void UserChoice(Account account, string? answer)
        {
            switch (answer)
            {
                case "1":
                    Console.Clear();
                    account.CheckBalance(account);
                    Console.WriteLine("Ange hur mycket du vill sätta in");
                    var input = Console.ReadLine();

                    if (double.TryParse(input, out var amount))
                    {
                        account.Deposit(account, amount);
                        Console.WriteLine(amount + "kr insatt på " + account.Name);
                    }
                    else
                    {
                        WrongFormat();
                    }
                    Console.ReadKey();
                    break;
                case "2":
                    while (true)
                    {
                        Console.Clear();
                        account.CheckBalance(account);
                        Console.WriteLine("Hur mycket vill du ta ut?");
                        input = Console.ReadLine();

                        if (double.TryParse(input, out amount))
                        {
                            if (amount <= account.Balance)
                            {
                                account.Withdrawal(account, amount);
                                Console.WriteLine("Uttaget genomfört");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Välj ett mindre belopp");
                            }
                        }
                        else
                        {
                            WrongFormat();
                        }
                        Console.ReadKey();
                    }
                    Console.ReadKey();
                    break;
                case "3":
                    account.CheckBalance(account);
                    Console.ReadKey();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Ej valbart");
                    Console.ReadKey();
                    break;
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("1: Vill du sätta in pengar?");
            Console.WriteLine("2: Vill du ta ut pengar?");
            Console.WriteLine("3: Vill du se ditt saldo?");
            Console.WriteLine("0: Avsluta ");
        }

        private static void WrongFormat() => Console.WriteLine("Felaktigt format");

    }
}