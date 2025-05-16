using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OctoEngine.Networking
{
    public class WebClient : IDisposable
    {
        private readonly HttpClient _httpClient;

        public WebClient(TimeSpan? timeout = null)
        {
            _httpClient = new HttpClient();
            if (timeout.HasValue)
            {
                _httpClient.Timeout = timeout.Value;
            }
        }

        /// <summary>
        /// Sends a GET request to the specified URL and returns the response as a deserialized object.
        /// </summary>
        public async Task<T> GetAsync<T>(string url)
        {
            using var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(json);
        }

        /// <summary>
        /// Sends a POST request with a JSON payload to the specified URL and returns the response as a deserialized object.
        /// </summary>
        public async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest payload)
        {
            var jsonContent = JsonSerializer.Serialize(payload);
            using var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            using var response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TResponse>(json);
        }

        /// <summary>
        /// Sends a PUT request with a JSON payload to the specified URL.
        /// </summary>
        public async Task PutAsync<T>(string url, T payload)
        {
            var jsonContent = JsonSerializer.Serialize(payload);
            using var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            using var response = await _httpClient.PutAsync(url, content);
            response.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// Sends a DELETE request to the specified URL.
        /// </summary>
        public async Task DeleteAsync(string url)
        {
            using var response = await _httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// Disposes the HttpClient.
        /// </summary>
        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
