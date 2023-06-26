namespace MockNavigationService.Sample.Services;

public interface IContactsService
{
    List<ContactItem> GetContacts();

    bool AddContact(ContactItem contact);
}
