using Newtonsoft.Json;
using SlackSDK.Models.DTO;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SlackSDK.Client
{
    public class SlackClient
    {

        private HttpClient _client;

        public SlackClient(
            IHttpClientFactory httpClientFactory
            )
        {
            _client = httpClientFactory.CreateClient("Slack");
        }

        public async Task<bool> SendMessageAsync(Uri webHookUrl, SlackMessage message)
        {
            string payload = JsonConvert.SerializeObject(message);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, webHookUrl);

            request.Content = new StringContent(payload, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {

            }
            else
            {

            }

            return response.IsSuccessStatusCode;
        }
    }
}
