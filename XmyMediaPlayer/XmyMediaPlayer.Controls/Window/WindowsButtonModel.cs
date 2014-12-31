using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows;

namespace XmyMediaPlayer.Controls
{
    internal class WindowsButtonModel : INotifyPropertyChanged
    {
        private Window uiWindow;

        public WindowsButtonModel(Window win) {
            this.uiWindow = win;
            switch (win.ResizeMode)
            {
                case ResizeMode.CanMinimize:
                    CanMinimize = true;
                    CanMaximize = false;
                    break;
                case ResizeMode.CanResize:
                case ResizeMode.CanResizeWithGrip:
                    CanMinimize = true;
                    CanMaximize = true;
                    break;
                case ResizeMode.NoResize:
                    CanMinimize = false;
                    CanMaximize = false;
                    break;
            }
        }

        private bool canMaximize;
        /// <summary>
        /// 是否可以最大化
        /// </summary>
        public bool CanMaximize
        {
            get { return canMaximize; }
            set
            {
                if (canMaximize != value)
                {
                    canMaximize = value;
                    NotifyPropertyChange("CanMaximize");
                }
            }
        }

        private bool canMinimize;

        /// <summary>
        /// 是否可以最大化
        /// </summary>
        public bool CanMinimize
        {
            get { return canMinimize; }
            set
            {
                if (canMinimize != value)
                {
                    canMinimize = value;
                    NotifyPropertyChange("CanMinimize");
                }
            }
        }

        private ICommand _maximizeCommand;
        /// <summary>
        /// 窗口最大化按钮事件
        /// </summary>
        public ICommand MaximizeCommand
        {
            get
            {
                if (_maximizeCommand == null)
                    _maximizeCommand = new DelegateCommand(() =>
                    {
                        if (uiWindow == null)  return;
                        if (uiWindow.WindowState == WindowState.Normal)
                        {
                            uiWindow.WindowState = WindowState.Maximized;
                        }
                        else
                        {
                            uiWindow.WindowState = WindowState.Normal;
                        }
                    });
                return _maximizeCommand;
            }
        }

        private ICommand _minimizeCommand;
        /// <summary>
        /// 窗口最小化按钮事件
        /// </summary>
        public ICommand MinimizeCommand
        {
            get
            {
                if (_minimizeCommand == null)
                    _minimizeCommand = new DelegateCommand(() =>
                    {
                        if (uiWindow == null) return;
                        uiWindow.WindowState = WindowState.Minimized;
                    });
                return _minimizeCommand;
            }
        }

        private ICommand _closeCommand;
        /// <summary>
        /// 窗口关闭按钮事件
        /// </summary>
        public ICommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                    _closeCommand = new DelegateCommand(() =>
                    {
                        if (uiWindow == null)  return;
                        uiWindow.Close();
                    });
                return _closeCommand;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChange(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
