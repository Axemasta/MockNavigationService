using CommunityToolkit.Mvvm.ComponentModel;

namespace MockNavigationService.Sample.ViewModels;

public partial class ContactViewModel : ViewModelBase, IInitialize
{
    [ObservableProperty]
    private ContactItem contact;

    public ContactViewModel(INavigationService navigationService)
        : base(navigationService)
    {
    }

    public void Initialize(INavigationParameters parameters)
    {
        if (!parameters.TryGetValue(Constants.ContactItemKey, out ContactItem contactItem))
        {
            throw new ArgumentException("Contact is required to display this page");
        }

        Contact = contactItem;

        Title = Contact.FirstName;
    }
}
