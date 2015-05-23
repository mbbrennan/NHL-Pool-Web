namespace NHL_Stat2
{
    partial class frmStartup
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
            this.cboPool = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.cmdLeaderboard = new System.Windows.Forms.Button();
            this.cmdPool = new System.Windows.Forms.Button();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.txtSeasonID = new System.Windows.Forms.TextBox();
            this.txtSeasonName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cboPool
            // 
            this.cboPool.FormattingEnabled = true;
            this.cboPool.Location = new System.Drawing.Point(70, 26);
            this.cboPool.Name = "cboPool";
            this.cboPool.Size = new System.Drawing.Size(207, 21);
            this.cboPool.TabIndex = 4;
            this.cboPool.SelectedIndexChanged += new System.EventHandler(this.cboPool_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pool:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(306, 27);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 5;
            // 
            // cmdLeaderboard
            // 
            this.cmdLeaderboard.Location = new System.Drawing.Point(70, 62);
            this.cmdLeaderboard.Name = "cmdLeaderboard";
            this.cmdLeaderboard.Size = new System.Drawing.Size(144, 39);
            this.cmdLeaderboard.TabIndex = 6;
            this.cmdLeaderboard.Text = "Go to Leaderboard";
            this.cmdLeaderboard.UseVisualStyleBackColor = true;
            this.cmdLeaderboard.Click += new System.EventHandler(this.cmdLeaderboard_Click);
            // 
            // cmdPool
            // 
            this.cmdPool.Location = new System.Drawing.Point(271, 62);
            this.cmdPool.Name = "cmdPool";
            this.cmdPool.Size = new System.Drawing.Size(144, 39);
            this.cmdPool.TabIndex = 7;
            this.cmdPool.Text = "Maintain Pools";
            this.cmdPool.UseVisualStyleBackColor = true;
            this.cmdPool.Click += new System.EventHandler(this.cmdPool_Click);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Location = new System.Drawing.Point(734, 26);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(75, 23);
            this.cmdRefresh.TabIndex = 8;
            this.cmdRefresh.Text = "Refresh";
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // txtSeasonID
            // 
            this.txtSeasonID.Location = new System.Drawing.Point(412, 27);
            this.txtSeasonID.Name = "txtSeasonID";
            this.txtSeasonID.Size = new System.Drawing.Size(100, 20);
            this.txtSeasonID.TabIndex = 9;
            // 
            // txtSeasonName
            // 
            this.txtSeasonName.Location = new System.Drawing.Point(518, 26);
            this.txtSeasonName.Name = "txtSeasonName";
            this.txtSeasonName.Size = new System.Drawing.Size(177, 20);
            this.txtSeasonName.TabIndex = 10;
            // 
            // frmStartup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 146);
            this.Controls.Add(this.txtSeasonName);
            this.Controls.Add(this.txtSeasonID);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.cmdPool);
            this.Controls.Add(this.cmdLeaderboard);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.cboPool);
            this.Controls.Add(this.label1);
            this.Name = "frmStartup";
            this.Text = "Select Pool";
            this.Load += new System.EventHandler(this.frmStartup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPool;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button cmdLeaderboard;
        private System.Windows.Forms.Button cmdPool;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.TextBox txtSeasonID;
        private System.Windows.Forms.TextBox txtSeasonName;
    }
}