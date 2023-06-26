using MockNavigationService.Sample.Services;
using MockNavigationService.Sample.ViewModels;

namespace MockNavigationService.Sample.UnitTests.Tests;

public class AddContactViewModelTests : FixtureBase<AddContactViewModel>
{
    #region Setup

    private Mock<IContactsService> contactsService;
    private Mock<INavigationService> navigationService;
    private Mock<IPageDialogService> pageDialogService;

    public AddContactViewModelTests()
    {
        contactsService = new Mock<IContactsService>();
        navigationService = new Mock<INavigationService>();
        pageDialogService = new Mock<IPageDialogService>();
    }

    protected override AddContactViewModel CreateSystemUnderTest()
    {
        return new AddContactViewModel(
            contactsService.Object,
            navigationService.Object,
            pageDialogService.Object);
    }

    #endregion Setup

    #region Tests

    [Fact]
	public void CreateContact_WhenContactNotPopulated_ShouldNotSave()
	{
        // Arrange

        // Act

        // Assert
        throw new NotImplementedException();
	}

    [Fact]
    public void CreateContact_WhenContactPopulated_ShouldSaveAndNavigate()
    {
        // Arrange

        // Act

        // Assert
        throw new NotImplementedException();
    }

    [Fact]
    public void Close_WhenCalled_ShouldCloseWithoutSaving()
    {
        // Arrange

        // Act

        // Assert
        throw new NotImplementedException();
    }


    #endregion Tests
}
