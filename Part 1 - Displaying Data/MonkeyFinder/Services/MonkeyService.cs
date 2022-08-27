namespace MonkeyFinder.Services;

public class MonkeyService
{
    List<Monkey> monkeys = new();
    HttpClient httpClient;

    public MonkeyService()
    {
        httpClient = new();
    }

    public async Task<List<Monkey>> GetMonkeysAsync()
    {
        if (monkeys?.Count > 0)
            return monkeys;

        var url = "https://montemagno.com/monkeys.json";
        var res = await httpClient.GetAsync(url);

        if (res.IsSuccessStatusCode)
        {
            monkeys = await res.Content.ReadFromJsonAsync<List<Monkey>>();
        }

        return monkeys;
    }
}
