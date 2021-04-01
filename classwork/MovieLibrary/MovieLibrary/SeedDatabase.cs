using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    public class SeedDatabase
    {
        public void Seed (IMovieDatabase database)
        {
            var movie1 = new Movie() {
                Title = "Jaws",
                Description = "The original shark movie",
                Rating = "PG",
                ReleaseYear = 1979,
                RunLength = 123
            };

            var movie2 = new Movie() {
                Title = "Jaws 2",
                Rating = "PG-13",
                ReleaseYear = 1981,
                RunLength = 156,
            };

            var movie3 = new Movie() {
                Title = "Dune",
                Rating = "PG",
                ReleaseYear = 1985,
                RunLength = 210
            };

            database.Add(movie1, out var error);
            database.Add(movie2, out error);
            database.Add(movie3, out error);
        }
    }
}
