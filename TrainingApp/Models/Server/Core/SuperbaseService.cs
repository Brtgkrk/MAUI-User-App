using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Supabase;

namespace TrainingApp.Models.Server.Core
{
    public static class SupabaseService
    {
        public static Client SupabaseClient;
        private static readonly HttpClient _httpClient;
        // TODO: ENV not working lol xd
        public static readonly string serverUrl = Environment.GetEnvironmentVariable("SERVER_URL") ?? "https://perqvkdlykymdttetgqf.supabase.co";
        public static readonly string serverKey = Environment.GetEnvironmentVariable("SERVER_KEY") ?? "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InBlcnF2a2RseWt5bWR0dGV0Z3FmIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MjI4MDIwNjEsImV4cCI6MjAzODM3ODA2MX0.K1snc4LJJ177WHx9y1NRh_t0FCoBnN08MsSYmjYKlT0";

        static SupabaseService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(serverUrl);
            _httpClient.DefaultRequestHeaders.Add("apikey", serverKey);
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {serverKey}");

            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true
            };

            SupabaseClient = new Supabase.Client(serverUrl, serverKey, options);
            SupabaseClient.InitializeAsync();
        }

        // Methods
        public static async Task<T> GetDataAsync<T>(string tableName)
        {
            var response = await _httpClient.GetAsync($"/rest/v1/{tableName}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static async Task InsertDataAsync<T>(string tableName, T data)
        {
            var jsonContent = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"/rest/v1/{tableName}", content);
            response.EnsureSuccessStatusCode();
        }

        // Authorization
        public static async Task<string> AuthenticateUserAsync(string email, string password)
        {
            var authRequest = new
            {
                email = email,
                password = password
            };

            var jsonContent = JsonConvert.SerializeObject(authRequest);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/auth/v1/token", content);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(jsonResponse);
            return result.access_token;
        }
    }
}
