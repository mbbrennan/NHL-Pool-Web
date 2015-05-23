using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using System.Data.Common;

    public class Team
    {
        string _abbrev;

        public string Abbrev
        {
            get { return _abbrev; }
            set { _abbrev = value; }
        }

        public List<Team> GetTeams()
        {
            List<Team> teams = new List<Team>();
            SqlDataReader reader = null;

            string connectionString = ConfigurationManager.ConnectionStrings["NHLPool"].ConnectionString;

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);

                conn.Open();
                string sql = "select abbrev from team";

                SqlCommand cmd = new SqlCommand(sql, conn);

                Team _team = new Team();
                _team.Abbrev = String.Empty;
                teams.Add(_team);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //this is the call to the factory property that returns a new instance of the Supplier object but as type ISupplier
                    Team _teamnull = new Team();
                    _teamnull.Abbrev = (reader.IsDBNull(0) ? "" : reader.GetString(0));
                    teams.Add(_teamnull);
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
            return teams;
        }
    }
