
namespace SimpleApp.Models
{
    public class Joke
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public string Url { get; set; }
        public string IconUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<string> Categories { get; set; }
    }
}
