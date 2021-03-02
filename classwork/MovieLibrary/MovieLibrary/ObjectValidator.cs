using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    public class ObjectValidator 
    {
        //Multiple constructors hidden by accessibility
        private ObjectValidator() //: base()
        {
            //Initialize();
            //Do initialization
        }

        //Constructor chaining - one constructor calls another constructor
        //  Follow ctor parameter list with a colon and 'this'(arguments)
        //  Chained constructor is called before the current ctor's body executes
        private ObjectValidator (int value) : this()
        {
            //Initialize();
        }

        public ObjectValidator (Movie movie) : this(1)
        {
            _movie = movie;

            //Initialize();
        }

        //Anyone can call who has access
        private void Initialize()
        {
            //initialization??
        }

        public string Validate()
        {
            if (_movie.Validate(out var message))
                return "";

            return message;
        }

        private Movie _movie;
    }
}
