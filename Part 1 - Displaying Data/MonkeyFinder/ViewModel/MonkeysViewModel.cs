using CommunityToolkit.Mvvm.Input;
using MonkeyFinder.Services;

namespace MonkeyFinder.ViewModel;

public partial class MonkeysViewModel : BaseViewModel
{
    MonkeyService monkeyService;

    public MonkeysViewModel(MonkeyService monkeyService)
    {
        Title = "Monkey Finder";
        this.monkeyService = monkeyService;
    }

    public ObservableCollection<Monkey> Monkeys { get; set; } = new();

    [RelayCommand]
    async Task GetMonkeysAsync()
    {
        if (IsBusy) return;
        try
        {
            IsBusy = true;
            var monkeys = await monkeyService.GetMonkeysAsync();

            if (Monkeys.Count != 0)
                Monkeys.Clear();

            foreach (var monkey in monkeys)
                Monkeys.Add(monkey);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            
            await Shell.Current.DisplayAlert("Error!",
                $"Unable to get monkeys: {ex.Message}", "Okay");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
