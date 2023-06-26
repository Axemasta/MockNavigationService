using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using MvvmHelpers;

namespace MockNavigationService.Sample.ViewModels;

public partial class ContactListViewModel : ViewModelBase
{
    private readonly IContactsService contactsService;

    public ObservableRangeCollection<ContactItem> Contacts { get; } = new ObservableRangeCollection<ContactItem>();

    public ContactListViewModel(
        IContactsService contactsService,
        INavigationService navigationService)
        : base(navigationService)
    {
        Title = "Contacts";

        this.contactsService = contactsService;
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

    public override void Initialize(INavigationParameters parameters)
    {
        var contacts = contactsService.GetContacts();

        Contacts.ReplaceRange(contacts);
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

