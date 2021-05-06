/*
 * Character Creator - Lab 5
 * ITSE 1430
 * Spring 2021
 * Matthew Smith
 * May 5, 2021
 */
using System;
using System.Linq;
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

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            var movies = _database.GetAll();

            UpdateUI();
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
            do
            {
                if (form.ShowDialog(this) == DialogResult.Cancel)
                    return;

                try
                {
                    _database.Add(form.Character);
                    break;
                }catch (ArgumentException ex)
                {
                    DisplayError("Add Failed", "You didn't pass the args right.");
                }catch (Exception ex)
                {
                    DisplayError("Add Failed", ex.Message);
                };
                //if (String.IsNullOrEmpty(error))
                //    break;

                //    DisplayError("Add failed", error);

                //_character = form.Character;
            } while (true);

            UpdateUI();
        }

        private void DisplayError ( string title, string message )
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private Character GetSelectedCharacter ()
        {
            return listCharacters.SelectedItem as Character;
        }

        private void UpdateUI ()
        {
            //TODO: Story 6 calls for this code to be used but when there is no character it gives weird message after deleting a char
            //var binding = new BindingSource();
            //binding.DataSource = _database.GetAll();

            //listCharacters.DataSource = binding;
            //listCharacters.DisplayMember = nameof(Character.Name);

            listCharacters.DisplayMember = "Name";
            listCharacters.ValueMember = "Id";
            try
            {
                var characters = _database.GetAll();
                                 
                listCharacters.DataSource = characters.ToArray();
            } catch (Exception e)
            {
                DisplayError("Error retrieving movies", e.Message);

                listCharacters.DataSource = new Character[0];
            };
        }

        private void OnCharacterDelete ( object sender, EventArgs e )
        {
            //If a character exists then display confirmation and delete
            var character = GetSelectedCharacter();
            if (character == null)
                return;

            var result = MessageBox.Show(this, $"Are you sure you want to delete '{character.Name}'?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            try
            {
                _database.Delete(character.Id);
            } catch (Exception ex)
            {
                DisplayError("Delete Failed", ex.Message);
            };

            UpdateUI();
        }

        private void OnCharacterEdit ( object sender, EventArgs e )
        {
            var character = GetSelectedCharacter();
            if (character == null)
                return;

            var form = new CharacterDetailForm();
            form.Character = character;
            form.Text = "Edit Character";
            do
            {
                if (form.ShowDialog(this) == DialogResult.Cancel)
                    return;

                //"Save" the character
                try
                {
                    _database.Update(character.Id, form.Character);
                    break;
                } catch (Exception ex)
                {
                    DisplayError("Add Failed", ex.Message);
                };

            } while (true);
            UpdateUI();
        }

        //private Character _character;
        private readonly ICharacterRoster _database = new SqlServer.SqlServerCharacterRoster(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=CharacterDb;Integrated Security=True;");
    }
}
