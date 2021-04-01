
namespace CharacterCreator.WinHost
{
    partial class CharacterDetailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbProfession = new System.Windows.Forms.ComboBox();
            this.cbRace = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtBiography = new System.Windows.Forms.TextBox();
            this.txtStrength = new System.Windows.Forms.TextBox();
            this.txtIntelligence = new System.Windows.Forms.TextBox();
            this.txtAgility = new System.Windows.Forms.TextBox();
            this.txtConstitution = new System.Windows.Forms.TextBox();
            this.txtCharisma = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Profession";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Race";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Biography";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(419, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Strength";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(419, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Intelligence";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(419, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Agility";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(419, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "Constitution";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(419, 200);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "Charisma";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(674, 398);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(531, 398);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 29);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.OnSave);
            // 
            // cbProfession
            // 
            this.cbProfession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProfession.FormattingEnabled = true;
            this.cbProfession.Items.AddRange(new object[] {
            "Fighter ",
            "Hunter ",
            "Priest ",
            "Rogue ",
            "Wizard"});
            this.cbProfession.Location = new System.Drawing.Point(134, 102);
            this.cbProfession.Name = "cbProfession";
            this.cbProfession.Size = new System.Drawing.Size(151, 28);
            this.cbProfession.TabIndex = 2;
            // 
            // cbRace
            // 
            this.cbRace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRace.FormattingEnabled = true;
            this.cbRace.Items.AddRange(new object[] {
            "Dwarf ",
            "Elf ",
            "Gnome",
            "Half-Elf ",
            "Human"});
            this.cbRace.Location = new System.Drawing.Point(134, 177);
            this.cbRace.Name = "cbRace";
            this.cbRace.Size = new System.Drawing.Size(151, 28);
            this.cbRace.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(134, 26);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(125, 27);
            this.txtName.TabIndex = 1;
            // 
            // txtBiography
            // 
            this.txtBiography.Location = new System.Drawing.Point(134, 243);
            this.txtBiography.Name = "txtBiography";
            this.txtBiography.Size = new System.Drawing.Size(125, 27);
            this.txtBiography.TabIndex = 4;
            // 
            // txtStrength
            // 
            this.txtStrength.Location = new System.Drawing.Point(531, 26);
            this.txtStrength.Name = "txtStrength";
            this.txtStrength.Size = new System.Drawing.Size(125, 27);
            this.txtStrength.TabIndex = 5;
            this.txtStrength.Text = "50";
            // 
            // txtIntelligence
            // 
            this.txtIntelligence.Location = new System.Drawing.Point(531, 66);
            this.txtIntelligence.Name = "txtIntelligence";
            this.txtIntelligence.Size = new System.Drawing.Size(125, 27);
            this.txtIntelligence.TabIndex = 6;
            this.txtIntelligence.Text = "50";
            // 
            // txtAgility
            // 
            this.txtAgility.Location = new System.Drawing.Point(531, 107);
            this.txtAgility.Name = "txtAgility";
            this.txtAgility.Size = new System.Drawing.Size(125, 27);
            this.txtAgility.TabIndex = 7;
            this.txtAgility.Text = "50";
            // 
            // txtConstitution
            // 
            this.txtConstitution.Location = new System.Drawing.Point(531, 150);
            this.txtConstitution.Name = "txtConstitution";
            this.txtConstitution.Size = new System.Drawing.Size(125, 27);
            this.txtConstitution.TabIndex = 8;
            this.txtConstitution.Text = "50";
            // 
            // txtCharisma
            // 
            this.txtCharisma.Location = new System.Drawing.Point(531, 197);
            this.txtCharisma.Name = "txtCharisma";
            this.txtCharisma.Size = new System.Drawing.Size(125, 27);
            this.txtCharisma.TabIndex = 9;
            this.txtCharisma.Text = "50";
            // 
            // CharacterDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtCharisma);
            this.Controls.Add(this.txtConstitution);
            this.Controls.Add(this.txtAgility);
            this.Controls.Add(this.txtIntelligence);
            this.Controls.Add(this.txtStrength);
            this.Controls.Add(this.txtBiography);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cbRace);
            this.Controls.Add(this.cbProfession);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CharacterDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create New Character";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbProfession;
        private System.Windows.Forms.ComboBox cbRace;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtBiography;
        private System.Windows.Forms.TextBox txtStrength;
        private System.Windows.Forms.TextBox txtIntelligence;
        private System.Windows.Forms.TextBox txtAgility;
        private System.Windows.Forms.TextBox txtConstitution;
        private System.Windows.Forms.TextBox txtCharisma;
    }
}