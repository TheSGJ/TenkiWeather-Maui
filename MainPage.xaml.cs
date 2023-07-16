using System.Diagnostics; // Add this using directive at the top of MainPage.xaml.cs

namespace TenkiWeather;

public partial class MainPage : ContentPage
{
    // ... Rest of the code ...

    public MainPage()
    {
        Title = "";
        NavigationPage.SetHasNavigationBar(this, false);
        ToolbarItems.Clear();
        InitializeComponent();
        _restService = new RestService();

        try
        {
            InitialWeather();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error in InitialWeather: {ex}");
            DisplayAlert("Error", "Failed to fetch initial weather data", "OK");
        }
    }

    // ... Rest of the code ...

    async void OnGetWeatherButtonClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(_cityEntry.Text))
        {
            try
            {
                WeatherData weatherData = await _restService.GetWeatherData(
                    GenerateRequestURL(Constants.OpenWeatherMapEndpoint)
                );

                if (weatherData != null)
                {
                    BindingContext = weatherData;
                }
                else
                {
                    DisplayAlert("Error", "Failed to fetch weather data for the city", "OK");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in OnGetWeatherButtonClicked: {ex}");
                DisplayAlert("Error", "Failed to fetch weather data", "OK");
            }
        }
    }

    // ... Rest of the code ...
}
