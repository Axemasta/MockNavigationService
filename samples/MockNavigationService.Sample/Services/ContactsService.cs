using System.Text.Json;

namespace MockNavigationService.Sample.Services;

public class ContactsService : IContactsService
{
    private static Lazy<List<ContactItem>> contacts = new Lazy<List<ContactItem>>(
        () => JsonSerializer.Deserialize<List<ContactItem>>(contactsJson),
        LazyThreadSafetyMode.ExecutionAndPublication);

    public bool AddContact(ContactItem contact)
    {
        return contact is not null
            ? true
            : false;
    }

    public List<ContactItem> GetContacts()
    {
        return contacts.Value;
    }

    private static string contactsJson = """
        [
          {
            "FirstName": "Annabell",
            "LastName": "Klein",
            "EmailAddress": "Ted.Runte@hotmail.com",
            "PhoneNumber": "1-553-599-5601 x68008",
            "Address": {
              "HouseNameOrNumber": "865",
              "Postcode": "67383-3777",
              "FirstLine": "Apt. 132",
              "SecondLine": "5004 Myah Bridge",
              "Town": "Port Francescobury",
              "Province": "Buckinghamshire",
              "Country": "Central African Republic"
            }
          },
          {
            "FirstName": "Alba",
            "LastName": "Mills",
            "EmailAddress": "Heaven.Abbott@gmail.com",
            "PhoneNumber": "530.494.7940",
            "Address": {
              "HouseNameOrNumber": "797",
              "Postcode": "69463-9489",
              "FirstLine": "Apt. 979",
              "SecondLine": "2090 Destiney Burg",
              "Town": "New Theresemouth",
              "Province": "Cambridgeshire",
              "Country": "Egypt"
            }
          },
          {
            "FirstName": "Gerhard",
            "LastName": "Crist",
            "EmailAddress": "Consuelo_Waelchi@gmail.com",
            "PhoneNumber": "860-723-1666",
            "Address": {
              "HouseNameOrNumber": "91202",
              "Postcode": "02838",
              "FirstLine": "Suite 241",
              "SecondLine": "2618 VonRueden Mountain",
              "Town": "Baileyborough",
              "Province": "Borders",
              "Country": "Yemen"
            }
          },
          {
            "FirstName": "Alessandro",
            "LastName": "Krajcik",
            "EmailAddress": "Letitia.Kozey@yahoo.com",
            "PhoneNumber": "514-969-4798",
            "Address": {
              "HouseNameOrNumber": "5397",
              "Postcode": "65391",
              "FirstLine": "Suite 239",
              "SecondLine": "42705 Pfeffer Flat",
              "Town": "North Betteland",
              "Province": "Buckinghamshire",
              "Country": "Finland"
            }
          },
          {
            "FirstName": "Dessie",
            "LastName": "Jacobi",
            "EmailAddress": "Lenore3@hotmail.com",
            "PhoneNumber": "1-227-916-3783 x02951",
            "Address": {
              "HouseNameOrNumber": "815",
              "Postcode": "65279-8866",
              "FirstLine": "Apt. 785",
              "SecondLine": "580 Kailyn Keys",
              "Town": "South Clairefort",
              "Province": "Cambridgeshire",
              "Country": "Argentina"
            }
          }
        ]
        """;
}
