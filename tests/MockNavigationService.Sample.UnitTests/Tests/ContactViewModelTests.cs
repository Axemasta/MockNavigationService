using MockNavigationService.Sample.ViewModels;

namespace MockNavigationService.Sample.UnitTests.Tests;

public class ContactViewModelTests : FixtureBase<ContactViewModel>
{
    #region Tests

    private Mock<INavigationService> navigationService;

    public ContactViewModelTests()
    {
        navigationService = new Mock<INavigationService>();
    }

    protected override ContactViewModel CreateSystemUnderTest()
    {
        return new ContactViewModel(navigationService.Object);
    }

    #endregion Tests

    #region Setup

    [Fact]
	public void Initialize_WhenNoContactContainedInParameters_ShouldThrow()
	{
		// Arrange

		// Act

		// Assert
		throw new NotImplementedException();
	}

    [Fact]
    public void Initialize_WhenContactContainedInParameters_ShouldSetContactAndTitle()
    {
        // Arrange

        // Act

        // Assert
        throw new NotImplementedException();
    }

    #endregion Setup
}
