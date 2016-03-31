using System.Data.Entity;

namespace VoterFileAnalyzer
{
    public class VoterFileContext : DbContext
    {
        public VoterFileContext() :base("VoterFileConnection")
        {
            Database.SetInitializer<VoterFileContext>(new CreateDatabaseIfNotExists<VoterFileContext>());
            Database.SetInitializer<VoterFileContext>(new DropCreateDatabaseIfModelChanges<VoterFileContext>());
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Vote> Votes { get; set; }
    }
}
