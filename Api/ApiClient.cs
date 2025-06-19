using System;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace agros_repo.ApiClient
{
    public class ApiClient
    {
        private readonly RestClient _client;

        public ApiClient(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        public async Task<RestResponse> PostAsync<T>(string endpoint, T body) where T : class
        {
            var request = new RestRequest(endpoint, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(body);

            return await _client.ExecuteAsync(request);
        }

        public async Task<RestResponse> GetAsync(string endpoint, Dictionary<string, string> queryParams)
        {
            var request = new RestRequest(endpoint, Method.Get);

            if (queryParams != null)
            {
                foreach (var param in queryParams)
                {
                    request.AddParameter(param.Key, param.Value);
                }
            }

            return await _client.ExecuteAsync(request);
        }

        public async Task<TRes> PostAndDeserializeAsync<TReq, TRes>(string endpoint, TReq body)
        where TReq : class
        {
            var response = await PostAsync(endpoint, body);

            if (!response.IsSuccessful)
                throw new Exception($"API call failed: {response.StatusCode} - {response.Content}");

            if (string.IsNullOrEmpty(response.Content))
            {
                throw new Exception("API response content is null or empty");
            }

            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<TRes>(response.Content)
            ?? throw new Exception("Failed to deserialize API response.");
            return result;
        }
    }
}