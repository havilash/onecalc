using OneCalc.ViewModels;
using System.Windows.Input;

namespace OneCalc.Views;

public partial class InfoPage : ContentPage
{
	public InfoPage()
	{
		InitializeComponent();
		this.BindingContext = new InfoViewModel();
	}

    async public void GoToContact(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new ContactPage());

    }
}