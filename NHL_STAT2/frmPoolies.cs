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
    public partial class frmPoolies : Form
    {
        Poolie poolee = new Poolie();
        int PoolID = 0;

        public frmPoolies()
        {
            InitializeComponent();
        }

        private void RefreshGrid()
        {
            dataGridView1.DataSource = poolee.GetPoolies(PoolID);
            dataGridView1.Columns["PoolID"].Visible = false;
            dataGridView1.Columns["Fullname"].Visible = false;
        }
            
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (txtFirstname.Text == String.Empty || txtLastname.Text == String.Empty)
            {
                MessageBox.Show("ERROR: Both 'Firstname' and 'Lastname' must be entered before add.");
                return;
            }

            Poolie pl = new Poolie();
            pl.Firstname = txtFirstname.Text;
            pl.Lastname = txtLastname.Text;

            if (cboPool.SelectedValue.ToString() == string.Empty || cboPool.SelectedValue.ToString() == "Pool")
            {
                MessageBox.Show("ERROR: Cannot determine the Pool ID for this Poolie.  Contact HelpDesk.");
                return;
            }

            string PoolIDString = cboPool.SelectedValue.ToString();
            int PoolID = 0;
            if (PoolIDString != String.Empty)
            {
                PoolID = Convert.ToInt32(cboPool.SelectedValue.ToString());
            }
            pl.PoolID = PoolID;  

            if (txtID.Text != string.Empty)
            {
                pl.ID = Convert.ToInt32(txtID.Text);
            }

            if (cmdAdd.Text == "Add")
            { pl.Insert(pl); }
            if (cmdAdd.Text == "Update")
            { pl.Update(pl); }

            txtID.Text = String.Empty;
            txtFirstname.Text = String.Empty;
            txtLastname.Text = String.Empty;

            RefreshGrid();
        }

        private void  GetPools()
        {
            Pool pl = new Pool();
            cboPool.DataSource = pl.GetPools();
            cboPool.DisplayMember = "Name";
            cboPool.ValueMember = "ID";
        }

        private void frmPoolies_Load(object sender, EventArgs e)
        {
            PoolID = Program.PoolID;

            GetPools();

            cboPool.Text = Program.PoolName;
            txtID.ReadOnly = true;

            RefreshGrid();
          //  dataGridView1.Columns[1].Visible = false;
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) {
                MessageBox.Show("ERROR: Select a row first by using the mouse.");
                return;
            }
            txtID.Text= dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtFirstname.Text =  ((string) dataGridView1.SelectedRows[0].Cells[2].Value);
            txtLastname.Text = ((string) dataGridView1.SelectedRows[0].Cells[3].Value);
            cmdAdd.Text = "Update";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtID.Text = string.Empty;
            txtFirstname.Text = string.Empty;
            txtLastname.Text = string.Empty;
            cmdAdd.Text = "Add";
            dataGridView1.CurrentCell = null;
        }

        private void cboPool_SelectedIndexChanged(object sender, EventArgs e)
        {
            int PoolID = 0;
            string PoolIDString;

            if (cboPool.Text == string.Empty || cboPool.Text == "Pool" )
            {
                return;
            }

            if (cboPool.SelectedValue.ToString() == string.Empty || cboPool.SelectedValue.ToString() == "Pool")
            {
                return;
            }

            PoolIDString = cboPool.SelectedValue.ToString();

            if (PoolIDString != String.Empty)
            {
                PoolID = Convert.ToInt32(cboPool.SelectedValue.ToString());
            }
            dataGridView1.DataSource = poolee.GetPoolies(PoolID);
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            txtID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtFirstname.Text = ((string)dataGridView1.SelectedRows[0].Cells[2].Value);
            txtLastname.Text = ((string)dataGridView1.SelectedRows[0].Cells[3].Value);
            cmdAdd.Text = "Update";
        }
    }
}
