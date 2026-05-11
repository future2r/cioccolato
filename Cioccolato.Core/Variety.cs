namespace Cioccolato.Core;

/// <summary>
/// Represents a chocolate variety with a name and creation date.
/// </summary>
/// <param name="Name">The name of the variety.</param>
/// <param name="CreatedAt">The date and time the variety was created.</param>
public sealed record Variety(string Name, DateTime CreatedAt)
{
    /// <summary>
    /// Initializes a new variety with the current date and time.
    /// </summary>
    /// <param name="name">The name of the variety.</param>
    public Variety(string name) : this(name, DateTime.Now) { }

    /// <summary>
    /// Gets the name of the variety.
    /// </summary>
    public string Name { get; init; } = Name ?? throw new ArgumentNullException(nameof(Name));
}
