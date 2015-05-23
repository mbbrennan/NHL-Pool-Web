namespace NHL_Stat2
{
    partial class frmAdmin
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
            this.cmdPoolies = new System.Windows.Forms.Button();
            this.cmdPlayers = new System.Windows.Forms.Button();
            this.cmdPooliePlayers = new System.Windows.Forms.Button();
            this.cmdDraft = new System.Windows.Forms.Button();
            this.cmdInitPlayers = new System.Windows.Forms.Button();
            this.cmdUpdateStats = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdPoolies
            // 
            this.cmdPoolies.Location = new System.Drawing.Point(100, 29);
            this.cmdPoolies.Name = "cmdPoolies";
            this.cmdPoolies.Size = new System.Drawing.Size(275, 53);
            this.cmdPoolies.TabIndex = 0;
            this.cmdPoolies.Text = "Poolies";
            this.cmdPoolies.UseVisualStyleBackColor = true;
            this.cmdPoolies.Click += new System.EventHandler(this.cmdPoolies_Click);
            // 
            // cmdPlayers
            // 
            this.cmdPlayers.Location = new System.Drawing.Point(100, 383);
            this.cmdPlayers.Name = "cmdPlayers";
            this.cmdPlayers.Size = new System.Drawing.Size(275, 53);
            this.cmdPlayers.TabIndex = 1;
            this.cmdPlayers.Text = "Players";
            this.cmdPlayers.UseVisualStyleBackColor = true;
            this.cmdPlayers.Click += new System.EventHandler(this.cmdPlayers_Click);
            // 
            // cmdPooliePlayers
            // 
            this.cmdPooliePlayers.Location = new System.Drawing.Point(100, 88);
            this.cmdPooliePlayers.Name = "cmdPooliePlayers";
            this.cmdPooliePlayers.Size = new System.Drawing.Size(275, 53);
            this.cmdPooliePlayers.TabIndex = 2;
            this.cmdPooliePlayers.Text = "View Poolie Players";
            this.cmdPooliePlayers.UseVisualStyleBackColor = true;
            this.cmdPooliePlayers.Click += new System.EventHandler(this.cmdPooliePlayers_Click);
            // 
            // cmdDraft
            // 
            this.cmdDraft.Location = new System.Drawing.Point(100, 206);
            this.cmdDraft.Name = "cmdDraft";
            this.cmdDraft.Size = new System.Drawing.Size(275, 53);
            this.cmdDraft.TabIndex = 3;
            this.cmdDraft.Text = "Poolie Player Draft";
            this.cmdDraft.UseVisualStyleBackColor = true;
            this.cmdDraft.Click += new System.EventHandler(this.cmdDraft_Click);
            // 
            // cmdInitPlayers
            // 
            this.cmdInitPlayers.Location = new System.Drawing.Point(100, 265);
            this.cmdInitPlayers.Name = "cmdInitPlayers";
            this.cmdInitPlayers.Size = new System.Drawing.Size(275, 53);
            this.cmdInitPlayers.TabIndex = 4;
            this.cmdInitPlayers.Text = "Initialize Player and Poolie Players Tables";
            this.cmdInitPlayers.UseVisualStyleBackColor = true;
            this.cmdInitPlayers.Click += new System.EventHandler(this.cmdInitPlayers_Click);
            // 
            // cmdUpdateStats
            // 
            this.cmdUpdateStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUpdateStats.Location = new System.Drawing.Point(100, 324);
            this.cmdUpdateStats.Name = "cmdUpdateStats";
            this.cmdUpdateStats.Size = new System.Drawing.Size(275, 53);
            this.cmdUpdateStats.TabIndex = 5;
            this.cmdUpdateStats.Text = "Update Player Stats (from Excel SS)";
            this.cmdUpdateStats.UseVisualStyleBackColor = true;
            this.cmdUpdateStats.Click += new System.EventHandler(this.cmdUpdateStats_Click);
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 478);
            this.Controls.Add(this.cmdUpdateStats);
            this.Controls.Add(this.cmdInitPlayers);
            this.Controls.Add(this.cmdDraft);
            this.Controls.Add(this.cmdPooliePlayers);
            this.Controls.Add(this.cmdPlayers);
            this.Controls.Add(this.cmdPoolies);
            this.Name = "frmAdmin";
            this.Text = "Admin";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdPoolies;
        private System.Windows.Forms.Button cmdPlayers;
        private System.Windows.Forms.Button cmdPooliePlayers;
        private System.Windows.Forms.Button cmdDraft;
        private System.Windows.Forms.Button cmdInitPlayers;
        private System.Windows.Forms.Button cmdUpdateStats;
    }
}