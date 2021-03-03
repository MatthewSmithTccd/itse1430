/*
 * Character Creator
 * ITSE 1430
 * Spring 2021
 * Matthew Smith
 */
using System;

namespace CharacterCreator.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Character Creator \nITSE 1430 \nSpring 2021 \nMatthew Smith\n");
            bool done = false;
            do
            {
                char option = DisplayMainMenu();

                switch (option)
                {
                    case 'A': AddNewCharacter(); break;
                    case 'V': ViewCharacter(); break;
                    case 'E': EditCharacter(); break;
                    case 'D': DeleteCharacter(); break;
                    case 'Q': if (ValidateQuit()) done = true; else done = false; break;

                    default: DisplayError("Unknown command"); break;
                };

            } while (!done);
        }

        private static void DeleteCharacter ()
        {
            throw new NotImplementedException();
        }

        private static void EditCharacter ()
        {
            throw new NotImplementedException();
        }

        private static void ViewCharacter ()
        {
            throw new NotImplementedException();
        }

        private static void AddNewCharacter ()
        {
            throw new NotImplementedException();
        }

        private static char DisplayMainMenu ()
        {

            Console.WriteLine("Main Menu");
            Console.WriteLine("-------------");

            Console.WriteLine("A) dd New Character");
            Console.WriteLine("V) iew Character");
            Console.WriteLine("E) dit Character");
            Console.WriteLine("D) elete Character");
            Console.WriteLine("Q) uit-");

            //Console Input
            do
            {
                string input = Console.ReadLine();


                switch (input)
                {
                    case "A":
                    case "a": return 'A';

                    case "V":
                    case "v": return 'V';

                    case "E":
                    case "e": return 'E';

                    case "D":
                    case "d": return 'D';

                    case "Q":
                    case "q": return 'Q';
                };

                DisplayError("Invalid option");
            } while (true);
        }

        private static bool ValidateQuit ()
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

        private static void DisplayError ( string message )
        {
            Console.WriteLine(message);
        }
    }
}
