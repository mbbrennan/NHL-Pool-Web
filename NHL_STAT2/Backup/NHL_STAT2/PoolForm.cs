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
    public partial class PoolForm : Form
    {
        public string SelectedPoolID;
        public string SelectedPoolName;
        public string SelectedSeasonName;
        public int SelectedSeasonID;
        public string NewPoolName = string.Empty;
        bool bFormLoaded = false;
        Season _season = new Season();

        public PoolForm()
        {
            InitializeComponent();
        }

        private void cmClear_Click(object sender, EventArgs e)
        {
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            cboSeason.Text = string.Empty;
            txtSeasonID.Text = string.Empty;
            cmdAdd.Text = "Add";
            cboSeason.DataSource = _season.GetSeasons();
            cboSeason.DisplayMember = "Name";
            cboSeason.ValueMember = "SeasonID";
            cboSeason.Text = string.Empty;
        }

        private void PoolForm_Load(object sender, EventArgs e)
        {

            txtID.Text = SelectedPoolID;
            txtName.Text = SelectedPoolName;
            cboSeason.Text = SelectedSeasonName;
            txtSeasonID.Text = SelectedSeasonID.ToString();
            cboSeason.Text = SelectedSeasonName.ToString();
//            txtSeasonName.Text = SelectedSeasonName.ToString();
/*
            cboSeason.DataSource = _season.GetSeasons();
            cboSeason.DisplayMember = "SEASONNAME";
            cboSeason.ValueMember = "SEASONID";
            */
            //cboSeason.Text = 

            RefreshGrid();
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 225;

            bFormLoaded = true;
        }

        private void RefreshGrid()
        {
            Pool pool = new Pool();

            dataGridView1.DataSource = pool.GetPools();
        }

        private void ClearFormFields()
        {
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtSeasonID.Text = string.Empty;
            cboSeason.Text = string.Empty;
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == String.Empty)
            {
                MessageBox.Show("ERROR: The name of the pool must be entered.");
                return;
            }
            if (cboSeason.Text == String.Empty)
            {
                MessageBox.Show("ERROR: The season field must be entered.");
                return;
            }

            Pool p = new Pool();
            /*
            if (rdoNo.Checked == true) {
                p.IsTrueDraft = true;
            }
            if (rdoNo.Checked == false)
            {
                p.IsTrueDraft = false;
            }*/
            if (cmdAdd.Text == "Add")
            {
                p.Name = txtName.Text;
                p.SeasonID = Convert.ToInt32(cboSeason.SelectedValue);
                p.DateCreated = DateTime.Now;
                p.IsTrueDraft = rdoNo.Checked;
                //rdoNo.Checked
                p.Insert(p);
            }

            if (cmdAdd.Text == "Update")
            {
                p.ID = Convert.ToInt32(txtID.Text);
                p.SeasonID = cboSeason.SelectedIndex;
                p.Name = txtName.Text;
                p.Update(p);
            }
            RefreshGrid();
            ClearFormFields();
        }

        private void cmdEdit_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("ERROR: Select a row first by using the mouse.");
                return;
            }
            txtID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtName.Text = ((string)dataGridView1.SelectedRows[0].Cells[1].Value);
            cmdAdd.Text = "Update";

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            txtID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtName.Text = ((string)dataGridView1.SelectedRows[0].Cells[1].Value);
            cmdAdd.Text = "Update";
            //txtID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            //txtName.Text = ((string)dataGridView1.SelectedRows[0].Cells[1].Value);

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            this.Name = "PoolForm";
            if (bFormLoaded == false)
            {
                return;
            }   

            //if (SelectedPoolName != String.Empty)
            //{
            ////    SelectedPoolName = String.Empty;
            //    return;
            //}
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            txtID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtName.Text = ((string)dataGridView1.SelectedRows[0].Cells[1].Value);
            txtSeasonID.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            cboSeason.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            cmdAdd.Text = "Add";            
            
            // MessageBox.Show("dataGridView1_SelectionChanged");
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            Pool pool = new Pool();

            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("ERROR: Name field must be provided before UPDATE.");
                return;
            }

            pool.ID = Convert.ToInt32(txtID.Text);
            pool.Name = txtName.Text;
            pool.IsTrueDraft = rdoNo.Checked;
            pool.Update(pool);
            ClearFormFields();
            RefreshGrid();
        }

        private void cmdClonePool_Click(object sender, EventArgs e)
        {
            string SourcePoolName;   
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("ERROR: Select a source pool from the grid first to clone it to a new pool name.");
                return;
            }
            if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("ERROR: Select only 1 row from the grid to clone in to a new pool name.");
                return;
            }
            SourcePoolName = (string)dataGridView1.SelectedRows[0].Cells[1].Value;
            frmNewPoolName NewPoolForm = new frmNewPoolName(SourcePoolName);
            NewPoolForm.ShowDialog();
            if (NewPoolForm.NewPoolName != string.Empty && NewPoolForm.NewPoolSeasonID != 0)
            {
          //      CreateNewPoolFromExisting(NewPoolForm.NewPoolName);
                CopyPooliesFromOtherPool(NewPoolForm.NewPoolName, NewPoolForm.NewPoolSeasonID, SourcePoolName);
            }
//            MessageBox.Show("NewPoolName = " + NewPoolForm.NewPoolName);

            //MessageBox.Show("Enter the new pool name", "Enter new pool name", MessageBoxButtons.OKCancel,
            //txtID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            //txtName.Text = ((string)dataGridView1.SelectedRows[0].Cells[1].Value);
            //cmdAdd.Text = "Update";

        }

        private void CopyPooliesFromOtherPool(string NewPoolName, int NewPoolSeasonID, string SourcePoolName)
        {
            PoolPoolie pp = new PoolPoolie();
            pp.CopyPooliesToPool(NewPoolName, NewPoolSeasonID, SourcePoolName);
            RefreshGrid();
        }


        private void CreateNewPoolFirst(string PoolName)
        {
            if (PoolName == String.Empty)
            {
                MessageBox.Show("ERROR: The name of the pool must be entered.");
                return;
            }

            Pool p = new Pool();

            p.Name = PoolName;
            p.DateCreated = DateTime.Now;
            p.Insert(p);

            RefreshGrid();
        }            

        private void CreateNewPoolFromExisting(string PoolName)
        {
            CreateNewPoolFirst(PoolName);
            MessageBox.Show("Created new pool");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboSeason_SelectedIndexChanged(object sender, EventArgs e)
        {

        }            
    }
}