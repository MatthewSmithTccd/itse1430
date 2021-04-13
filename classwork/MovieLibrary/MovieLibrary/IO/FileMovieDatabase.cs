using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            //Find highest ID in use
            var movies = GetAllCore();
            var id = GetHighestId(movies);

            movie.Id = ++id;

            //TODO: Show how to union
            var items = new List<Movie>(movies);
            items.Add(movie);
            SaveMovies(items);
            return movie;
        }

        protected override void DeleteCore ( int id )
        {
            //TODO: Remove item correctly
            var movies = GetAllCore().ToList();

            var movie = FindById(movies, id);
            if (movie != null)
                movies.Remove(movie);

            SaveMovies(movies);
        }

        protected override Movie GetCore ( int id )
        {
            //var movies = GetAllCore();
            //return FindById(movies, id);

            //Streaming IO
            //   OpenRead/OpenWrite/Open -> Stream
            //   OpenText -> StreamReader
            // StreamReader - reads a stream of text
            // StreamWriter - writes a stream of text
            // Use a reader/writer to work with streams to make it easier
            //    BinaryReader/BinaryWriter

            //try-finally ::= allows cleanup of code before try block completes successful or otherwise
            //    try-finally-statement ::= try-block [catch-block] finally { S* }

            #region Try-finally demo
            //StreamReader reader = null;
            //try
            //{
            //    //FileStream stream = File.OpenRead(_filename);
            //    reader = File.OpenText(_filename);  // new StreamReader(File.OpenRead())
            //                                        //do
            //                                        //{
            //                                        //    var line = reader.ReadLine();
            //                                        //    if (line != null)
            //                                        //    {
            //                                        //    };
            //                                        //} while (true);

            //    while (!reader.EndOfStream)
            //    {
            //        var line = reader.ReadLine();
            //        var movie = LoadMovie(line);
            //        if (movie?.Id == id)
            //            return movie;
            //    };

            //    //reader.Close();
            ////} catch
            ////{
            ////    //reader.Close();
            ////    throw;
            //} finally
            //{
            //    //Guaranteed to be called
            //    //Reader can be null so handle that case
            //    reader?.Close();
            //};
            #endregion


            // Preferred approach over try-finally
            //   using-statement ::= using (E) S;
            //       E must be IDisposable
            //   IDisposable - interface used to identify resources that must be explicitly cleaned up
            //       Dispose() - cleans up instance
            //   ALWAYS wrap IDisposable objects in a using if you own the object
            using (var reader = File.OpenText(_filename))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var movie = LoadMovie(line);
                    if (movie?.Id == id)
                        return movie;
                };
            };

            // Object lifetime
            //   Must explicitly clean up any memory allocated if deterministic clean up needed
            //   Owner of instance must clean up
            //     If returning value from method, caller becomes owner and must clean up
            //     If passing as a parameter to another object then it generally becomes owner and will clean
            //      => RAII ::= resource acquisition is initialization
            //reader.Close();
            // It is not maintainable
            // Not exception safe

            return null;
        }

        protected override IEnumerable<Movie> GetAllCore ()
        {
            var movies = LoadMovies();

            return movies;

            //return base.GetAllCore();
        }

        protected override void UpdateCore ( int id, Movie movie )
        {
            var movies = GetAllCore().ToArray();

            var existing = FindById(movies, id);
            if (existing == null)
                throw new Exception("Movie not found");

            existing.Title = movie.Title;
            existing.Rating = movie.Rating;
            existing.ReleaseYear = movie.ReleaseYear;
            existing.RunLength = movie.RunLength;
            existing.IsClassic = movie.IsClassic;
            existing.Description = movie.Description;

            SaveMovies(movies);
        }

        private Movie FindById ( IEnumerable<Movie> items, int id )
        {
            //Enumerable.FirstOrDefault();
            //  FirstOrDefault - finds the first matching item in IEnumerable<T> or returns the default value if not found
            //  LastOrDefault - finds the last matching item, doesn't work in all cases outside of memory
            //  First/Last - find the first/last matching item or throw exception otherwise
            //  SingleOrDefault/Single - Finds the only matching item or throws an exception

            //TODO: Broke it
            //Enumerable.FirstOrDefault()
            return items.FirstOrDefault();
            //foreach (var item in items)
            //    if (item.Id == id)
            //        return item;

            //return null;
        }

        private int GetHighestId ( IEnumerable<Movie> items )
        {
            //TODO: Broke it
            // Enumerable.
            //    Max() - gets the max value
            //    Min() - gets the min value
            //    Sum() - sums the values
            //    Count() - gets total items
            //         IEnumerable<T> forward only iterations
            //         List<T>.Count
            //         T.Length
            //return items.Max();
            var id = 0;
            foreach (var item in items)
            {
                //id = Math.Max(id, item.Id);
                if (item.Id > id)
                    id = item.Id;
            };

            return id;
        }

        //Buffered IO
        private IEnumerable<Movie> LoadMovies ()
        {
            if (File.Exists(_filename))
            {
                //TODO: Convert it
                //  Enumerable
                //     .Select() takes IEnumerable<T> and returns IEnumerable<S>
                //     .Where() - returns IEnumerable<T> containing all items that match a condition
                //     .OrderBy() returns IEnumerable<T> ordered by certain values

                //ReadAllBytes - returns a byte[]
                //ReadAllLines - returns a string[]
                //ReadAllText - returns all lines as a single string
                var lines = File.ReadAllLines(_filename); //string[]
                foreach (var line in lines)
                {
                    var movie = LoadMovie(line);
                    if (movie != null)
                        yield return movie;
                };
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

        private void SaveMovies ( IEnumerable<Movie> items )
        {
            //throw new IOException("Something went wrong");

            var lines = new List<string>();

            foreach (var item in items)
                lines.Add(SaveMovie(item));

            //Buffered write
            //  WriteAllBytes - writes a byte array
            //  WriteAllLines - writes a string array
            //  WriteAllText - writes a string
            File.WriteAllLines(_filename, lines);
        }

        private string SaveMovie ( Movie movie )
        {
            // Collection initializer - arrays, List<T>, Collection<T>, T.Add
            //    Initialize a collection with elements as part of the creation
            //Id, Title, Rating, ReleaseYear, RunLength, IsClassic, Description
            var fields = new[] { //new string[] {
                                movie.Id.ToString(),
                                QuoteString(movie.Title),
                                QuoteString(movie.Rating),
                                movie.ReleaseYear.ToString(),
                                movie.RunLength.ToString(),
                                (movie.IsClassic ? "1" : "0"),
                                QuoteString(movie.Description),
                        };

            return String.Join(',', fields);
        }

        private string QuoteString ( string value )
        {
            if (String.IsNullOrEmpty(value))
                return "\"\"";

            var hasStartingQuote = value.StartsWith('"');
            var hasEndingQuote = value.EndsWith('"');

            //If no starting quote but might have ending quote then wrap it
            if (!hasStartingQuote)
                return "\"" + value + (hasEndingQuote ? "" : "\"");
            else if (!hasEndingQuote)  //Has starting quote but no ending quote
                return value + "\"";

            return value;   //Has starting and ending quote
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
