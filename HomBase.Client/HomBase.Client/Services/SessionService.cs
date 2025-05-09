using System.Net.Http.Json;
using HomBase.Client.Models;
using Microsoft.AspNetCore.Components;

namespace HomBase.Client.Services
{
    public class SessionService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public SessionService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public async Task<bool> LoginAsync(UserLogin loginRequest)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/auth/login", loginRequest);
                if (response.IsSuccessStatusCode)
                {
                    // Navigate to the properties page on successful login
                    _navigationManager.NavigateTo("/properties");
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Login error: {ex.Message}");
                return false;
            }
        }

        public void Logout()
        {
            // Redirect to login page on logout
            _navigationManager.NavigateTo("/login");
        }
    }
}
