using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiDemo
{
    public class APIHelper
    {
             


        public RestClient SetUrl(string baseUrl,string endpoint)
        {
            var url = Path.Combine(baseUrl, endpoint);
            var restClient = new RestClient(url);
            return restClient;

        }
        public RestRequest CreateGETRequest()
        {
            var restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;


        }
        public RestRequest CreatePostRequest(string payload)
        {
            var restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", payload, ParameterType.RequestBody);
            return restRequest;
        }

        public RestRequest DeleteRequest()
        {
            var restRequest = new RestRequest(Method.DELETE);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }

        public IRestResponse GetRestResponse(RestClient restClient, RestRequest restRequest)
        {
            var restResponse = restClient.Execute(restRequest);

            return restResponse;

        }
        //Get Content methods
        public DTO GetContent<DTO>(IRestResponse restResponse)
        {
            var Content = restResponse.Content;
            DTO dtoObject = JsonConvert.DeserializeObject<DTO>(Content);
            return dtoObject;
        }

        public string Serialize(dynamic content)
        {
            string serializeObject = JsonConvert.SerializeObject(content, Formatting.Indented);
             return serializeObject;

        }

        public T parseJson<T>(string file)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(file));
        }
    }
}
