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

        private void OnSave ( object sender, EventArgs e )
        {
            //Creating Character
            var character = SaveCharacter();

            //Validation
            if (!character.Validate(out var error))
            {
                MessageBox.Show(error, "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            };

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

        private Character SaveCharacter()
        {
            var character = new Character();

            character.Name = txtName.Text;
            character.Profession = cbProfession.SelectedText;
            character.Race = cbRace.SelectedText;
            character.Biography = txtBiography.Text;
            character.StrengthAttribute = GetInt32(txtStrength);
            character.IntelligenceAttribute = GetInt32(txtIntelligence);
            character.AgilityAttribute = GetInt32(txtAgility);
            character.ConstitutionAttribute = GetInt32(txtConstitution);
            character.CharismaAttribute = GetInt32(txtCharisma);
            
            return character;
        }
    }
}
