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
    public class Poolie
    {
        int _id;
        int _poolid;
        string _firstname;
        string _lastname;
        string _fullname;

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

        public string Fullname
        {
            get { return _fullname; }
            set { _fullname = value; }
        }


        public void Insert(Poolie poolie)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["NHLPool"].ConnectionString;

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string sql = @"INSERT INTO [NHLPOOL].[dbo].[Poolie] ([LASTNAME], [FIRSTNAME]) VALUES (@Lastname, @Firstname)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                List<DbParameter> pars = new List<DbParameter>();

            /*    SqlParameter poolid = new SqlParameter("@ID", System.Data.SqlDbType.Int);
                poolid.Value = poolie.PoolID;
                cmd.Parameters.Add(poolid);
                */
                SqlParameter lname = new SqlParameter("@Lastname", System.Data.SqlDbType.VarChar, 35);
                lname.Value = poolie.Lastname;
                cmd.Parameters.Add(lname);

                SqlParameter fname = new SqlParameter("@Firstname", System.Data.SqlDbType.VarChar, 20);
                fname.Value = poolie.Firstname;
                cmd.Parameters.Add(fname);

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

        public void Update(Poolie poolie)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["NHLPool"].ConnectionString;

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string sql = @"UPDATE [NHLPOOL].[dbo].[Poolie] SET [LASTNAME] = @LASTNAME, [FIRSTNAME] = @FIRSTNAME WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(sql, conn);

                List<DbParameter> pars = new List<DbParameter>();

                SqlParameter id = new SqlParameter("@ID", System.Data.SqlDbType.Int);
                id.Value = poolie.ID;
                cmd.Parameters.Add(id);

                SqlParameter lname = new SqlParameter("@Lastname", System.Data.SqlDbType.VarChar, 35);
                lname.Value = poolie.Lastname;
                cmd.Parameters.Add(lname);

                SqlParameter fname = new SqlParameter("@Firstname", System.Data.SqlDbType.VarChar, 20);
                fname.Value = poolie.Firstname;
                cmd.Parameters.Add(fname);

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

        public List<Poolie> GetPoolies(int PoolID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["NHLPool"].ConnectionString;
            List<Poolie> poolies = new List<Poolie>();
            SqlDataReader reader = null;

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string sql = @"SELECT POOLIE.ID, POOLIE.FIRSTNAME, POOLIE.LASTNAME FROM [NHLPOOL].[dbo].[POOLPoolie] PP,[NHLPOOL].[dbo].[Poolie]  where poolid = @ID AND Poolie.ID =PP.POOLIEID";
                SqlCommand cmd = new SqlCommand(sql, conn);

                List<DbParameter> pars = new List<DbParameter>();

                SqlParameter poolid_ = new SqlParameter("@ID", System.Data.SqlDbType.Int);
                poolid_.Value = PoolID;
                cmd.Parameters.Add(poolid_);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Poolie xpoolie = new Poolie();
                    xpoolie.ID = reader.GetInt32(0);
                    xpoolie.Firstname = reader.GetString(1);
                    xpoolie.Lastname = reader.GetString(2);
                    poolies.Add(xpoolie);
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
            return poolies;
        }

        public List<Poolie> GetPooliesFullname(int poolid)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["NHLPool"].ConnectionString;
            List<Poolie> poolies = new List<Poolie>();
            SqlDataReader reader = null;

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string sql = @"SELECT ID, POOLID, FIRSTNAME, LASTNAME FROM [NHLPOOL].[dbo].[Poolie] WHERE POOLID = @POOLID";
                SqlCommand cmd = new SqlCommand(sql, conn);

                List<DbParameter> pars = new List<DbParameter>();

                SqlParameter poolid_ = new SqlParameter("@POOLID", System.Data.SqlDbType.Int);
                poolid_.Value = poolid;
                cmd.Parameters.Add(poolid_);


                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //this is the call to the factory property that returns a new instance of the Supplier object but as type ISupplier
                    Poolie xpoolie = new Poolie();
                    xpoolie.ID = reader.GetInt32(0);
                    xpoolie.PoolID = reader.GetInt32(1);
                    xpoolie.Firstname = reader.GetString(2);
                    xpoolie.Firstname = xpoolie.Firstname.Trim();
                    xpoolie.Lastname = reader.GetString(3);
                    xpoolie.Lastname = xpoolie.Lastname.Trim();

                    xpoolie.Fullname = xpoolie.Firstname + " " + xpoolie.Lastname;
                    xpoolie.Fullname = xpoolie.Fullname.Trim();
                    poolies.Add(xpoolie);
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
            return poolies;
        }

        public Poolie FindPoolieByID(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["NHLPool"].ConnectionString;
            List<Poolie> poolies = new List<Poolie>();
            SqlDataReader reader = null;
            Poolie xpoolie = new Poolie();

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string sql = @"SELECT ID, POOLID, FIRSTNAME, LASTNAME FROM [NHLPOOL].[dbo].[Poolie] where ID =@ID";
                SqlCommand cmd = new SqlCommand(sql, conn);

                List<DbParameter> pars = new List<DbParameter>();

                SqlParameter pid = new SqlParameter("@ID", System.Data.SqlDbType.Int);
                pid.Value = id;
                cmd.Parameters.Add(pid);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //this is the call to the factory property that returns a new instance of the Supplier object but as type ISupplier
                    xpoolie.ID = reader.GetInt32(0);
                    xpoolie.PoolID = reader.GetInt32(1);
                    xpoolie.Firstname = reader.GetString(2);
                    xpoolie.Firstname = xpoolie.Firstname.Trim();
                    xpoolie.Lastname = reader.GetString(3);
                    xpoolie.Lastname = xpoolie.Lastname.Trim();

                    xpoolie.Fullname = xpoolie.Firstname + " " + xpoolie.Lastname;
                    xpoolie.Fullname = xpoolie.Fullname.Trim();
                    poolies.Add(xpoolie);
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
            return xpoolie;
        }
    }
}