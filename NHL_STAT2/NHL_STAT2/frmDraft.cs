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
    public partial class frmDraft : Form
    {
        int FirstTimeInCount = 0;
        int PoolID = 0;
        public frmDraft()
        {
            InitializeComponent();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            PooliePlayer pp = new PooliePlayer();

            dataGridView1.DataSource = pp.SearchPlayers((int)cboPoolies.SelectedValue, txtLastname.Text, txtFirstname.Text);
            dataGridView1.Columns["Rank"].Visible = false;
            dataGridView1.Columns["Drafted"].Visible = false;

        }
        
        private void GetPools()
        {
            Pool pl = new Pool();
            cboPool.DataSource = pl.GetPools();
            cboPool.DisplayMember = "Name";
            cboPool.ValueMember = "ID";
        }

        private void frmDraft_Load(object sender, EventArgs e)
        {
       //     PoolID = Program.PoolID;

            GetPools();

         //   cboPool.Text = Program.PoolName;

            PoolPoolie pp = new PoolPoolie();

            cboPoolies.DataSource = pp.GetPoolPoolies(1);
            cboPoolies.DisplayMember = "PoolieName";
            cboPoolies.ValueMember = "PoolieID";
/*
            
            Poolie pl = new Poolie();
            cboPoolies.DataSource = pl.GetPooliesFullname(Program.PoolID);
            cboPoolies.DisplayMember = "Fullname";
            cboPoolies.ValueMember = "ID";
            txtPoolieID.Text = cboPoolies.SelectedValue.ToString();
            */
            if (txtPoolieID.Text == String.Empty)
            {
                return;
            }

            PooliePlayer pplayer = new PooliePlayer();

            dataGridView2.DataSource = pplayer.GetPooliePlayers(Convert.ToInt32(txtPoolieID.Text), Program.PoolID);
            dataGridView2.Columns["Rank"].Visible = false;
            dataGridView2.Columns["Available"].Visible = false;
        }

        private void cboPoolies_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (FirstTimeInCount < 2)
            {
                FirstTimeInCount += 1;
                return;
            }
            //  MessageBox.Show("cboPoolies.ValueMember = " + cboPoolies.SelectedValue);

            PooliePlayer pp = new PooliePlayer();

            //MessageBox.Show("cboPoolies.ValueMember = " + cboPoolies.SelectedValue);
            dataGridView2.DataSource = pp.GetPooliePlayers((int)cboPoolies.SelectedValue, PoolID);
            txtPoolieID.Text = cboPoolies.SelectedValue.ToString();
            
        }


        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtLastname.Text = String.Empty;
            txtFirstname.Text = String.Empty;
            dataGridView1.DataSource = null;

        }

        private void cmdDraftPlayer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("No row(s) selected.");
                return;
            }
            if (cboPool.Text == String.Empty)
            {
                MessageBox.Show("Pool must be selected.");
                return;
            }

            foreach (DataGridViewRow roww in dataGridView1.SelectedRows)
            {
                if ((string)roww.Cells["Available"].Value.ToString() == "No")
                {
                    MessageBox.Show("Cannot draft players that have 'Available' set to 'No'");
                    return;
                }
            }
            int i = 0;
            int PoolID = 0;

            foreach (DataGridViewRow roww in dataGridView1.SelectedRows)
            {
                PooliePlayer pp = new PooliePlayer();

                PoolID = Convert.ToInt32(cboPool.SelectedValue);

                pp.PoolID = PoolID;
                pp.PoolieID = Convert.ToInt32(txtPoolieID.Text);
                pp.PlayerID = (int)roww.Cells[1].Value;
                pp.Insert(pp);

                txtLastname.Text = String.Empty;
                txtFirstname.Text = String.Empty;
                dataGridView1.DataSource = null;
                dataGridView2.DataSource = pp.GetPooliePlayers((int)cboPoolies.SelectedValue, PoolID);
                dataGridView2.Columns["Rank"].Visible = false;
                dataGridView2.Columns["Available"].Visible = false;
                dataGridView2.Columns["Drafted"].Visible = false;
                // MessageBox.Show("Insert to PooliePlayer done!");
            }
        }

        private void cmdRemovePlayer_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("No row(s) selected.");
                return;
            }

            foreach (DataGridViewRow roww in dataGridView2.SelectedRows)
            {
                PooliePlayer pp = new PooliePlayer();

                pp.PoolieID = Convert.ToInt32(txtPoolieID.Text);
                pp.PlayerID = (int)roww.Cells[1].Value;

                if (MessageBox.Show("Are you sure you want to remove the player from this poolie's list of players", "Confirm removal", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    pp.Delete(pp);
                }

                txtLastname.Text = String.Empty;
                txtFirstname.Text = String.Empty;
                dataGridView1.DataSource = null;
                dataGridView2.DataSource = pp.GetPooliePlayers((int)cboPoolies.SelectedValue, Program.PoolID);
                dataGridView2.Columns["Available"].Visible = false;
                dataGridView2.Columns["Drafted"].Visible = false;

            }
        }
        private void cboPool_SelectedIndexChanged(object sender, EventArgs e)
        {
            string PoolIDString;

            if (cboPool.Text == string.Empty || cboPool.Text == "Pool" )
            {
                return;
            }
            //PoolID = Convert.ToInt32(cboPool.SelectedValue);
            PoolIDString = cboPool.SelectedValue.ToString();
            if (PoolIDString == "Pool")
            {
                return;
            }
            PoolID = Convert.ToInt32(PoolIDString);

            PoolPoolie pp = new PoolPoolie();

            cboPoolies.DataSource = pp.GetPoolPoolies(1);
            cboPoolies.DisplayMember = "PoolieName";
            cboPoolies.ValueMember = "PoolieID";
      
      

            txtPoolieID.Text = cboPoolies.SelectedValue.ToString();

            if (txtPoolieID.Text == String.Empty)
            {
                return;
            }

            PooliePlayer pp_ = new PooliePlayer();

            dataGridView2.DataSource = pp_.GetPooliePlayers(Convert.ToInt32(txtPoolieID.Text), PoolID);
            dataGridView2.Columns["Drafted"].Visible = false;

        }

        private void cboPool_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string PoolIDString;

            if (cboPool.Text == string.Empty || cboPool.Text == "Pool")
            {
                return;
            }
            //PoolID = Convert.ToInt32(cboPool.SelectedValue);
            PoolIDString = cboPool.SelectedValue.ToString();
            if (PoolIDString == "Pool")
            {
                return;
            }
            PoolID = Convert.ToInt32(PoolIDString);

            PoolPoolie pp = new PoolPoolie();

            cboPoolies.DataSource = pp.GetPoolPoolies(PoolID);
            cboPoolies.DisplayMember = "PoolieName";
            cboPoolies.ValueMember = "PoolieID";



            txtPoolieID.Text = cboPoolies.SelectedValue.ToString();

            if (txtPoolieID.Text == String.Empty)
            {
                return;
            }

            PooliePlayer pp_ = new PooliePlayer();

            dataGridView2.DataSource = pp_.GetPooliePlayers(Convert.ToInt32(txtPoolieID.Text), PoolID);
            dataGridView2.Columns["Drafted"].Visible = false;

        }
      
    }
}
