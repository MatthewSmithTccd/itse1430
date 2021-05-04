using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using MovieLibrary.WebHost.Models;

namespace MovieLibrary.WebHost.Controllers
{
    public class MovieController : Controller
    {
        public MovieController (IMovieDatabase database)
        {
            _database = database;
        }

        [HttpGet]
        public IActionResult Index ()
        {
            var model = _database.GetAll()
                                  .OrderBy(x => x.Title)
                                  .Select(x => new MovieViewModel(x));

            return View("Index", model);
        }

        private readonly IMovieDatabase _database;
    }
}
