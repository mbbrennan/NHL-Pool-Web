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
    public partial class frmUpdateStats : Form
    {
        public string SeasonName = string.Empty;
        public int SeasonID = 0;

        public frmUpdateStats()
        {
            InitializeComponent();
        }

        private void  GetSeasons()
        {
            Season _season = new Season();
            cboSeasons.DataSource = _season.GetSeasons();
            cboSeasons.DisplayMember = "Name";
            cboSeasons.ValueMember = "SeasonID";
        }

        private void frmUpdateStats_Load(object sender, EventArgs e)
        {
            GetSeasons();
            SeasonName = string.Empty;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            SeasonName = cboSeasons.Text.Trim();
            SeasonID = Convert.ToInt32(cboSeasons.SelectedValue);
            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            SeasonName = string.Empty;
            Close();
        }
    }
}
