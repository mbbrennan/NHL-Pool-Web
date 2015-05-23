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
    public class Stats
    {
        int _seasonid;
        int _playerid;
        int _goals;
        int _assists;
        int _points;

        public int SeasonID
        {
            get { return _seasonid; }
            set { _seasonid = value; }
        }

        public int PlayerID
        {
            get { return _playerid; }
            set { _playerid = value; }
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

        public bool Insert(Stats stats)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["NHLPool"].ConnectionString;

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string sql = @"INSERT INTO [NHLPOOL].[dbo].[Stats] ([SEASONID], [PLAYERID], [GOALS], [ASSISTS]) VALUES (@SeasonID, @PlayerID, @Goals, @Assists)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                List<DbParameter> pars = new List<DbParameter>();

                SqlParameter seasonid = new SqlParameter("@SeasonID", System.Data.SqlDbType.Int);
                seasonid.Value = stats.SeasonID;
                cmd.Parameters.Add(seasonid);

                SqlParameter playerid = new SqlParameter("@PlayerID", System.Data.SqlDbType.Int);
                playerid.Value = stats.PlayerID;
                cmd.Parameters.Add(playerid);

                SqlParameter goals = new SqlParameter("@Goals", System.Data.SqlDbType.Int);
                goals.Value = stats.Goals;
                cmd.Parameters.Add(goals);

                SqlParameter assists = new SqlParameter("@Assists", System.Data.SqlDbType.Int);
                assists.Value = stats.Assists;
                cmd.Parameters.Add(assists);

                cmd.ExecuteNonQuery();
            }
            catch 
            {
                throw;
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }
        /*
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
        */

        public bool Find(int ParamPlayerID, int ParamSeasonID)
        {
            bool isRecFound = false;
            string connectionString = ConfigurationManager.ConnectionStrings["NHLPool"].ConnectionString;

            SqlConnection conn = null;
                
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string sql = @"SELECT * FROM [NHLPOOL].[dbo].[STATS] WHERE [PLAYERID] = @PLAYERID and [SEASONID] = @SEASONID";
                SqlCommand cmd = new SqlCommand(sql, conn);

                List<DbParameter> pars = new List<DbParameter>();

                SqlParameter seasonid = new SqlParameter("@SeasonID", System.Data.SqlDbType.Int);
                seasonid.Value = ParamSeasonID;
                cmd.Parameters.Add(seasonid);

                SqlParameter playerid = new SqlParameter("@PlayerID", System.Data.SqlDbType.Int);
                playerid.Value = ParamPlayerID;
                cmd.Parameters.Add(playerid);

                SqlDataReader reader = cmd.ExecuteReader();

                isRecFound = false;

                while (reader.Read())
                {
                    isRecFound = true;
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
            return isRecFound;
        }
        
        public bool Update(Stats stats)
        {
            bool UpdateOK = false;

            string connectionString = ConfigurationManager.ConnectionStrings["NHLPool"].ConnectionString;

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string sql = @"UPDATE [NHLPOOL].[dbo].[STATS] SET GOALS = @GOALS, ASSISTS = @ASSISTS WHERE [PLAYERID] = @PLAYERID AND [SEASONID] = @SEASONID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                
                List<DbParameter> pars = new List<DbParameter>();

                SqlParameter seasonid = new SqlParameter("@SeasonID", System.Data.SqlDbType.Int);
                seasonid.Value = stats.SeasonID;
                cmd.Parameters.Add(seasonid);

                SqlParameter playerid = new SqlParameter("@PlayerID", System.Data.SqlDbType.Int);
                playerid.Value = stats.PlayerID;
                cmd.Parameters.Add(playerid);

                SqlParameter goals = new SqlParameter("@Goals", System.Data.SqlDbType.Int);
                goals.Value = stats.Goals;
                cmd.Parameters.Add(goals);

                SqlParameter assists = new SqlParameter("@Assists", System.Data.SqlDbType.Int);
                assists.Value = stats.Assists;
                cmd.Parameters.Add(assists);
   
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
                UpdateOK = true;
            }
            return UpdateOK;
        }
    }
}
