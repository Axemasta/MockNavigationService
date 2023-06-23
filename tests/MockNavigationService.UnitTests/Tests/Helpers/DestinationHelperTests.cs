using MockNavigationService.Helpers;

namespace MockNavigationService.UnitTests.Tests.Helpers;

public class DestinationHelperTests
{
    #region Tests

    [Theory]
    [InlineData("MainPage", new string[] { "MainPage", "MainViewModel", "MainPageViewModel" })]
    [InlineData("SplashPage", new string[] { "SplashPage", "SplashViewModel", "SplashPageViewModel" })]
    public void GetValidDestinations_WhenPassedPageDestination_ShouldCreateViewModelDestinations(string pageName, string[] expectedDestinations)
    {
        // Arrange

        // Act
        var destinations = DestinationHelper.GetValidDestinations(pageName);

        // Assert
        destinations.Should().BeEquivalentTo(expectedDestinations);
    }

    [Theory]
    [InlineData("MainViewModel", new string[] { "MainViewModel", "MainPage" })]
    [InlineData("MainPageViewModel", new string[] { "MainPageViewModel", "MainPage" })]
    public void GetValidDestinations_WhenPassedViewModelDestination_ShouldCreatePageDestination(string pageName, string[] expectedDestinations)
    {
        // Arrange

        // Act
        var destinations = DestinationHelper.GetValidDestinations(pageName);

        // Assert
        destinations.Should().BeEquivalentTo(expectedDestinations);
    }

    [Theory]
    [InlineData("MainViewModelPlace", new string[] { "MainViewModelPlace" })]
    [InlineData("Destination", new string[] { "Destination" })]
    [InlineData("", new string[] { "" } )]
    public void GetValidDestinations_WhenPassedDestinationWithUnknownSuffix_ShouldNotCreateExtraDestination(string pageName, string[] expectedDestinations)
    {
        // Arrange

        // Act
        var destinations = DestinationHelper.GetValidDestinations(pageName);

        // Assert
        destinations.Should().BeEquivalentTo(expectedDestinations);
    }

    #endregion Tests
}
