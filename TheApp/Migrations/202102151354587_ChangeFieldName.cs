namespace TheApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFieldName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "SignUpFee", c => c.Int(nullable: false));
            DropColumn("dbo.MembershipTypes", "SignUpFree");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "SignUpFree", c => c.Int(nullable: false));
            DropColumn("dbo.MembershipTypes", "SignUpFee");
        }
    }
}
