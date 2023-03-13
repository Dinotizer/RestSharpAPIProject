using Newtonsoft.Json;
using RestSharp;
using System;

namespace APIDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://reqres.in/");
            var request = new RestRequest("api/users?page=2", Method.Get);
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(request);
            var content = response.Content;
            Console.WriteLine(content);
            Console.ReadKey();
        }
    }
}
