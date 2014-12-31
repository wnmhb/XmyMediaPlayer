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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Windows.Threading;
using XmyMediaPlayer.Controls;
using System.Threading;
using System.IO;
using Microsoft.Win32;

namespace XmyMediaPlayer
{
    /// <summary>
    /// VideoPlayWin.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        #region ===实例化===

        public MainWindow()
        {
            InitializeComponent();
            SetMainWindowDefaultSize();
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ThreadPool.RegisterWaitForSingleObject(App.ProgramStarted, OnProgramStarted, null, -1, false);

            SystemEvents.DisplaySettingsChanged += (se, ee) => {
                SetMainWindowDefaultSize();
            };
            IsPlayPause = false;
            this.DataContext = this;
        }

        /// <summary>
        /// 主线程在接收到其他线程通知后回调函数
        /// </summary>
        /// <param name="state"></param>
        /// <param name="timeout"></param>
        private void OnProgramStarted(object state, bool timeout)
        {
            //从系统数据文件夹中读取需要打开的文件
            string openFile = File.ReadAllText(Global.SystemNoticeFile,Encoding.UTF8);
            if (!string.IsNullOrEmpty(openFile))
            {
                this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (System.Threading.ThreadStart)delegate()
                {
                    Play(openFile);
                });
            }
        }

        private void SetMainWindowDefaultSize() {
            this.Width = SystemParameters.FullPrimaryScreenWidth * 0.5;
            this.Height = SystemParameters.PrimaryScreenHeight * 0.6;
        }

        #endregion

        #region ===属性===

        private string videoTitle;

        /// <summary>
        /// 当前正在播放的音频视频文件名称
        /// </summary>
        public string VideoTitle
        {
            get { return videoTitle; }
            set
            {
                videoTitle = value;
                OnPropertyChanged("VideoTitle");
            }
        }

        public bool isPlayPause;
        /// <summary>
        /// 是否正在播放
        /// </summary>
        public bool IsPlayPause
        {
            get { return isPlayPause; }
            set
            {
                PlayControl.ToolTip = value ? "点击继续播放" : "点击停止播放";
                isPlayPause = value;
                OnPropertyChanged("IsPlayPause");
            }
        }

        /// <summary>
        /// 当前播放进度
        /// </summary>
        public double CurrentTime
        {
            get
            {
                return mediaElement.Position.TotalMilliseconds;
            }
            set
            {
                mediaElement.Position = TimeSpan.FromMilliseconds(value);
            }
        }

        /// <summary>
        /// 当前视频时长
        /// </summary>
        public double DurationTime
        {
            get
            {
                if (mediaElement.NaturalDuration.HasTimeSpan)
                    return mediaElement.NaturalDuration.TimeSpan.TotalMilliseconds;
                return double.NaN;
            }
        }

        /// <summary>
        /// 当前正在播放的音频视频文件绝对路径
        /// </summary>
        private string videoUrl;

        private DispatcherTimer timer;

        #endregion

        internal void Play(string VideoUrl)
        {
            if (string.IsNullOrEmpty(VideoUrl))
                return;
            this.videoUrl = VideoUrl;
            this.VideoTitle = System.IO.Path.GetFileName(VideoUrl);

            mediaElement.Source = new Uri(VideoUrl, UriKind.Relative);
            mediaElement.Play();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;

            mediaElement.MediaOpened += (ss, ee) =>
            {
                OnPropertyChanged("DurationTime");
                timer.Start();
            };

            //发生错误和视频播放完毕 停止计时器
            mediaElement.MediaEnded += (ss, ee) =>
            {
                timer.Stop();
                IsPlayPause = true;
            };
            mediaElement.MediaFailed += (ss, ee) =>
            {
                timer.Stop();
                IsPlayPause = true;
            };
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.OnPropertyChanged("CurrentTime");
        }

        private void PlayControl_Click(object sender, RoutedEventArgs e)
        {
            MediaPlay();
        }

        private void mediaElement_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //修改状态
            IsPlayPause = !IsPlayPause;
            MediaPlay();
        }

        /// <summary>
        /// 播放和暂停
        /// </summary>
        private void MediaPlay()
        {
            if (IsPlayPause == true)
            {
                mediaElement.Pause();
                timer.Stop();
            }
            else
            {
                mediaElement.Play();
                timer.Start();
            }
        }
        
        //后退
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Position = mediaElement.Position - TimeSpan.FromMilliseconds(DurationTime / 60);
        }

        //前进
        private void forwardBtn_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Position = mediaElement.Position + TimeSpan.FromMilliseconds(DurationTime / 60);
        }

        private void slider_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            timer.Stop();

            IsPlayPause = true;
            mediaElement.Pause();
        }

        private void slider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            CurrentTime = slider.Value;
            timer.Start();

            IsPlayPause = false;
            mediaElement.Play();
        }

        #region PropertyChanged

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this,
                    new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

        #endregion

        private void mediaElement_TouchDown(object sender, TouchEventArgs e)
        {

        }

        ///// <summary>
        ///// 导出系统图标
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void SystemIcon_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        FileStream fs = new FileStream("image.png", FileMode.Create);
        //        RenderTargetBitmap bmp = new RenderTargetBitmap((int)this.SystemIcon.Width, (int)this.SystemIcon.Height+20, 96d, 96d, PixelFormats.Pbgra32);
        //        bmp.Render(this.SystemIcon);
        //        BitmapEncoder encoder = new PngBitmapEncoder();
        //        encoder.Frames.Add(BitmapFrame.Create(bmp));
        //        encoder.Save(fs);
        //        fs.Close();
        //        fs.Dispose();
        //    }
        //    catch (Exception)
        //    {

        //    }
        //}
    }
}
