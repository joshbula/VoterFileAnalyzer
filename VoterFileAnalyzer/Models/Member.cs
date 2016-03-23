using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoterFileAnalyzer
{
    public class Member
    {
        public int MemberID { get; set; } //FMEAID
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HomeCounty { get; set; }
        public string HomeCity { get; set; }
        public string HomeEmail { get; set; }
        public bool RegisteredTovote { get; set; }
        public string Party { get; set; }
        public int VoterID { get; set; }
        public int TotalVotes { get; set; }
        public DateTime FirstElection { get; set; }
        public DateTime LastElection { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
