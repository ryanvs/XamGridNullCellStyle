using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace XamGridNullCellStyle
{
    [ValueConversion(typeof(object), typeof(bool))]
    public class IsNullConverter : MarkupExtension, IValueConverter
    {
        #region MarkupExtension support
        public static readonly IsNullConverter instance = new IsNullConverter();
        public static IsNullConverter Instance { get { return instance; } }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Instance;
        }
        #endregion

        #region Conversion
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value == null) || value == DBNull.Value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("IsNullConverter can only be used OneWay.");
        }
        #endregion
    }
}
