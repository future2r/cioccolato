using System.Globalization;
using Microsoft.UI.Xaml.Data;

namespace Cioccolato.Gui.Converters;

/// <summary>
/// Converts a <see cref="DateTime"/> to a formatted string using the format
/// supplied as the binding parameter.
/// </summary>
public sealed class DateTimeFormatConverter : IValueConverter
{
    /// <summary>
    /// Formats the given <see cref="DateTime"/> using the supplied format string.
    /// </summary>
    /// <param name="value">The <see cref="DateTime"/> to format.</param>
    /// <param name="targetType">The target binding type. Unused.</param>
    /// <param name="parameter">A .NET date and time format string.</param>
    /// <param name="language">The binding language tag (e.g. "en-US"). Unused.</param>
    /// <returns>The formatted date string, or an empty string if the input is not a <see cref="DateTime"/>.</returns>
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is DateTime dateTime)
        {
            var format = parameter as string ?? "g";
            return dateTime.ToString(format, CultureInfo.CurrentCulture);
        }
        return string.Empty;
    }

    /// <summary>
    /// Not supported. One-way conversion only.
    /// </summary>
    public object ConvertBack(object value, Type targetType, object parameter, string language) =>
        throw new NotSupportedException();
}
