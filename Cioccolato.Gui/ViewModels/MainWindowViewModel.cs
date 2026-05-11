using System.Collections.ObjectModel;
using Cioccolato.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Cioccolato.Gui.ViewModels;

/// <summary>
/// View model for the main window, managing chocolate varieties.
/// </summary>
public partial class MainWindowViewModel : ObservableObject
{
    private readonly Database _database = new();

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AddCommand))]
    private string _newVarietyName = string.Empty;

    /// <summary>
    /// Gets the collection of chocolate varieties.
    /// </summary>
    public ObservableCollection<VarietyItem> Varieties { get; } = [];

    /// <summary>
    /// Gets the collection of currently selected varieties.
    /// </summary>
    public ObservableCollection<object> SelectedVarieties { get; } = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
    /// </summary>
    public MainWindowViewModel()
    {
        foreach (var variety in _database.Varieties)
        {
            Varieties.Add(new VarietyItem(variety));
        }

        Varieties.CollectionChanged += (_, _) =>
        {
            RemoveAllCommand.NotifyCanExecuteChanged();
            AddCommand.NotifyCanExecuteChanged();
        };

        SelectedVarieties.CollectionChanged += (_, _) =>
        {
            RemoveCommand.NotifyCanExecuteChanged();
        };
    }

    private bool CanAdd() =>
        !string.IsNullOrWhiteSpace(NewVarietyName)
        && !Varieties.Any(v => string.Equals(v.Name, NewVarietyName.Trim(), StringComparison.OrdinalIgnoreCase));

    [RelayCommand(CanExecute = nameof(CanAdd))]
    private void Add()
    {
        Varieties.Add(new VarietyItem(new Variety(NewVarietyName.Trim())));
        NewVarietyName = string.Empty;
    }

    private bool CanRemove() =>
        SelectedVarieties.Count > 0;

    [RelayCommand(CanExecute = nameof(CanRemove))]
    private void Remove()
    {
        var items = SelectedVarieties.Cast<VarietyItem>().ToList();
        var firstIndex = items.Min(item => Varieties.IndexOf(item));

        foreach (var item in items)
        {
            Varieties.Remove(item);
        }

        if (Varieties.Count > 0)
        {
            var nextIndex = Math.Min(firstIndex, Varieties.Count - 1);
            SelectedVarieties.Add(Varieties[nextIndex]);
        }
    }

    private bool CanRemoveAll() =>
        Varieties.Count > 0;

    [RelayCommand(CanExecute = nameof(CanRemoveAll))]
    private void RemoveAll()
    {
        Varieties.Clear();
    }
}
