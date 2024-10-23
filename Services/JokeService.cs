using JokeAPIWrapper; // Use this instead of JokeAPI
using System.Collections.Generic;
using System.Threading.Tasks;

public class JokeService
{
    private readonly JokeAPIWrapper.JokeAPI _jokeApi; // Update namespace here

    public JokeService()
    {
        _jokeApi = new JokeAPIWrapper.JokeAPI(); // Update namespace here
    }

    public async Task<Joke> GetRandomJoke()
    {
        return await _jokeApi.GetRandomJokeAsync();
    }

    public async Task<List<Joke>> GetMultipleJokes(int count)
    {
        var jokes = new List<Joke>();
        for (int i = 0; i < count; i++)
        {
            jokes.Add(await GetRandomJoke());
        }
        return jokes;
    }
}
