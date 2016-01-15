namespace UrlShortener.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VanityUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UrlRecords", "VanityShortUrl", c => c.String(maxLength: 50));
            AlterColumn("dbo.UrlRecords", "ProviderReference", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UrlRecords", "ProviderReference", c => c.String());
            DropColumn("dbo.UrlRecords", "VanityShortUrl");
        }
    }
}
