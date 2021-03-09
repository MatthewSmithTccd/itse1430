
namespace MovieLibrary.WinHost
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.miMoviesAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.miMovieEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miMovieDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.miHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(857, 28);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFileExit});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(46, 24);
            this.toolStripMenuItem1.Text = "&File";
            // 
            // miFileExit
            // 
            this.miFileExit.Name = "miFileExit";
            this.miFileExit.Size = new System.Drawing.Size(116, 26);
            this.miFileExit.Text = "E&xit";
            this.miFileExit.Click += new System.EventHandler(this.OnFileExit);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miMoviesAdd,
            this.miMovieEdit,
            this.toolStripSeparator1,
            this.miMovieDelete});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(70, 24);
            this.toolStripMenuItem2.Text = "&Movies";
            // 
            // miMoviesAdd
            // 
            this.miMoviesAdd.Name = "miMoviesAdd";
            this.miMoviesAdd.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.miMoviesAdd.Size = new System.Drawing.Size(178, 26);
            this.miMoviesAdd.Text = "Add";
            this.miMoviesAdd.Click += new System.EventHandler(this.OnMovieAdd);
            // 
            // miMovieEdit
            // 
            this.miMovieEdit.Name = "miMovieEdit";
            this.miMovieEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Insert)));
            this.miMovieEdit.Size = new System.Drawing.Size(178, 26);
            this.miMovieEdit.Text = "Edit";
            this.miMovieEdit.Click += new System.EventHandler(this.OnMovieEdit);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
            // 
            // miMovieDelete
            // 
            this.miMovieDelete.Name = "miMovieDelete";
            this.miMovieDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.miMovieDelete.Size = new System.Drawing.Size(178, 26);
            this.miMovieDelete.Text = "Delete";
            this.miMovieDelete.Click += new System.EventHandler(this.OnMovieDelete);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miHelpAbout});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(55, 24);
            this.toolStripMenuItem3.Text = "&Help";
            // 
            // miHelpAbout
            // 
            this.miHelpAbout.Name = "miHelpAbout";
            this.miHelpAbout.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.miHelpAbout.Size = new System.Drawing.Size(157, 26);
            this.miHelpAbout.Text = "About";
            this.miHelpAbout.Click += new System.EventHandler(this.OnHelpAbout);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 436);
            this.Controls.Add(this.mainMenu);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miFileExit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem miMoviesAdd;
        private System.Windows.Forms.ToolStripMenuItem miMovieEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem miMovieDelete;
        private System.Windows.Forms.ToolStripMenuItem miHelpAbout;
    }
}

