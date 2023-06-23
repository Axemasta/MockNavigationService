using MockNavigationService.Helpers;
using Moq;

namespace MockNavigationService.Extensions;

public static class VerificationExtension
{
    /// <summary>
    /// Verifies Navigation
    /// </summary>
    /// <param name="mockNavigationService">Instance of mock navigation service to setup</param>
    /// <param name="destination">The destination to validate</param>
    /// <param name="times">Times invokation occurred</param>
    /// <param name="navigationParameters">The navigation parameters passed to navigation</param>
    public static void VerifyNavigation(this MockNavigationService mockNavigationService, string destination, Times times, INavigationParameters? navigationParameters = null)
    {
        var validDestinations = DestinationHelper.GetValidDestinations(destination);

        if (navigationParameters is null)
        {
            mockNavigationService.Verify(
                m => m.NavigateAsync(
                    It.Is<Uri>(u => validDestinations.Any(v => u.Equals(v))),
                    It.IsAny<INavigationParameters>()),
                times);
        }
        else
        {
            mockNavigationService.Verify(
                m => m.NavigateAsync(
                    It.Is<Uri>(u => validDestinations.Any(v => u.Equals(v))),
                    It.Is<INavigationParameters>(n => EquivalenceHelper.Equivalent(n, navigationParameters))),
                times);
        }
    }
}
