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
    public partial class frmPlayers : Form
    {
      

        public frmPlayers()
        {
            InitializeComponent();
        }

        private void frmPlayers_Load(object sender, EventArgs e)
        {
            Team _team = new Team();

            cboTeam.DataSource = _team.GetTeams();
            cboTeam.DisplayMember = "Abbrev";
            cboTeam.ValueMember = "Abbrev";

            Player _player = new Player();

            this.Text = "Players";
            dataGridView1.DataSource = _player.SelectAllActive(String.Empty);
            dataGridView1.Columns["Rank"].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[5].Visible = false;
        }

        private void cboTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cmdGetPlayers_Click(object sender, EventArgs e)
        {
         
            Player _player = new Player();
            dataGridView1.DataSource = _player.SelectAllActive((string)cboTeam.SelectedValue);

        }
    }
}
