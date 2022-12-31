using OneCalc.Models;
using OneCalc.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OneCalc.ViewModels;

public class IntroScreenViewModel : BaseViewModel
{

    #region Properties

    private string _buttonText = "Next";
    public string ButtonText
    {
        get => _buttonText;
        set => SetProperty(ref _buttonText, value);
    }

    private int _position;
    public int Position
    {
        get => _position;
        set => SetProperty(ref _position, value, onChanged: (() =>
        {
            if (value == IntroScreens.Count - 1)
            {
                ButtonText = "Start";
            }
            else
            {
                ButtonText = "Next";
            }
        }));
    }

    public ObservableCollection<IntroScreenModel> IntroScreens { get; set; } = new ObservableCollection<IntroScreenModel>();
    #endregion


    public IntroScreenViewModel()
    {
        IntroScreens.Add(new IntroScreenModel
        {
            IntroTitle = "OneCalc",
            IntroDescription = "This is my first .NET MAUI project.",
            IntroImage = "onecalc_icon.png"
        });
        IntroScreens.Add(new IntroScreenModel
        {
            IntroTitle = "Navigation",
            IntroDescription = "Using the button at the top left, you can navigate between pages.",
            IntroImage = "navigation_screenshot.png"
        });
        IntroScreens.Add(new IntroScreenModel
        {
            IntroTitle = "Calculator",
            IntroDescription = "To navigate to the scientific calculator press next or open the menu.",
            IntroImage = "calculator_screenshot.png"
        });

    }



    public ICommand NextCommand => new Command(async () =>
    {
        if (Position >= IntroScreens.Count - 1)
        {
            await AppShell.Current.GoToAsync($"//{nameof(CalculatorPage)}");
        }
        else
        {
            Position += 1;
        }
    });

    public ICommand OnOneCalcButtonClickedCommand => new Command(() =>
    {
        Shell.Current.FlyoutIsPresented = true;

    });
}