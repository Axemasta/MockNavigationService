using FluentAssertions;

namespace Axemasta.MockNavigationService.Helpers;

internal class EquivalenceHelper
{
    public static bool Equivalent(object a, object b)
    {
        try
        {
            if (a.Equals(b))
            {
                return true;
            }

            a.Should().BeEquivalentTo(b);

            return true;
        }
        catch
        {
            return false;
        }
    }
}
