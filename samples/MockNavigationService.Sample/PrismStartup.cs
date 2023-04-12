using System.Diagnostics;
using MockNavigationService.Sample.Views;

namespace MockNavigationService.Sample;

internal static class PrismStartup
{
    public static void Configure(PrismAppBuilder builder)
    {
        builder.RegisterTypes(RegisterTypes)
            .OnInitialized(OnInitialized)
            .OnAppStart(OnAppStart);
    }

    private static void RegisterTypes(IContainerRegistry containerRegistry)
    {
        // Services

        // Pages
        containerRegistry.RegisterForNavigation<MainPage, MainViewModel>();
    }

    private static void OnInitialized(IContainerProvider containerProvider)
    {
    }

    private static async Task OnAppStart(INavigationService navigationService)
    {
        var nav = await navigationService.CreateBuilder()
            .AddNavigationPage()
            .AddSegment<MainViewModel>()
            .NavigateAsync();

        if (!nav.Success)
        {
            Debug.WriteLine("Unable to navigate to first page!");
            Debug.WriteLine(nav.Exception);
            Debugger.Break();
        }
    }
}

