namespace MessageHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedapplicationuser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 400));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String(maxLength: 400));
        }
    }
}
