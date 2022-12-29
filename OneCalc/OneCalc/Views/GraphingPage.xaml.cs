using OneCalc.ViewModels;

namespace OneCalc.Views;

public partial class GraphingPage : ContentPage
{
	public GraphingPage()
	{
		InitializeComponent();
		this.BindingContext = new GraphingViewModel();
	}
}