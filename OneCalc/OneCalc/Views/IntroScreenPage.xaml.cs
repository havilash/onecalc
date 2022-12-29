using OneCalc.Models;
using OneCalc.ViewModels;

namespace OneCalc.Views;

public partial class IntroScreenPage : ContentPage
{
	public IntroScreenPage()
	{
		InitializeComponent();
		this.BindingContext = new IntroScreenViewModel();
	}
}