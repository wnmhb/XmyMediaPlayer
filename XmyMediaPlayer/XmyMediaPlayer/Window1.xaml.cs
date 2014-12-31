using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace XmyMediaPlayer
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Window1_Loaded);
        }

        void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                FileStream fs = new FileStream("image.png", FileMode.Create);
                RenderTargetBitmap bmp = new RenderTargetBitmap((int)this.SystemIcon.Width, (int)this.SystemIcon.Height, 96d, 96d, PixelFormats.Pbgra32);
                bmp.Render(this.SystemIcon);
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bmp));
                encoder.Save(fs);
                fs.Close();
                fs.Dispose();

            }
            catch (Exception)
            {

            }
        }
    }
}
