using MockNavigationService.Helpers;
using Moq;

namespace MockNavigationService.Extensions;

public static class SetupExtension
{
    /// <summary>
    /// Setup Navigation Result.
    /// This is the simple setup and will only populate Success
    /// </summary>
    /// <param name="mockNavigationService">Instance of mock navigation service to setup</param>
    /// <param name="destination">The navigation target</param>
    /// <param name="success">Whether the navigation suceeds</param>
    /// <param name="navigationParameters">The navigation parameters for navigation</param>
    public static void SetupNavigationResult(this MockNavigationService mockNavigationService, string destination, bool success, INavigationParameters? navigationParameters = null)
    {
        SetupNavigationResultInternal(mockNavigationService, destination, success, navigationParameters);
    }

    /// <summary>
    /// Setup Navigation Result With Exception.
    /// This will set Success to false and populate the exception property of the navigation result.
    /// </summary>
    /// <param name="mockNavigationService">Instance of mock navigation service to setup</param>
    /// <param name="destination">The navigation target</param>
    /// <param name="exception">The exception to throw during navigation</param>
    /// <param name="navigationParameters">The navigation parameters for navigation</param>
    public static void SetupNavigationResult(this MockNavigationService mockNavigationService, string destination, Exception exception, INavigationParameters? navigationParameters = null)
    {
        SetupNavigationResultInternal(mockNavigationService, destination, false, navigationParameters, exception);
    }

    /// <summary>
    /// Setup Navigation Result With Exception.
    /// This will set Success to false and populate the exception property of the navigation result.
    /// Cancelled will be set according to the given parameter.
    /// </summary>
    /// <param name="mockNavigationService">Instance of mock navigation service to setup</param>
    /// <param name="destination">The navigation target</param>
    /// <param name="cancelled">Whether the navigation was cancelled</param>
    /// <param name="exception">The exception to throw during navigation</param>
    /// <param name="navigationParameters"><The navigation parameters for navigation/param>
    public static void SetupNavigationResult(this MockNavigationService mockNavigationService, string destination, bool cancelled, Exception exception, INavigationParameters? navigationParameters = null)
    {
        SetupNavigationResultInternal(mockNavigationService, destination, false, navigationParameters, exception, cancelled);
    }

    private static void SetupNavigationResultInternal(MockNavigationService mockNavigationService, string destination, bool success, INavigationParameters? navigationParameters = null, Exception? navigationException = null, bool? cancelled = null)
    {
        var mockResult = new Mock<INavigationResult>();

        mockResult.SetupGet(m => m.Success)
            .Returns(success);

        if (navigationException is not null)
        {
            mockResult.SetupGet(m => m.Exception)
                .Returns(navigationException);
        }

        if (cancelled.HasValue)
        {
            mockResult.SetupGet(m => m.Cancelled)
                .Returns(cancelled.Value);
        }

        var destinations = DestinationHelper.GetValidDestinations(destination);

        foreach (var validDestination in destinations)
        {
            if (navigationParameters is null)
            {
                mockNavigationService.Setup(
                    m => m.NavigateAsync(
                        It.Is<Uri>(u => u.Equals(validDestination)),
                        It.IsAny<INavigationParameters>())) // This will be null
                    .ReturnsAsync(mockResult.Object);
            }
            else
            {
                mockNavigationService.Setup(
                    m => m.NavigateAsync(
                        It.Is<Uri>(u => u.Equals(validDestination)),
                        It.Is<INavigationParameters>(n => EquivalenceHelper.Equivalent(n, navigationParameters))))
                    .ReturnsAsync(mockResult.Object);
            }
        }
    }
}
