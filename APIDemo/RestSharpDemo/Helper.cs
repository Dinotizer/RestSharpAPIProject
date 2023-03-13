using RestSharp;
using System.IO;
using System.Threading.Tasks;

namespace RestSharpDemo
{
    public class Helper
    {
        public RestClient client;
        private RestRequest request;

        public RestClient SetUrl(string baseUrl, string endpoint)
        {
            var url = Path.Combine(baseUrl, endpoint);
            client = new RestClient(url);
            return client;
        }
        public RestRequest CreateGetRequest()
        {
            request = new RestRequest
            {
                Method = Method.Get
            };
            request.AddHeader("Accept", "application/json");
            return request;
        }
        public RestRequest CreatePostRequest<T>(T payload) where T : class
        {
            var request = new RestRequest
            {
                Method= Method.Post
            };
            request.AddHeader("Accept", "application/json");
            request.AddBody(payload);
            request.RequestFormat = DataFormat.Json;
            return request;
        }
        public RestRequest CreatePutRequest<T>(T payload) where T: class
        {
            request = new RestRequest
            {
                Method = Method.Put
            };
            request.AddHeader("Accept", "application/json");
            request.AddBody(payload);
            request.RequestFormat = DataFormat.Json;
            return request;
        }
        public RestRequest CreateDeleteRequest()
        {
            request = new RestRequest
            {
                Method = Method.Delete
            };
            request.AddHeader("Accept", "application/json");
            return request;
        }
        public async Task<RestResponse> GetResponseAsync(RestClient restClient, RestRequest restRequest)
        {
            return await restClient.ExecuteAsync(restRequest);
        }
    }
}
