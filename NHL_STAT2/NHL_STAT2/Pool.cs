using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using System.Data.Common;

    public class Pool
    {
        int _id;
        string _name;
        int _seasonid;
        string _seasonname;
        DateTime _datecreated;
        bool _istruedraft;
        DateTime _datecloed;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int SeasonID
        {
            get { return _seasonid; }
            set { _seasonid = value; }
        }

        public string SeasonName
        {
            get { return _seasonname; }
            set { _seasonname = value; }
        }

        public DateTime DateCreated
        {
            get { return _datecreated; }
            set { _datecreated = value; }
        }

        public bool IsTrueDraft
        {
            get { return _istruedraft; }
            set { _istruedraft = value; }
        }

        public DateTime DateClosed
        {
            get { return _datecloed; }
            set { _datecloed = value; }
        }

        public void Insert(Pool pool)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["NHLPool"].ConnectionString;

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string sql = @"INSERT INTO [NHLPOOL].[dbo].[Pool_] ([NAME], [SEASONID], [DATECREATED], [ISTRUEDRAFT]) VALUES (@name, @SeasonID, @datecreated, @isTrueDraft)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                List<DbParameter> pars = new List<DbParameter>();

                SqlParameter lname = new SqlParameter("@name", System.Data.SqlDbType.VarChar, 50);
                lname.Value = pool.Name;
                cmd.Parameters.Add(lname);

                SqlParameter seasonid = new SqlParameter("@seasonid", System.Data.SqlDbType.Int);
                seasonid.Value = pool.SeasonID;
                cmd.Parameters.Add(seasonid);

                SqlParameter dtcreated = new SqlParameter("@datecreated", System.Data.SqlDbType.DateTime);
                dtcreated.Value = pool.DateCreated;
                cmd.Parameters.Add(dtcreated);

                SqlParameter istruedraft = new SqlParameter("@isTrueDraft", System.Data.SqlDbType.Bit);
                istruedraft.Value = pool.IsTrueDraft;
                cmd.Parameters.Add(istruedraft);

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

        public void Update(Pool pool)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["NHLPool"].ConnectionString;

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string sql = @"UPDATE [NHLPOOL].[dbo].[Pool_] SET [NAME] = @NAME, SEASONID=@SEASONID WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(sql, conn);

                List<DbParameter> pars = new List<DbParameter>();

                SqlParameter id = new SqlParameter("@ID", System.Data.SqlDbType.Int);
                id.Value = pool.ID;
                cmd.Parameters.Add(id);

                SqlParameter seasonid = new SqlParameter("@SEASONID", System.Data.SqlDbType.Int);
                seasonid.Value = pool.SeasonID;
                cmd.Parameters.Add(seasonid);

                SqlParameter lname = new SqlParameter("@name", System.Data.SqlDbType.VarChar, 50);
                lname.Value = pool.Name;
                cmd.Parameters.Add(lname);

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

        public List<Pool> GetPools()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["NHLPool"].ConnectionString;
            List<Pool> pools = new List<Pool>();
            SqlDataReader reader = null;

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string sql = @"SELECT P.ID, P.NAME, P.SEASONID, S.NAME, P.DATECREATED, P.ISTRUEDRAFT, P.DATECLOSED FROM [NHLPOOL].[dbo].[Pool_] P, SEASON S WHERE p.SEASONID = S.SeasonID";
                SqlCommand cmd = new SqlCommand(sql, conn);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Pool xpool = new Pool();
                    xpool.ID = reader.GetInt32(0);
                    xpool.Name = reader.GetString(1);
                    if (reader[2] == DBNull.Value)
                    {
                        xpool.SeasonID = 0;
                    }
                    else {
                        xpool.SeasonID = reader.GetInt32(2);                    
                    }

                    xpool.SeasonName = reader.GetString(3);
                    
                    if (reader[4] != DBNull.Value)
                    {
                        xpool.DateCreated = reader.GetDateTime(4);
                    }

                    if (reader[5] == DBNull.Value)
                    {
                        xpool.IsTrueDraft = true;
                    }
                    else {
                        xpool.IsTrueDraft = reader.GetBoolean(5);
                    }

                    if (reader[6] != DBNull.Value)
                    {
                        xpool.DateClosed = reader.GetDateTime(6);
                    }
                    pools.Add(xpool);
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
            return pools;
        }

        public List<Pool> GetPoolName()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["NHLPool"].ConnectionString;
            List<Pool> pools = new List<Pool>();
            SqlDataReader reader = null;

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string sql = @"SELECT ID, NAME FROM [NHLPOOL].[dbo].[Pool_]";
                SqlCommand cmd = new SqlCommand(sql, conn);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //this is the call to the factory property that returns a new instance of the Supplier object but as type ISupplier
                    Pool xpool = new Pool();
                    xpool.ID = reader.GetInt32(0);
                    xpool.Name = reader.GetString(1);
                    pools.Add(xpool);
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
            return pools;
        }

        public string GetPoolSeasonID(int PoolID)
        {
            string _SeasonName = string.Empty;
            string connectionString = ConfigurationManager.ConnectionStrings["NHLPool"].ConnectionString;
            List<Pool> pools = new List<Pool>();
            SqlDataReader reader = null;

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string sql = @"SELECT NAME  FROM [NHLPOOL].[dbo].[Pool_] WHERE ID = @POOLID";
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlParameter id = new SqlParameter("@POOLID", System.Data.SqlDbType.Int);
                id.Value = PoolID;
                cmd.Parameters.Add(id);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //this is the call to the factory property that returns a new instance of the Supplier object but as type ISupplier
                    _SeasonName = reader.GetString(0);
                    break;
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
            return _SeasonName;
        }
    }
