using System;
using System.Windows.Forms;

namespace MovieLibrary.WinHost
{
    public partial class MainForm : Form
    {
        #region Construction

        public MainForm ()
        {
            InitializeComponent();
        }
        #endregion

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            var movies = _database.GetAll();
            if (movies.Length == 0)
            {
                if (MessageBox.Show(this, "Do you want to seed the database?", "Seed Database", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var seed = new SeedDatabase();
                    seed.Seed(_database);
                };
            };

            UpdateUI();
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            //MessageBox.Show("Help - About");
            var form = new AboutBox();

            //Show the form modally
            form.ShowDialog();
            //form.Show(); //modeless
        }

        private void OnFileExit ( object sender, EventArgs e )
        {
            //Display a confirmation and quit if yes
            var result = MessageBox.Show(this, "Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            //Close the form
            Close();
        }

        private void OnMovieAdd ( object sender, EventArgs e )
        {
            var form = new MovieDetailForm();

            do
            {
                if (form.ShowDialog(this) == DialogResult.Cancel)
                    return;

                //Save the movie
                _database.Add(form.Movie, out var error);
                if (String.IsNullOrEmpty(error))
                    break;

                DisplayError("Add Failed", error);
            } while (true);

            UpdateUI();
        }

        private void DisplayError ( string title, string message )
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OnMovieDelete ( object sender, EventArgs e )
        {
            //If a movie exists then display confirmation and delete
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            var result = MessageBox.Show(this, $"Are you sure you want to delete '{movie.Title}'?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            //TODO: Error checking
            _database.Delete(movie.Id, out var error);

            UpdateUI();
        }

        // Standard event signature - object, EventArgs (or derived)
        private void OnMovieEdit ( object sender, EventArgs e )
        {
            //If a movie exists then display confirmation and delete
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            var form = new MovieDetailForm();
            form.Movie = movie;

            do
            {
                if (form.ShowDialog(this) == DialogResult.Cancel)
                    return;

                //Save the movie
                _database.Update(movie.Id, form.Movie, out var error);
                if (String.IsNullOrEmpty(error))
                    break;

                DisplayError("Add Failed", error);
            } while (true);

            UpdateUI();
        }

        #region Private Members

        private Movie GetSelectedMovie ()
        {
            //Cast SelectedItem as Movie
            return lstMovies.SelectedItem as Movie;
        }

        private void UpdateUI ()
        {
            var movies = _database.GetAll();

            //Can bind listbox using Items or DataSource            
            lstMovies.DataSource = movies;
            lstMovies.DisplayMember = "Title";
        }

        private readonly MemoryMovieDatabase _database = new MemoryMovieDatabase();

        #endregion
    }
}
