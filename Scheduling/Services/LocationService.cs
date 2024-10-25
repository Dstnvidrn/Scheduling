using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Services
{
    public class LocationService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<string> GetLocationAsync()
        {
            try
            {
                string url = "https://ipinfo.io/json";
                var response = await _httpClient.GetStringAsync(url);
                dynamic locationData = null;
                return null;
            }
            catch { return null; }
        }
    }
}
