using System.Globalization;

namespace OneCalc.Converters;

public class ColumnRowConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        // Convert the bound value to a Grid.Column or Grid.Row value
        // depending on the parameter.
        return parameter switch
        {
            "Column" => Grid.GetColumn((BindableObject)value),
            "Row" => Grid.GetRow((BindableObject)value),
            _ => throw new InvalidOperationException($"Unknown parameter: {parameter}")
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        // Not needed for this example, so we can throw an exception.
        throw new NotImplementedException();
    }
}