namespace TheApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnsToMovieTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false, defaultValueSql: "getdate()"));
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false, defaultValueSql: "getdate()"));
            AddColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false, defaultValue: 5));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberInStock");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "ReleaseDate");
        }
    }
}
