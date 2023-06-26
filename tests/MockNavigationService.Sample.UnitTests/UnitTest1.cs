using Bogus;
using MockNavigationService.Sample.Models;
using Newtonsoft.Json;

namespace MockNavigationService.Sample.UnitTests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var addressGenerator = new Faker<AddressItem>()
            .RuleFor(c => c.HouseNameOrNumber, f => f.Address.BuildingNumber())
            .RuleFor(c => c.FirstLine, f => f.Address.SecondaryAddress())
            .RuleFor(c => c.SecondLine, f => f.Address.StreetAddress())
            .RuleFor(c => c.Town, f => f.Address.City())
            .RuleFor(c => c.Province, f => f.Address.County())
            .RuleFor(c => c.Postcode, f => f.Address.ZipCode())
            .RuleFor(c => c.Country, f => f.Address.Country());

        var contactGenerator = new Faker<ContactItem>()
            .RuleFor(c => c.FirstName, f => f.Name.FirstName())
            .RuleFor(c => c.LastName, f => f.Name.LastName())
            .RuleFor(c => c.EmailAddress, f => f.Internet.Email())
            .RuleFor(c => c.PhoneNumber, f => f.Phone.PhoneNumber())
            .RuleFor(c => c.Address, f => addressGenerator.Generate());

        var contacts = contactGenerator.Generate(5);

        var contactsJson = JsonConvert.SerializeObject(contacts, Formatting.Indented);

        var debug = 1;
    }
}
