using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System;
using System.Text.Json.Serialization;

namespace Scheduling.Services
{
    public class LocationService : IDisposable
    {
        private readonly HttpClient _httpClient;

        public LocationService()
        {
            _httpClient = new HttpClient();
        }

        // Fetches user info from the provided URL
        public async Task<UserInfo> GetUserInfo(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
               // MessageBox.Show(content);
                return JsonSerializer.Deserialize<UserInfo>(content);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching data: {ex.Message}");
                return null;
            }
        }

        // Performs a GET request and displays the response
        public async Task GetRequest(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                // Read response body
                string responseBody = await response.Content.ReadAsStringAsync();
                MessageBox.Show(responseBody);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in GET request: {ex.Message}");
            }
        }

        // Disposes of HttpClient when LocationService is disposed
        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }

    public class UserInfo
    {
        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }
    }
}
