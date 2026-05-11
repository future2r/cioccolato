using Cioccolato.Core;

namespace Cioccolato.Gui.ViewModels;

/// <summary>
/// Wraps a <see cref="Variety"/> for display in the UI.
/// </summary>
/// <param name="variety">The variety to wrap.</param>
public sealed class VarietyItem(Variety variety)
{
    private readonly Variety _variety = variety ?? throw new ArgumentNullException(nameof(variety));

    /// <summary>
    /// Gets the name of the variety.
    /// </summary>
    public string Name => _variety.Name;

    /// <summary>
    /// Gets the date and time the variety was created.
    /// </summary>
    public DateTime CreatedAt => _variety.CreatedAt;
}
