using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using SimpleApp.Models;

namespace SimpleApp.Services
{
    public class JokeService
    {
        private readonly HttpClient _httpClient;

        public JokeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Joke[]> GetJokesAsync()
        {
            var response = await _httpClient.GetAsync("https://official-joke-api.appspot.com/jokes/ten");
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Joke[]>(json);
        }

        public async Task<Joke> GetRandomJokeAsync()
        {
            var response = await _httpClient.GetAsync("https://official-joke-api.appspot.com/jokes/random");
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Joke>(json);
        }
    }
}
