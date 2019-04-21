namespace Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Records",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        EntryTime = c.DateTime(nullable: false),
                        LeavingTime = c.DateTime(nullable: false),
                        ClientName = c.String(),
                        PassportNumber = c.Int(nullable: false),
                        VisitPurpose = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Records");
        }
    }
}
