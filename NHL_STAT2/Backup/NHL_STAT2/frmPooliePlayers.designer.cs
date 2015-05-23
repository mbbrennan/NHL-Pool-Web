namespace NHL_Stat2
{
    partial class frmPooliePlayers
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboPoolies = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cboPool = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Poolie:";
            // 
            // cboPoolies
            // 
            this.cboPoolies.FormattingEnabled = true;
            this.cboPoolies.Location = new System.Drawing.Point(77, 50);
            this.cboPoolies.Name = "cboPoolies";
            this.cboPoolies.Size = new System.Drawing.Size(207, 21);
            this.cboPoolies.TabIndex = 1;
            this.cboPoolies.SelectedIndexChanged += new System.EventHandler(this.cboPoolies_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(33, 88);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(667, 332);
            this.dataGridView1.TabIndex = 2;
            // 
            // cboPool
            // 
            this.cboPool.FormattingEnabled = true;
            this.cboPool.Location = new System.Drawing.Point(77, 21);
            this.cboPool.Name = "cboPool";
            this.cboPool.Size = new System.Drawing.Size(207, 21);
            this.cboPool.TabIndex = 15;
            this.cboPool.SelectedIndexChanged += new System.EventHandler(this.cboPool_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Pool:";
            // 
            // frmPooliePlayers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 432);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboPool);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cboPoolies);
            this.Controls.Add(this.label1);
            this.Name = "frmPooliePlayers";
            this.Text = "frmPooliePlayers";
            this.Load += new System.EventHandler(this.frmPooliePlayers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPoolies;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cboPool;
        private System.Windows.Forms.Label label2;
    }
}