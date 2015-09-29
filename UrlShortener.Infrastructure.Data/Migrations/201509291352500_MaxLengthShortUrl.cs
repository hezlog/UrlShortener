using System.Data.Entity.Migrations;

namespace UrlShortener.Infrastructure.Data.Migrations
{
    public partial class MaxLengthShortUrl : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UrlRecords", "ShortUrl", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UrlRecords", "ShortUrl", c => c.String());
        }
    }
}
