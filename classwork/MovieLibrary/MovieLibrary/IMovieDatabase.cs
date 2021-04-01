using System.Collections.Generic;

namespace MovieLibrary
{
    public interface IMovieDatabase
    {
        Movie Add ( Movie movie, out string error );
        void Delete ( int id, out string error );
        Movie Get ( int id, out string error );
        IEnumerable<Movie> GetAll ();
        void Update ( int id, Movie movie, out string error );
    }
}