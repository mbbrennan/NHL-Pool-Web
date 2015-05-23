using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using Excel = Microsoft.Office.Interop.Excel;

namespace NHL_Stat2
{
    public partial class Form1 : Form
    {
        const int ARRAYLEN  = 1000;
        string[] Players = new String[ARRAYLEN];
        string IOFullFilePath = string.Empty;
        int PlayerID;
        public Form1()
        {
            InitializeComponent();
        }

        private bool ValidateInputFileExists()
        {
            IOFullFilePath = System.Configuration.ConfigurationManager.AppSettings["InputFile"];

            if (!File.Exists(IOFullFilePath))
            {
                MessageBox.Show("Input file : " + IOFullFilePath + " does not exist.");
                return false;
            }
            return true;
        }

        private void OpenInputFile()
        {
            Excel.Application ExcelObj = new Excel.Application();

            if (ExcelObj == null)
            {
                MessageBox.Show("Unable to instanciate Excel object.");
            }

            string filead = IOFullFilePath;

            Microsoft.Office.Interop.Excel.Workbook theWorkbook = ExcelObj.Workbooks.Open(filead, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "",

            true, false, 0, true, false, false);

            Microsoft.Office.Interop.Excel.Sheets sheets = theWorkbook.Worksheets;

            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)sheets.get_Item(1);

            int cntexcelint = worksheet.UsedRange.Rows.Count; // .Rows.Count.ToString();

            for (int h = 2; h <= cntexcelint; h++)
            {

                Microsoft.Office.Interop.Excel.Range range = worksheet.get_Range("A" + h.ToString(), "A" + h.ToString());

                //System.Array myvalues = (System.Array)range.Cells.Value2;
                string myvalues = range.Cells.Value2.ToString();
                //strArray = ConvertToStringArray(myvalues);
                Players[h - 2] = myvalues;
//                MessageBox.Show("Player = " + myvalues);
            }

          //  InsertPlayersToDB();
        }

        private void UpdateStats()
        {

        }


        private void InsertPlayersToDB()
        {
            foreach (string player in Players)
            {
                if (player != null)
                {
                    string[] words = player.Split(' ');

                    string Lastname = string.Empty;
                    string Firstname = string.Empty;

                    if (words.Count() != 0)
                    {
                        if (words.Count() == 1)
                        {
                            Lastname = words[0];
                        }
                        if (words.Count() == 2)
                        {
                            Firstname = words[0];
                            Lastname = words[1];
                        }
                        if (words.Count() == 3)
                        {
                            Firstname = words[0];
                            Lastname = words[1] + " " + words[2];
                        }
                        if (words.Count() == 4)
                        {
                            Firstname = words[0];
                            Lastname = words[1] + " " + words[2] + " " + words[3];
                        }
                        //MessageBox.Show("Player - Firstname = " + Firstname + " Lastname " + Lastname);

                        Player playerobj = new Player();

                        playerobj.Firstname = Firstname;
                        playerobj.Lastname = Lastname;

                        playerobj.Insert(playerobj);
                    }
                }
            }
        }
        private void InsertNewPlayersToDB()
        {
            string TeamStr = string.Empty;

            foreach (string player in Players)
            {
                if (player != null)
                {
                    string[] words = player.Split(' ');

                    string Lastname = string.Empty;
                    string Firstname = string.Empty;

                    if (words.Count() != 0)
                    {
                        if (words.Count() == 1)
                        {
                            Lastname = words[0];
                        }
                        if (words.Count() == 2)
                        {
                            Firstname = words[0];
                            Lastname = words[1];
                        }
                        if (words.Count() == 3)
                        {
                            Firstname = words[0];
                            Lastname = words[1] + " " + words[2];
                        }
                        if (words.Count() == 4)
                        {
                            Firstname = words[0];
                            Lastname = words[1] + " " + words[2] + " " + words[3];
                        }
                        //MessageBox.Show("Player - Firstname = " + Firstname + " Lastname " + Lastname);

                        Player playerobj = new Player();

                        playerobj.Firstname = Firstname;
                        playerobj.Lastname = Lastname;
                        
                        if (playerobj.Find(playerobj, out PlayerID, out TeamStr) != 0) {
                            playerobj.Insert(playerobj);
                        }

                    
                    }
                }
            }
        }
        
        private void CloseInputFile()
        {

        }

        private void ClearPlayerTable()
        {
            Player plyer = new Player();
            plyer.DeleteAllRecords();
        }

        private void cmdUpdateStats_Click(object sender, EventArgs e)
        {
            UpdateStats();
        }

        private void getLatestStatsFromYahooToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ValidateInputFileExists() == true) {
                OpenInputFile();
                UpdateStats();
                CloseInputFile();
            }
        }

        private void initializePlayersTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ValidateInputFileExists() == true)
            {
                OpenInputFile();
                ClearPlayerTable();
                InsertPlayersToDB();
                CloseInputFile();
            }
        }

        private void updateStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cmdImportExcel_Click(object sender, EventArgs e)
        {
            if (ValidateInputFileExists() == true)
            {
                OpenInputFile();
                InsertNewPlayersToDB();
                
                CloseInputFile();
            }
       }
    }
}
