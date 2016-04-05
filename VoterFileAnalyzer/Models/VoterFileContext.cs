using System;
using System.Data.Entity;

namespace VoterFileAnalyzer
{
    public class VoterFileContext : DbContext
    {
        public VoterFileContext() :base("VoterFileConnection")
        {
            //Saving database in the project directory rather than the user's app_data folder so each user doesn't have to go through the import process
            //Make sure to set read/write/modify permissions on the .mdf and .ldf files in the installer setup project
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);

            Database.SetInitializer<VoterFileContext>(new CreateDatabaseIfNotExists<VoterFileContext>());
            Database.SetInitializer<VoterFileContext>(new DropCreateDatabaseIfModelChanges<VoterFileContext>());
        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Vote> Votes { get; set; }
    }
}
