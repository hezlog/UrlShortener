// <auto-generated />

using System.CodeDom.Compiler;
using System.Data.Entity.Migrations.Infrastructure;
using System.Resources;

namespace UrlShortener.Infrastructure.Data.Migrations
{
    [GeneratedCode("EntityFramework.Migrations", "6.1.3-40302")]
    public sealed partial class MaxLengthShortUrl : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(MaxLengthShortUrl));
        
        string IMigrationMetadata.Id
        {
            get { return "201509291352500_MaxLengthShortUrl"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
