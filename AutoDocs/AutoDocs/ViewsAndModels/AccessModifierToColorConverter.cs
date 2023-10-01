using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using static System.Windows.Media.ColorConverter;

namespace AutoDocs.ViewsAndModels
{
    public class AccessModifierToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string modifier) || targetType == null || parameter == null || culture == null)
                return new SolidColorBrush((Color)ConvertFromString("#BBCAD5"));

            switch (modifier.ToLower())
            {
                case "private":
                    return new SolidColorBrush((Color)ConvertFromString("#ED9494"));
                case "public":
                    return new SolidColorBrush((Color)ConvertFromString("#A7ED94"));
                case "protected":
                    return new SolidColorBrush((Color)ConvertFromString("#94D2ED"));
                case "constant":
                    return new SolidColorBrush((Color)ConvertFromString("#ED94DD"));
                default:
                    return new SolidColorBrush((Color)ConvertFromString("#BBCAD5"));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}