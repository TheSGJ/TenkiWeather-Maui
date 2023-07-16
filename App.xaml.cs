using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Controls.Xaml;

namespace TenkiWeather
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<AppShell>();

            // Set the default theme to light
            builder.ConfigureMauiHandlers((_, handlers) =>
            {
                handlers.AddHandler(typeof(IShellFlyoutRenderer), typeof(ShellFlyoutRenderer));
            });

            var mauiApp = builder.Build();

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
}
