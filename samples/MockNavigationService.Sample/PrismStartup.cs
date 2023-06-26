using System.Diagnostics;
using MockNavigationService.Sample.Views;

namespace MockNavigationService.Sample;

internal static class PrismStartup
{
    public static void Configure(PrismAppBuilder builder)
    {
        builder.RegisterTypes(RegisterTypes)
            .OnAppStart(OnAppStart);
    }

    private static void RegisterTypes(IContainerRegistry containerRegistry)
    {
        // Services
        containerRegistry.RegisterSingleton<IContactsService, ContactsService>();

        // Pages
        containerRegistry.RegisterForNavigation<ContactListPage, ContactListViewModel>();
        containerRegistry.RegisterForNavigation<AddContactPage, AddContactViewModel>();
        containerRegistry.RegisterForNavigation<ContactPage, ContactViewModel>();
    }

    private static async Task OnAppStart(INavigationService navigationService)
    {
        var nav = await navigationService.CreateBuilder()
            .AddNavigationPage()
            .AddSegment<ContactListViewModel>()
            .NavigateAsync();

        if (!nav.Success)
        {
            Debug.WriteLine("Unable to navigate to first page!");
            Debug.WriteLine(nav.Exception);
            Debugger.Break();
        }
    }
}

