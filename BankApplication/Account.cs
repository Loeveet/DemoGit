using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    public class Account
    {
        public string? Name { get; set; }
        public int AccountNumber { get; set; }
        public double Balance { get; set; }

        public Account CreateAccount()
        {
            Console.Write("Namn på bankkonto: ");
            var name = Console.ReadLine();
            var random = new Random();
            AccountNumber = random.Next(10000, 99999);
            return new Account { Name = name, AccountNumber = random.Next(10000, 99999), Balance = 0};
        }

                
        public double Deposit(Account account, double amount) => account.Balance += amount;

        public double Withdrawal(Account account, double amount) => account.Balance -= amount; 
        
        public void CheckBalance(Account account) => Console.WriteLine(account.Name + ": " + account.Balance + "kr");

    }
}
