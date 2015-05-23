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
    public partial class frmAdmin : Form
    {
        const int ARRAYLEN = 1500;
        string[,] Players = new String[ARRAYLEN,5];
        string IOFullFilePath = string.Empty;
        int NumberOfPlayers = 0;
        int SeasonID = 0;
        string PlayerTeam;    

        public frmAdmin()
        {
            InitializeComponent();
        }

        private void cmdPoolies_Click(object sender, EventArgs e)
        {
            frmPoolies frmPoolPlayers = new frmPoolies();

            frmPoolPlayers.Show();
        }

        private void cmdPooliePlayers_Click(object sender, EventArgs e)
        {
            frmPooliePlayers frmPP = new frmPooliePlayers();
            frmPP.Show();
        }

        private void cmdDraft_Click(object sender, EventArgs e)
        {
            frmDraft DraftForm = new frmDraft();
            DraftForm.Show();
        }

        private void cmdInitPlayers_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This will reset the entire player table.  All player will be created from the Excel SS and stats re-set to 0.  Are you sure you want to continue?", "Confirm Table Reset", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (ValidateInputFileExists() == true)
                {
                    OpenInputFile();
                    ClearPlayerTable();
                    UpdateInitPlayerDB();
                    CloseInputFile();
                }
            }
            else {
                MessageBox.Show("Nothing done.");

            }
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
                Microsoft.Office.Interop.Excel.Range rangeteam = worksheet.get_Range("B" + h.ToString(), "B" + h.ToString());
                Microsoft.Office.Interop.Excel.Range rangegoals = worksheet.get_Range("E" + h.ToString(), "E" + h.ToString());
                Microsoft.Office.Interop.Excel.Range rangeassists = worksheet.get_Range("G" + h.ToString(), "G" + h.ToString());

                string myvalues = range.Cells.Value2.ToString();
                string myteams = rangeteam.Cells.Value2.ToString();
                string mygoals = rangegoals.Cells.Value2.ToString();
                string myassists = rangeassists.Cells.Value2.ToString();

                Players[h - 2,0] = myvalues;
                Players[h - 2,1] = myteams;
                Players[h - 2, 2] = mygoals;
                Players[h - 2, 3] = myassists;
                NumberOfPlayers += 1;
            }
        }
        
        private void UpdateStats()
        {

        }

        private void CloseInputFile()
        {

        }

        private void UpdatePlayerStats()
        {
            int PlayerRecsUpdated = 0;
            int PlayerRecsAdded = 0;
            int PlayerID = 0;
            int StatsRecsUpdated = 0;
            int StatsRecsFailedUpdate = 0;
            int StatsRecsInserted = 0;

            for (int x = 0; x <= NumberOfPlayers; x += 1)
            {
                string fullname = Players[x, 0];
                if ((fullname != null) && (fullname != String.Empty))
                {
                    string[] words = fullname.Split(' ');

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

                        Player playerobj = new Player();

                        playerobj.Firstname = Firstname;
                        playerobj.Lastname = Lastname;
                        playerobj.Team = Players[x, 1];

                        if (playerobj.Find(playerobj, out PlayerID, out PlayerTeam) != 0)
                        {
                            if (playerobj.Team.Trim() != PlayerTeam.Trim())
                            {
                                playerobj.Update(playerobj);
                                PlayerRecsUpdated += 1;
                            }

                            Stats statsobj = new Stats();
                            statsobj.SeasonID = SeasonID;
                            statsobj.PlayerID = PlayerID;
                            statsobj.Goals = Convert.ToInt32(Players[x, 2]);
                            statsobj.Assists = Convert.ToInt32(Players[x, 3]);

                            if (statsobj.Find(PlayerID, SeasonID) == false)
                            {
                                if (statsobj.Insert(statsobj) == true)
                                {
                                    StatsRecsInserted += 1;
                                }
                            }
                            else {

                                if (statsobj.Update(statsobj) == true)
                                {
                                    StatsRecsUpdated += 1;
                                }
                                else
                                {
                                    StatsRecsFailedUpdate += 1;
                                }
                            }
                        }
                        else
                        {
                            playerobj.Insert(playerobj);
                        }
                    }
                }
            }
            MessageBox.Show(PlayerRecsUpdated.ToString() + " player records updated. \n " + PlayerRecsAdded.ToString() + " player records added.");
        }
    
        private void UpdateInitPlayerDB()
        {
            int PlayerID;
            int StatsRecsUpdated = 0;
            int StatsRecsFailedUpdate = 0;
            int StatsRecsInserted = 0;
            int PlayerRecsUpdated = 0;

            for (int x = 0; x <= Players.Length - 1; x += 1)
            {
                string fullname = Players[x, 0];
                if ((fullname != null) && (fullname != String.Empty))
                {
                    string[] words = fullname.Split(' ');

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

                        Player playerobj = new Player();

                        playerobj.Firstname = Firstname;
                        playerobj.Lastname = Lastname;
                        playerobj.Team = Players[x, 1];
//                        playerobj.Goals = Convert.ToInt32(Players[x, 2]);
  //                      playerobj.Assists = Convert.ToInt32(Players[x, 3]);
                        PlayerID = 0;
                        if (playerobj.Find(playerobj, out PlayerID, out PlayerTeam) != 0)
                        {
                            if (playerobj.Team != PlayerTeam)
                            {
                                playerobj.Update(playerobj);
                                PlayerRecsUpdated += 1;
                            }

                            Stats stats = new Stats();
 
                            stats.PlayerID= PlayerID;
                            stats.SeasonID=SeasonID;
                            stats.Goals = Convert.ToInt32(Players[x, 2]);
                            stats.Assists= Convert.ToInt32(Players[x, 3]);
 
                            if (stats.Find(PlayerID,SeasonID) == true)
                            {   
                                if (stats.Update(stats) == true) 
                                {
                                    StatsRecsUpdated += 1;
                                }    
                                else {
                                    StatsRecsFailedUpdate += 1;
                                }
                            }
                            else {
                                if (stats.Insert(stats) == true) 
                                {
                                    StatsRecsInserted += 1;
                                }
                            }
                        }
                        else {
                            playerobj.Insert(playerobj);
                        }
                    }
                }
            }
        }
        
        private void ClearPlayerTable()
        {
            Player plyer = new Player();
            plyer.DeleteAllRecords();

            PooliePlayer pplayer = new PooliePlayer();
            pplayer.DeleteAllRecords();
        }

        private void cmdUpdateStats_Click(object sender, EventArgs e)
        {
            frmUpdateStats statsform = new frmUpdateStats();
            statsform.ShowDialog();
            if (statsform.SeasonName == String.Empty)
            {
                return;
            }
            SeasonID = statsform.SeasonID;

            DialogResult result = MessageBox.Show("This action will update the stats with the latest data from the Excel spreadsheet.  Proceed?", "Confirm Stats Update", MessageBoxButtons.YesNo);
            
            if (result == DialogResult.Yes)
            {
                if (ValidateInputFileExists() == true)
                {
                    OpenInputFile();
                    UpdatePlayerStats();
                    CloseInputFile();
                }
            }
        }

        private void cmdPlayers_Click(object sender, EventArgs e)
        {
            frmPlayers xfrmplayers = new frmPlayers();
            xfrmplayers.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmPoolPoolies frmPP = new frmPoolPoolies();

            frmPP.Show();
        }
    }
}
