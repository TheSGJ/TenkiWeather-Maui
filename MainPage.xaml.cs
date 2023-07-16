using System;
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
    }

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

    string GenerateRequestURL(string endPoint)
    {
        string requestUri = endPoint;
        requestUri += $"?q={_cityEntry.Text}";
        requestUri += "&units=imperial";
        requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
        return requestUri;
    }

}
