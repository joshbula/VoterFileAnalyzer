using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoterFileAnalyzer
{
    public class Vote
    {
        public int VoterID { get; set; }

        public DateTime ElectionDate { get; set; }

        public string ElectionType { get; set; }

        public string VoteType { get; set; }

        public int MemberID { get; set; }
        public Member Member { get; set; }
    }
}
