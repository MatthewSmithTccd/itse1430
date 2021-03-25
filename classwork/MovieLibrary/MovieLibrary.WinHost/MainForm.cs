using System;
using System.Windows.Forms;

namespace MovieLibrary.WinHost
{
    public partial class MainForm : Form
    {
        public MainForm ()
        {
            InitializeComponent();
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

                //TODO: "Save" the movie
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

            //TODO: "Delete" the movie            
            _movie = null;

            UpdateUI();
        }

        //Standard event signature - object, Event Args (or derived)
        private void OnMovieEdit ( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            var form = new MovieDetailForm();
            form.Movie = movie;

            if (form.ShowDialog(this) == DialogResult.Cancel)
                return;

            //TODO: "Save" the movie
            _movie = form.Movie;

            UpdateUI();
        }

        private Movie GetSelectedMovie ()
        {
            //Cast SelectedItem as Movie
            return lstMovies.SelectedItem as Movie;
        }

        private void UpdateUI ()
        {
            var movies = _database.GetAll();

            //Can bind listbox using Items or DataSource
            //lstMovies.Items
            //lstMovies.DataSource = null;
            lstMovies.DataSource = movies;
            lstMovies.DisplayMember = "Title";
            //lstMovies.ValueMember = "Id";
        }

        private Movie _movie;
        private readonly MemoryMovieDatabase _database = new MemoryMovieDatabase();
    }
}
