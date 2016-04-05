using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoterFileAnalyzer
{
    /// <summary>
    /// Data Access Layer that uses datatables instead of Entity Framework for ReportViewer and EPPlus compatibility
    /// </summary>
    class DataFunctions
    {
        public static DataTable GetMembers()
        {
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add("Members");
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VoterFileConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Select * FROM Members", conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
            da.Dispose();
            return dt;
        }

        public static DataTable VotersByCounty()
        {
            string Query = "SELECT HomeCounty, Count(*) AS TotalMembers, SUM(CASE WHEN RegisteredTovote = 1 THEN 1 ELSE 0 END) AS Registered, SUM(CASE WHEN TotalVotes > 0 THEN 1 ELSE 0 END) AS Voted FROM Members GROUP BY HomeCounty";

            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add("Counties");
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VoterFileConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(Query, conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
            da.Dispose();
            return dt;
        }

        public static DataTable MembersByParty()
        {
            string Query = "SELECT Party, Count(*) AS Count FROM Members WHERE NOT (Party IS NULL) GROUP BY Party";

            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add("Parties");
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VoterFileConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(Query, conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
            da.Dispose();
            return dt;
        }

        public static DataTable ElectionDates()
        {
            //For Drop-Down List on MainPage
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add("Elections");
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VoterFileConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Select ElectionDate, CONVERT(nvarchar, ElectionDate, 106) + ' ' + ElectionType AS Description FROM Votes GROUP BY ElectionDate, ElectionType", conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
            da.Dispose();
            return dt;
        }

        public static DataTable VotesByCounty(DateTime ElectionDate)
        {
            string Query = "SELECT Members.HomeCounty, ISNULL(MembersVoted, 0) AS MembersVoted FROM Members LEFT OUTER JOIN ";
            Query += " (SELECT m.HomeCounty, Count(*) AS MembersVoted FROM Votes v INNER JOIN Members m ON v.VoterId = m.VoterId WHERE v.ElectionDate = @ElectionDate GROUP BY m.HomeCounty) VoteQuery ";
            Query += " ON Members.HomeCounty = VoteQuery.HomeCounty";
            Query += " GROUP BY Members.HomeCounty, VoteQuery.MembersVoted";

            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add("Counties");
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VoterFileConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@ElectionDate", ElectionDate);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
            da.Dispose();
            return dt;
        }

    }
}
