using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    // Naming Rules for types
    //      Noun, no abbreviations or acronyms
    //      Pascal cased

    // this keyword is only usable inside a type
    //      it represents the current instance/object
    //      it is used to distinguish class members from local identifiers

    // Accessibility - complie time access given to code(type, member, function, etc) for something
    //      public - usable by anyone
    //      private - only usable by defining type (default for members of a class
    //      internal - (default for types): only usable in definining assembly

    //class-declaration: [modifiers] class identifier { members* }
    // class members ::= field
    // field ::= [modifiers] T identifier [ = E ]; 
    // modifiers ::= [public | internal]

    //fields should always start with _ underscore and be camel cased
    //fields are initialized early in the process to 0, can be changed to another value
    //fields are initialized in an undefined order
    //fields cannot be initialized to another field's value

    // Lab 2 talks about documenting code.  This is it.
    /// <summary>Represents a movie.</summary>
    /// <remarks>
    /// Where you put additional comments that may be useful to someone.
    /// </remarks>
    public class Movie
    {
        /// <summary>Gets or sets the title.</summary>
        public string title = ""; 

        public string description = "";
        public int releaseYear = 1900;
        public int runLength;
        public string rating = "";
        public bool isClassic;
    }
}
