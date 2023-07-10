using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace IndeedJobs
{
    public class IndeedJobAPIClient
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;

        public IndeedJobAPIClient(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _client = clientFactory.CreateClient();
            _configuration = configuration;
        }

        public async Task<string> GetJobsAsync(string keyword, string location)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://indeed-jobs-api.p.rapidapi.com/indeed-us/?offset=0&keyword={keyword}&location={location}"),
            };

            request.Headers.Add("X-RapidAPI-Key", _configuration["RapidAPI:Key"]);
            request.Headers.Add("X-RapidAPI-Host", _configuration["RapidAPI:Host"]);

            using (var response = await _client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }
        }
    }
}
