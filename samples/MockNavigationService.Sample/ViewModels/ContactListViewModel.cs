using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.ApplicationModel.Communication;

namespace MockNavigationService.Sample.ViewModels;

public partial class ContactListViewModel : ViewModelBase
{
    private readonly IContactsService contactsService;

    public ObservableCollection<ContactItem> Contacts { get; }

    public ContactListViewModel(
        IContactsService contactsService,
        INavigationService navigationService)
        : base(navigationService)
    {
        Title = "Contacts";

        this.contactsService = contactsService;

        var contacts = this.contactsService.GetContacts();

        Contacts = new ObservableCollection<ContactItem>(contacts);
    }

    [RelayCommand]
    private async Task AddContact()
    {
        await navigationService.CreateBuilder()
            .AddNavigationPage(useModalNavigation: true)
            .AddSegment<AddContactViewModel>()
            .NavigateAsync();
    }

    [RelayCommand]
    private async Task ContactSelected(ContactItem contact)
    {
        if (contact is null)
        {
            Debug.WriteLine("Contact was null");
            return;
        }

        await navigationService.CreateBuilder()
            .AddParameter(Constants.ContactItemKey, contact)
            .AddSegment<ContactViewModel>()
            .NavigateAsync();
    }

    public override void OnNavigatedTo(INavigationParameters parameters)
    {
        if (parameters.GetNavigationMode() == Prism.Navigation.NavigationMode.Back &&
            parameters.TryGetValue(Constants.NewContactKey, out ContactItem contact))
        {
            Contacts.Add(contact);
        }
    }
}

