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
    public partial class frmPoolPoolies : Form
    {
        int FirstTimeInCount = 0;
        bool fromLB = false;
        int PoolieID = 0;
        public frmPoolPoolies()
        {
            InitializeComponent();
        }

        public frmPoolPoolies(string wherefrom, int poolieid)
        {
            InitializeComponent();
            fromLB = true;
            PoolieID = poolieid;
        }

        private void frmPoolPoolies_Load(object sender, EventArgs e)
        {
            PoolPoolie pp = new PoolPoolie();

            cboPool.DataSource = pp.GetPoolPoolies(Program.PoolID);
            cboPool.DisplayMember = "Fullname";
            cboPool.ValueMember = "ID";

            cboPool.Text = Program.PoolName;
               
            
            /*

            if (fromLB == true)
            {
                p2 = pl.FindPoolieByID(PoolieID);
                cboPool.Text = p2.Fullname;
            }
              */      /*
            if (fromLB == true)
            {
//                MessageBox.Show("Called from the LB");
                cboPoolies.DataSource = pl.FindPoolieByID(PoolieID);
                cboPoolies.DisplayMember = "Fullname";
                cboPoolies.ValueMember = "ID";
            }
            else {
                cboPoolies.DataSource = pl.GetPooliesFullname();
                cboPoolies.DisplayMember = "Fullname";
                cboPoolies.ValueMember = "ID";
            }
            */
//            PooliePlayer pp = new PooliePlayer();

            //MessageBox.Show("cboPoolies.ValueMember = " + cboPoolies.SelectedValue);
           //.. dataGridView1.DataSource = pp.GetPooliePlayers((int)cboPoolies.SelectedValue);
  /*          dataGridView1.DataSource = pp.GetPooliePlayers((int)cboPool.SelectedValue, Program.PoolID);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            */
        }

        private void cboPoolies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FirstTimeInCount < 2) {
                FirstTimeInCount += 1;
                return;
            }
          //  MessageBox.Show("cboPoolies.ValueMember = " + cboPoolies.SelectedValue);
            
                PoolPoolie pp = new PoolPoolie();

                //MessageBox.Show("cboPoolies.ValueMember = " + cboPoolies.SelectedValue);
                dataGridView1.DataSource = pp.GetPoolPoolies((int)cboPool.SelectedValue);
        }

        private void frmPoolPoolies_Load_1(object sender, EventArgs e)
        {
            Pool p = new Pool();
            PoolPoolie pp = new PoolPoolie();

            cboPool.DataSource = p.GetPools();
            cboPool.DisplayMember = "name";
            cboPool.ValueMember = "ID";

            dataGridView1.DataSource = pp.GetPoolPoolies((int)cboPool.SelectedValue);

            cboPool.Text = Program.PoolName;

/*
            cboPool.DataSource = pp.GetPoolPoolies(Program.PoolID);
            cboPool.DisplayMember = "Fullname";
            cboPool.ValueMember = "ID";
            */
               
/*
            Pool pool = new Pool();

            cboPool.DataSource = pool.GetPools();
            cboPool.DisplayMember = "name";
            cboPool.ValueMember = "ID";
            
            PoolPoolie pp = new PoolPoolie();

            dataGridView1.DataSource = pp.GetPoolPoolies((int)cboPool.SelectedValue);
        
 */ }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
