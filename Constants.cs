namespace TenkiWeather
{
    public static class Constants
    {
        public static string OpenWeatherMapEndpoint =
            "https://api.openweathermap.org/data/2.5/weather";

        public static string OpenWeatherMapAPIKey { get; } =
            Environment.GetEnvironmentVariable("WEATHER_API_KEY");
    }
}
