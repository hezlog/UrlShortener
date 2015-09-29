using UrlShortener.Core.Interfaces;
using UrlShortener.Core.Objects;

namespace UrlShortener.Infrastructure.Data
{
    public class UrlRecordRepository : IUrlRecordRepository
    {
        private readonly IUrlRecordContext _urlRecordContext;

        public UrlRecordRepository(IUrlRecordContext urlRecordContext)
        {
            _urlRecordContext = urlRecordContext;
        }

        public bool CreateUrlRecord(UrlRecord record)
        {
            if (string.IsNullOrEmpty(record.ProviderReference))
                return false;

            _urlRecordContext.Records.Add(record);
            return _urlRecordContext.SaveChanges() > 0;
        }
    }
}
