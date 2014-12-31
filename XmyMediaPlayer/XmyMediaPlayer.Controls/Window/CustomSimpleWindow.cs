using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Interop;

namespace XmyMediaPlayer.Controls
{
    /// <summary>
    /// 简单窗口自定义
    /// <remarks>
    /// 该窗口类去除了窗口非客户区，仅实现了窗口移动、顶部双击放大、最小化、最大化、关闭功能
    /// 若需要更加友好的自定义窗口，使用CustomChromeWindow窗口类
    /// </remarks>
    /// </summary>
    public class CustomSimpleWindow : Window
    {
        #region 字段
        /// <summary>
        /// 窗口标题栏
        /// </summary>
        private TextBlock headerTitle;

        private WindowsButtonModel ViewModel;

        protected bool CanMaximize = true;
        #endregion

        #region 静态构造函数

        static CustomSimpleWindow ()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomSimpleWindow), new FrameworkPropertyMetadata(typeof(CustomSimpleWindow)));
        }

        public CustomSimpleWindow() {
            ViewModel = new WindowsButtonModel(this);
            CanMaximize = ViewModel.CanMaximize;
            this.DataContext = ViewModel;
        }

        #endregion

        #region 应用模板

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            headerTitle = GetTemplateChild ("PART_Title") as TextBlock;
            if (headerTitle != null)
            {
                headerTitle.MouseDown += HeaderMouseDown;
                headerTitle.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(HeaderTitle_PreviewMouseLeftButtonDown);
            }
        }

        #endregion

        #region 私有方法

        private void HeaderMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void HeaderTitle_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (CanMaximize && e.ClickCount == 2)
            {
                if (this.WindowState == WindowState.Maximized)
                {
                    this.WindowState = WindowState.Normal;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                }
            }
        }
        #endregion
    }
}
