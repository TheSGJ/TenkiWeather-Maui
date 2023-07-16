using System.Diagnostics;
namespace TenkiWeather;

public partial class MainPage : ContentPage
{
    RestService _restService;

    public MainPage()
    {
        Title = "";
        NavigationPage.SetHasNavigationBar(this, false);
        ToolbarItems.Clear();
        InitializeComponent();
        _restService = new RestService();

        // Call InitialWeather in a try-catch block to handle potential exceptions
        try
        {
            InitialWeather();
        }
        catch (Exception ex)
        {
            // Log the exception or display an error message
            Debug.WriteLine($"Error in InitialWeather: {ex}");
            DisplayAlert("Error", "Failed to fetch initial weather data", "OK");
        }
    }

    async void InitialWeather()
    {
        WeatherData weatherData = await _restService.GetWeatherData(
            InitialRequestURL(Constants.OpenWeatherMapEndpoint)
        );

        // Check if the weatherData is null before setting the BindingContext
        if (weatherData != null)
        {
            BindingContext = weatherData;
        }
        else
        {
            // Display an error message if weatherData is null
            DisplayAlert("Error", "Failed to fetch initial weather data", "OK");
        }
    }

    string InitialRequestURL(string endPoint)
    {
        string requestUri = endPoint;
        requestUri += $"?q=Delhi";
        requestUri += "&units=imperial";
        requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
        return requestUri;
    }

    async void OnGetWeatherButtonClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(_cityEntry.Text))
        {
            // Call GenerateRequestURL in a try-catch block to handle potential exceptions
            try
            {
                WeatherData weatherData = await _restService.GetWeatherData(
                    GenerateRequestURL(Constants.OpenWeatherMapEndpoint)
                );

                // Check if the weatherData is null before setting the BindingContext
                if (weatherData != null)
                {
                    BindingContext = weatherData;
                }
                else
                {
                    // Display an error message if weatherData is null
                    DisplayAlert("Error", "Failed to fetch weather data for the city", "OK");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or display an error message
                Debug.WriteLine($"Error in OnGetWeatherButtonClicked: {ex}");
                DisplayAlert("Error", "Failed to fetch weather data", "OK");
            }
        }
    }

    string GenerateRequestURL(string endPoint)
    {
        string requestUri = endPoint;
        requestUri += $"?q={_cityEntry.Text}";
        requestUri += "&units=imperial";
        requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
        return requestUri;
    }
}