using MockNavigationService.Extensions;

namespace MockNavigationService.UnitTests.Tests.Extensions;

public class SetupExtensionTests
{
    #region Setup

    private MockNavigationService sut;

	public SetupExtensionTests()
	{
		sut = new MockNavigationService();
	}

    #endregion Setup

    #region Tests

    [Theory]
    [InlineData("SomePage", "AnotherPage")]
    public async Task SetupNavigationResult_SetupDestination_ShouldNoRegisterAlternateDestination(string destination, string alternateDestination)
    {
        // Arrange
        sut.SetupNavigationResult(destination, true);

        // Act
        var navigationResult = await sut.NavigateAsync(alternateDestination);

        // Assert
        Assert.False(navigationResult.Success);
    }

    [Theory]
    [InlineData("SomePage", true)]
    [InlineData("SomePageViewModel", true)]
    [InlineData("SomeViewModel", true)]
    [InlineData("SomePage", false)]
    [InlineData("SomePageViewModel", false)]
    [InlineData("SomeViewModel", false)]
    public async Task SetupNavigationResult_SimpleOverload_ShouldRegisterExtras(string destination, bool expectedSuccess)
	{
        // Arrange

        // Act
        sut.SetupNavigationResult(destination, expectedSuccess);

        var navigationSuccess = await sut.NavigateAsync(destination);

        // Assert
        Assert.Equal(expectedSuccess, navigationSuccess.Success);
    }

    [Theory]
    [InlineData("SomePage", true)]
    [InlineData("SomePageViewModel", true)]
    [InlineData("SomeViewModel", true)]
    [InlineData("SomePage", false)]
    [InlineData("SomePageViewModel", false)]
    [InlineData("SomeViewModel", false)]
    public async Task SetupNavigationResult_SimpleOverloadWithParameters_ShouldRegisterExtras(string destination, bool expectedSuccess)
    {
        // Arrange

        // Act
        sut.SetupNavigationResult(destination, expectedSuccess);

        var navigationSuccess = await sut.NavigateAsync(destination);

        // Assert
        Assert.Equal(expectedSuccess, navigationSuccess.Success);
    }

    [Fact]
    public async Task SetupNavigationResult_WithException_ShouldReturnFailedNavigationResultWithDetail()
    {
        // Arrange
        var destination = "SomePage";
        var exception = new Exception("The maui navigation exploded");

        // Act
        sut.SetupNavigationResult(destination, exception);

        var navigationResult = await sut.NavigateAsync(destination);

        // Assert
        Assert.False(navigationResult.Success);
        Assert.Equal(exception, navigationResult.Exception);
    }

    [Fact]
    public async Task SetupNavigationResult_WhenCancelledWithException_ShouldReturnFailedNavigationResultWithDetail()
    {
        // Arrange
        var destination = "SomePage";
        var exception = new Exception("The maui navigation exploded");

        // Act
        sut.SetupNavigationResult(destination, true ,exception);

        var navigationResult = await sut.NavigateAsync(destination);

        // Assert
        Assert.False(navigationResult.Success);
        Assert.Equal(exception, navigationResult.Exception);
        Assert.True(navigationResult.Cancelled);
    }

    [Fact]
    public async Task SetupNavigationResult_WithExceptionAndParameters_ShouldReturnFailedNavigationResultWithDetail()
    {
        // Arrange
        var destination = "SomePage";
        var exception = new Exception("The maui navigation exploded");
        var navParams = new NavigationParameters()
        {
            { "Username", "Axemasta" },
            { "Score", 123 },
        };

        // Act
        sut.SetupNavigationResult(destination, exception, navParams);

        var navigationResult = await sut.NavigateAsync(destination, navParams);

        // Assert
        Assert.False(navigationResult.Success);
        Assert.Equal(exception, navigationResult.Exception);
    }

    [Fact]
    public async Task SetupNavigationResult_WhenCancelledWithExceptionAndParameters_ShouldReturnFailedNavigationResultWithDetail()
    {
        // Arrange
        var destination = "SomePage";
        var exception = new Exception("The maui navigation exploded");
        var navParams = new NavigationParameters()
        {
            { "Username", "Axemasta" },
            { "Score", 123 },
        };

        // Act
        sut.SetupNavigationResult(destination, true, exception, navParams);

        var navigationResult = await sut.NavigateAsync(destination, navParams);

        // Assert
        Assert.False(navigationResult.Success);
        Assert.Equal(exception, navigationResult.Exception);
        Assert.True(navigationResult.Cancelled);
    }

    [Fact]
    public async Task SetupNavigationResult_WhenSetupButCallingAlternativeNavigation_ShouldReturnGenericResult()
    {
        // Arrange
        var destination = "SomePage";
        var exception = new Exception("The maui navigation exploded");
        var navParams = new NavigationParameters()
        {
            { "Username", "Axemasta" },
            { "Score", 123 },
        };

        // Act
        sut.SetupNavigationResult(destination, true, exception, navParams);

        var navigationResult = await sut.NavigateAsync(destination);

        // Assert
        Assert.False(navigationResult.Success);
        Assert.Null(navigationResult.Exception);
        Assert.False(navigationResult.Cancelled);
    }

    #endregion Tests
}
