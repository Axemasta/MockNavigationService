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
            var viewModel = destination.Replace("Page", "ViewModel", StringComparison.InvariantCultureIgnoreCase);

            return new List<string>()
            {
                destination,
                viewModel
            };
        }
        else if (destination.EndsWith("ViewModel", StringComparison.InvariantCultureIgnoreCase))
        {
            var page = destination.Replace("ViewModel", "Page", StringComparison.InvariantCultureIgnoreCase);

            return new List<string>()
            {
                destination,
                page
            };
        }
        else
        {
            return new List<string>()
            {
                destination,
            };
        }
    }
}
