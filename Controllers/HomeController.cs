using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SimpleApp.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SimpleApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient(); // Initialize HttpClient for making API calls
        }

        // Method to get a single random fact
        private async Task<string> GetRandomFactAsync()
        {
            var response = await _httpClient.GetStringAsync("https://uselessfacts.jsph.pl/random.json?language=en");
            var factObject = JObject.Parse(response);
            return factObject["text"]?.ToString(); // Extract the 'text' field containing the fact
        }

        // Method to get a list of random facts
        private async Task<List<string>> GetRandomFactsAsync(int count)
        {
            var facts = new List<string>();
            for (int i = 0; i < count; i++)
            {
                facts.Add(await GetRandomFactAsync());
            }
            return facts;
        }

        public async Task<IActionResult> Index()
        {
            var randomFact = await GetRandomFactAsync(); // Get a random fact for the Index page
            ViewData["RandomFact"] = randomFact; // Pass it to the view
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            var randomFacts = await GetRandomFactsAsync(5); // Get 5 random facts for the Privacy page
            ViewData["RandomFacts"] = randomFacts; // Pass the list of facts to the view
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> GetRandomFact()
{
    var randomFact = await GetRandomFactAsync(); // Fetch a random fact
    return Json(randomFact); // Return the fact as JSON
}

    }
}
