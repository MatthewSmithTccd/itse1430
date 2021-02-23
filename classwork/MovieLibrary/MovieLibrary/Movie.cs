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
        public int GetAgeInYears
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

        /// <summary>Gets or sets the title.</summary>
        public string Title
        {
            //getter - T identifier ()
            get // string get_Title ()
            {
                //Return title if not null or empty string otherwise
                return (_title != null) ? _title : "";
            }

            //setter - void identifier ( T value ) - validation done in setter
            set     // void set_Title ( string value )
            {
                _title = value;
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
            get { return (_description != null) ? _description : ""; }
            set { _description = value; }
        }
        private string _description = "";

        public int ReleaseYear
        {
            get { return _releaseYear; }
            set { _releaseYear = value; }
        }
        private int _releaseYear = 1900;

        public int RunLength
        {
            get { return _runLength; }
            set { _runLength = value; }
        }
        private int _runLength;

        public string Rating
        {
            get { return (_rating != null) ? _rating : ""; }
            set { _rating = value; }
        }
        private string _rating = "";

        public bool IsClassic
        {
            get { return _isClassic; }
            set { _isClassic = value; }
        }
        private bool _isClassic;

        private string _note;
    }
}
