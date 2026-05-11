using System.IO;
using Cioccolato.Gui.Resources.Strings;
using Cioccolato.Gui.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Windows.System;

namespace Cioccolato.Gui;

/// <summary>
/// The main window displaying the chocolate variety list.
/// </summary>
public sealed partial class MainWindow : Window
{
    /// <summary>
    /// Gets the view model bound to this window.
    /// </summary>
    public MainWindowViewModel ViewModel { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/> class.
    /// </summary>
    public MainWindow()
    {
        ViewModel = new MainWindowViewModel();
        InitializeComponent();
        Title = AppStrings.WindowTitle;
        AppWindow.SetIcon(Path.Combine(AppContext.BaseDirectory, "Resources", "Images", "cioccolato.ico"));
    }

    private void NewVarietyTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
    {
        if (e.Key == VirtualKey.Enter && ViewModel.AddCommand.CanExecute(null))
        {
            ViewModel.AddCommand.Execute(null);
            e.Handled = true;
        }
    }

    private void VarietiesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        foreach (var removed in e.RemovedItems)
        {
            ViewModel.SelectedVarieties.Remove(removed);
        }

        foreach (var added in e.AddedItems)
        {
            if (!ViewModel.SelectedVarieties.Contains(added))
            {
                ViewModel.SelectedVarieties.Add(added);
            }
        }
    }

    private void VarietiesListView_KeyDown(object sender, KeyRoutedEventArgs e)
    {
        if (e.Key == VirtualKey.Delete && ViewModel.RemoveCommand.CanExecute(null))
        {
            ViewModel.RemoveCommand.Execute(null);
            e.Handled = true;
        }
    }
}
