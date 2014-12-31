using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace XmyMediaPlayer
{
    class Global
    {
        /// <summary>
        /// 系统名称(只读)
        /// </summary>
        public static string SystemName
        {
            get
            {
                return "XmyMediaPlayer";
            }
        }

        /// <summary>
        /// 用户数据
        /// </summary>
        public static string SystemAppDataFolder
        {
            get
            {
                string baseUserFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), SystemName);
                if (!Directory.Exists(baseUserFolder))
                {
                    Directory.CreateDirectory(baseUserFolder);
                }
                return baseUserFolder;
            }
        }

        /// <summary>
        /// 系统线程通知文件
        /// </summary>
        public static string SystemNoticeFile
        {
            get
            {
                return Path.Combine(SystemAppDataFolder, "Notice.txt");
            }
        }
    }
}
