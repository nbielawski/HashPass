namespace HashPass.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "PinNum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUser", "PinNum");
        }
    }
}
