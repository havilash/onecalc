namespace OneCalc;

public partial class App : Application
{
	const string Title = nameof(OneCalc);

	const int Width = 340;
	const int Height = 540;

	const int X = 100;
	const int Y = 100;

	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

    protected override Window CreateWindow(IActivationState activationState)
    {
        Window window = base.CreateWindow(activationState);

		if (window == null)
			return window;

		window.Title = Title;

		window.Width = Width;
		window.Height = Height;

		window.MaximumWidth = Width; 
		window.MaximumHeight = Height;
		window.MinimumWidth = Width; 
		window.MinimumHeight = Height;

		window.X = X;
		window.Y = Y;


		return window;
    }
}
