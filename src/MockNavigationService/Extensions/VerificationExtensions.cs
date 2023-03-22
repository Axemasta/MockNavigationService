using MockNavigationService.Helpers;
using Moq;

namespace MockNavigationService.Extensions;

public static class VerificationExtensions
{
    public static void VerifyNavigation(this MockNavigationService mockNavigationService, string destination, Times times)
    {
        var validDestinations = DestinationHelper.GetValidDestinations(destination);

        mockNavigationService.Verify(
            m => m.NavigateAsync(
                It.Is<Uri>(u => u.Equals(destination)),
                It.IsAny<INavigationParameters>()),
            times);
    }

    public static void VerifyNavigation(this MockNavigationService mockNavigationService, string destination, INavigationParameters navigationParameters, Times times)
    {
        var validDestinations = DestinationHelper.GetValidDestinations(destination);

        mockNavigationService.Verify(
            m => m.NavigateAsync(
                It.Is<Uri>(u => validDestinations.Any(v => u.Equals(v))),
                It.Is<INavigationParameters>(n => EquivalenceHelper.Equivalent(n, navigationParameters))),
            times);
    }
}
