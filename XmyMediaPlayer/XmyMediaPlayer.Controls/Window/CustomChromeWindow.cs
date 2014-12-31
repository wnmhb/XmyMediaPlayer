using System;
using System.Windows;
using System.Windows.Input;
using Microsoft.Windows.Shell;
using System.Windows.Media;
using System.Windows.Controls;

namespace XmyMediaPlayer.Controls
{
    [TemplatePart(Name = CustomChromeWindow._clientAreaBorderTemplateName, Type = typeof(Border))]
    [TemplatePart(Name = CustomChromeWindow._clientHeaderBorderTemplateName, Type = typeof(Border))]
    [TemplatePart(Name = CustomChromeWindow._clientContentBorderTemplateName, Type = typeof(Border))]
    [TemplatePart(Name = CustomChromeWindow._iconTemplateName, Type = typeof(Image))]
    public class CustomChromeWindow : Window
    {
        /// <summary>
        /// 初始化窗口元数据
        /// </summary>
        static CustomChromeWindow()
        {
            Type ownerType = typeof(CustomChromeWindow);
            DefaultStyleKeyProperty.OverrideMetadata(ownerType,new FrameworkPropertyMetadata(ownerType));

            Window.TitleProperty.OverrideMetadata(ownerType, new FrameworkPropertyMetadata(String.Empty, new PropertyChangedCallback(OnTitleChangedCallback)));
            Window.WindowStateProperty.OverrideMetadata(ownerType, new FrameworkPropertyMetadata(WindowState.Normal, new PropertyChangedCallback(OnSizeChangedCallback)));
            
            CommandManager.RegisterClassCommandBinding(ownerType, new CommandBinding(SystemCommands.MinimizeWindowCommand, MinimizeWindowExecuted, MinimizeWindowCanExecute));
            CommandManager.RegisterClassCommandBinding(ownerType, new CommandBinding(SystemCommands.MaximizeWindowCommand, MaximizeWindowExecuted, MaximizeWindowCanExecute));
            CommandManager.RegisterClassCommandBinding(ownerType, new CommandBinding(SystemCommands.RestoreWindowCommand, RestoreWindowExecuted, RestoreWindowCanExecute));
            CommandManager.RegisterClassCommandBinding(ownerType, new CommandBinding(SystemCommands.CloseWindowCommand, CloseWindowExecuted, CloseWindowCanExecute));
            CommandManager.RegisterClassCommandBinding(ownerType, new CommandBinding(SystemCommands.ShowSystemMenuCommand, SystemMenuExecuted, SystemMenuCanExecute));
            CommandManager.RegisterClassCommandBinding(ownerType, new CommandBinding(ApplicationCommands.Close, CloseApplicationExecuted, CloseApplicationCanExecute));
        }

        #region 依赖属性

        /// <summary>
        /// 标题高度
        /// </summary>
        public double CaptionHeight
        {
            get { return (double)GetValue(CaptionHeightProperty); }
            set { SetValue(CaptionHeightProperty, value); }
        }

        public static readonly DependencyProperty CaptionHeightProperty = DependencyProperty.Register("CaptionHeight", typeof(double), typeof(CustomChromeWindow), new UIPropertyMetadata(23d));

        /// <summary>
        /// 窗口圆角大小
        /// </summary>
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(CustomChromeWindow), new UIPropertyMetadata(default(CornerRadius)));

        /// <summary>
        /// 标题栏颜色
        /// </summary>
        public Brush CaptionBackground {
            get { return (Brush)GetValue(CaptionBackgroundProperty); }
            set { SetValue(CaptionBackgroundProperty, value); }
        }

        public static readonly DependencyProperty CaptionBackgroundProperty = DependencyProperty.Register("CaptionBackground", typeof(Brush), typeof(CustomChromeWindow), new UIPropertyMetadata(default(Brush)));
        #endregion

        #region ===应用模板===
        
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _icon = GetTemplateChild(_iconTemplateName) as Image;
            if (_icon != null)
            {
                _icon.MouseLeftButtonDown += new MouseButtonEventHandler(IconMouseLeftButtonDown);
                _icon.MouseRightButtonDown += new MouseButtonEventHandler(IconMouseRightButtonDown);
            }
            _clientAreaBorder = GetTemplateChild(CustomChromeWindow._clientAreaBorderTemplateName) as Border;
            _clientHeaderBorder = GetTemplateChild(CustomChromeWindow._clientHeaderBorderTemplateName) as Border;
            _clientContentBorder = GetTemplateChild(CustomChromeWindow._clientContentBorderTemplateName) as Border;

