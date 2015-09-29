using System.Data.Entity.Migrations;

namespace UrlShortener.Infrastructure.Data.Migrations
{
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UrlRecords",
                c => new
                    {
                        UrlRecordId = c.Int(nullable: false, identity: true),
                        ProviderReference = c.String(),
                        LongUrl = c.String(),
                        ShortUrl = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UrlRecordId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UrlRecords");
        }
    }
}
