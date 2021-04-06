using System;
using System.Collections.Generic;
using System.IO;

namespace MovieLibrary.IO
{
    /// <summary>Represents an in-memory movie database.</summary>
    public class FileMovieDatabase : Memory.MemoryMovieDatabase
    {
        public FileMovieDatabase ( string filename )
        {
            _filename = filename;
        }

        protected override Movie AddCore ( Movie movie )
        {
            return base.AddCore(movie);
        }

        protected override void DeleteCore ( int id )
        {
            base.DeleteCore(id);
        }

        protected override Movie GetCore ( int id )
        {
            return base.GetCore(id);
        }

        protected override IEnumerable<Movie> GetAllCore ()
        {
            var movies = LoadMovies();

            return movies;

            //return base.GetAllCore();
        }

        protected override void UpdateCore ( int id, Movie movie )
        {
            base.UpdateCore(id, movie);
        }

        //Buffered IO
        private IEnumerable<Movie> LoadMovies ()
        {
            //ReadAllText - returns all lines as a single string
            var lines = File.ReadAllLines(_filename); //string[]
            foreach (var line in lines)
            {
                var movie = LoadMovie(line);
                if (movie != null)
                    yield return movie;
            };
        }

        private Movie LoadMovie ( string line )
        {
            //Id, Title, Rating, ReleaseYear, RunLength, IsClassic, Description
            var tokens = line.Split(',');  //string[]
            if (tokens.Length != 7)
                return null;

            //TODO: Should validate here...
            // Not handling strings with commas in them
            // Will handle quotes and leading/trailing spaces
            var movie = new Movie() {
                Id = Int32.Parse(tokens[0].Trim()),
                Title = tokens[1].Trim().Trim('"'),
                Rating = tokens[2].Trim().Trim('"'),
                ReleaseYear = Int32.Parse(tokens[3].Trim()),
                RunLength = Int32.Parse(tokens[4].Trim()),
                IsClassic = Int32.Parse(tokens[5].Trim()) != 0,
                Description = tokens[6].Trim().Trim('"')
            };

            return movie;
        }

        // CSV - comma separate variable
        //   Each line represents a "record"
        //   A record consists of fields separate by commas
        //   Field names are implied
        // IO
        //   Buffered - read the entire contents into memory
        //   Streamed - read set of bytes at a time
        private readonly string _filename;
    }
}
