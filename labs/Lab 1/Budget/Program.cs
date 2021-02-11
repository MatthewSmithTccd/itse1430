/*
 * Budget
 * ITSE 1430
 * Spring 2021
 * Matthew Smith
 */

using System;
using System.Globalization;

namespace Budget
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Budget \nITSE 1430 \nSpring 2021 \nMatthew Smith\n");
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
                    case 'Q': if (ValidateQuit()) done = true; else done = false;  break;                            

                    default: DisplayError("Unknown command"); break;
                };

            } while (!done);
        }

        //Global Variables to be used throughout program
        static string accountName;
        static string accountNumber;
        static decimal startingBalance;

        static void PromptUser ()
        {
            do
            {
                Console.WriteLine("Enter Account Information");
                Console.WriteLine("-------------------------");
                Console.WriteLine("Enter account name: ");
                accountName = Console.ReadLine();

                if (accountName == "")
                    DisplayError("Account Name Required");

            } while (accountName == "");

            Console.WriteLine("Enter account number(12 digits): ");
            accountNumber = ReadAccountNumber();    //Tests that account number is 12 characters long, only digits 0-9, does not start or end with 0

            Console.WriteLine("Enter starting balance: ");
            startingBalance = ReadDecimal(0);
        }

        private static bool ValidateQuit()
        {
            do
            {
                Console.WriteLine("Are you sure you would like to quit?(Y/N) ");
                string quit = Console.ReadLine();


                if (quit == "Y" || quit == "y")
                    return true;
                else if (quit == "N" || quit == "n")
                    return false;
                else
                    DisplayError("Please enter Y or N ");
            } while (true);
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
            Console.Write("How much would you like to deposit? ");
            decimal depositAmount = ReadDecimal(0);

            if (depositAmount > 0)
            {
                startingBalance = startingBalance + depositAmount;  //adds deposit amount to balance

                string depositDescription = "";

                do
                {
                    Console.Write("Enter a description: ");
                    depositDescription = Console.ReadLine();

                    if (depositDescription == "")
                        DisplayError("Description Required.");

                } while (depositDescription == "");

                Console.Write("Enter a Category (Optional): ");
                string depositCategory = Console.ReadLine();

                Console.Write("Enter check number (Optional): ");
                int checkNumber = ReadInt32(0);

                Console.Write("Date of deposit MM/dd/yyyy (Optional): ");
                DateTime depositDate = ReadDate();

                Console.Write("Balance successfully updated.  Returning to Main Menu.\n");
            } else
                DisplayError("Value must be greater than 0. Returning to Main Menu.\n");
        }

        static DateTime ReadDate ()
        {  
            do
            {
                var input = Console.ReadLine();
                string dateFormat = "MM/dd/yyyy" ;
                DateTime validDay;

                if (DateTime.TryParseExact(input, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out validDay))
                    return validDay;
                else if (input == "")
                    return validDay;
                else
                    DisplayError("Not a valid date (mm/dd/yyyy)");

            } while (true);
        }

        static void WithdrawFunds ()
        {
            Console.Write("How much would you like to withdraw? ");
            decimal withdrawAmount = ReadDecimal(0);

            if (withdrawAmount > 0 && withdrawAmount <= startingBalance)    
            {
                startingBalance = startingBalance - withdrawAmount;  //adds deposit amount to balance

                string withdrawDescription = "";

                do
                {
                    Console.Write("Enter a description: ");
                    withdrawDescription = Console.ReadLine();

                    if (withdrawDescription == "")
                        DisplayError("Description Required.");

                } while (withdrawDescription == "");

                Console.Write("Enter a Category (Optional): ");
                string depositCategory = Console.ReadLine();

                Console.Write("Enter check number (Optional): ");
                string checkNumber = Console.ReadLine();
                Int32.TryParse(checkNumber, out int intCheckNumber);

                Console.Write("Date of deposit MM/dd/yyyy (Optional): ");
                DateTime depositDate = ReadDate();

                Console.Write("Balance successfully updated.  Returning to Main Menu.\n");

            } else DisplayError("Withdraw amount can't be 0 or greater than balance.");
        }

        //Reads in the account number and validates input
        static string ReadAccountNumber ()  
        {
            do
            {
                string testAccountNumber = Console.ReadLine();
                bool startsWithZero = testAccountNumber.StartsWith('0');
                bool endsWithZero = testAccountNumber.EndsWith('0');
                int accountNumberLength = testAccountNumber.Length;
                bool containsNonNumerics = TestForLetters(testAccountNumber);

                if (testAccountNumber == "")
                    DisplayError("Account Number Required\nTry again: ");
                else if (containsNonNumerics)
                    DisplayError("Account Numbers are 0-9 only.\nTry again: ");
                else if (startsWithZero)
                    DisplayError("Account Number may not start with a 0.\nTry again: ");
                else if (endsWithZero)
                    DisplayError("Account Number may not end with a 0.\nTry again: ");
                else if (accountNumberLength < 12 || accountNumberLength > 12)
                    DisplayError("Account Number must be 12 numbers.\nTry again: ");
                else
                    return testAccountNumber;
            } while (true);
            
        }

        static bool TestForLetters (string isDigits)    //helper function that returns true if the string contains letters
        {
            foreach (char c in isDigits)
            {
                if (c < '0' || c > '9')
                    return true;
            }
            return false;
        }

        static void DisplayAccountInfo ()
        {
            Console.WriteLine("\nAccount Information");
            Console.WriteLine("Account Name: " + accountName);
            Console.WriteLine("Account Number: " + accountNumber);
            Console.WriteLine("Account Balance: " + startingBalance.ToString("C"));
            Console.WriteLine("");
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

        static int ReadInt32 ()
        {
            return ReadInt32(Int32.MinValue);
        }

        static int ReadInt32 ( int minimumValue )
        {
            do
            {
                var input = Console.ReadLine();

                if (Int32.TryParse(input, out var result))  
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
