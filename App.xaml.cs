namespace TenkiWeather;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        // Set the default theme to light
        var mauiApp = new MauiApp();
        mauiApp.RequestedTheme = OSAppTheme.Light;
        mauiApp.RequestedThemeChanged += OnRequestedThemeChanged;

        MainPage = new AppShell();
    }

    private void OnRequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
    {
        // If the user tries to change the theme, reset it back to light mode
        var mauiApp = sender as MauiApp;
        if (mauiApp.RequestedTheme == OSAppTheme.Dark)
        {
            mauiApp.RequestedTheme = OSAppTheme.Light;
        }
    }
}
