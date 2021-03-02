using System;

namespace MovieLibrary
{
    /// <summary>Represents a movie.</summary>
    /// <remarks>
    /// Where you put additional comments that may be useful to someone.
    /// </remarks>
    public class Movie
    {
        //CAVEAT: NOT NEEDED HERE - just demo

        #region Construction

        /// <summary>Initializes an instance of the <see cref="Movie"/> class.</summary>
        public Movie ()  //Default constructor
        {
            //Initialize the fields that cannot be initialized using the field initializer syntax
            _description = _title;
        }

        /// <summary>Initializes an instance of the <see cref="Movie"/> class.</summary>
        /// <param name="title">The title of the movie.</param>
        /// <remarks>
        /// Allows you to create the instance and set a common property all at once
        /// </remarks>
        public Movie ( string title )
        {
            _title = title;
        }
        #endregion

        #region Properties

        public int AgeInYears
        {
            get {
                if (DateTime.Now.Year < ReleaseYear)
                    return 0;

                return DateTime.Today.Year - ReleaseYear;
            }
            //set { }
        }
        //public void SetAgeInYears ( int year ) {}                

        /// <summary>Gets or sets the title.</summary>
        public string Title //()
        {
            //getter - T identifier ()
            get  // string get_Title ()
            {
                //Return title if not null or empty string otherwise                
                return _title ?? "";   //return (_title != null) ? _title : "";
            }

            //setter - void identifier ( T value )
            set   // void set_Title ( string value )
            {
                //_title = (value != null) ? value.Trim() : null;
                _title = value?.Trim() ?? "";
            }
        }

        /// <summary>Gets or sets the description.</summary>
        public string Description
        {
            //get { return (_description != null) ? _description : "";  }
            get { return _description ?? ""; }
            set { _description = value; }
        }

        /// <summary>Gets or sets the release year.</summary>
        //public int ReleaseYear
        //{
        //    get { return _releaseYear; }
        //    set { _releaseYear = value; }
        //}
        //private int _releaseYear = 1900;
        public int ReleaseYear { get; set; } = MinimumReleaseYear; // = 1900
        //public int ReleaseYear2 = 1900;

        /// <summary>Gets or sets the run length.</summary>
        //public int RunLength  //Full property syntax
        //{
        //    get { return _runLength; }
        //    set { _runLength = value; }
        //}
        //private int _runLength;

        //Auto property syntax - compiler will auto-generate the full property
        public int RunLength { get; set; }

        /// <summary>Gets or sets the rating.</summary>
        public string Rating
        {
            //get { return (_rating != null) ? _rating : ""; }
            get { return _rating ?? ""; }
            set { _rating = value; }
        }

        /// <summary>Gets or sets the classic indicator.</summary>
        public bool IsClassic { get; set; }
        //{
        //    get { return _isClassic; }
        //    set { _isClassic = value; }
        //}
        //private bool _isClassic;d

        // Auto properties can be getter or setter only if needed
        public int Age { get; } // = 10;
        //private readonly int _age;
        #endregion

        #region Fields

        // Allowed to expose a field if const or readonly
        //   const - glorified, named literal; value baked in to usage at compile time (primitive and value will never change)
        //   readonly - const named variable; value referenced at runtime (non primitive, only option)
        public const int MinimumReleaseYear = 1900;
        public readonly DateTime MinimumReleaseDate = new DateTime(1900, 1, 1);

        private string _title = "";
        private string _description = "";
        private string _rating = "";
        #endregion

        #region Methods

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

        #endregion
    }
}
