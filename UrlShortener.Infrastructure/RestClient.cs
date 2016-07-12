using System;
using System.Net;
using Newtonsoft.Json;
using RestSharp;

namespace UrlShortener.Infrastructure
{
    public class RestClient : Core.Interfaces.IRestClient
    {
        public string Get(Uri uri)
        {
            var client = new RestSharp.RestClient(uri);
            var request = new RestRequest();
            var response = client.Execute(request);

            return response.StatusCode == HttpStatusCode.OK ? response.Content : "";
        }

        public string Post(Uri uri)
        {
            var client = new RestSharp.RestClient(uri);
            var request = new RestRequest { RequestFormat = DataFormat.Json };
            request.Method = Method.POST;

            var response = client.Execute(request);

            if (response == null) return "";

            foreach (var item in response.Headers)
            {
                if (item.Name == "Location")
                {
                    var url = item.Value.ToString();
                    var pos = url.LastIndexOf("/", StringComparison.Ordinal) + 1;
                    return url.Substring(pos, url.Length - pos);
                }
            }
            return "";
        }

        public string Post<T>(Uri uri, T obj)
        {
            var client = new RestSharp.RestClient();
            var request = new RestRequest {RequestFormat = DataFormat.Json};
            request.AddBody(obj);
            request.Method = Method.POST;

            var response = client.Execute(request);

            if (response == null) return "";

            foreach (var item in response.Headers)
            {
                if (item.Name == "Location")
                {
                    var url = item.Value.ToString();
                    var pos = url.LastIndexOf("/", StringComparison.Ordinal) + 1;
                    return url.Substring(pos, url.Length - pos);
                }
            }
            return "";
        }

        public T Deserialize<T>(string json)
        {
            T obj;
            try
            {
                obj = JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception)
            {
                return default(T);
            }

            return obj;
        }
    }
}
