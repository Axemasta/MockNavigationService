namespace MockNavigationService.Sample.Models;

public class ContactItem
{
	public string FirstName { get; set; }

    public string LastName { get; set; }

    public string EmailAddress { get; set; }

    public string PhoneNumber { get; set; }

    public AddressItem Address { get; set; }
}
