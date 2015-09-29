using UrlShortener.Core.Objects;

namespace UrlShortener.Core.Interfaces
{
    public interface IUrlRecordRepository
    {
        bool CreateUrlRecord(UrlRecord record);
    }
}
