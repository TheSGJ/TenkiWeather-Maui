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
        InitialWeather();
        _restService = new RestService();
    }

    async void InitialWeather(object sender, EventArgs e)
    {
        WeatherData weatherData = await _restService.GetWeatherData(
            InitialRequestURL(Constants.OpenWeatherMapEndpoint)
        );

        BindingContext = weatherData;
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
            WeatherData weatherData = await _restService.GetWeatherData(
                GenerateRequestURL(Constants.OpenWeatherMapEndpoint)
            );

            BindingContext = weatherData;
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
