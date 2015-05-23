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
    public partial class Form2 : Form
    {
        Leaderboard lb = new Leaderboard();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text = "Leaderboard for " + Program.PoolName + " as of " + DateTime.Now.Date.ToShortDateString();
            dataGridView1.DataSource = lb.GetLeaderboard(Program.PoolID);
            dataGridView1.Columns[0].Visible = false;
    //        dataGridView1.Columns[1].Visible = false;
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdmin frmAdmin = new frmAdmin();
            frmAdmin.Show();
        }

        private void dataGridView1_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int poolieid = 0;
            string PoolieName = string.Empty;

            DataGridViewRow roww = dataGridView1.SelectedRows[0];

            poolieid=  (int)roww.Cells["PoolieID"].Value;
            PoolieName = roww.Cells["Lastname"].Value.ToString().Trim() + " " + roww.Cells["Firstname"].Value.ToString().Trim();

            frmPooliePlayers frmPP = new frmPooliePlayers("LB", poolieid, PoolieName);

            frmPP.Show();
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = lb.GetLeaderboard(Program.PoolID);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
