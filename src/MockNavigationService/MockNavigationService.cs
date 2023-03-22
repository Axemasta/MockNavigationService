using Moq;
using Prism.Common;

namespace MockNavigationService;

public class MockNavigationService : Mock<INavigationService>, INavigationService, IRegistryAware
{
    private IViewRegistry viewRegistry;

    public MockNavigationService()
    {
        viewRegistry = new MockViewRegistry();

        var mockResult = new Mock<INavigationResult>();

        mockResult.SetupGet(m => m.Success)
            .Returns(false);

        this.Setup(m => m.NavigateAsync(It.IsAny<Uri>(), It.IsAny<INavigationParameters>()))
            .ReturnsAsync(mockResult.Object);
    }

    #region INavigationService

    public Task<INavigationResult> GoBackAsync(INavigationParameters parameters)
    {
        return Object.GoBackAsync(parameters);
    }

    public Task<INavigationResult> GoBackToAsync(string name, INavigationParameters parameters)
    {
        return Object.GoBackToAsync(name, parameters);
    }

    public Task<INavigationResult> GoBackToRootAsync(INavigationParameters parameters)
    {
        return Object.GoBackToRootAsync(parameters);
    }

    public Task<INavigationResult> NavigateAsync(Uri uri, INavigationParameters parameters)
    {
        return Object.NavigateAsync(uri, parameters);
    }

    #endregion INavigationService

    #region IRegistryAware

    public IViewRegistry Registry => viewRegistry;

    #endregion IRegistryAware

    private class MockViewRegistry : IViewRegistry
    {
        public IEnumerable<ViewRegistration> Registrations { get; } = new List<ViewRegistration>();

        public object CreateView(IContainerProvider container, string name)
        {
            return name;
        }

        public string GetViewModelNavigationKey(Type viewModelType)
        {
            return viewModelType.Name;
        }

        public Type GetViewType(string name)
        {
            return name.GetType();
        }

        public bool IsRegistered(string name)
        {
            return true;
        }

        public IEnumerable<ViewRegistration> ViewsOfType(Type baseType)
        {
            return Registrations;
        }
    }
}
