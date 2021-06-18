
using APIClients;
using AutomationClasses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PageObjects;
using RestSharp;
using System;
using System.Collections.Generic;
using static AutomationClasses.AutomationOptions;

namespace CodeExecution
{
    class Program
    {
        static void Main(string[] args)
        {
            string URL = "https://petstore.swagger.io/";
            string URI = "v2/user";
            APIEncapsulator api = new APIEncapsulator(URL, URI, EndpointMethod.POST);
            api.AddHeaderToRequest("accept", "application/json");
            api.AddHeaderToRequest("Content-Type", "application/json");

            JObject user = new JObject();
            user.Add("id", 3);
            user.Add("username", "ejemplo");
            user.Add("firstName", "carlos");
            user.Add("lastName", "lastTest");
            user.Add("email", "email@email.com");
            user.Add("password", "password123");
            user.Add("phone", "456789");
            user.Add("userStatus", 1);

            api.AddJSONPayloadToRequest(user.ToString());
            IRestResponse resp = api.ExecuteAPICall();
            int code = (int)resp.StatusCode;
            JObject data = JObject.Parse(resp.Content);

            RespuestaUser userResp = new RespuestaUser();
            if (code == 200)
            {
                userResp.message = data.GetValue("message").Value<string>();
                userResp.code = data.GetValue("code").Value<int>();
                userResp.type = data.GetValue("type").Value<string>();
            }

            Console.WriteLine(userResp.message);
            Console.WriteLine(userResp.code);
            Console.WriteLine(userResp.type);

        }
    }
}

