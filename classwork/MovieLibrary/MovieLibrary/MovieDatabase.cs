using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieLibrary
{
    /// <summary>Represents a base implementation of movie database.</summary>
    public abstract class MovieDatabase : IMovieDatabase
    {
        //public void NotVisibleInInterface () { }

        // Exceptions - error objects
        //   when an error case occurs we throw/raise an exception
        //   throw ::= throw E;
        //   when a throw occurs current function stops executing and error is immediately returned
        //
        //   Exception is a base type - use when no other exception works
        //     ArgumentException - when an argument is invalid and no other exception is better
        //         ArgumentNullException - when an argument is null and you do not support it
        //         ArgumentOutOfRangException - when an argument is out of range
        //     ValidationException - validation errors from IValidableObject
        //     InvalidOperationException - currently not valid but may be later
        //     NotSupportedException - not currently supported things
        //     NotImplementedException - not currently implemented
        //     SystemException - NEVER THROW
        //        NullReferenceException - thrown when you use a null instance
        //        OutOfMemoryException - *no more memory, always fatal
        //        StackOverflowException - *no more stack space, always fatal
        //     ApplicationException - NEVER USE THIS

        public Movie Add ( Movie movie )
        {
            //Validation
            //  Check for null and valid movie
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));
            //{
            //    error = "Movie is null";
            //    return null;
            //};

            //Validate using IValidatableObject
            //var context = new ValidationContext(movie);
            //var errors = new List<ValidationResult>();
            //if (!Validator.TryValidateObject(movie, context, errors))
            //{
            //    error = errors[0].ErrorMessage;
            //    //if (!movie.Validate(out error))
            //    return null;
            //};
            new ObjectValidator().Validate(movie);
            //var errors = new ObjectValidator().TryValidate(movie);
            //if (errors.Count > 0)
            //{
            //    error = errors[0].ErrorMessage;
            //    return null;
            //};

            //Must be unique
            var existing = FindByTitle(movie.Title);
            if (existing != null)
            {
                throw new InvalidOperationException("Movie title must be unique.");
                //error = "Movie title must be unique";
                //return null;
            };

            //Add the movie
            return AddCore(movie);
            //movie.Id = ++_id;
            //_movies.Add(CloneMovie(movie));

            //error = null;
            //return movie;
        }

        /// <summary>
        /// Adds the movie to the database
        /// </summary>
        /// <param name="movie"></param>
        /// <returns>The new movie.</returns>
        protected abstract Movie AddCore ( Movie movie );

        public void Delete ( int id )
        {
            //Validation
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than 0.");

            //Delete
            DeleteCore(id);
        }

        protected abstract void DeleteCore ( int id );

        public Movie Get ( int id )
        {
            //Validation
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than 0.");

            //Get
            return GetCore(id);
        }

        protected abstract Movie GetCore ( int id );

        
        public IEnumerable<Movie> GetAll ()
        {
            //Will never return null
            return GetAllCore() ?? Enumerable.Empty<Movie>();
        }

        protected abstract IEnumerable<Movie> GetAllCore ();

        public void Update ( int id, Movie movie )
        {
            //Validation
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than 0.");

            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            new ObjectValidator().Validate(movie);

            //Must be unique
            var existing = FindByTitle(movie.Title);
            if (existing != null && existing.Id != id)
                throw new InvalidOperationException("Movie title must be unique.");

            //Must exist
            //existing = FindById(id);
            //if (existing == null)
            //    throw new Exception("Movie does not exist.");
            //existing = FindById(id) ?? throw new Exception("Movie does not exist.");

            UpdateCore(id, movie);
            
        }

        protected abstract void UpdateCore ( int id, Movie movie );

        protected virtual Movie FindByTitle ( string title )
        {
            foreach (var item in GetAllCore())
            {
                //Match movie by title, case insensitive
                if (String.Compare(item.Title, title, true) == 0)
                    return item;
            };

            return null;
        }

        // Generic type - a class that uses the same implementation irrelevant of the type        
        //   closed type - can be instantiated because all type parameters are specified
        //   open type - cannot be instantiated because at least one type parameter is missing
        //private Movie[] _movies = new Movie[100];
        // List<T> is a dynamic resizing array of T
        //private readonly List<Movie> _movies = new List<Movie>();
        //private readonly System.Collections.ObjectModel.Collection<Movie> _movies = new System.Collections.ObjectModel.Collection<Movie>();

        //private int _id;

        // Collection<T> vs List<T>
        //  List<T> - low level implementation of a dynamic array, private facing
        //  Collection<T> - high level impl of a dynamic array, public facing
        //private System.Collections.ObjectModel.Collection<Movie> _test = new System.Collections.ObjectModel.Collection<Movie>();
    }

    //class GenericDynamicArray<T>
    //{
    //    public T Get ( int index );
    //    public void Add ( T item );
    //    public void Remove ( T item );

    //    private T[] _items;
    //}

    //class MovieDynamicArray
    //{
    //    public Movie Get ( int index );
    //    public void Add ( Movie item );
    //    public void Remove ( Movie item );

    //    private Movie[] _items;
    //}

    //class StringDynamicArray
    //{
    //    public string Get ( int index );
    //    public void Add ( string item );
    //    public void Remove ( string item );

    //    private string[] _items;
    //}

    //class Int32DynamicArray
    //{
    //    public int Get ( int index );
    //    public void Add ( int item );
    //    public void Remove ( int item );

    //    private int[] _items;
    //}
}
