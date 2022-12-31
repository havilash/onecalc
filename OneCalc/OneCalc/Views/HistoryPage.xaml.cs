namespace OneCalc.Views;

using OneCalc.ViewModels;

public partial class HistoryPage : ContentPage
{
	public HistoryPage()
	{
		InitializeComponent();
		this.BindingContext = new HistoryViewModel();
	}
}