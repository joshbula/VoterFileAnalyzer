using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoterFileAnalyzer
{
    class DataFunctions
    {
        public static DataTable GetMembers()
        {
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add("Members");

            using (var db = new VoterFileContext())
            {
               
                string[] columns = typeof(Member).GetProperties().Select(p => p.Name).ToArray();
                foreach (var column in columns)
                {
                    dt.Columns.Add(column);
                }

                var Members = db.Members.OrderBy(p => p.LastName);
                foreach (var m in Members)
                {
                    DataRow r = dt.NewRow();
                    r["FMEAID"] = m.FMEAID;
                    r["FirstName"] = m.FirstName;
                    r["LastName"] = m.LastName;
                    r["HomeCounty"] = m.HomeCounty;
                    r["HomeCity"] = m.HomeCity;
                    r["HomeEmail"] = m.HomeEmail;
                    r["RegisteredTovote"] = m.RegisteredTovote;
                    r["Party"] = m.Party;
                    r["VoterID"] = m.VoterID;
                    r["TotalVotes"] = m.TotalVotes;
                    r["FirstElection"] = m.FirstElection;
                    r["LastElection"] = m.LastElection;

                    dt.Rows.Add(r);

                }
            }
            return dt;
        }
    }
}
