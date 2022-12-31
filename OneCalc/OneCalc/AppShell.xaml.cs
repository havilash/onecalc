namespace OneCalc;

public partial class AppShell : Shell
{
    bool OnboardingShown
    {
        get => Microsoft.Maui.Storage.Preferences.Get("OnboardingShown", false);
        set => Microsoft.Maui.Storage.Preferences.Set("OnboardingShown", value);
    }
    public AppShell()
	{

        //OnboardingShown = false;
        InitializeComponent();
        if (OnboardingShown)
            introFlyoutItem.IsVisible = false;
        else
            OnboardingShown = true;
    }
}
