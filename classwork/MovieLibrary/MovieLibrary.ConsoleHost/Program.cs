/*
 * ITSE 1430
 * Spring 2021
 * Sample Implementation
 */
using System;  //Bring into scope all the types defined in the given namespace

//Renamed to match project name
namespace MovieLibrary.ConsoleHost
{
    class Program  //MovieLibrary.ConsoleHost.Program
    {
        static void Main()  //string[] args
        {
            //Fully qualified type name: System.Boolean   [namespace].[type]
            bool done = false;
            do
            {
                char option = DisplayMainMenu();

                // Switch statement is equivalent to a series of if-else if with equality checks
                //      switch statement ::= switch(E) { case-statement* [default-statement] };
                // case-statement ::= case E : S;
                // default-statement ::= default : S ;
                //
                // case label rules:
                //      - Must be constant values : literals or simple expressions of constant values
                //      - Must be unique
                //      - Can be a string
                // Fallthrough behavior
                //      - Not allowed
                //      - Every case statement must end with either break or return statement
                //      - Allowed if case label has no statement (including semicolon)
                // Styling rules
                //      - Single statement (excluding break) no block statement neeeded
                //      - Multiple statements (excluding break) should use block statement to avoid compiler errors

                /*switch (10)
                {
                    case 10: S1; S2; S3; break;
                    case 12:
                    {
                        int x; x = 10;
                        break;
                    };
                    case 13: SByte; break;
                }
                */

                /*
                if (option == 'A')
                    AddMovie();
                else if (option == 'V')
                    ViewMovie();
                else if (option == 'Q')
                    done = true;
                else
                    DisplayError("Unknown command");
                */
                switch (option)
                {
                    case 'A': AddMovie(); break;
                    case 'V': ViewMovie(); break;
                    case 'Q': done = true; break;

                    default: DisplayError("Unknown command"); break;
                };

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
            //Console.WriteLine("-------------");
            Console.WriteLine("".PadLeft(20, '-'));

            Console.WriteLine("A) dd Movie");
            Console.WriteLine("V) iew Movie");
            Console.WriteLine("Q) uit-");

            //Console Input
            do
            {
                string input = Console.ReadLine();

                //TODO: Validate input better
                /*if (input == "A" || input == "a")
                    return 'A';
                else if (input == "Q" || input == "q")
                    return 'Q';
                else if (input == "V" || input == "v")
                    return 'V';
                */
                switch (input)
                {
                    case "A": 
                    case "a": return 'A';

                    case "Q": 
                    case "q": return 'V';

                    case "V": 
                    case "v": return 'v';
                };

                DisplayError("Invalid option");
            } while (true);
        }

        // Get movie from user
        static void AddMovie ()
        {
            // new T();
            // C++ example Movie* movie = new Movie();
            Movie movie = new Movie();
            
            //Member access operator
            //      member-access ::= E . Member

            //title, release year, run length (min), description, rating
            Console.Write("Enter a title: ");
            movie.title = Console.ReadLine();

            Console.Write("Enter an optional description: ");
            movie.description = Console.ReadLine();

            Console.Write("Enter a release year: ");
            movie.releaseYear = ReadInt32(1900);

            Console.Write("Enter a run length in minutes: ");
            movie.runLength = ReadInt32(0);

            Console.Write("Enter a rating: ");
            movie.rating = Console.ReadLine();

            Console.Write("Is a Classic (Y/N)? ");
            movie.isClassic = ReadBoolean();

            //Hiding the field movie
            //this.movie = movie;
            _movie = movie;

            ViewMovie();
        }


        static Movie _movie;

        static void ViewMovie()
        {
            //TODO: Format
            Console.WriteLine($"{_movie.title} ({_movie.releaseYear})");
            if (_movie.runLength > 0)
                Console.WriteLine($"Running Time: {_movie.runLength} minutes");
            if (!String.IsNullOrEmpty(_movie.rating))
                Console.WriteLine($"MPAA Rating: {_movie.rating}");

            Console.WriteLine($"Classic? {(_movie.isClassic ? 'Y' : 'N')}");

            if (!String.IsNullOrEmpty(_movie.description))
                Console.WriteLine(_movie.description);
        }

        static bool ReadBoolean()
        {
            do
            {
                //ConsoleKeyInfo key = Console.ReadKey();
                string input = Console.ReadLine();

                //TODO: Case does not matter
                // input == "Y" || "y" --- Not Correct
                //Comparison 1
                //if (input == "Y" || input == "y")
                //    return true;
                //else if (input == "N" || input == "n")
                //    return false;

                //Should use switch but will play around with comparison
                // Not really recommended...
                //Comparison 2
                //if (input.ToUpper() == "Y")
                //    return true;
                //else if (input.ToLower() == "n")
                //    return false;

                //Comparison 3
                if (String.Compare(input, "Y", true) == 0)
                    return true;
                else if (String.Compare(input, "N", true) == 0)
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
                //Type inferencing - compiler infers type based upon assignment
                // var can be used if it's inferred what type of variable will be inputted (allowed only with local variables
                // personal preference, used to save some time, when doing code maintence you won't have to change the type

                //Keep prompting until valid value
                var input = Console.ReadLine();

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
                if (Int32.TryParse(input, out var result))  //Inline variable declaration makes it clear that the result only matters in this function
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

        void DemoString()
        {
            //Conversion to string E.ToString();
            // Console.WriteLine(10); -> Console.WriteLine(10.ToString()); behind the scenes console write line is doing ToString
            int hours = 10;
            string hourString = hours.ToString();
            hourString = 10.ToString();

            //String literals ""
            //escape sequence - \? inside a string literal, have special meaning to the compiler
            //  \n - new line (you will rarely use this in csharp)
            //  \t - horizontal tab
            //  \\ - slash (e.g. C:\\temp\\test.txt"   slashes count once when counting the amount of characters in the string
            //  \" - double quote (e.g. "Hello \"Bob\"")
            //  \' - single quote in character
            //  \x## - hex code equivalent

            string stringLiteral = "Hello" + "World";
            stringLiteral = "Hello\nWorld";

            //Verbatim syntax - escape sequence ignored
            string filePath = "C:\\Temp\\test.txt";
            string filePath2 = @"C:\Temp\test.txt";

            //Empty string
            //null and empty string are not the same
            string emptyString = "";
            string defaultString = null;
            bool areEqual = emptyString == defaultString;   //false
            string emptyString2 = String.Empty;      // "" == String.Empty

            //Checking for empty, use String.IsNullOrEmpty()
            bool isEmpty = emptyString == "";
            bool isEmpty2 = emptyString == "" || emptyString == null;   //if empty or null
            bool isEmptyPreferred = String.IsNullOrEmpty(emptyString);  //Handles both - USE THIS METHOD returns true if empty or null, false if it has any other value

            // String concatenation
            //  +
            //  String.Concat()
            //  String.Join
            string first = "Hello", second = "World";

            // start with 3 strings (first + " "), (first + " " + second), (now we have 5 strings in memory)
            string concatOp = first + " " + second;     //Compiler rewrites this as String.Concat() to optimize
            string concatFunction = String.Concat(first, " ", second);  //More optimized for performance
            string joinFunction = String.Join(' ', first, second);

            //  Strings are immutable!!!! Value Can't be changed
            //      10 + 2 = 12
            string immutableString = "Hello";
            immutableString += " ";     // two strings: "Hello", "Hello "
            immutableString += "World"; // three strings "Hello", "Hello ", "Hello World"

            // String formatting
            //      The result of 4 + 5 is 9

            int x = 4, y = 5;

            // 1) String concatenation  - ugly and lot to type
            string format1 = "The result of " + x + " _ " + y + " = " + (x+y);

            // 2) String Format - more readable than string concat
            //          - runtime overhead
            //          - missing arguments then crashes
            //      Format specifiers follow the ordinal :
            String format2 = String.Format("The result {0:00} + {1:N2} = {2}", x, y, (x+y));

            Console.WriteLine(format2);
            Console.WriteLine("The result {0} + {1} = {2}", x, y, (x+y));

            // 3) String interpolation - let the compiler do it (Preferred Method)
            //      Only works with string literals
            //      Still has the runtime overhead
            string format3 = $"The result of {x:00} + {y:N2} = {x+y}";

            string formattedValue = x.ToString("00");

            decimal price = 8500;
            string priceString = price.ToString("C");   // $8,500.00

            // Common string functions
            //      String.<function>
            //      <string>.<function>
            int len = priceString.Length;   // Length, in chars, of string

            // Casing
            var name = "Bob";
            string upperName = name.ToUpper();  //Upper cases string
            string lowerName = name.ToLower();  //Lower cases string

            // Comparison
            // 1)"a" == "A"   //false
            // int to boolean functions ::>
            //      < 0 means a < b
            //      == 0 means a == b
            //      > 0 means a > b
            // 2) // string.CompareTo(string) -> int,  case sensitive
            var areEqualStrings1 = name.CompareTo("bob") == 0;

            // 3) String.Compare(str, str) -> int
            //      String.Compare(str, str, bool ) -> int
            var areEqualStrings2 = String.Compare(name, "bob", true) == 0; // Case insensitive
            var areEqualStrings3 = String.Compare(name, "bob", StringComparison.CurrentCultureIgnoreCase) == 0; // Case insensitive

            // Padding / Trimming
            //      <string>.Trim() -> string with all whitespace removed from front and back
            //      <string>.TrimStart() / TrimEnd() -> only from front and back
            //      <string.PadLeft(width) / PadRight(width) -> adds spaces until given width
            string trimmedString = name.Trim();
            string trimmedPath = @"C:\Temp\test\folder1\".Trim('\\', ' ', '\t');

            string paddedString = name.PadLeft(10);

            // Manipulate strings
            string world = "Hello World".Substring(6);
            string wor = "Hellow World".Substring(6, 3);
            int index = "Hello World".IndexOf(' ');
            

            // Matching 
            // USE THIS FOR CHECKING ACCOUNT NUMBER and .Length
            bool startsWithSlash = @"\Temp\test.txt".StartsWith('\\');
            bool endsWithSlash = @"\Temp\test.txt".EndsWith('\\');
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

            // Primitive types in .NET map to framework types (type aliasing)
            // int -> Int32
            // double -> Double
            // short -> Int16
            // bool -> Boolean
            // char -> Char
            int int1 = 10;
            Int32 int2 = 20;
            int1 = int2;        //When calling functions we use the formal type (Int32 etc.)

            //result = int.Parse("123");  //Int32.Parse("123"); is the same thing
            

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
