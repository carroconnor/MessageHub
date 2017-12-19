namespace MessageHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsCanceledToMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "IsCanceled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "IsCanceled");
        }
    }
}
