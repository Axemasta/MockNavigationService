using CommunityToolkit.Mvvm.ComponentModel;

namespace MockNavigationService.Sample.ViewModels.Base;

public class ViewModelBase : ObservableObject, INavigationAware
{
    private bool isBusy;

    public bool IsBusy
    {
        get => isBusy;
        set => SetProperty(ref isBusy, value);
    }

    private string title;

    public string Title
    {
        get => title;
        set => SetProperty(ref title, value);
    }

    protected INavigationService navigationService { get; }

    public ViewModelBase(INavigationService navigationService)
    {
        this.navigationService = navigationService;
    }

    public virtual void OnNavigatedFrom(INavigationParameters parameters) { }

    public virtual void OnNavigatedTo(INavigationParameters parameters) { }
}

