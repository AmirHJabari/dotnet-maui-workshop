namespace MonkeyFinder.ViewModel;

[QueryProperty("Item", "Item")]
public partial class MonkeyDetailsViewModel : BaseViewModel
{
	IMap map;
	public MonkeyDetailsViewModel(IMap map)
	{
		this.map = map;
	}
	[ObservableProperty]
	Monkey item;

	[RelayCommand]
	async Task OpenMapAsync()
	{
		try
		{
			await map.OpenAsync(Item.Latitude, Item.Longitude,
				new MapLaunchOptions
				{
					Name = $"{Item.Name}'s Location",
					NavigationMode = NavigationMode.None
				});
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Error!",
				$"Unable to open map: {ex.Message}", "OK");
		}
	}
}
