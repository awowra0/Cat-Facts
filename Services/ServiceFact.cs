using Models;
using System.Net.Http.Json;

namespace Services;

public interface IServiceFact
{
    public Task AddNewFactAsync();
}
public class ServiceFact(HttpClient client, string url = "https://catfact.ninja/fact", string file = "./facts.txt") : IServiceFact
{    
    public async Task AddNewFactAsync()
    {
        try
        {
            Fact? response = await client.GetFromJsonAsync<Fact>(url);
            if (response is not null)
                File.AppendAllText(file, response.fact + "\n");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Something went wrong: {e.Message}");
        }
    }
}