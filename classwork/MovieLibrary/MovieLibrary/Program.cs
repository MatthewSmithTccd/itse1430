/*
 * ITSE 1430
 * Spring 2021
 * Sample Implementation
 */
using System;

namespace MovieLibrary
{
    class Program
    {
        static void Main()  //string[] args
        {
            bool done = false;
            do
            {
                char option = DisplayMainMenu();

                if (option == 'A')
                    AddMovie();
                else if (option == 'V')
                    ViewMovie();
                else if (option == 'Q')
                    done = true;
                else
                    DisplayError("Unknown command");

            } while (!done);
        }

        // [modifiers* T identifier ( [parameters] ) { S* }
        // function declaration - function signature that tells the compiler a function exists
        // function signature - T identifier ( parameters )
        // function definition - function declaration + implementation
        private static char DisplayMainMenu ()
        {
            //Display output - equivalent to cout
            //Console.Write(); for no new line
            Console.WriteLine("Movie Library"); //String literals are enclosed in double quotes
            Console.WriteLine("-------------");

            Console.WriteLine("A) dd Movie");
            Console.WriteLine("V) iew Movie");
            Console.WriteLine("Q) uit-");

            //Console Input
            do
            {
                string input = Console.ReadLine();

                //TODO: Validate input better
                if (input == "A" || input == "a")
                    return 'A';
                else if (input == "Q" || input == "q")
                    return 'Q';
                else if (input == "V" || input == "v")
                    return 'V';

                DisplayError("Invalid option");
            } while (true);
        }

        // Get movie from user
        static void AddMovie ()
        {
            //title, release year, run length (min), description, rating
            Console.Write("Enter a title: ");
            title = Console.ReadLine();

            Console.Write("Enter an optional description: ");
            description = Console.ReadLine();

            Console.Write("Enter a release year: ");
            releaseYear = ReadInt32(1900);

            Console.Write("Enter a run length in minutes: ");
            runLength = ReadInt32(0);

            Console.Write("Enter a rating: ");
            rating = Console.ReadLine();

            Console.Write("Is a Classic (Y/N)? ");
            isClassic = ReadBoolean();

            ViewMovie();
        }

        static string title;        //lab assignment says to declare the variables outside the function (this is what it's talking about)
        static string description;
        static int releaseYear;
        static int runLength;
        static string rating;
        static bool isClassic;

        static void ViewMovie()
        {
            //TODO: Format
            Console.WriteLine(title);
            Console.WriteLine(description);
            Console.WriteLine(releaseYear);
            Console.WriteLine(runLength);
            Console.WriteLine(rating);
            Console.WriteLine(isClassic);
        }

        static bool ReadBoolean()
        {
            do
            {
                //ConsoleKeyInfo key = Console.ReadKey();
                string input = Console.ReadLine();

                //TODO: Case does not matter
                // input == "Y" || "y" --- Not Correct
                if (input == "Y" || input == "y")
                    return true;
                else if (input == "N" || input == "n")
                    return false;

                DisplayError("Please enter either Y or N");
            } while (true);
        }

        static int ReadInt32 ()
        {
            return ReadInt32(Int32.MinValue);
        }

