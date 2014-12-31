using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Threading;
using log4net;
using System.Windows.Markup;
using System.Globalization;
using System.IO;
using XmyMediaPlayer.Controls;
using System.Diagnostics;

namespace XmyMediaPlayer
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public static EventWaitHandle ProgramStarted;
        private bool CreatedNew;

        public static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected override void OnStartup(StartupEventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();

            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), 
                new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

            string mediaFile = string.Empty;
            //从命令提示符或桌面传递到应用程序的命令行参数中，得到需要打开的文件列表
            foreach (string argTypeMediaFile in e.Args)
            {
                if (System.IO.File.Exists(argTypeMediaFile) && Path.GetExtension(argTypeMediaFile).ToLower() == ".mp3")
                {
                    mediaFile = argTypeMediaFile;
                }
            }

            ProgramStarted = new EventWaitHandle(false, EventResetMode.AutoReset, "MyStartEvent", out CreatedNew);

            if (CreatedNew)
            {
                try
                {
                    MainWindow mainWin = new MainWindow();
                    mainWin.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    mainWin.Show();
                    mainWin.Play(mediaFile);
                    base.MainWindow = mainWin;
                }
                catch (Exception err)
                {
                    WPFMessageBox.Show("系统启动失败！", "错误提示");
                    log.Error("系统启动失败!\n" + typeof(App).ToString() + "\tOnStartup\t" + err.Message);
                    Current.Shutdown(2);
                    log.Info("<<<========================End==");
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(mediaFile))
                {
                    //将需要打开的文件写入到系统系统通知文件中，当然也可以写注册表
                    File.WriteAllText(Global.SystemNoticeFile, mediaFile, System.Text.Encoding.UTF8);
                    //通知另一个进程可以读取临时文件夹中的路径
                    ProgramStarted.Set();
                }
                Thread.Sleep(100);

                Process current = Process.GetCurrentProcess();
                foreach (Process process in Process.GetProcessesByName(current.ProcessName))
                {
                    if (process.Id != current.Id){
                        NativeMethods.SetForegroundWindow(process.MainWindowHandle);
                        NativeMethods.ShowWindow(process.MainWindowHandle, WindowShowStyle.Restore);
                        break;
                    }
                }
                Environment.Exit(-2);
            }
            log.Info("==Startup=====================>>>");
        }
    }
}
