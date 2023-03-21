using Moq;

namespace Axemasta.MockNavigationService.Abstractions
{
    public interface IMockNavigationService
    {
        void SetupNavigationResult(string destination, bool success);

        void SetupNavigationResult(string destination, INavigationParameters navigationParameters, bool success);

        void VerifyNavigation(string destination, Times times);

        void VerifyNavigation(string destination, INavigationParameters navigationParameters, Times times);
    }
}
