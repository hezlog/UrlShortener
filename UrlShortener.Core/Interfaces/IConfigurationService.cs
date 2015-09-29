namespace UrlShortener.Core.Interfaces
{
    public interface IConfigurationService
    {
        string GetSetting(string key);
    }
}
