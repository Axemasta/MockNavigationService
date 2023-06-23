namespace MockNavigationService.Helpers;

/// <summary>
/// Destination Helper
/// </summary>
internal class DestinationHelper
{
    /// <summary>
    /// Prism Uri navigation can now be either Page or ViewModel based. This means that if the user
    /// sets up MainPage but uses the navigation builder then their verification will fail since it
    /// will build a Uri with the viewmodel name, not the page name this method makes it easier to
    /// setup verification uri's
    /// </summary>
    /// <param name="destination"></param>
    /// <returns></returns>
    public static List<string> GetValidDestinations(string destination)
    {
        if (destination.EndsWith("Page", StringComparison.InvariantCultureIgnoreCase))
        {
            // MainPage Passed in, Valid Destinations:
            // - MainViewModel
            // - MainPageViewModel

            var viewModel = destination.Replace("Page", "ViewModel", StringComparison.InvariantCultureIgnoreCase);
            var pageViewModel = destination.Replace("Page", "PageViewModel", StringComparison.InvariantCultureIgnoreCase);

            return new List<string>()
            {
                destination,
                viewModel,
                pageViewModel,
            };
        }
        else if (destination.EndsWith("ViewModel", StringComparison.InvariantCultureIgnoreCase))
        {
            // MainViewModel Passed in, Valid Destinations:
            // - MainViewModel
            // - MainPageViewModel

            var page = destination.Replace("ViewModel", "Page", StringComparison.InvariantCultureIgnoreCase);

            if (page.EndsWith("PagePage"))
            {
                page = page.Remove(page.Length - 4, 4);
            }

            return new List<string>()
            {
                destination,
                page,
            };
        }
        else
        {
            // Maybe this doesn't help, should we warn the consumer?

            return new List<string>()
            {
                destination,
            };
        }
    }
}
