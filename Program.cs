using System;
using System.Linq;
using System.Collections.Generic;

namespace FirstBankOfSuncoast
{
    class Transaction
    {
        public int TotalAmount { get; set; }
        public string AccountType { get; set; }
        public string TransactionType { get; set; }
        public DateTime TimeOfTransaction { get; set; }

    }

    class Program
    {
        static void DisplayGreeting()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine(" Welcome to the Best Bank in Da World!  ");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
        }

        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine().ToUpper();
            return userInput;
        }

        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine().ToUpper(), out userInput);
            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("This is not valid input. Using 0 ");
                return 0;
            }
        }

        static void Main(string[] args)
        {
            var allTransactions = new List<Transaction>();

            var keepGoing = true;
            DisplayGreeting();

            while (keepGoing)
            {
                var money = new Transaction();

                Console.WriteLine();
                Console.WriteLine("What would you like to do? (D)eposit, (W)ithdraw, (B)alance, (T)ransaction List, or (Q)uit ");
                var choice = Console.ReadLine().ToUpper();

                switch (choice)
                {
                    case "Q":

                        keepGoing = false;

                        break;

                    case "D":

                        Console.WriteLine("You chose to Deposit some money! ");
                        var choiceAccount0 = PromptForString("Which account would you like to interact with (S)avings or (C)heckings?");

                        if (choiceAccount0 == "S")
                        {
                            Console.WriteLine("You chose to Deposit money to Savings! ");
                            money.TotalAmount = PromptForInteger("How much do you want to deposit in Savings? ");
                            money.TransactionType = ("Deposit");
                            money.AccountType = ("Savings");
                            money.TimeOfTransaction = DateTime.Now;

                            if (money.TotalAmount <= 0)
                            {
                                Console.WriteLine("You are not able to deposit a negative amount!");
                            }
                            else
                            {
                                Console.WriteLine($"You have depositted {money.TotalAmount} in your savings account!");
                                allTransactions.Add(money);
                            }

                        }
                        else if (choiceAccount0 == "C")
                        {
                            Console.WriteLine("You chose to Deposit some money to Checkings! ");
                            money.TotalAmount = PromptForInteger("How much do you want to deposit in Checkings? ");
                            money.TransactionType = ("Deposit");
                            money.AccountType = ("Checkings");
                            money.TimeOfTransaction = DateTime.Now;

                            if (money.TotalAmount <= 0)
                            {
                                Console.WriteLine("You are not able to deposit a negative amount!");
                            }
                            else
                            {
                                Console.WriteLine($"You have depositted {money.TotalAmount} in your checkings account!");
                                allTransactions.Add(money);
                            }
                        }

                        break;

                    case "W":

                        Console.WriteLine("Which account would you like to interact with (S)avings or (C)heckings?");
                        var choiceAccount1 = Console.ReadLine().ToUpper();
                        if (choiceAccount1 == "S")
                        {
                            Console.WriteLine("You chose to Withdraw some money from Savings! ");
                            money.TotalAmount = PromptForInteger("How much do you want to Withdraw? ");
                            money.AccountType = ("Savings");
                            money.TransactionType = ("Withdraw");
                            money.TimeOfTransaction = DateTime.Now;

                            var foundDeposits = allTransactions.Where(s => s.AccountType == "Savings").Where(s => s.TransactionType == "Deposit").Sum(s => s.TotalAmount);
                            var foundWithdraw = allTransactions.Where(s => s.AccountType == "Savings").Where(s => s.TransactionType == "Withdraw").Sum(s => s.TotalAmount);

                            if (money.TotalAmount > foundDeposits - foundWithdraw)
                            {
                                Console.WriteLine($"You broke! No money in your Savings Account");
                            }
                            else
                            {
                                Console.WriteLine($"You have withdrew {money.TotalAmount} from your savings account!");
                                allTransactions.Add(money);
                            }

                        }
                        else if (choiceAccount1 == "C")
                        {
                            Console.WriteLine("You chose to Withdraw some money from Checkings! ");
                            money.TotalAmount = PromptForInteger("How much do you want to Withdraw? ");
                            money.AccountType = ("Checkings");
                            money.TransactionType = ("Withdraw");
                            money.TimeOfTransaction = DateTime.Now;

                            var foundDeposits = allTransactions.Where(s => s.AccountType == "Checkings").Where(s => s.TransactionType == "Deposit").Sum(s => s.TotalAmount);
                            var foundWithdraw = allTransactions.Where(s => s.AccountType == "Checkings").Where(s => s.TransactionType == "Withdraw").Sum(s => s.TotalAmount);

                            if (money.TotalAmount > foundDeposits - foundWithdraw)
                            {
                                Console.WriteLine($"You broke! No money in your Checking Account");
                            }
                            else
                            {
                                Console.WriteLine($"You have withdrew {money.TotalAmount} from your checkings account!");
                                allTransactions.Add(money);
                            }
                        }

                        break;

                    case "B":

                        Console.WriteLine("Which account would you like to interact with (S)avings or (C)heckings");
                        var choiceAccount2 = Console.ReadLine().ToUpper();
                        if (choiceAccount2 == "S")
                        {
                            var foundDeposits = allTransactions.Where(s => s.AccountType == "Savings").Where(s => s.TransactionType == "Deposit").Sum(s => s.TotalAmount);
                            var foundWithdraw = allTransactions.Where(s => s.AccountType == "Savings").Where(s => s.TransactionType == "Withdraw").Sum(s => s.TotalAmount);
                            var savingsBalance = $"{foundDeposits - foundWithdraw}";
                            Console.WriteLine($"You have {savingsBalance} in Savings");

                        }
                        else if (choiceAccount2 == "C")
                        {

                            var foundDeposits = allTransactions.Where(s => s.AccountType == "Checkings").Where(s => s.TransactionType == "Deposit").Sum(s => s.TotalAmount);
                            var foundWithdraw = allTransactions.Where(s => s.AccountType == "Checkings").Where(s => s.TransactionType == "Withdraw").Sum(s => s.TotalAmount);
                            var checkingsBalance = $"{foundDeposits - foundWithdraw}";
                            Console.WriteLine($"You have {checkingsBalance} in Checkings");

                        }
                        break;

                    case "T":
                        foreach (var transaction in allTransactions)
                        {
                            Console.WriteLine($"{transaction.TotalAmount}");
                            Console.WriteLine($"{transaction.TransactionType}");
                            Console.WriteLine($"{transaction.AccountType}");
                            Console.WriteLine($"{transaction.TimeOfTransaction}");
                        }

                        break;


                }
            }
        }
    }

}