            _clientHeaderBorder.CornerRadius = new CornerRadius(_clientAreaBorder.CornerRadius.TopLeft, _clientAreaBorder.CornerRadius.TopRight, 0, 0);
            _clientContentBorder.CornerRadius = new CornerRadius(0, 0, _clientAreaBorder.CornerRadius.BottomRight, _clientAreaBorder.CornerRadius.BottomLeft);
        }

        #endregion

        #region 私有属性

        private Image _icon;

        private Border _clientAreaBorder;

        private Border _clientHeaderBorder;

        private Border _clientContentBorder;

        private const string _iconTemplateName = "PART_Icon";

        private const string _clientAreaBorderTemplateName = "PART_ClientAreaBorder";

        private const string _clientHeaderBorderTemplateName = "PART_ClientHeaderBorder";

        private const string _clientContentBorderTemplateName = "PART_ClientContentBorder";

        #endregion

        #region 事件和处理函数

        internal event EventHandler TitleChanged;

        private static void MinimizeWindowCanExecute(object sender, CanExecuteRoutedEventArgs args)
        {
            CustomChromeWindow rw = sender as CustomChromeWindow;
            if (rw != null && rw.WindowState != WindowState.Minimized)
            {
                args.CanExecute = true;
            }
        }

        private static void MinimizeWindowExecuted(object sender, ExecutedRoutedEventArgs args)
        {
            CustomChromeWindow rw = sender as CustomChromeWindow;
            if (rw != null)
            {
                SystemCommands.MinimizeWindow(rw);
                args.Handled = true;
            }
        }

        private static void MaximizeWindowCanExecute(object sender, CanExecuteRoutedEventArgs args)
        {
            CustomChromeWindow rw = sender as CustomChromeWindow;
            if (rw != null)
            {
                args.CanExecute = true;
            }
        }

        private static void MaximizeWindowExecuted(object sender, ExecutedRoutedEventArgs args)
        {
            CustomChromeWindow rw = sender as CustomChromeWindow;
            if (rw != null)
            {
                SystemCommands.MaximizeWindow(rw);
                args.Handled = true;
            }
        }

        private static void RestoreWindowCanExecute(object sender, CanExecuteRoutedEventArgs args)
        {
            CustomChromeWindow rw = sender as CustomChromeWindow;
            if (rw != null)
            {
                args.CanExecute = true;
            }
        }

        private static void RestoreWindowExecuted(object sender, ExecutedRoutedEventArgs args)
        {
            CustomChromeWindow rw = sender as CustomChromeWindow;
            if (rw != null)
            {
                SystemCommands.RestoreWindow(rw);
                args.Handled = true;
            }
        }

        private static void CloseWindowCanExecute(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }

        private static void CloseWindowExecuted(object sender, ExecutedRoutedEventArgs args)
        {
            CustomChromeWindow rw = sender as CustomChromeWindow;
            if (rw != null)
            {
                SystemCommands.CloseWindow(rw);
                args.Handled = true;
            }
        }

        private static void SystemMenuCanExecute(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }

        private static void SystemMenuExecuted(object sender, ExecutedRoutedEventArgs args)
        {
            CustomChromeWindow rw = sender as CustomChromeWindow;
            if (rw != null)
            {
                Point devicePoint;
                MouseButtonEventArgs e = args.Parameter as MouseButtonEventArgs;
                if (e != null)
                {
                    devicePoint = rw.PointToScreen(e.GetPosition(rw));
                }
                else if (rw._clientAreaBorder != null)
                {
                    devicePoint = rw._clientAreaBorder.PointToScreen(new Point(0, rw.CaptionHeight+14));
                }
                else
                {
                    return;
                }

                CompositionTarget compositionTarget = PresentationSource.FromVisual(rw).CompositionTarget;
                SystemCommands.ShowSystemMenu(rw, compositionTarget.TransformFromDevice.Transform(devicePoint));
                args.Handled = true;
            }
        }

        private static void CloseApplicationCanExecute(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }

        private static void CloseApplicationExecuted(object sender, ExecutedRoutedEventArgs args)
        {
            CustomChromeWindow rw = sender as CustomChromeWindow;
            if (rw != null)
            {
                Application.Current.Shutdown();
                args.Handled = true;
            }
        }

        #endregion

        #region 私有方法

        private void IconMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1)
            {
                if (SystemCommands.ShowSystemMenuCommand.CanExecute(null, this))
                {
                    SystemCommands.ShowSystemMenuCommand.Execute(null, this);
                }
            }
            else if (e.ClickCount == 2)
            {
                if (ApplicationCommands.Close.CanExecute(null, this))
                {
                    ApplicationCommands.Close.Execute(null, this);
                }
            }
        }

        private void IconMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (SystemCommands.ShowSystemMenuCommand.CanExecute(e, this))
            {
                SystemCommands.ShowSystemMenuCommand.Execute(e, this);
            }
        }

        private static void OnTitleChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CustomChromeWindow rw = d as CustomChromeWindow;
            rw.OnTitleChanged(null);
        }

        internal void OnTitleChanged(EventArgs e)
        {
            if (TitleChanged != null)
            {
                TitleChanged(this, e);
            }
        }

        private static void OnSizeChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CustomChromeWindow rw = d as CustomChromeWindow;
            if (rw.WindowState == System.Windows.WindowState.Maximized)
            {
                //假设系统任务栏在底部
                double bottomThickness = SystemParameters.PrimaryScreenHeight - SystemParameters.WorkArea.Height;
                rw.BorderThickness = new Thickness(1, 1, 1, bottomThickness);
            }
            else
            {
                rw.BorderThickness = new Thickness(1);
            }
        }
        #endregion
    }
}
