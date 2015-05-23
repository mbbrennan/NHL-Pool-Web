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
    public partial class frmPool1 : Form
    {
        public frmPool1()
        {
            InitializeComponent();
        }
        private void RefreshGrid()
        {
            Pool pool = new Pool();

            dataGridView1.DataSource = pool.GetPools();
        }
            
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == String.Empty)
            {
                MessageBox.Show("ERROR: The name of the pool must be entered.");
                return;
            }

            Pool p = new Pool();
            
            if (cmdAdd.Text == "Add")
            {
                p.Name = txtName.Text;
                p.DateCreated = DateTime.Now;
                p.Insert(p);    
            }

            if (cmdAdd.Text == "Update")
            {
                p.Name = txtName.Text;
                p.Update(p);
            }
            RefreshGrid();
        }

        private void frmPool_Load_1(object sender, EventArgs e)
        {
            RefreshGrid();        
        }

        //private void cmdEdit_Click(object sender, EventArgs e)
        //{
        //    if (dataGridView1.SelectedRows.Count == 0) {
        //        MessageBox.Show("ERROR: Select a row first by using the mouse.");
        //        return;
        //    }
        //    txtID.Text= dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        //    txtName.Text =  ((string) dataGridView1.SelectedRows[0].Cells[1].Value);
        //    cmdAdd.Text = "Update";
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    e.Text = string.Empty;
        //    txtLastname.Text = string.Empty;
        //    cmdAdd.Text = "Add";
        //    dataGridView1.CurrentCell = null;
        //}
    }
}
