using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterCreator.WinHost
{
    public partial class CharacterDetailForm : Form
    {
        public CharacterDetailForm ()
        {
            InitializeComponent();
        }

        public Character Character { get; set; }

        
        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            if (Character != null)
                LoadCharacter(Character);
        }

        private void OnSave ( object sender, EventArgs e )
        {
            //Creating Character
            var character = SaveCharacter();

            //Validation
            if (!character.Validate(out var error))
            {
                MessageBox.Show(error, "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                return;
            };

            Character = character;
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void OnCancel ( object sender, EventArgs e )
        {
            //this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private int GetInt32 ( Control control)
        {
            var text = control.Text;

            if (Int32.TryParse(text, out var result))
                return result;

            return -1;
        }

        private void LoadCharacter (Character character)
        {
            txtName.Text = character.Name;

            cbProfession.SelectedItem = character.Profession;
            cbRace.SelectedItem = character.Race;

            txtBiography.Text = character.Biography;
            
            txtStrength.Text = character.StrengthAttribute.ToString();
            txtIntelligence.Text = character.IntelligenceAttribute.ToString();
            txtAgility.Text = character.AgilityAttribute.ToString();
            txtConstitution.Text = character.ConstitutionAttribute.ToString();
            txtCharisma.Text = character.CharismaAttribute.ToString();

        }

        private Character SaveCharacter()
        {
            var character = new Character();

            character.Name = txtName.Text;

            character.Profession = cbProfession.SelectedItem as string;
            character.Race = cbRace.SelectedItem as string;

            character.Biography = txtBiography.Text;

            character.StrengthAttribute = GetInt32(txtStrength);
            character.IntelligenceAttribute = GetInt32(txtIntelligence);
            character.AgilityAttribute = GetInt32(txtAgility);
            character.ConstitutionAttribute = GetInt32(txtConstitution);
            character.CharismaAttribute = GetInt32(txtCharisma);
            
            return character;
        }

        private void OnValidatingName ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                //Invalid
                _errors.SetError(control, "Name is required");
                e.Cancel = true;
            }else
            {
                _errors.SetError(control, "");
            };
        }

        private void OnValidatingProfession ( object sender, CancelEventArgs e )
        {
            var control = sender as ComboBox;

            var profession = control.SelectedItem as string;

            if (String.IsNullOrEmpty(profession))
            {
                //Invalid
                _errors.SetError(control, "Profession is required");
                e.Cancel = true;
            } else
            {
                _errors.SetError(control, "");
            };
        }
    }
}
