
namespace MovieLibrary.WinHost
{
    partial class MovieDetailForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ckIsClassic = new System.Windows.Forms.CheckBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtRunLength = new System.Windows.Forms.TextBox();
            this.txtReleaseYear = new System.Windows.Forms.TextBox();
            this.cbRating = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rating";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Release Year";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Run Length";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(650, 369);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(515, 368);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 29);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.OnSave);
            // 
            // ckIsClassic
            // 
            this.ckIsClassic.AutoSize = true;
            this.ckIsClassic.Location = new System.Drawing.Point(161, 320);
            this.ckIsClassic.Name = "ckIsClassic";
            this.ckIsClassic.Size = new System.Drawing.Size(96, 24);
            this.ckIsClassic.TabIndex = 8;
            this.ckIsClassic.Text = "Is Classic?";
            this.ckIsClassic.UseVisualStyleBackColor = true;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(161, 22);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(125, 27);
            this.txtTitle.TabIndex = 9;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(161, 78);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(125, 27);
            this.txtDescription.TabIndex = 10;
            // 
            // txtRunLength
            // 
            this.txtRunLength.Location = new System.Drawing.Point(161, 258);
            this.txtRunLength.Name = "txtRunLength";
            this.txtRunLength.Size = new System.Drawing.Size(125, 27);
            this.txtRunLength.TabIndex = 11;
            // 
            // txtReleaseYear
            // 
            this.txtReleaseYear.Location = new System.Drawing.Point(161, 188);
            this.txtReleaseYear.Name = "txtReleaseYear";
            this.txtReleaseYear.Size = new System.Drawing.Size(125, 27);
            this.txtReleaseYear.TabIndex = 12;
            // 
            // cbRating
            // 
            this.cbRating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRating.FormattingEnabled = true;
            this.cbRating.Items.AddRange(new object[] {
            "G",
            "PG",
            "PG-13",
            "R"});
            this.cbRating.Location = new System.Drawing.Point(161, 136);
            this.cbRating.Name = "cbRating";
            this.cbRating.Size = new System.Drawing.Size(151, 28);
            this.cbRating.TabIndex = 13;
            // 
            // MovieDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbRating);
            this.Controls.Add(this.txtReleaseYear);
            this.Controls.Add(this.txtRunLength);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.ckIsClassic);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MovieDetailForm";
            this.Text = "Movie Details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox ckIsClassic;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtRunLength;
        private System.Windows.Forms.TextBox txtReleaseYear;
        private System.Windows.Forms.ComboBox cbRating;
    }
}