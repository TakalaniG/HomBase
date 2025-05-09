using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using HomBase.Client.Models;

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

        public async Task<Property> CreatePropertyAsync(Property property)
        {
            var response = await _httpClient.PostAsJsonAsync("api/properties", property);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Property>();
        }

        public async Task DeletePropertyAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/properties/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<Property?> GetPropertyByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/properties/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Property>();
        }

        public async Task<bool> UpdatePropertyAsync(Property property)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/properties/{property.Id}", property);
            return response.IsSuccessStatusCode;
        }
    }
}
