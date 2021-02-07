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

            Console.WriteLine("Account Name:" + accountName);
            Console.WriteLine("Account Number:" + accountNumber);
            Console.WriteLine("Account Balance: $" + startingBalance);
        }

        //Global Variables to be used throughout program
        static string accountName;
        static string accountNumber;
        static decimal startingBalance;

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
