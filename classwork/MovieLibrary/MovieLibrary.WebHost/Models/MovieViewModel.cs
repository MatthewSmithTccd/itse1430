using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLibrary.WebHost.Models
{
    public class MovieViewModel
    {
        public MovieViewModel ()
        {

        }

        public MovieViewModel (Movie movie)
        {
            Id = movie.Id;
            Title = movie.Title;
            Description = movie.Description;
            Rating = movie.Rating;
            ReleaseYear = movie.ReleaseYear;
            RunLength = movie.RunLength;
            IsClassic = movie.IsClassic;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Rating { get; set; }

        public int ReleaseYear { get; set; }

        public int RunLength { get; set; }

        public bool IsClassic { get; set; }
    }
}
