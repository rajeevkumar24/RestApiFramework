using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiDemo
{
    public class Users<T>
    {
        
        public UserDTOResponse GetUsers(string baseUrl,string endpoint)
         {

              //var restClient = new RestClient(url);
              //var restRequest = new RestRequest("/api/users?page=2", Method.GET);
              //restRequest.AddHeader("Accept","application/json");
              //restRequest.RequestFormat = DataFormat.Json;

              //var restResponse = restClient.Execute(restRequest);
              //var resContent = restResponse.Content;

              //var users = JsonConvert.DeserializeObject<ListOfObjectsDTO>(resContent);

              //return users;
             var helper = new APIHelper();
            var url = helper.SetUrl(baseUrl,endpoint);
            var request = helper.CreateGETRequest();
            var response = helper.GetRestResponse(url, request);
            UserDTOResponse content = helper.GetContent<UserDTOResponse>(response);
            return content;
        }

        public dynamic CreateUsers(string baseUrl,string endpoint, dynamic payload)
        {
            var user = new APIHelper();
            var url = user.SetUrl(baseUrl,endpoint);
            var JsonRequest = user.Serialize(payload);
            var request = user.CreatePostRequest(JsonRequest);
            var response = user.GetRestResponse(url, request);
            var content = user.GetContent<T>(response);
            return content;
        }

        public CreateUserDTORequest PostUsers(string baseUrl)
        {
            var restClient = new RestClient(baseUrl);
            var restRequest = new RestRequest("/api/users", Method.POST);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;
            var restResponse = restClient.Execute(restRequest);
            var resContent = restResponse.Content;

            var users = JsonConvert.DeserializeObject<CreateUserDTORequest>(resContent);

            return users;
        }
    }
}
