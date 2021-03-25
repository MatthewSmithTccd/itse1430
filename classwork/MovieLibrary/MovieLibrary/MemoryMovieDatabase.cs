using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    /// <summary> Represents a database of movies.</summary>
    public class MemoryMovieDatabase
    {
        public Movie Add (Movie movie, out string error)
        {
            //Validation
            //  Check for null and valid movie
            if (movie == null)
            {
                error = "Movie is null";
                return null;
            };
            
            if (!movie.Validate(out error))
                return null;

            //Must be unique
            var existing = FindByTitle(movie.Title);
            if (existing != null)
            {
                error = "Movie title must be unique";
                return null;
            };

            //Add the movie
            //_movies[0] = CloneMovie(movie);
            movie.Id = ++_id;
            _movies.Add(CloneMovie(movie));

            return movie;

        }

        private object FindByTitle ( string title )
        {
            foreach(var item in _movies)
            {
                //Match movie by title, case insensitive
                if (String.Compare(item.Title, title, true) == 0)
                    return item;
            };

            return null;
        }

        public Movie[] GetAll ()
        {
            //Can create an empty array
            //var emptyArray = new Movie[0];
            
            // Enumeration - could us a for if you need the index
            // Prefer foreach
            //Counter determines # of items in list
            var items = new Movie[_movies.Count]; //switched length to Count when switched to List instead of array
            //for (var index = 0; index < items.Length; ++index)
            //      items[index] = _movies[index];

            //Foreach - preferred for enumeration
            //  item is readonly
            //  cannot write to array
            //  array cannot change during enumeration
            int index = 0;
            foreach (var item in _movies)
                items[index++] = CloneMovie(item);

            return items;
        }

        private Movie CloneMovie ( Movie movie )
        {
            //Object initializer syntax - creates and initializes an object as a single expression
            // 1. Remove semicolon from end of new expression
            // 2. Put curly braces after new expression
            // 3. Move closing curly after last property assignment
            // 4. Replace each semicolon on property assignment with a comma
            // 5. Remove the temp variable name and member access on each property
            // Limitations
            //  - Only works with new
            //  - Can only assign a value to settable properties
            //  - Cannot access the newly created value while inside the initializer

            //var target = new Movie();
            //target.Id = movie.Id;
            //target.Title = movie.Title;
            //target.Description = movie.Description;
            //target.ReleaseYear = movie.ReleaseYear;
            //target.Rating = movie.Rating;
            //target.RunLength = movie.RunLength;
            //target.IsClassic = movie.IsClassic;
            //var target = new Movie() {
            return new Movie() { 
                            Id = movie.Id,
                            Title = movie.Title,
                            Description = movie.Description,
                            ReleaseYear = movie.ReleaseYear,
                            Rating = movie.Rating,
                            RunLength = movie.RunLength,
                            IsClassic = movie.IsClassic,
                        };

            //return target;
        }

        // Array declaration
        //      Array specification is part of the type
        //      Arrays are always open (meaning no row size), multiple dimensions have fixed size columns
        //      Arrays are reference types (nullable, they follow reference semantics)
        //      Arrays are, for the most part, limited to 2 billion
        // Array size
        //      Can be any size >= 0
        //      Does not have to be a compile time constant
        //      No need for some constant size value
        //      Size is determinable at runtime (no need for a size parameter in functions)
        //      Length returns the # of rows in an array
        // Array behavior
        //      Bounds checking always happens
        //      Zero initialized
        //      Can be empty
        //      Indexing is zero based
        //      Should never return null array from property

        //  Generic type - a class that uses the same implementation irrelevant of the type
        //      closed type - can be instantiated because all type parameters are specified
        //      open type - cannot be instantiated because at least one type parameter is missing
        //private Movie[] _movies = new Movie[100];
        // List<T> is a dynamic resizing array of T
        private readonly List<Movie> _movies = new List<Movie>();

        private int _id;

        //Collection<T> vs List<T>
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
