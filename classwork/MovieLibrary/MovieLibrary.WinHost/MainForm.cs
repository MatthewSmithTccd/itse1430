using System;
using System.Windows.Forms;
/*
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
*/

namespace MovieLibrary.WinHost
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            //MessageBox.Show("Help - About");
            var form = new AboutBox();

            //Show the form modally (user must interact with it, for it to go away and can't go back by clicking off of it)
            form.ShowDialog();
            //form.Show(); //modeless

        }

        private void OnFileExit ( object sender, EventArgs e )
        {
            //Display a confirmation and quit if yes
            var result = MessageBox.Show(this, "Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            Close();
        }

        private void OnMovieAdd ( object sender, EventArgs e )
        {
            var form = new MovieDetailForm();

            if (form.ShowDialog(this) == DialogResult.Cancel)
                    return;

            //TODO: "Save" the movie
            //_movie = ;
            MessageBox.Show("Saved the movie");
        }

        private void OnMovieEdit ( object sender, EventArgs e )
        {
            //TODO: If a movie exists then display confirmation and delete
            if (_movie == null)
                return;

            var result = MessageBox.Show(this, $"Are you sure you want to delete '{_movie.Title}'?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            //TODO: "Delete" the movie
            MessageBox.Show("Deleted the movie");
            _movie = null;
        }

        private void OnMovieDelete ( object sender, EventArgs e )
        {
            //TODO: If movie exists then edit movie

            //TODO: "Update" the movie
        }

        private Movie _movie;
    }
}
