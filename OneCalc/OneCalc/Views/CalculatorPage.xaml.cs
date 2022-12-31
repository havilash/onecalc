using OneCalc.Models;
using OneCalc.ViewModels;
namespace OneCalc.Views;

using org.matheval;
using System.Data;
using System.Windows.Input;

public partial class CalculatorPage : ContentPage
{
    private CalculatorViewModel calculatorViewModel = new CalculatorViewModel();

    public CalculatorPage() {
        InitializeComponent();
        this.BindingContext = calculatorViewModel;

    }

    private void OnOperatorButtonClicked(object sender, EventArgs e)
    {
        calculatorViewModel.OnOperatorButtonClicked(sender, e);
    }

    async public void GoToHistoryPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HistoryPage());

    }
}