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
    public partial class frmPooliePlayers : Form
    {
        int FirstTimeInCount = 0;
        bool fromLB = false;
        int PoolieID = 0;
        int PoolieID_ = 0;
        string PoolieIDString = String.Empty;
        int PoolID = 0;
//        Poolie poolee = new Poolie();
        PoolPoolie pp = new PoolPoolie();
        PooliePlayer poolieplayer = new PooliePlayer();
        string PoolieName;
        public frmPooliePlayers()
        {
            InitializeComponent();
        }

        public frmPooliePlayers(string wherefrom, int poolieid, string pooliename)
        {
            InitializeComponent();
            fromLB = true;
            PoolieID_ = poolieid;
            PoolieName = pooliename;
        }

        private void GetPools()
        {
            Pool pl = new Pool();
            cboPool.DataSource = pl.GetPools();
            cboPool.DisplayMember = "Name";
            cboPool.ValueMember = "ID";
        }

        private void frmPooliePlayers_Load(object sender, EventArgs e)
        {
            PoolID = Program.PoolID;

            GetPools();

            cboPool.Text = Program.PoolName;

            cboPoolies.DataSource = pp.GetPoolPoolies(PoolID);
            cboPoolies.DisplayMember = "PoolieName";
            cboPoolies.ValueMember = "PoolieID";

            int poolieid = 0;

            if (cboPoolies.SelectedValue.ToString() != String.Empty)
            {
                poolieid = Convert.ToInt32(cboPoolies.SelectedValue.ToString());
            }

            if (fromLB == true)
            {
                cboPoolies.Text = PoolieName;
      //          cboPoolies.SelectedText = PoolieName;
              //  poolieid = PoolieID;
            }


            dataGridView1.DataSource = poolieplayer.GetPooliePlayers(PoolieID_, PoolID);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns["Available"].Visible = false;
            dataGridView1.Columns["Drafted"].Visible = false;
        }

        private void cboPoolies_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboPoolies.Text == string.Empty)
            {
                return;
            }

            if (cboPoolies.SelectedValue == "NHL_Stat2.PoolPoolie" || cboPoolies.SelectedValue == "NHL_Stat2.Poolie" || cboPoolies.SelectedText == "NHL_Stat2.Poolie" || cboPoolies.Text == "NHL_Stat2.Poolie" || cboPoolies.Text == String.Empty)
            {
                return;
            }

            if (cboPoolies.SelectedValue == null)
            {
                return;
            }

            PoolieIDString = cboPoolies.SelectedValue.ToString();

            if (PoolieIDString == "NHL_Stat2.Poolie") { return;  }

            if (PoolieIDString == "NHL_Stat2.PoolPoolie") { return; }
            if (PoolieIDString != String.Empty)
            {
                PoolieID = Convert.ToInt32(cboPoolies.SelectedValue.ToString());
            }

            dataGridView1.DataSource = poolieplayer.GetPooliePlayers(PoolieID, PoolID);
        }

        private void cboPool_SelectedIndexChanged(object sender, EventArgs e)
        {
            string PoolIDString;

            if (cboPool.Text == string.Empty || cboPool.Text == "Pool")
            {
                return;
            }

            if (cboPool.SelectedValue.ToString() == string.Empty || cboPool.SelectedValue.ToString() == "Pool")
            {
                return;
            }

            if (cboPoolies.Text == "NHL_Stat2.Poolie" ||
            cboPoolies.Text == "Pool")
            {
                return;
            }

            PoolIDString = cboPool.SelectedValue.ToString();

            if (PoolIDString != String.Empty)
            {
                PoolID = Convert.ToInt32(cboPool.SelectedValue.ToString());
            }
            cboPoolies.DataSource = pp.GetPoolPoolies(PoolID);
            cboPoolies.DisplayMember = "PoolieName";
            cboPoolies.ValueMember = "PoolieID";




/*
            cboPoolies.DataSource = poolee.GetPoolies(PoolID);
            cboPoolies.DisplayMember = "Fullname";
            cboPoolies.ValueMember = "ID";
            */

            int poolieid = 0;


//            if (dataGridView1.SelectedRows[0].Cells["PoolieID"].ToString() != string.Empty)
            if            (cboPoolies.SelectedValue.ToString() != String.Empty)
            {
             //   poolieid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["PoolieID"].ToString());
            //    poolieid = Convert.ToInt32(cboPoolies.SelectedValue.ToString());
            }

            /*            
            if (cboPoolies.SelectedValue.ToString() != String.Empty)
            {
                poolieid = Convert.ToInt32(cboPoolies.SelectedValue.ToString());
            }
            */
            dataGridView1.DataSource = poolieplayer.GetPooliePlayers(PoolieID, PoolID);

        }
    }
}
