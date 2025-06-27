using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TodoList
{
    class BoolToTextDecorationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isCompleted = (bool)value;
            return isCompleted ? TextDecorations.Strikethrough : null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
