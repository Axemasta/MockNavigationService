namespace MockNavigationService.Sample.Views;

public partial class ContactListPage : ContentPage
{
	public ContactListPage()
	{
		InitializeComponent();

		NavigationPage.SetBackButtonTitle(this, "Back");
	}
}
