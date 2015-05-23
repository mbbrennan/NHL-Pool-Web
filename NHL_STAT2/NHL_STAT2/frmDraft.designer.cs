namespace NHL_Stat2
{
    partial class frmDraft
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cboPoolies = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLastname = new System.Windows.Forms.TextBox();
            this.txtFirstname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.cmdClear = new System.Windows.Forms.Button();
            this.cmdDraftPlayer = new System.Windows.Forms.Button();
            this.txtPoolieID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdRemovePlayer = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cboPool = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 125);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(781, 211);
            this.dataGridView1.TabIndex = 5;
            // 
            // cboPoolies
            // 
            this.cboPoolies.FormattingEnabled = true;
            this.cboPoolies.Location = new System.Drawing.Point(70, 46);
            this.cboPoolies.Name = "cboPoolies";
            this.cboPoolies.Size = new System.Drawing.Size(207, 21);
            this.cboPoolies.TabIndex = 4;
            this.cboPoolies.SelectedIndexChanged += new System.EventHandler(this.cboPoolies_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Poolie:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Lastname:";
            // 
            // txtLastname
            // 
            this.txtLastname.Location = new System.Drawing.Point(70, 82);
            this.txtLastname.Name = "txtLastname";
            this.txtLastname.Size = new System.Drawing.Size(190, 20);
            this.txtLastname.TabIndex = 7;
            // 
            // txtFirstname
            // 
            this.txtFirstname.Location = new System.Drawing.Point(351, 85);
            this.txtFirstname.Name = "txtFirstname";
            this.txtFirstname.Size = new System.Drawing.Size(150, 20);
            this.txtFirstname.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(290, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Firstname:";
            // 
            // cmdSearch
            // 
            this.cmdSearch.Location = new System.Drawing.Point(505, 83);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(75, 23);
            this.cmdSearch.TabIndex = 10;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 371);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(781, 181);
            this.dataGridView2.TabIndex = 11;
            // 
            // cmdClear
            // 
            this.cmdClear.Location = new System.Drawing.Point(586, 85);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(75, 23);
            this.cmdClear.TabIndex = 12;
            this.cmdClear.Text = "Clear";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // cmdDraftPlayer
            // 
            this.cmdDraftPlayer.Location = new System.Drawing.Point(505, 342);
            this.cmdDraftPlayer.Name = "cmdDraftPlayer";
            this.cmdDraftPlayer.Size = new System.Drawing.Size(75, 23);
            this.cmdDraftPlayer.TabIndex = 13;
            this.cmdDraftPlayer.Text = "Draft Player";
            this.cmdDraftPlayer.UseVisualStyleBackColor = true;
            this.cmdDraftPlayer.Click += new System.EventHandler(this.cmdDraftPlayer_Click);
            // 
            // txtPoolieID
            // 
            this.txtPoolieID.Location = new System.Drawing.Point(351, 49);
            this.txtPoolieID.Name = "txtPoolieID";
            this.txtPoolieID.ReadOnly = true;
            this.txtPoolieID.Size = new System.Drawing.Size(190, 20);
            this.txtPoolieID.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(289, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Poolier ID:";
            // 
            // cmdRemovePlayer
            // 
            this.cmdRemovePlayer.Location = new System.Drawing.Point(505, 558);
            this.cmdRemovePlayer.Name = "cmdRemovePlayer";
            this.cmdRemovePlayer.Size = new System.Drawing.Size(75, 23);
            this.cmdRemovePlayer.TabIndex = 16;
            this.cmdRemovePlayer.Text = "Remove Player";
            this.cmdRemovePlayer.UseVisualStyleBackColor = true;
            this.cmdRemovePlayer.Click += new System.EventHandler(this.cmdRemovePlayer_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Pool:";
            // 
            // cboPool
            // 
            this.cboPool.FormattingEnabled = true;
            this.cboPool.Location = new System.Drawing.Point(70, 12);
            this.cboPool.Name = "cboPool";
            this.cboPool.Size = new System.Drawing.Size(207, 21);
            this.cboPool.TabIndex = 17;
            this.cboPool.SelectedIndexChanged += new System.EventHandler(this.cboPool_SelectedIndexChanged_1);
            // 
            // frmDraft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 633);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboPool);
            this.Controls.Add(this.cmdRemovePlayer);
            this.Controls.Add(this.txtPoolieID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdDraftPlayer);
            this.Controls.Add(this.cmdClear);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.txtFirstname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLastname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cboPoolies);
            this.Controls.Add(this.label1);
            this.Name = "frmDraft";
            this.Text = "frmDraft";
            this.Load += new System.EventHandler(this.frmDraft_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cboPoolies;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLastname;
        private System.Windows.Forms.TextBox txtFirstname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.Button cmdDraftPlayer;
        private System.Windows.Forms.TextBox txtPoolieID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdRemovePlayer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboPool;
    }
}