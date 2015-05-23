using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using System.Data.Common;

namespace NHL_Stat2
{
    public class Player
    {
        int _counter;
        int _id;
        string _firstname;
        string _lastname;
        string _team;
        string _available;
        string _drafted;
        int _goals;
        int _assists;
        int _points;

        public int Rank
        {
            get { return _counter; }
            set { _counter = value; }
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Firstname 
        { 
            get { return _firstname; }
            set { _firstname = value; }
        }

        public string Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        public string Team
        {
            get { return _team; }
            set { _team = value; }
        }
        
        public string Available
        {
            get { return _available; }
            set { _available = value; }
        }

        public string Drafted
        {
            get { return _drafted; }
            set { _drafted = value; }
        }

        public int Goals
        {
            get { return _goals; }
            set { _goals = value; }
        }

        public int Assists
        {
            get { return _assists; }
            set { _assists = value; }
        }

        public int Points
        {
            get { return _points; }
            set { _points = value; }
        }

        public void Insert(Player player)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["NHLPool"].ConnectionString;

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string sql = @"INSERT INTO [NHLPOOL].[dbo].[Player] ([LASTNAME], [FIRSTNAME], [TEAM], [POSITION], [BIRTHDATE], [RETIRED]) VALUES (@Lastname, @Firstname, @Team, @Position, @Birthdate, @Retired)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                List<DbParameter> pars = new List<DbParameter>();

                SqlParameter lname = new SqlParameter("@Lastname", System.Data.SqlDbType.VarChar, 35);
                lname.Value = player.Lastname;
                cmd.Parameters.Add(lname);

                SqlParameter fname = new SqlParameter("@Firstname", System.Data.SqlDbType.VarChar, 20);
                fname.Value = player.Firstname;
                cmd.Parameters.Add(fname);

                SqlParameter position = new SqlParameter("@Position", System.Data.SqlDbType.Char, 1);
                position.Value = string.Empty;
                cmd.Parameters.Add(position);

                SqlParameter birthdate = new SqlParameter("@Birthdate", System.Data.SqlDbType.DateTime);
                birthdate.Value = DateTime.Now;
                cmd.Parameters.Add(birthdate);

                SqlParameter retired = new SqlParameter("@Retired", System.Data.SqlDbType.Bit);
                retired.Value = false;
                cmd.Parameters.Add(retired);

                SqlParameter team = new SqlParameter("@Team", System.Data.SqlDbType.VarChar, 3);
                team.Value = player.Team;
                cmd.Parameters.Add(team);

                cmd.ExecuteNonQuery();
            }
            catch 
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public void DeleteAllRecords()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["NHLPool"].ConnectionString;

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string sql = @"DELETE FROM [NHLPOOL].[dbo].[Player]";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.ExecuteNonQuery();
            }
            catch 
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public int Find(Player player, out int PlayerID, out string Teamstr)
        {
            int PID = 0;
            string TeamOut = string.Empty;

            string connectionString = ConfigurationManager.ConnectionStrings["NHLPool"].ConnectionString;

            SqlConnection conn = null;
            bool isRecFound = false;
                
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string sql = @"SELECT [ID], [LASTNAME], [FIRSTNAME],[TEAM] FROM [NHLPOOL].[dbo].[Player] WHERE [LASTNAME] = @LASTNAME AND [FIRSTNAME] = @FIRSTNAME";
                SqlCommand cmd = new SqlCommand(sql, conn);

                List<DbParameter> pars = new List<DbParameter>();

                SqlParameter lname = new SqlParameter("@Lastname", System.Data.SqlDbType.VarChar, 35);
                lname.Value = player.Lastname;
                cmd.Parameters.Add(lname);

                SqlParameter fname = new SqlParameter("@Firstname", System.Data.SqlDbType.VarChar, 20);
                fname.Value = player.Firstname;
                cmd.Parameters.Add(fname);

                SqlDataReader reader = cmd.ExecuteReader();

                PlayerID = 0;

                while (reader.Read())
                {
                    isRecFound = true;
                    PID = reader.GetInt32(0);
                    TeamOut = reader.GetString(3);
                    break;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            PlayerID = PID;
            Teamstr = TeamOut;

            return PlayerID;
        }

        public bool Update(Player player)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["NHLPool"].ConnectionString;

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string sql = @"UPDATE [NHLPOOL].[dbo].[Player] SET TEAM = @TEAM WHERE [ID] = @PLAYERID";
                SqlCommand cmd = new SqlCommand(sql, conn);

                List<DbParameter> pars = new List<DbParameter>();

                SqlParameter team = new SqlParameter("@Team", System.Data.SqlDbType.VarChar, 35);
                team.Value = player.Team;
                cmd.Parameters.Add(team);

                SqlParameter PlayerID = new SqlParameter("@PlayerID", System.Data.SqlDbType.Int);
                PlayerID.Value = player.ID;
                cmd.Parameters.Add(PlayerID);

                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }

        public List<Player> SelectAllActive(string Team)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["NHLPool"].ConnectionString;
            int xCounter = 0;
            SqlConnection conn = null;
            List<Player> players = new List<Player>();
            SqlDataReader reader = null;

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string sql = @"SELECT PLAYER.[FIRSTNAME],PLAYER.[LASTNAME], " +
                "PLAYER.[TEAM], CASE WHEN poolieplayer.playerid != 0 THEN 'True' ELSE 'False' END as 'Drafted', " +
                "[GOALS],[ASSISTS], [GOALS]+[ASSISTS] AS 'Points' FROM [NHLPOOL].[dbo].[Player] " +
                " left outer join poolieplayer on poolieplayer.playerid = player.id " +
               " WHERE [RETIRED] = 0 and ([TEAM] = @TEAM OR @TEAM = '') order by Points desc";
                SqlCommand cmd = new SqlCommand(sql, conn);
                
                List<DbParameter> pars = new List<DbParameter>();

                SqlParameter _team = new SqlParameter("@TEAM", System.Data.SqlDbType.VarChar, 10);
                if (Team == null || Team == String.Empty)
                {
                    _team.Value = String.Empty;
                }
                else {
                    _team.Value = Team;
                }
                
                cmd.Parameters.Add(_team);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    xCounter += 1;

                    Player pyer = new Player();
                    pyer.Rank = xCounter;
                    pyer.Firstname = (reader.IsDBNull(0) ? "" : reader.GetString(0));
                    pyer.Lastname = (reader.IsDBNull(1) ? "" : reader.GetString(1));
                    pyer.Team = (reader.IsDBNull(2) ? "" : reader.GetString(2));
                    pyer.Drafted = (reader.IsDBNull(3) ? "false" : reader.GetString(3));
                    pyer.Goals = (reader.IsDBNull(4) ? 0 : reader.GetInt32(4));
                    pyer.Assists = (reader.IsDBNull(5) ? 0 : reader.GetInt32(5));
                    pyer.Points = (reader.IsDBNull(6) ? 0 : reader.GetInt32(6));
                    players.Add(pyer);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (reader != null) reader.Close();
            }
            return players;
        }
    }
}
