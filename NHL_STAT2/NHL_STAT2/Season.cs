using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using System.Data.Common;

public class Season
{
    int _seasonid;
    string _name;
    int _typeid;
    string _typedesc;
    DateTime _datecreated;

    public int SeasonID
    {
        get { return _seasonid; }
        set { _seasonid = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public int TypeID
    {
        get { return _typeid; }
        set { _typeid = value; }
    }

    public string TypeDesc
    {
        get { return _typedesc; }
        set { _typedesc = value; }
    }

    public DateTime DateCreated
    {
        get { return _datecreated; }
        set { _datecreated = value; }
    }

    public void Insert(Season season)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["NHLPool"].ConnectionString;

        SqlConnection conn = null;
        try
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            string sql = @"INSERT INTO [NHLPOOL].[dbo].[SEASON] ([NAME], [TYPEID], [DATECREATED]) VALUES (@name, @typeid, @DateCreated)";
            SqlCommand cmd = new SqlCommand(sql, conn);

            List<DbParameter> pars = new List<DbParameter>();

            SqlParameter name = new SqlParameter("@name", System.Data.SqlDbType.VarChar, 50);
            name.Value = season.Name;
            cmd.Parameters.Add(name);

            SqlParameter typeid = new SqlParameter("@typeid", System.Data.SqlDbType.Int);
            typeid.Value = season.TypeID;
            cmd.Parameters.Add(typeid);

            SqlParameter dtcreated = new SqlParameter("@datecreated", System.Data.SqlDbType.DateTime);
            dtcreated.Value = season.DateCreated;
            cmd.Parameters.Add(dtcreated);

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

    public void Update(Season season)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["NHLPool"].ConnectionString;

        SqlConnection conn = null;
        try
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            string sql = @"UPDATE [NHLPOOL].[dbo].[SEASON] SET [NAME] = @NAME, TYPEID = @TYPEID WHERE SEASONID = @ID";
            SqlCommand cmd = new SqlCommand(sql, conn);

            List<DbParameter> pars = new List<DbParameter>();

            SqlParameter id = new SqlParameter("@ID", System.Data.SqlDbType.Int);
            id.Value = season.SeasonID;
            cmd.Parameters.Add(id);

            SqlParameter typeid = new SqlParameter("@TypeID", System.Data.SqlDbType.Int);
            typeid.Value = season.TypeID;
            cmd.Parameters.Add(typeid);

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

    public List<Season> GetSeasons()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["NHLPool"].ConnectionString;
        List<Season> seasons = new List<Season>();
        SqlDataReader reader = null;

        SqlConnection conn = null;
        try
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            string sql = @"SELECT SEASONID, SEASON.NAME, SEASONTYPE.NAME AS SEASONNAME,  DATECREATED FROM [NHLPOOL].[dbo].[SEASON] SEASON, [NHLPOOL].[dbo].[SEASONTYPE] WHERE SEASON.TYPEID = SEASONTYPE.ID";
            SqlCommand cmd = new SqlCommand(sql, conn);

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Season _season = new Season();
                _season.SeasonID = reader.GetInt32(0);
                _season.Name = reader.GetString(1);
                _season.TypeDesc = reader.GetString(2);
                if (reader[3] != DBNull.Value)
                {
                    _season.DateCreated = reader.GetDateTime(3);
                }
                seasons.Add(_season);
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
        return seasons;
    }

}
