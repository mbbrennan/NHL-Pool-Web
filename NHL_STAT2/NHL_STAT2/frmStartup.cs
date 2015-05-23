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
    public partial class frmStartup : Form
    {
        BindingSource bs = new BindingSource();

        public frmStartup()
        {
            InitializeComponent();
        }

        public void SetGlobalPoolID()
        {
            if (txtID.Text != String.Empty && txtID.Text != "Pool")
            {
                Program.PoolID = Convert.ToInt32(txtID.Text);
                Program.PoolName = cboPool.Text;
                Program.SeasonID = Convert.ToInt32(txtSeasonID.Text);
            }
        }

        private void cmdLeaderboard_Click(object sender, EventArgs e)
        {
            SetGlobalPoolID();
            
            Form2 frmLB = new Form2();
            frmLB.ShowDialog();
        }

        private void RefreshGrid()
        {
            Pool pl = new Pool();

            bs.DataSource = pl.GetPools();

//            cboPool.DataSource = bs.DataSource;

            cboPool.DataSource = bs;
            cboPool.DisplayMember = "Name";
            cboPool.ValueMember = "ID";

            //this.cboPool.DataBindings.Add("Text", bs, "Name", true);
            txtID.DataBindings.Add("Text", bs, "ID", true);
            txtSeasonID.DataBindings.Add("Text", bs, "SeasonID", true);
            txtSeasonName.DataBindings.Add("Text", bs, "SeasonName", true);
            /*

            Pool pl = new Pool();
            cboPool.DataSource = pl.GetPools();
            cboPool.DisplayMember = "Name";
            cboPool.ValueMember = "ID";
        
             */ }

        private void frmStartup_Load(object sender, EventArgs e)
        {
            RefreshGrid();
            /*
            txtID.Text = string.Empty;
            txtID.Text = cboPool.SelectedValue.ToString();

             */ //           txtSeasonID.Text = 
            SetGlobalPoolID();
        }

/*        private void cboPool_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtID.Text = cboPool.SelectedValue.ToString();

            SetGlobalPoolID();
        }
        */
        private void cmdPool_Click(object sender, EventArgs e)
        {
            PoolForm poolform = new PoolForm();
            int PoolID = 0;
            if (cboPool.SelectedValue.ToString() == string.Empty)
            {
                poolform.SelectedPoolID = string.Empty;
                poolform.SelectedPoolName = string.Empty;
                poolform.SelectedSeasonName = string.Empty;
                poolform.SelectedSeasonID = 0;
                poolform.SelectedSeasonName = string.Empty; 
            }
            else {
                poolform.SelectedPoolID = cboPool.SelectedValue.ToString();
                poolform.SelectedPoolName = cboPool.Text;
                PoolID = Convert.ToInt32(poolform.SelectedPoolID);
                poolform.SelectedSeasonID = Convert.ToInt32(txtSeasonID.Text);
                poolform.SelectedSeasonName = txtSeasonName.Text; 
            }
            poolform.Show();
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void cboPool_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

