using Axemasta.MockNavigationService.Helpers;
using Moq;

namespace Axemasta.MockNavigationService.Extensions
{
    public static class SetupExtensions
    {
        public static void SetupNavigationResult(this MockNavigationService mockNavigationService, string destination, bool success)
        {
            var mockResult = new Mock<INavigationResult>();

            mockResult.SetupGet(m => m.Success)
                .Returns(success);

            mockNavigationService.Setup(
                m => m.NavigateAsync(
                    It.Is<Uri>(u => u.Equals(destination)),
                    It.IsAny<INavigationParameters>()))
                .ReturnsAsync(mockResult.Object);
        }

        public static void SetupNavigationResult(this MockNavigationService mockNavigationService, string destination, bool success, INavigationParameters navigationParameters)
        {
            var mockResult = new Mock<INavigationResult>();

            mockResult.SetupGet(m => m.Success)
                .Returns(success);

            var destinations = DestinationHelper.GetValidDestinations(destination);

            foreach (var validDestination in destinations)
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
