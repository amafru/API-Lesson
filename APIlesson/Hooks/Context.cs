using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace APIlesson.Hooks
{
    class Context
    {
        string baseUrl = "https://reqres.in";
        public string resultContent;
        public string resultStatusCode;
        public string resultDescription;

        public void GetMethod(string resource)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(resource, Method.GET);
            var result = client.Execute(request);
            //get the result data to be used for assertions
            resultContent = result.Content;
            resultStatusCode = result.StatusCode.ToString();
            resultDescription = result.StatusDescription;
        }

        public void PostMethod(string resource, string body)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(resource, Method.POST);
            request.AddBody(body);
            var result = client.Execute(request);
            //get the result data to be used for assertions
            resultStatusCode = result.ResponseStatus.ToString();
            resultDescription = result.StatusDescription;
        }

        public void PutMethod(string resource, Dictionary<string,string> body)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(resource, Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(body);
            var result = client.Execute(request);
            //get the result data to be used for assertions
            resultStatusCode = result.ResponseStatus.ToString();
            resultDescription = result.StatusDescription;
        }

        public void DeleteMethod(string resource)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(resource, Method.DELETE);
            var result = client.Execute(request);
            //get the result data to be used for assertions            
            resultStatusCode = result.StatusCode.ToString();
            resultDescription = result.StatusDescription;
        }
    }
}
