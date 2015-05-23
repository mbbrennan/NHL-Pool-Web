using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data.Common;
using System.Configuration;

namespace NHL_Stat2
{
    public class PooliePlayer
    {
        int _id;
        int _poolid;
        int _playerid;
        int _poolieid;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public int PoolID
        {
            get { return _poolid; }
            set { _poolid = value; }
        }

        public int PlayerID
        {
            get { return _playerid; }
            set { _playerid = value; }
        }
        public int PoolieID
        {
            get { return _poolieid; }
            set { _poolieid = value; }
        }

        public List<Player> GetPooliePlayers(int ID, int PoolID)
        {
            List<Player> players = new List<Player>();
            SqlDataReader reader = null;

            string connectionString = ConfigurationManager.ConnectionStrings["NHLPool"].ConnectionString;

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);

                conn.Open();
                string sql = "select player.id, player.firstname, player.lastname, PLAYER.TEAM, stats.goals, stats.assists, stats.goals+stats.assists as 'Points' " +
                    "from Player, poolieplayer, stats " +
                    "where poolieplayer.playerid = Player.ID and poolieplayer.Poolieid = @ID" +
                    " and poolieplayer.Poolid = @POOLID " +
                    " and stats.playerid = player.id " +
                    " order by stats.goals+stats.assists desc";   

                SqlCommand cmd = new SqlCommand(sql, conn);

                List<DbParameter> pars = new List<DbParameter>();

                SqlParameter poolieid = new SqlParameter("@ID", System.Data.SqlDbType.Int);
                poolieid.Value = ID;
                cmd.Parameters.Add(poolieid);

                SqlParameter poolid = new SqlParameter("@POOLID", System.Data.SqlDbType.Int);
                poolid.Value = PoolID;
                cmd.Parameters.Add(poolid);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //this is the call to the factory property that returns a new instance of the Supplier object but as type ISupplier
                    Player pyer = new Player();
                    pyer.ID = (reader.IsDBNull(0) ? 0 : reader.GetInt32(0));
                    pyer.Firstname = (reader.IsDBNull(1) ? "" : reader.GetString(1));
                    pyer.Lastname = (reader.IsDBNull(2) ? "" : reader.GetString(2));
                    pyer.Team = (reader.IsDBNull(3) ? "" : reader.GetString(3));
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

        public List<Player> SearchPlayers(int ID, string lname, string fname)
        {
            List<Player> players = new List<Player>();
            SqlDataReader reader = null;

            string connectionString = ConfigurationManager.ConnectionStrings["NHLPool"].ConnectionString;

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);

                conn.Open();
                string sql = "SELECT PLAYER.ID as 'Playerid', LASTNAME, FIRSTNAME, TEAM, " +
                    "stats.GOALS, stats.ASSISTS, stats.GOALS+stats.ASSISTS as 'Points', " +
                "poolieplayer.playerid as 'Available' from stats, player " +
                        "left outer join poolieplayer on poolieplayer.playerid = player.id " +
                        "where LASTNAME like '%'+@LASTNAME+'%' AND FIRSTNAME like '%'+@FIRSTNAME+'%' " +
                        " and stats.playerid = player.id"; 
                SqlCommand cmd = new SqlCommand(sql, conn);

                List<DbParameter> pars = new List<DbParameter>();

                SqlParameter id = new SqlParameter("@ID", System.Data.SqlDbType.Int);
                id.Value = ID;
                cmd.Parameters.Add(id);

                SqlParameter lastname = new SqlParameter("@LASTNAME", System.Data.SqlDbType.NVarChar);
                lastname.Value = lname;
                cmd.Parameters.Add(lastname);

                SqlParameter firstname = new SqlParameter("@FIRSTNAME", System.Data.SqlDbType.NVarChar);
                firstname.Value = fname;
                cmd.Parameters.Add(firstname);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //this is the call to the factory property that returns a new instance of the Supplier object but as type ISupplier
                    Player pp = new Player();
                    pp.ID = (reader.IsDBNull(0) ? 0 : reader.GetInt32(0));
                    pp.Firstname = (reader.IsDBNull(1) ? "" : reader.GetString(1));
                    pp.Lastname = (reader.IsDBNull(2) ? "" : reader.GetString(2));
                    pp.Team = (reader.IsDBNull(3) ? "" : reader.GetString(3));
                    pp.Goals = (reader.IsDBNull(4) ? 0 : reader.GetInt32(4));
                    pp.Assists = (reader.IsDBNull(5) ? 0 : reader.GetInt32(5));
                    pp.Points = (reader.IsDBNull(6) ? 0 : reader.GetInt32(6));
                    pp.Available = (reader.IsDBNull(7) ? "Yes": "No");
                    players.Add(pp);
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

        public void Insert(PooliePlayer pplayer)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["NHLPool"].ConnectionString;

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string sql = @"INSERT INTO [NHLPOOL].[dbo].[PooliePlayer] ([POOLID], [POOLIEID], [PLAYERID]) VALUES (@PoolID, @PoolieID, @PlayerID)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                List<DbParameter> pars = new List<DbParameter>();

                SqlParameter poolid = new SqlParameter("@PoolID", System.Data.SqlDbType.Int);
                poolid.Value = pplayer.PoolID;
                cmd.Parameters.Add(poolid);

                SqlParameter poolieid = new SqlParameter("@PoolieID", System.Data.SqlDbType.Int);
                poolieid.Value = pplayer.PoolieID;
                cmd.Parameters.Add(poolieid);

                SqlParameter playerid = new SqlParameter("@PlayerID", System.Data.SqlDbType.Int);
                playerid.Value = pplayer.PlayerID;
                cmd.Parameters.Add(playerid);

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
                string sql = @"DELETE FROM [NHLPOOL].[dbo].[PooliePlayer]";
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

        public void Delete(PooliePlayer pplayer)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["NHLPool"].ConnectionString;

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string sql = @"DELETE [NHLPOOL].[dbo].[PooliePlayer] WHERE POOLIEID = @PoolieID AND PLAYERID = @PlayerID";
                SqlCommand cmd = new SqlCommand(sql, conn);

                List<DbParameter> pars = new List<DbParameter>();

                SqlParameter poolieid = new SqlParameter("@PoolieID", System.Data.SqlDbType.Int);
                poolieid.Value = pplayer.PoolieID;
                cmd.Parameters.Add(poolieid);

                SqlParameter playerid = new SqlParameter("@PlayerID", System.Data.SqlDbType.Int);
                playerid.Value = pplayer.PlayerID;
                cmd.Parameters.Add(playerid);

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



    }
}
