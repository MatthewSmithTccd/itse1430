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
            Character character;
            character = new Character();
            
            Console.WriteLine("Enter your character's name: ");
            character.Name = Console.ReadLine();

            Console.WriteLine("Choose a profession: ");
            character.Profession = ChooseProfession();

            Console.WriteLine("Choose a race: ");
            character.Race = ChooseRace();

            Console.WriteLine("Biography(optional): ");
            character.Biography = Console.ReadLine();

            Console.WriteLine("Assign Strength Attribute(1-100): ");
            character.StrengthAttribute = ReadAttribute();

            Console.WriteLine("Assign Intelligence Attribute(1-100): ");
            character.IntelligenceAttribute = ReadAttribute();

            Console.WriteLine("Assign Agility Attribute(1-100): ");
            character.AgilityAttribute = ReadAttribute();

            Console.WriteLine("Assign Constitution Attribute(1-100): ");
            character.ConstitutionAttribute = ReadAttribute();

            Console.WriteLine("Assign Charisma Attribute(1-100): ");
            character.CharismaAttribute = ReadAttribute();
        }

        private static int ReadAttribute ()
        {
            do
            {
                var input = Console.ReadLine();

                if (Int32.TryParse(input, out var result))
                {
                    //Make sure it is at least minValue
                    if (result > 0 && result < 101)
                        return result;
                    else
                        DisplayError("Value must be between 1 and 100");
                } else
                    DisplayError("Value must be numeric");
            } while (true);
        }

        private static string ChooseRace ()
        {
            Console.WriteLine("(D)warf, (E)lf, (G)nome, (H)alf-Elf, H(U)man");
            Console.WriteLine("Press D, E, G, H, or U: ");
            string choice = Console.ReadLine();
            do
            {
                switch (choice)
                {
                    case "D":
                    case "d": return "Dwarf";

                    case "E":
                    case "e": return "Elf";

                    case "G":
                    case "g": return "Gnome";

                    case "H":
                    case "h": return "Half Elf";

                    case "U":
                    case "u": return "Human";
                };

                DisplayError("Invalid Option");
            } while (true);
        }

        private static string ChooseProfession ()
        {
            Console.WriteLine("(F)ighter, (H)unter, (P)riest, (R)ogue, (W)izard");
            Console.WriteLine("Press F, H, P, R, or W: ");
            string choice = Console.ReadLine();
            do
            {
                switch (choice)
                {
                    case "F":
                    case "f": return "Fighter";

                    case "H":
                    case "h": return "Hunter";

                    case "P":
                    case "p": return "Priest";

                    case "R":
                    case "r": return "Rogue";

                    case "W":
                    case "w": return "Wizard";
                };

                DisplayError("Invalid Option");
            } while (true);

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
