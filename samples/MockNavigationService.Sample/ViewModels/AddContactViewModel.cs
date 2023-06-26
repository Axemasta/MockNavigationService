using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MockNavigationService.Sample.ViewModels;

public partial class AddContactViewModel : ViewModelBase
{
    private readonly IContactsService contactsService;
    private readonly IPageDialogService pageDialogService;

    [ObservableProperty]
    private ContactItem contact;

    public AddContactViewModel(
        IContactsService contactsService,
        INavigationService navigationService,
        IPageDialogService pageDialogService)
        : base(navigationService)
    {
        this.contactsService = contactsService;
        this.pageDialogService = pageDialogService;

        contact = new ContactItem();

        Title = "Create Contact";
    }

    [RelayCommand]
    private async Task CreateContact()
    {
        if (!ValidateContact())
        {
            await pageDialogService.DisplayAlertAsync(
                "Invalid Contact",
                "Please complete all of the required information to save this contact",
                "Ok");

            return;
        }

        contactsService.AddContact(Contact);

        await navigationService.GoBackAsync(new NavigationParameters()
        {
            { KnownNavigationParameters.UseModalNavigation, true },
            { Constants.NewContactKey, Contact },
        });
    }

    [RelayCommand]
    private async Task Close()
    {
        await navigationService.GoBackAsync(new NavigationParameters()
        {
            { KnownNavigationParameters.UseModalNavigation, true }
        });
    }

    private bool ValidateContact()
    {
        return !string.IsNullOrEmpty(Contact.FirstName) &&
            !string.IsNullOrEmpty(Contact.LastName) &&
            !string.IsNullOrEmpty(Contact.PhoneNumber);
    }
}
