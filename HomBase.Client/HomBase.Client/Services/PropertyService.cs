using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using HomBase.Client.Models;
//using HomBase.Client.Models; // Ensure you have shared models

namespace HomBase.Client.Services
{
    public class PropertyService
    {
        private readonly HttpClient _httpClient;

        public PropertyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Property>> GetPropertiesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Property>>("api/properties") ?? new List<Property>();
        }
    }
}
