using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    // Naming rules for types
    //   Noun, no abbreviations or acronyms
    //   Pascal cased

    // this keyword is only usable inside a type
    //   it represents the current instance/object
    //   it is used to distinguish class members from local identifiers

    // Accessibility - compile time access given to code (type, member, function, etc) for something
    //   public - usable by anyone
    //   private - only usable by defining type (default for members of a class)
    //   internal - (default for types): only usable in defining assembly

    // class-declaration ::= [modifiers] class identifier { class-members* }
    // class-members ::= field | method
    // field ::= [modifiers] T identifier [ = E ];
    // method ::= [modifiers] (T | void) identifier ( [parameters] ) { S* } 
    // modifiers ::= [public | internal]

    /// <summary>Represents a movie.</summary>
    /// <remarks>
    /// Where you put additional comments that may be useful to someone.
    /// </remarks>
    public class Movie
    {
        //CABEAT: NOT NEEDED HERE - just demo
        // Constructors - Create an instance of the type
        //      Bear minimal to create an instance
        //      method declaration with no return type and name is always the type name
        //      Use a constructor ONLY when field initializers will not work
        //          1. Non-primitive field that requires complex initialization
        //          2. One field relies on the value of another field
        //          3. (Depreciated) Allow creating and setting the most common properties
        //          4. Allow setting of properties that are not writable
        public Movie ()     //Default Constructor
        {
            //Initialize the fields that cannot be initialized using the field intializer syntax
            _description = _title;
        }

        //Allows you to create the instance and set a common property all at once
        public Movie ( string title)
        {
            _title = title;
        }

        // Methods - provide functionality to a class (functions)
        //   Methods are verbs representing action
        //   Methods are always Pascal cased

        // this is a reference to the instance the method is being called
        //   can be used to get the current instance
        //   never needed

        /// <summary>Determines if movie is black and white.</summary>
        /// <returns>Returns true if movie is black and white.</returns>
        public bool IsBlackAndWhite ( /* Movie this */ )
        {
            var isOld = ReleaseYear < 1940;
            //var isOld = this.releaseYear < 1940;

            //Only case where `this` makes sense
            //var title = "";
            //title = this.title;

            var note = "";
            note = Title;

            return isOld;
        }

        /// <summary>Do something complex.</summary>
        /// <param name="age">The age of the movie when restored.</param>
        /// <param name="enable">Determines if movie has been restored.</param>
        private void DoComplex ( int age, bool enable )
        { }

        // Problems with fields
        //  1) Can be read or written at will
        //  2) Calculated and must be updated whenever variant values are changed
        //  3) Can never change type from int
        //  4) What happens if it is negative
        //  5) Cannot initialize to another field
        //public int AgeInYears = DateTime.Today.Year - releaseYear;
        //public int GetAgeInYears ()
        //{
        //    if (DateTime.Now.Year < ReleaseYear)
        //        return 0;

        //    return DateTime.Today.Year - ReleaseYear;
        //}
        public int AgeInYears
        {
            //must have a setter or a getter but doesn't require that you have both
            get 
            {
                if (DateTime.Now.Year < ReleaseYear)
                    return 0;

                return DateTime.Today.Year - ReleaseYear;
            }
            //set {  }
        }
        //public void SetAgeInYears (int year) {}


        /// <summary>Validates the movie data is correct.</summary>
        /// <param name="error">The error message if any.</param>
        /// <returns>True if movie is valid.</returns>
        public bool Validate ( out string error )
        {
            //Title is required
            if (String.IsNullOrEmpty(Title))
            {
                error = "Title is required.";
                return false;
            };

            //Release year >= 1900
            if (ReleaseYear < 1900)
            {
                error = "Release year must be >= 1900.";
                return false;
            };

            //Run length >= 0
            if (RunLength < 0)
            {
                error = "Run length must be >= 0.";
                return false;
            };

            error = "";
            return true;
        }

        // Properties - expose data using methods (simple field syntax to call a complex method)
        //  Syntax starts out as a field but curly braces (no parens) like a method
        //  Use cases:
        //      1) Expose a backing field
        //      2) Calculated property - does not store data, just calculates it
        //  Golden rules:
        //      1) String and array properties never return null

        // Null handling
        //      null coalescing operator ::= E ?? E
        //          Find first non-null value
        //          equivalent to (E != null) ? E1 : E2
        //          left associative, can be combined (E1 ?? E2 ?? E3)
        //          can still return null, works with classes and strings only
        //      null condition operator ::= E ?. member
        //          Evaluates expression and if instance is not null, invokes member, or skips if it is
        //          Expression is changed to nullable E, works with all types
        //              int Hours(); instance?.Hours() => type of expression is int || null

        /// <summary>Gets or sets the title.</summary>
        public string Title
        {
            //getter - T identifier ()
            get // string get_Title ()
            {
                //Return title if not null or empty string otherwise
                return _title ?? ""; //return (_title != null) ? _title : "";
            }

            //setter - void identifier ( T value ) - validation done in setter
            set     // void set_Title ( string value )
            {
                _title = value?.Trim() ?? ""; //_title = (value != null) ? value.Trim() : null;
            }
        }

        //Fields - variables that store data
        // fields should always start with underscore and be camel cased
        // fields are initialized early in the process to 0, can be changed to another value
        // fields are initialized in an undefined order
        // fields cannot be initialized to another field's value
        // fields should always be preceded by an underscore

        /// <summary>Gets or sets the title.</summary>
        private string _title = "";

        public string Description
        {
            //get { return (_description != null) ? _description : ""; }
            get { return _description ?? ""; }
            set { _description = value; }
        }
        private string _description = "";

        public int ReleaseYear { get; set; } = 1900;

        //public int RunLength  //Full property Syntax
        //{
        //    get { return _runLength; }
        //    set { _runLength = value; }
        //}
        //private int _runLength;

        //Auto property Syntax - compiler will auto-generate the full property
        public int RunLength { get; set; }

        public string Rating
        {
            //get { return (_rating != null) ? _rating : ""; }
            get { return _rating ?? ""; }
            set { _rating = value; }
        }
        private string _rating = "";

        public bool IsClassic { get; set; }

        //Demo of mixed accessibility
        //  1. Can only be applied to either the getter or setter, not both
        //  2. Access modifier must be more restrictive than the property
        public int RestrictedProperty
        {
            get;
            private set;
        }

        //Allowed to expose a field if const or readonly
        //  const - glorified, named literal; value baked in to usage at compile time, must be set as part of the field initializer, only changes when you recompile everything(primitive and value will never change)
        //  readonly - const named variable; value referenced at runtime, must be initialized or in the constructor (non primitive only option)
        public const int MinimumReleaseYear = 1900;
        public readonly DateTime MinimumReleaseDate = new DateTime(1900, 1, 1);

        private string _note;
    }
}
