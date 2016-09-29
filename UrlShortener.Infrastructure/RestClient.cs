using System;
using System.Net;
using Conditions.Guards;
using Newtonsoft.Json;
using RestSharp;
using UrlShortener.Core.Interfaces;

namespace UrlShortener.Infrastructure
{
    public class RestClient : Core.Interfaces.IRestClient
    {
        private readonly IConfigurationService _configurationService;

        public RestClient(IConfigurationService configurationService)
        {
            Check.If(configurationService).IsNotNull();

            _configurationService = configurationService;
        }

        public string Get(Uri uri)
        {
            var client = new RestSharp.RestClient(uri);
            var request = new RestRequest();
            request.AddHeader("apikey", _configurationService.GetSetting("RebrandlyApiKey"));

            var response = client.Execute(request);

            return response.StatusCode == HttpStatusCode.OK ? response.Content : "";
        }

        public string Post(Uri uri)
        {
            var client = new RestSharp.RestClient(uri);

            var request = new RestRequest { RequestFormat = DataFormat.Json };
            request.Method = Method.POST;
            request.AddHeader("apikey", _configurationService.GetSetting("RebrandlyApiKey"));

            var response = client.Execute(request);

            return response.StatusCode == HttpStatusCode.OK ? response.Content : "";
        }

        public string Post<T>(Uri uri, T obj)
        {
            var client = new RestSharp.RestClient
            {
                BaseUrl = uri
            };

            var request = new RestRequest { RequestFormat = DataFormat.Json };
            request.AddBody(obj);
            request.Method = Method.POST;
            request.AddHeader("apikey", _configurationService.GetSetting("RebrandlyApiKey"));

            var response = client.Execute(request);

            return response.StatusCode == HttpStatusCode.OK ? response.Content : "";
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
