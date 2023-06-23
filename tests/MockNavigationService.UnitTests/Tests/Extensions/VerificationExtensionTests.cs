using MockNavigationService.Extensions;

namespace MockNavigationService.UnitTests.Tests.Extensions;

public class VerificationExtensionTests
{
    #region Setup

    private MockNavigationService sut;

    public VerificationExtensionTests()
    {
        sut = new MockNavigationService();
    }

    #endregion Setup

    #region Tests

    [Fact]
    public void VerifyNavigation_WhenNoNavigationOccurred_ShouldThrow()
    {
        // Arrange

        // Act
        var ex = Record.Exception(() => sut.VerifyNavigation("SomePage", Times.Once(), null));

        // Assert
        Assert.NotNull(ex);
    }

    [Fact]
    public async Task VerifyNavigation_WhenDestinationDidntMatch_ShouldThrow()
    {
        // Arrange
        await sut.NavigateAsync("SomePage");

        // Act
        var ex = Record.Exception(() => sut.VerifyNavigation("AlternativePage", Times.Once(), null));

        // Assert
        Assert.NotNull(ex);
    }

    [Fact]
    public async Task VerifyNavigation_WhenTimesDidntMatch_ShouldThrow()
    {
        // Arrange
        var destination = "SomePage";

        await sut.NavigateAsync(destination);
        await sut.NavigateAsync(destination);
        await sut.NavigateAsync(destination);

        // Act
        var ex = Record.Exception(() => sut.VerifyNavigation(destination, Times.Once(), null));

        // Assert
        Assert.NotNull(ex);
    }

    [Fact]
	public async Task VerifyNavigation_WhenCriteriaMatchedWithoutNavigationParameters_ShouldNotThrow()
	{
        // Arrange
        var destination = "SomePage";

        await sut.NavigateAsync(destination);

        // Act
        var ex = Record.Exception(() => sut.VerifyNavigation(destination, Times.Once(), null));

        // Assert
        Assert.Null(ex);
    }

    [Fact]
    public async Task VerifyNavigation_WhenCriteriaMatchedWithNavigationParameters_ShouldNotThrow()
    {
        // Arrange
        var destination = "SomePage";
        var parameters = new NavigationParameters()
        {
            { "UserName", "Axemasta" },
        };

        await sut.NavigateAsync(destination, parameters);

        // Act
        var ex = Record.Exception(() => sut.VerifyNavigation(destination, Times.Once(), parameters));

        // Assert
        Assert.Null(ex);
    }

    [Theory]
    [InlineData(2)]
    [InlineData(5)]
    public async Task VerifyNavigation_WhenCriteriaMatchedWithMultipleParameterlessNavigations_ShouldNotThrow(int times)
    {
        // Arrange
        var destination = "SomePage";

        for (int i = 0; i < times; i++)
        {
            await sut.NavigateAsync(destination);
        }

        // Act
        var ex = Record.Exception(() => sut.VerifyNavigation(destination, Times.Exactly(times), null));

        // Assert
        Assert.Null(ex);
    }

    [Theory]
    [InlineData(2)]
    [InlineData(5)]
    public async Task VerifyNavigation_WhenCriteriaMatchedWithMultipleParameterNavigations_ShouldNotThrow(int times)
    {
        // Arrange
        var destination = "SomePage";
        var parameters = new NavigationParameters()
        {
            { "UserName", "Axemasta" },
        };

        for (int i = 0; i < times; i++)
        {
            await sut.NavigateAsync(destination, parameters);
        }

        // Act
        var ex = Record.Exception(() => sut.VerifyNavigation(destination, Times.Exactly(times), parameters));

        // Assert
        Assert.Null(ex);
    }

    #endregion Tests
}

