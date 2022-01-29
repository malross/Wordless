using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Wordle.Converters
{
    public class LetterStatusToForegroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case LetterStatus.NotSubmitted:
                    return Brushes.Black;
                case LetterStatus.NotInWord:
                case LetterStatus.InWrongPlace:
                case LetterStatus.InRightPlace:
                    return Brushes.White;
                default:
                    return Brushes.Black;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
