namespace VoterFileAnalyzer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullablefields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "VoterID", c => c.Int());
            AlterColumn("dbo.Members", "TotalVotes", c => c.Int());
            AlterColumn("dbo.Members", "FirstElection", c => c.DateTime());
            AlterColumn("dbo.Members", "LastElection", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "LastElection", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Members", "FirstElection", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Members", "TotalVotes", c => c.Int(nullable: false));
            AlterColumn("dbo.Members", "VoterID", c => c.Int(nullable: false));
        }
    }
}
