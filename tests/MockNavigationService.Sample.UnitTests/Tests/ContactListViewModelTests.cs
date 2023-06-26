using MockNavigationService.Sample.Models;
using MockNavigationService.Sample.Services;
using MockNavigationService.Sample.ViewModels;

namespace MockNavigationService.Sample.UnitTests.Tests;

public class ContactListViewModelTests : FixtureBase<ContactListViewModel>
{
    #region Setup

    private Mock<IContactsService> contactsService;
    private Mock<INavigationService> navigationService;

    public ContactListViewModelTests()
    {
        contactsService = new Mock<IContactsService>();
        navigationService = new Mock<INavigationService>();
    }

    protected override ContactListViewModel CreateSystemUnderTest()
    {
        return new ContactListViewModel(
            contactsService.Object,
            navigationService.Object);
    }

    #endregion Setup

    #region Tests

    [Fact]
    public void Initialize_WhenCalled_ShouldLoadContacts()
    {
        // Arrange
        var contacts = new List<ContactItem>()
        {
            new ContactItem()
            {
                FirstName = "Billy",
                LastName = "Person",
                PhoneNumber = "1395849202847",
            },
            new ContactItem()
            {
                FirstName = "Fiona",
                LastName = "Random",
                PhoneNumber = "101010011011101",
            }
        };

        contactsService.Setup(m => m.GetContacts())
            .Returns(contacts);

        // Act
        Sut.Initialize(null);

        // Assert
        Sut.Contacts.ToList()
            .Should()
            .BeEquivalentTo(contacts);
    }

    [Fact]
    public void AddContact_WhenCalled_ShouldNavigateToAddPage()
    {
        // Arrange

        // Act

        // Assert
        throw new NotImplementedException();
    }

    [Fact]
    public void ContactSelected_WhenContactIsNull_ShouldDoNothing()
    {
        // Arrange

        // Act

        // Assert
        throw new NotImplementedException();
    }

    [Fact]
    public void ContactSelected_WhenContactIsNotNull_ShouldNavigateToContactPageWitPayload()
    {
        // Arrange

        // Act

        // Assert
        throw new NotImplementedException();
    }

    [Fact]
    public void OnNavigatedTo_WhenNavigatingForward_ShouldDoNothing()
    {
        // Arrange

        // Act

        // Assert
        throw new NotImplementedException();
    }

    [Fact]
    public void OnNavigatedTo_WhenNavigatingBackwardsWithoutParameters_ShouldDoNothing()
    {
        // Arrange

        // Act

        // Assert
        throw new NotImplementedException();
    }

    [Fact]
    public void OnNavigatedTo_WhenNavigatingBackwardsWithNewContact_ShouldAddToContacts()
    {
        // Arrange

        // Act

        // Assert
        throw new NotImplementedException();
    }

    #endregion Tests
}
