using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NHL_Stat2
{
    public partial class frmNewPoolName : Form
    {
        public string NewPoolName;
        public int NewPoolSeasonID;
        private string SourcePoolName;

        Season _season = new Season();

        public frmNewPoolName()
        {
            InitializeComponent();
        }

        public frmNewPoolName(string sourcepool)
        {
            InitializeComponent();
            SourcePoolName = sourcepool;
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            NewPoolName = txtNewPoolName.Text;
            if (txtSeasonID.Text != string.Empty)
            {
                NewPoolSeasonID = Convert.ToInt32(txtSeasonID.Text);
            }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmNewPoolName_Load_1(object sender, EventArgs e)
        {
            txtSourcePoolName.Text = SourcePoolName;
            txtSourcePoolName.ReadOnly = true;
            NewPoolName = string.Empty;
            cboSeason.DataSource = _season.GetSeasons();
            cboSeason.DisplayMember = "Name";
            cboSeason.ValueMember = "SeasonID";
            cboSeason.Text = string.Empty;

        }

        private void cboSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSeason.Text != string.Empty)
            {
                txtSeasonID.Text = cboSeason.SelectedValue.ToString();
            }

            // MessageBox.Show("dataGridView1_SelectionChanged");

        }
    }
}
