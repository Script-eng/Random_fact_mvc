using Microsoft.AspNetCore.Mvc;
using SimpleApp.Services;
using SimpleApp.Models;

namespace SimpleApp.Controllers
{
     public class JokesController : Controller
{
    private readonly JokeService _jokeService;

    public JokesController()
    {
        _jokeService = new JokeService();
    }

    public async Task<IActionResult> Index()
    {
        var jokes = await _jokeService.GetMultipleJokes(5); // Fetch 5 jokes
        return View(jokes);
    }
}
}
