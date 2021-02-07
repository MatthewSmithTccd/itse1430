/*
 * Budget
 * ITSE 1430
 * Spring 2021
 * Matthew Smith
 */

using System;

namespace Budget
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Budget, ITSE 1430, Spring 2021, Matthew Smith\n");
            PromptUser();

            bool done = false;
            do
            {
                DisplayAccountInfo();

                char option = DisplayMainMenu();

                switch (option)
                {
                    case 'D': DepositFunds(); break;
                    case 'W': WithdrawFunds(); break;
                    //TODO: Only Allow Y or y or N or n 
                    case 'Q': if (ValidateQuit()) done = true; else DisplayMainMenu(); break;                             //done = true; break;

                    default: DisplayError("Unknown command"); break;
                };

            } while (!done);
        }

        //Global Variables to be used throughout program
        static string accountName;
        static string accountNumber;
        static decimal startingBalance;

        private static bool ValidateQuit()
        {
            Console.WriteLine("Are you sure you would like to quit?(Y/N) ");
            string quit = Console.ReadLine();

            if (quit == "Y" || quit =="y")
                return true;
            else
                return false;
                
        }


        private static char DisplayMainMenu ()
        {
            
            Console.WriteLine("Main Menu"); 
            Console.WriteLine("-------------");

            Console.WriteLine("D) eposit Funds");
            Console.WriteLine("W) ithdraw Funds");
            Console.WriteLine("Q) uit-");

            //Console Input
            do
            {
                string input = Console.ReadLine();

                
                switch (input)
                {
                    case "D":
                    case "d": return 'D';

                    case "W":
                    case "w": return 'W';
                    
                    case "Q":
                    case "q": return 'Q';
                };

                DisplayError("Invalid option");
            } while (true);
        }

        static void DepositFunds()
        {

        }

        static void WithdrawFunds ()
        {

        }

        static void PromptUser ()
        {
            Console.WriteLine("Enter account name: ");
            accountName = Console.ReadLine();


            Console.WriteLine("Enter account number: ");
            //TODO: validate account is 12 chars long, only digits 0-9, Doesnt start or end with a zero.
            accountNumber = Console.ReadLine();

            Console.WriteLine("Enter starting balance: ");
            startingBalance = ReadDecimal(0);
        }

        static void DisplayAccountInfo ()
        {
            Console.WriteLine("\nAccount Name: " + accountName);
            Console.WriteLine("Account Number: " + accountNumber);
            Console.WriteLine("Account Balance: $" + startingBalance);
        }
        

        static decimal ReadDecimal ()
        {
            return ReadDecimal(Decimal.MinValue);
        }

        static decimal ReadDecimal (decimal minimumValue)
        {
            do
            {
                var input = Console.ReadLine();

                if (Decimal.TryParse(input, out var result))  
                {
                    //Make sure it is at least minValue
                    if (result >= minimumValue)
                        return result;
                    else
                        DisplayError("Value must be at least " + minimumValue);
                } else
                    DisplayError("Value must be numeric");

            } while (true);
        }


        private static void DisplayError (string message)
        {
            Console.WriteLine(message);
        }

        
    }
}
