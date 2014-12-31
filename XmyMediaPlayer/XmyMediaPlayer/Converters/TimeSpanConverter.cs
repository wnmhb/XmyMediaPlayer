using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmyMediaPlayer
{
    public class TimeSpanConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                var ts = TimeSpan.FromMilliseconds((double)value);
                return string.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
            }
            catch
            {
                return "00:00:00";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
