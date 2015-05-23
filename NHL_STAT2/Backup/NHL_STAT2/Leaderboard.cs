using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using System.Data.Common;
using System.Collections.Generic;

public class Leaderboard
{
    int _poolid;
    int _poolieid;
    string _lastname;
    string _firstname;
    int _totalgoals;
    int _totalassists;
    int _totalpoints;

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

    public string Lastname
    {
        get { return _lastname; }
        set { _lastname = value; }
    }

    public string Firstname
    {
        get { return _firstname; }
        set { _firstname = value; }
    }

    public int Total_Goals
    {
        get { return _totalgoals; }
        set { _totalgoals = value; }
    }

    public int Total_Assists
    {
        get { return _totalassists; }
        set { _totalassists = value; }
    }

    public int Total_Points
    {
        get { return _totalpoints; }
        set { _totalpoints = value; }
    }

    public List<Leaderboard> GetLeaderboard(int PoolID)
    {
        List<Leaderboard> leaderboards = new List<Leaderboard>();
        SqlDataReader reader = null;

        string connectionString = ConfigurationManager.ConnectionStrings["NHLPool"].ConnectionString;

        SqlConnection conn = null;
        try
        {
            conn = new SqlConnection(connectionString);

            conn.Open();
            string sql = "select poolieid, poolie.firstname, poolie.lastname, " +
                        " SUM(stats.goals) as 'Total Goals',SUM(stats.assists) as 'Total Assists', SUM(stats.goals + stats.assists) as 'Total Points' " +
                    "from poolieplayer PP, Stats, POOLIE " +
                "where PP.poolid = @POOLID AND PP.playerid = stats.playerid "+
                "AND POOLIE.ID = PP.poolieid " +
                "group by poolieid, poolie.firstname, poolie.lastname " +
                "order by SUM(stats.goals + stats.assists) desc";

            SqlCommand cmd = new SqlCommand(sql, conn);

            List<DbParameter> pars = new List<DbParameter>();

            SqlParameter id = new SqlParameter("@POOLID", System.Data.SqlDbType.Int);
            id.Value = PoolID;
            cmd.Parameters.Add(id);
            
            reader = cmd.ExecuteReader();
  
            while (reader.Read())
            {
                //this is the call to the factory property that returns a new instance of the Supplier object but as type ISupplier
                Leaderboard lb = new Leaderboard();
//                lb.PoolID = (reader.IsDBNull(0) ? 0 : reader.GetInt32(0));
                lb.PoolieID = (reader.IsDBNull(0) ? 0 : reader.GetInt32(0));
                lb.Lastname = (reader.IsDBNull(1) ? "" : reader.GetString(1));
                lb.Firstname = (reader.IsDBNull(2) ? "" : reader.GetString(2));
                lb.Total_Goals = (reader.IsDBNull(3) ? 0 : reader.GetInt32(3));
                lb.Total_Assists = (reader.IsDBNull(4) ? 0 : reader.GetInt32(4));
                lb.Total_Points = (reader.IsDBNull(5) ? 0 : reader.GetInt32(5));

                leaderboards.Add(lb);
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
        return leaderboards;
    }
}