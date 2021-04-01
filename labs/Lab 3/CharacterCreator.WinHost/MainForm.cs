using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterCreator.WinHost
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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

        private void miHelpAbout_Click ( object sender, EventArgs e )
        {
            var form = new AboutBox();

            form.ShowDialog();
        }

        private void OnCharacterNew ( object sender, EventArgs e )
        {
            var form = new CharacterDetailForm();

            if (form.ShowDialog(this) == DialogResult.Cancel)
                return;

            //TODO: "Save" the character
            _character = form.Character;

            UpdateUI();

        }

        private void UpdateUI ()
        {
            //TODO: Clean up
            var count = (_character != null) ? 1 : 0;
            Character[] characters = new Character[count];
            if (_character != null)
                characters[0] = _character;

            listCharacters.DataSource = characters;
            listCharacters.DisplayMember = "Title";
            //listCharacters.ValueMember = "Id";
        }

        private void OnCharacterDelete ( object sender, EventArgs e )
        {
            //If a character exists then display confirmation and delete
            if (_character == null)
                return;

            var result = MessageBox.Show(this, $"Are you sure you want to delete '{_character.Name}'?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            //TODO: "Delete" the movie
            
            _character = null;

            UpdateUI();
        }

        private void OnCharacterEdit ( object sender, EventArgs e )
        {
            if (_character == null)
                return;

            var form = new CharacterDetailForm();
            form.Character = _character;

            if (form.ShowDialog(this) == DialogResult.Cancel)
                return;

            //TODO: "Save" the character
            _character = form.Character;

            UpdateUI();
        }

        private Character _character;
    }
}
