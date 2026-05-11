namespace Cioccolato.Core;

/// <summary>
/// Provides access to the chocolate variety data store.
/// </summary>
public class Database
{
    private readonly List<Variety> _varieties =
    [
        new("Dark", new DateTime(2025, 1, 15)),
        new("Milk", new DateTime(2025, 2, 20)),
        new("White", new DateTime(2025, 3, 10)),
        new("Hazelnut", new DateTime(2025, 4, 5)),
        new("Ruby", new DateTime(2025, 5, 12)),
    ];

    /// <summary>
    /// Gets the list of all chocolate varieties.
    /// </summary>
    public IReadOnlyList<Variety> Varieties => _varieties.AsReadOnly();
}
