namespace FluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBasket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Baskets", "User_Id", c => c.Guid());
            CreateIndex("dbo.Baskets", "User_Id");
            AddForeignKey("dbo.Baskets", "User_Id", "dbo.Users", "Id");
            DropColumn("dbo.Baskets", "UserLogin");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Baskets", "UserLogin", c => c.String());
            DropForeignKey("dbo.Baskets", "User_Id", "dbo.Users");
            DropIndex("dbo.Baskets", new[] { "User_Id" });
            DropColumn("dbo.Baskets", "User_Id");
        }
    }
}
