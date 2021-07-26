using OnlineShopingGatewayAPI.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineShopingGatewayAPI.Utils
{
    class HttpClientHub : IHttpClientHub
    {
        public HttpClientHub(IObjectSerializer objectSerializer)
        {
            _objectSerializer = objectSerializer;
        }
        private readonly IObjectSerializer _objectSerializer;
        public async Task<W> PostAsync<W>(JsonObject model, string fullUrl, string extentionGrantToken = "")
        {
            var x = _objectSerializer.Serialize(model);
            var _uri = new Uri(fullUrl);
            string authority;
            if (fullUrl.Contains("https:"))
            {
                authority = string.Concat("https://", _uri.Authority.ToString());
            }
            else
                authority = string.Concat("http://", _uri.Authority.ToString());
            var _baseUri = new Uri(authority);
            W result = default;
            using (var client = new HttpClient { BaseAddress = _baseUri })
            {
                client.Timeout = TimeSpan.FromMinutes(1);

                HttpResponseMessage response = null;

                string path = _uri.AbsolutePath;
                using (var request = new HttpRequestMessage(HttpMethod.Post, path))
                {
                    string fafa = _objectSerializer.Serialize(model);
                    request.Content = new StringContent(model.JsonObjectString);
                    request.Content.Headers.Clear();
                    request.Content.Headers.Add("Content-Type", "application/json");
                    //request.Content.Headers.Add("CurrentCorrelationId", _currentUserInfo.CorrelationId.ToString());
                    if (!string.IsNullOrWhiteSpace(extentionGrantToken))
                        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", extentionGrantToken);

                    response = await client.SendAsync(request);
                }
                if (response.IsSuccessStatusCode)
                {
                    var strContent = await response.Content.ReadAsStringAsync()
                                                           .ConfigureAwait(false);

                    result = _objectSerializer.Deserialize<W>(strContent);
                }

                response.Dispose();
            }

            return result;
        }

        public async Task<string> PostAsync(string fullUrl, string extentionGrantToken = "")
        {
            var _uri = new Uri(fullUrl);
            string authority;
            if (fullUrl.Contains("https:"))
            {
                authority = string.Concat("https://", _uri.Authority.ToString());
            }
            else
                authority = string.Concat("http://", _uri.Authority.ToString());
            var _baseUri = new Uri(authority);
            string result = default;
            using (var client = new HttpClient { BaseAddress = _baseUri })
            {
                HttpResponseMessage response = null;

                string path = _uri.AbsolutePath;
                using (var request = new HttpRequestMessage(HttpMethod.Post, path))
                {
                    request.Content = new StringContent("");
                    request.Content.Headers.Clear();
                    request.Content.Headers.Add("Content-Type", "application/json");
                    if (!string.IsNullOrWhiteSpace(extentionGrantToken))
                        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", extentionGrantToken);

                    response = client.SendAsync(request).GetAwaiter().GetResult();
                }
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync()
                                                           .ConfigureAwait(false);
                }

                response.Dispose();
            }

            return result;
        }
    }
}
