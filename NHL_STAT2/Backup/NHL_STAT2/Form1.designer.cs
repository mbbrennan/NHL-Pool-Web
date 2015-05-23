namespace NHL_Stat2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdUpdateStats = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.initializePlayersTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdImportExcel = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdUpdateStats
            // 
            this.cmdUpdateStats.Location = new System.Drawing.Point(223, 142);
            this.cmdUpdateStats.Name = "cmdUpdateStats";
            this.cmdUpdateStats.Size = new System.Drawing.Size(228, 73);
            this.cmdUpdateStats.TabIndex = 0;
            this.cmdUpdateStats.Text = "Update NHL Stats";
            this.cmdUpdateStats.UseVisualStyleBackColor = true;
            this.cmdUpdateStats.Click += new System.EventHandler(this.cmdUpdateStats_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.initializePlayersTableToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(732, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // initializePlayersTableToolStripMenuItem
            // 
            this.initializePlayersTableToolStripMenuItem.Name = "initializePlayersTableToolStripMenuItem";
            this.initializePlayersTableToolStripMenuItem.Size = new System.Drawing.Size(134, 20);
            this.initializePlayersTableToolStripMenuItem.Text = "Initialize Players Table";
            this.initializePlayersTableToolStripMenuItem.Click += new System.EventHandler(this.initializePlayersTableToolStripMenuItem_Click);
            // 
            // cmdImportExcel
            // 
            this.cmdImportExcel.Location = new System.Drawing.Point(223, 63);
            this.cmdImportExcel.Name = "cmdImportExcel";
            this.cmdImportExcel.Size = new System.Drawing.Size(228, 73);
            this.cmdImportExcel.TabIndex = 2;
            this.cmdImportExcel.Text = "Import Excel Data";
            this.cmdImportExcel.UseVisualStyleBackColor = true;
            this.cmdImportExcel.Click += new System.EventHandler(this.cmdImportExcel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 357);
            this.Controls.Add(this.cmdImportExcel);
            this.Controls.Add(this.cmdUpdateStats);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdUpdateStats;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem initializePlayersTableToolStripMenuItem;
        private System.Windows.Forms.Button cmdImportExcel;
    }
}

