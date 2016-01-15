using System;

namespace UrlShortener.Core.Interfaces
{
    public interface IRestClient
    {
        string Get(Uri uri);
        string Post(Uri uri);
        string Post<T>(Uri uri, T obj);
        T Deserialize<T>(string json);
    }
}
