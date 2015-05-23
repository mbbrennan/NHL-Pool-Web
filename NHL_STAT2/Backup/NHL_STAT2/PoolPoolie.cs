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
    public class PoolPoolie
    {
        int _id;
        int _poolid;
        int _poolieid;
        string _poolieFN;
        string _poolieLN;
        string _poolieName;
        SqlTransaction sqltran;

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

        public int PoolieID
        {
            get { return _poolieid; }
            set { _poolieid = value; }
        }

        public string PoolieFN
        {
            get { return _poolieFN; }
            set { _poolieFN = value; }
        }

        public string PoolieLN
        {
            get { return _poolieLN; }
            set { _poolieLN = value; }
        }

        public string PoolieName
        {
            get { return _poolieName; }
            set { _poolieName = value; }
        }

        public List<PoolPoolie> GetPoolPoolies(int ID)
        {
            List<PoolPoolie> listpps = new List<PoolPoolie>();
            SqlDataReader reader = null;

            string connectionString = ConfigurationManager.ConnectionStrings["NHLPool"].ConnectionString;

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);

                conn.Open();
                string sql = "select poolpoolie.poolieid,  " +
                "Poolie.Firstname, Poolie.Lastname  " +
                "from poolpoolie, poolie " +
                "where poolpoolie.poolid = @poolid " +
                "and poolpoolie.poolieid = poolie.ID " +
                "order by poolpoolie.poolieid";
                SqlCommand cmd = new SqlCommand(sql, conn);

           //     List<DbParameter> pars = new List<DbParameter>();

                SqlParameter id = new SqlParameter("@poolid", System.Data.SqlDbType.Int);
                id.Value = ID;
                cmd.Parameters.Add(id);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //this is the call to the factory property that returns a new instance of the Supplier object but as type ISupplier
                    PoolPoolie pp = new PoolPoolie();
                    pp.PoolieID = (reader.IsDBNull(0) ? 0 : reader.GetInt32(0));
                    pp.PoolieFN = (reader.IsDBNull(1) ? "" : reader.GetString(1));
                    pp.PoolieLN = (reader.IsDBNull(2) ? "" : reader.GetString(2));
                    pp.PoolieName = pp.PoolieFN.Trim() + " " + pp.PoolieLN.Trim();  
                   
                    listpps.Add(pp);
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
            return listpps;
        }

        public void CopyPooliesToPool(string NewPoolName, int NewPoolSeasonID, string ExistingPoolName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["NHLPool"].ConnectionString;

            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(connectionString);

                conn.Open();

//                sqltran = conn.BeginTransaction();
                SqlCommand cmd;
                
                Pool p = new Pool();

                p.Name = NewPoolName;
                p.SeasonID = NewPoolSeasonID;
                p.DateCreated = DateTime.Now;
                p.Insert(p);



                string sql;

                sql = "SELECT ID FROM POOL_ WHERE NAME = @NAME";

                SqlParameter existingpname = new SqlParameter("@NAME", System.Data.SqlDbType.VarChar);
                existingpname.Value = ExistingPoolName;

                cmd = new SqlCommand(sql, conn);
               
                cmd.Parameters.Add(existingpname);

                int? existingpoolid = (int?)cmd.ExecuteScalar();
                if (existingpoolid.HasValue == false)
                {
                    return;
                }

                sql = "SELECT ID FROM POOL_ WHERE NAME = @NAME";

                SqlParameter newpoolname = new SqlParameter("@NAME", System.Data.SqlDbType.VarChar);
                newpoolname.Value = NewPoolName;

                cmd = new SqlCommand(sql, conn);

                cmd.Parameters.Add(newpoolname);

                int? newpoolid = (int?)cmd.ExecuteScalar();
                if (newpoolid.HasValue == false)
                {
                    return;
                }

                sql = "insert into poolpoolie(PoolID, PoolieID) " +
                "select " + newpoolid + ", PoolieID From PoolPoolie where PoolID = @ExistingPoolID";
                cmd = new SqlCommand(sql, conn);

                SqlParameter ExistingPoolID = new SqlParameter("@existingpoolid", System.Data.SqlDbType.Int);
                ExistingPoolID.Value = existingpoolid;
                cmd.Parameters.Add(ExistingPoolID);

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

        /*
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
                string sql = "SELECT PLAYER.ID as 'Playerid', LASTNAME, FIRSTNAME, GOALS, ASSISTS, GOALS+ASSISTS as 'Points', poolieplayer.playerid as 'Available' from player " +
                        "left outer join poolieplayer on poolieplayer.playerid = player.id " +
                        "where LASTNAME like '%'+@LASTNAME+'%' AND FIRSTNAME like '%'+@FIRSTNAME+'%'"; 

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
                    pp.Goals = (reader.IsDBNull(3) ? 0 : reader.GetInt32(3));
                    pp.Assists = (reader.IsDBNull(4) ? 0 : reader.GetInt32(4));
                    pp.Points = (reader.IsDBNull(5) ? 0 : reader.GetInt32(5));
                    pp.Available = (reader.IsDBNull(6) ? "Yes": "No");
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
                string sql = @"INSERT INTO [NHLPOOL].[dbo].[PooliePlayer] ([POOLIEID], [PLAYERID]) VALUES (@PoolieID, @PlayerID)";
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

*/

    }
}
