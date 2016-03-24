using System.Data.Entity;

namespace VoterFileAnalyzer
{
    public class VoterFileContext : DbContext
    {
        public VoterFileContext() :base("VoterFileConnection")
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Vote> Votes { get; set; }
    }
}