        static int ReadInt32 ( int minimumValue )
        {
            //TODO: Handle min value
            // WHILE Statement
            // while (Eb) S;
            //      S executes 0 or more times (pretest)
            // DO WHILE statement - preferred and more common vs While loop
            //  do S while (Eb) ;
            //      S executes at least once (posttest) 
            // break statement
            //      only valid in loop constructs
            //      immediately exits the current loop
            // continue statement
            //      only valid in loop constructs
            //      immediately exits the current iteration and checks the loop again

            do
            {
                //Keep prompting until valid value
                string input = Console.ReadLine();

                //TODO: fix so it doesn't crash if not integer
                //Convert string to int
                //int value = Int32.Parse(input);    //atoi - prefer TryParse

                // IF statement
                // if (Eb) S;
                // if (Eb)
                //      St
                // else if (Eb)
                //      Stt;
                // else
                //      Sf;
                //int result;
                //if (Int32.TryParse(input, out result))
                //  int result;
                if (Int32.TryParse(input, out int result))  //Inline variable declaration makes it clear that the result only matters in this function
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

        private static void DisplayError ( string message )
        {
            Console.WriteLine(message);
        }

        void DemoTypes()
        {
            //Primitive types - types known by the compiler

            //integrals - signed
            // sbyte | 1 byte | -128 to 127                     (SByte.TryParse/Parse)
            // short | 2 bytes | +-32k                          (Int16.TryParse/Parse)
            // int   | 4 bytes | +- 2 billion | default         (Int32.TryParse/Parse)
            // long  | 8 bytes | really large | only for really large values over 2 billion  (Int64.TryParse/Parse)
            sbyte sbyteValue = 10;
            short shortValue = 10;
            int hours = 20;
            long starsInGalaxy = 10_000_000_000;
            long anotherLong = 10L; //Long literal

            //integrals - unsigned
            // byte | 1 byte | 0 to 255                         (Byte.TryParse/Parse)
            // ushort | 2 bytes | 0 to 64k                      (UInt16.TryParse/Parse)
            // uint   | 4 bytes | 0 to 4 billion | default      (UInt32.TryParse/Parse)
            // ulong  | 8 bytes | really large | only for really large values over 2 billion (UInt64.TryParse/Parse)
            ulong uLongCode = 10UL; //ulong literal

            //floating point
            //float     | 4 bytes   | +- E38    | 7-9 precision 123.456789
            //double    | 8 bytes   | +-E308    | 10-15 precision   | default
            //decimal   | 80 bytes  | currency (money)
            float delta = 4.5F;     //Float literal             (Single.TryParse/Parse)
            double taxRate = 8.75;  //                          (Double.TryParse/Parse)
            decimal payRate = 12.50M;   //Decimal literal use for price and payrate (Decimal.TryParse/Parse)

            //textual
            //char  | 2 bytes   | Single Character
            //string ! = ! Test
            char letter = 'A';
            string className = "ITSE 1430";

            //Miscellaneous
            // bool | 1 bit | True or false | Do not use 0 or 1
            bool isPassing = true;  //false                     (Boolean.TryParse/Parse)

            //Other types that may not be used (not primitive types)
            // DateTime 
            // TimeSpan
            // Guid
            DateTime today;
            TimeSpan duration;
            Guid uniqueId;

        }

        // Use Pascal Casing for functions (capitalize on word boundaries and first word - e.g. GetName, CalculateGrade)
        void DemoVariables()
        {
            string textInput = "";

            //textInput = "Hello";
            string textInput2 = textInput;

            //multiple declarations
            int x = 10, y = 12;

            //identifier rules
            // 1. must start with letter or underscore
            // 2. Consist of letters or digits or underscores
            // 3. must be unique in scope
            // 4. Cannot be a keyword

            //Variable name guidelines
            // nouns, descriptive
            // generally less than 15 characters long
            // are not single letters (e.g. x, y)
            // no abbreviations or acronyms unless they are well known (good: ok bad: nbr, num)
            // USE camel casing (capitalize on word boundaries, lowercase first word - e.g. firstName, payRate, hours)

            //Function name guidelines
            // descriptive verbs (e.g. Get, Display ..., Calculate ... )
            // Use Pascal casing
            // no abbreviations or acronyms
        }

        //Data to collect - title, genre, release year, actors, runtime, director, rating
        //title, release year, run length (min), description, rating

        void DemoExpressions ()
        {
            //Arithmetic    (op1 op op2)
            // op1 and op2 must be exact same type
            // If they are not then type coercion (compiler type casting - always safe)
            // double + int == double + double = double  (smaller type gets promoted temporarily)
            int result = 4 + 5;
            result = 5 - 45;
            result = 8 / 5;     // Int division: 1
            result = 8 % 5;     // result = 3  isEven ::= number % 2 = 0

            result = 4 + 6 * 5; //4 + (6 * 5) = 34

            //Logical (bool op bool -> bool)
            // Not same = && Y || Z (x && Y) || z not X && (Y || Z)  just use parenthesis because && and || are not the same precedent
            bool logicalResult = true && true;  //Logical AND
            logicalResult = true || true;       //Logical OR
            logicalResult = !true;              //Logical !

            // Relational (op1 rop op2 -> bool)
            bool relationalResult = 10 > 20;
            relationalResult = 10 < 20;
            relationalResult = 10 >= 20;
            relationalResult = 10 <= 20;
            relationalResult = 10 != 20;    //Not equal
            relationalResult = 10 == 10;    //Equality

            // Conditional
            //  E ? Et : Ef
            //  if (E)
            //      Et
            //  else
            //      Ef

            //Caveat is Et and Ef must be the exact same type (use typecasting if needed)

            //Expression always has a value and a type 
            //Statements don't have a value and a type

            // Misc
            // assignment lvalue = E
            //      right associative : evals the right side first and then the left
            logicalResult = relationalResult = false;

            // Prefix and postfix increment and decrements
            result = 5;
            int postfixinc = result++;  // result += 1; original value of result
            int prefixinc = ++result;   // result += 1;
            int postfixdec = result--;
            int prefixdec = --result;

            //Function Calls
            //  Parameter ::= variable inside function definition used to store temporary value
            //  Argument ::= expression used to assign a value to a parameter (Part of the function call)
            //  Kinds of parameters :: = Foo(x)
            //      Input (pass by value) - copies the argument value into the parameter's memory location, two separate copies
            //          Foo(12);
            //      Input/Output (pass by reference) - temporarily share the same memory location for two different variables
            //          Foo(ref arg);  keyword of ref is needed and is there to make sure you know it's pass by reference
            //      Output - Function caller provides space but the function provides the value
            //          Foo(out arg); It is required by the language that all output parameters must be set, out types must have a value returned
            result = ReadInt32();
            result = Int32.Parse("123");

        }

        //  Input parameter - 1 name
        // Input/Output parameter - ref T name
        // Output parameter - out T name
        void Foo ( int inputParameter, ref double ioParameter, out bool result )
        {
            result = false;
        }
    }
}
