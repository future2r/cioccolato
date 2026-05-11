using System.Globalization;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;

namespace Cioccolato.Gui;

/// <summary>
/// Application entry point for the unpackaged WinUI 3 app.
/// </summary>
public static class Program
{
    /// <summary>
    /// Application main method. Parses command line arguments, initializes
    /// the WinUI 3 runtime, and starts the application.
    /// </summary>
    /// <param name="args">The command line arguments.</param>
    [STAThread]
    public static void Main(string[] args)
    {
        ApplyCultureFromArgs(args);

        WinRT.ComWrappersSupport.InitializeComWrappers();
        Application.Start(p =>
        {
            var context = new DispatcherQueueSynchronizationContext(
                DispatcherQueue.GetForCurrentThread());
            SynchronizationContext.SetSynchronizationContext(context);
            new App();
        });
    }

    private static void ApplyCultureFromArgs(string[] args)
    {
        var langArg = args.FirstOrDefault(a => a.StartsWith("--lang=", StringComparison.OrdinalIgnoreCase));
        if (langArg != null)
        {
            var culture = new CultureInfo(langArg.Substring("--lang=".Length));
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }
    }
}
