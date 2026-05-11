using Microsoft.UI.Xaml;

namespace Cioccolato.Gui;

/// <summary>
/// The main application class.
/// </summary>
public partial class App : Application
{
    private Window? _window;

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    public App()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Invoked when the application is launched. Creates and activates
    /// the main window.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        _window = new MainWindow();
        _window.Activate();
    }
}
