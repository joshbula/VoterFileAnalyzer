namespace VoterFileAnalyzer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberID = c.Int(nullable: false, identity: true),
                        FMEAID = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        HomeCounty = c.String(),
                        HomeCity = c.String(),
                        HomeEmail = c.String(),
                        RegisteredTovote = c.Boolean(nullable: false),
                        Party = c.String(),
                        VoterID = c.Int(),
                        TotalVotes = c.Int(),
                        FirstElection = c.DateTime(),
                        LastElection = c.DateTime(),
                    })
                .PrimaryKey(t => t.MemberID);
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VoterID = c.Int(nullable: false),
                        ElectionDate = c.DateTime(nullable: false),
                        ElectionType = c.String(),
                        VoteType = c.String(),
                        MemberID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberID, cascadeDelete: true)
                .Index(t => t.MemberID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votes", "MemberID", "dbo.Members");
            DropIndex("dbo.Votes", new[] { "MemberID" });
            DropTable("dbo.Votes");
            DropTable("dbo.Members");
        }
    }
}
