using System;
using System.Net;
using RestSharp;

namespace APIClients
{
    public class APIEncapsulator
    {
        private string targetURI;
        private string targetURL;
        private IRestClient clientAPI;
        private IRestRequest request;
        private bool requestReady = false;



        public APIEncapsulator(string url, string uri)
        {
            targetURL = url;
            targetURI = uri;
            Uri urlObj = new Uri(targetURL);
            IRestClient client = new RestClient(urlObj);
            clientAPI = client;
        }


        public APIEncapsulator(string url, string uri, string method)
        {
            targetURL = url;
            targetURI = uri;
            Uri urlObj = new Uri(targetURL);
            IRestClient client = new RestClient(urlObj);
            clientAPI = client;
            switch (method.ToLower())
            {
                case "get":
                    CreateGETRequest();
                    break;
                case "post":
                    CreatePOSTRequest();
                    break;
                case "put":
                    CreatePUTRequest();
                    break;
                case "delete":
                    CreateDELETERequest();
                    break;
                default:
                    CreateGETRequest();
                    break;
            }
        }


        public void ChangeRequestURI(string newURI)
        {
            targetURI = newURI;
            Uri urlObj = new Uri(targetURL);
            IRestClient client = new RestClient(urlObj);
            clientAPI = client;
            requestReady = false;
        }


        public void CreateGETRequest()
        {
            IRestRequest _request = new RestRequest(targetURI, Method.GET);
            request = _request;
            requestReady = true;
        }

        public void CreatePOSTRequest()
        {
            IRestRequest _request = new RestRequest(targetURI, Method.POST);
            request = _request;
            requestReady = true;
        }


        public void CreatePUTRequest()
        {
            IRestRequest _request = new RestRequest(targetURI, Method.PUT);
            request = _request;
            requestReady = true;
        }


        public void CreateDELETERequest()
        {
            IRestRequest _request = new RestRequest(targetURI, Method.DELETE);
            request = _request;
            requestReady = true;
        }

        public void AddHeaderToRequest(string key, string value)
        {
            if (requestReady)
            {
                request.AddHeader(key, value);
            }
        }

        public void AddJSONPayloadToRequest(string payload)
        {
            if (requestReady)
            {
                request.AddParameter("application/json; charset=utf-8", payload, ParameterType.RequestBody);
            }
        }

        public void AddBearerTokenToRequest(string token)
        {
            if (requestReady)
            {
                request.AddHeader("authorization", "Bearer " + token);
            }
        }

        public IRestResponse ExecuteAPICall()
        {
            IRestResponse response = clientAPI.Execute(request);
            return response;
        }

        public void AddFileToRequest(string fileKey, string path, string name)
        {
            if (requestReady)
            {
                request.AddFile(fileKey, path + name);
            }
        }

    }
}
