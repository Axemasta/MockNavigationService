using System;

namespace MockNavigationService.Sample.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel(INavigationService navigationService)
        : base(navigationService)
    {
        Title = "Mock Navigation";
    }
}

