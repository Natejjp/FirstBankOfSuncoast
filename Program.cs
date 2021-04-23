using System;
using System.Linq;
using System.Collections.Generic;

namespace FirstBankOfSuncoast
{
    class Transaction
    {
        public int ComputeAmount()
        {
            var startAmount = 0 + TotalAmount;
            return startAmount;
        }
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
            var checkingsTransactions = new List<Transaction>();
            var savingsTransactions = new List<Transaction>();
            var moneySavings = new Transaction();
            var moneyCheckings = new Transaction();

            var keepGoing = true;
            DisplayGreeting();

            while (keepGoing)
            {

                Console.WriteLine();
                Console.WriteLine("What would you like to do? (D)eposit, (W)ithdraw, (B)alance, (T)ransaction List, or (Q)uit ");
                var choiceAction = Console.ReadLine().ToUpper();

                switch (choiceAction)
                {
                    case "Q":

                        keepGoing = false;

                        break;

                    case "D":

                        Console.WriteLine("You chose to Deposit some money! ");
                        var choiceAccount0 = PromptForString("Which account, Checkings or Savings? ");

                        if (choiceAccount0 == "S")
                        {
                            moneySavings.TotalAmount = PromptForInteger("How much do you want to deposit in Savings? ");
                            moneySavings.TransactionType = ("Deposit");
                            moneySavings.AccountType = ("Savings");

                            savingsTransactions.Add(moneySavings);
                            allTransactions.Add(moneySavings);
                        }
                        else if (choiceAccount0 == "C")
                        {
                            Console.WriteLine("You chose to Deposit some money to Checkings! ");
                            moneyCheckings.TotalAmount = PromptForInteger("How much do you want to deposit? ");
                            moneyCheckings.TransactionType = ("Deposit");
                            moneyCheckings.AccountType = ("Checkings");

                            allTransactions.Add(moneyCheckings);
                            checkingsTransactions.Add(moneyCheckings);
                        }

                        break;

                    case "W":

                        Console.WriteLine("Which account would you like to interact with (S)avings or (C)heckings");
                        var choiceAccount1 = Console.ReadLine().ToUpper();
                        if (choiceAccount1 == "S")
                        {
                            Console.WriteLine("You chose to Withdraw some money from Savings! ");
                            moneySavings.TotalAmount = PromptForInteger("How much do you want to Withdraw? ");
                            moneySavings.AccountType = ("Savings");
                            moneySavings.TransactionType = ("Withdraw");

                            allTransactions.Remove(moneySavings);
                            savingsTransactions.Remove(moneySavings);
                        }
                        else if (choiceAccount1 == "C")
                        {
                            Console.WriteLine("You chose to Withdraw some money from Checkings! ");
                            moneyCheckings.TotalAmount = PromptForInteger("How much do you want to Withdraw? ");
                            moneyCheckings.AccountType = ("Checkings");
                            moneyCheckings.TransactionType = ("Withdraw");

                            allTransactions.Remove(moneyCheckings);
                            checkingsTransactions.Remove(moneyCheckings);
                        }
                        break;

                    case "B":

                        Console.WriteLine("Which account would you like to interact with (S)avings or (C)heckings");
                        var choiceAccount2 = Console.ReadLine().ToUpper();
                        if (choiceAccount2 == "S")
                        {
                            var foundDeposits = savingsTransactions.Where(s => s.TransactionType == "Deposit").Sum(s => s.TotalAmount);
                            var foundWithdraw = savingsTransactions.Where(s => s.TransactionType == "Withdraw").Sum(s => s.TotalAmount);
                            var savingsBalance = $"{foundDeposits - foundWithdraw}";
                            Console.WriteLine($"You have {savingsBalance} in Savings");

                        }
                        else if (choiceAccount2 == "C")
                        {

                            var foundDeposits = checkingsTransactions.Where(s => s.TransactionType == "Deposit").Sum(s => s.TotalAmount);
                            var foundWithdraw = checkingsTransactions.Where(s => s.TransactionType == "Withdraw").Sum(s => s.TotalAmount);
                            var checkingsBalance = $"{foundDeposits - foundWithdraw}";
                            Console.WriteLine($"You have {checkingsBalance} in Checkings");


                        }
                        break;

                    case "T":
                        {

                        }
                        break;



                }
            }
        }
    }

}









