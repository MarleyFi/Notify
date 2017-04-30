using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Notify.Properties;

namespace Notify
{
    class Supporter
    {
        static DataStore dataStore = FrmNotify.dataStore;

        private const string INDENT_STRING = "    ";

        /// <summary>
        /// Prüft, ob die gespeicherten Standards ausführbar sind
        /// </summary>
        /// <returns></returns>
        public static bool AreDefaultsValid()
        {
            string title = Settings.Default.defaultTitle;
            string body = Settings.Default.defaultBody;
            int priority = Settings.Default.defaultPriority;
            int tokenLength = FrmNotify.dataStore.TokenIDs.Length;
            int token = Settings.Default.defaultToken;
            if ((title != string.Empty || title != null) && (body != string.Empty || body != null) && (priority >= 0 && priority <= 4) && (token <= tokenLength && token >= 0))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gibt den Timestamp mit dem angegebenen offset zurück
        /// </summary>
        /// <returns></returns>
        public static long GetUnixTimestamp(int offset)
        {
            long unixTimestamp = DateTime.Now.Subtract(new TimeSpan(offset, 0, 0)).Ticks - new DateTime(1970, 1, 1).Ticks;
            unixTimestamp /= TimeSpan.TicksPerSecond;
            return unixTimestamp;
        }

        /// <summary>
        /// Formatiert den mitgegebenen Text so um, dass die enthaltenen Variablen eingefügt werden
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string FormatText(string text)
        {
            string formattetText = text;
            for (int i = 0; i < FrmNotify.dataStore.Variables.Length; i++)
            {
                formattetText = formattetText.Replace(FrmNotify.dataStore.Variables[i], FrmNotify.dataStore.GetVariable(FrmNotify.dataStore.Variables[i]));
            }
            return formattetText;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string GetAM(DateTime time = new DateTime())
        {
            return time.Hour > 11 ? "PM" : "AM";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="senderString"></param>
        /// <returns></returns>
        public static string ExtraxtParams(string senderString)
        {
            char[] seps = { '{', '}' };
            string[] results = senderString.Split(seps);
            return string.Format("{{{0}}}", results[1]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        public static void OpenBrowser(string url)
        {
            System.Diagnostics.Process.Start(url);
        }

        /// <summary>
        /// Öffnet den mitgegebenen Pfad im Windows-Explorer(Datei)
        /// </summary>
        /// <param name="path"></param>
        public static void OpenFile(string path)
        {
            if (File.Exists(path))
                Process.Start("explorer.exe", path);
        }

        /// <summary>
        /// Öffnet den mitgegebenen Pfad im Windows-Explorer(Ordner)
        /// </summary>
        /// <param name="path"></param>
        public static void OpenPath(string path)
        {
            if (Directory.Exists(path))
            {
                Process.Start("explorer.exe", path);
            }
            else if (Directory.Exists(Path.GetDirectoryName(path)))
            {
                Process.Start("explorer.exe", Path.GetDirectoryName(path));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void ClearGarbageContainer()
        {
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string BuildPath(string path, bool useJSON, string filename = "Tokens")
        {
            if (Directory.Exists(path))
            {
                return Path.Combine(path, filename + (useJSON ? ".json" : ".txt"));
            }
            else if (File.Exists(path))
            {
                FileInfo file = new FileInfo(path);
                if (file.Extension == ".json" && useJSON)
                {
                    return path;
                }
                else if (file.Extension == ".txt" && !useJSON)
                {
                    return path;
                }
                else if (file.Extension == ".json" && !useJSON)
                {
                    return ChangeFileExtension(file.FullName, ".txt");
                }
                else if (file.Extension == ".txt" && useJSON)
                {
                    return ChangeFileExtension(file.FullName, ".json");
                }
                else
                {
                    FrmNotify.NotifyIcon.ShowBalloonTip(250, "Path was invalid", "Arg path is neither a filepath nor a directory-path", System.Windows.Forms.ToolTipIcon.Error);
                    return path;
                }
            }
            else
            {
                FrmNotify.NotifyIcon.ShowBalloonTip(250, "Path was invalid", "Arg path is neither a filepath nor a directory-path", System.Windows.Forms.ToolTipIcon.Error);
                return path;
            }
        }

        public static bool FileIsJSON(string path)
        {
            FileInfo file = new FileInfo(path);
            return (file.Extension == ".json");
        }


        private static string ChangeFileExtension(string path, string extension)
        {
            return (path.Remove(path.LastIndexOf('.'))) +extension;
        }



        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shareLink"></param>
        /// <returns></returns>
        public static string GetGoogleDriveDirectLink(string shareLink)
        {
            try
            {
                const string front = "https://drive.google.com/uc?export=download&id=";
                return front + GetIDofGoogleDriveLink(shareLink);
            }
            catch (Exception e)
            {
                Settings.Default.lastInputCorrect = false;
                return e.Message;
            }
        }

        public static bool ArrayContains(object[] list, object item)
        {
            foreach (var tempItem in list)
            {
                if(tempItem == item)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shareLink"></param>
        /// <returns></returns>
        private static string GetIDofGoogleDriveLink(string shareLink)
        {
            string id = shareLink.Substring(shareLink.IndexOf("/d/") + 3);
            int index = 0;
            if (shareLink.Contains("edit"))
            {
                index = (id.IndexOf("edit"));
            }
            else if (shareLink.Contains("view"))
            {
                index = (id.IndexOf("view"));
            }
            else
            {
                throw new ArgumentException("Sharelink could not be extracted\r\n" + shareLink);
            }

            return id.Remove(index - 1);
        }

        
        public static string FormatJson(string str)
        {
            var indent = 0;
            var quoted = false;
            var sb = new StringBuilder();
            for (var i = 0; i < str.Length; i++)
            {
                var ch = str[i];
                switch (ch)
                {
                    case '{':
                    case '[':
                        sb.Append(ch);
                        if (!quoted)
                        {
                            sb.AppendLine();
                            Enumerable.Range(0, ++indent).ForEach(item => sb.Append(INDENT_STRING));
                        }
                        break;
                    case '}':
                    case ']':
                        if (!quoted)
                        {
                            sb.AppendLine();
                            Enumerable.Range(0, --indent).ForEach(item => sb.Append(INDENT_STRING));
                        }
                        sb.Append(ch);
                        break;
                    case '"':
                        sb.Append(ch);
                        bool escaped = false;
                        var index = i;
                        while (index > 0 && str[--index] == '\\')
                            escaped = !escaped;
                        if (!escaped)
                            quoted = !quoted;
                        break;
                    case ',':
                        sb.Append(ch);
                        if (!quoted)
                        {
                            sb.AppendLine();
                            Enumerable.Range(0, indent).ForEach(item => sb.Append(INDENT_STRING));
                        }
                        break;
                    case ':':
                        sb.Append(ch);
                        if (!quoted)
                            sb.Append(" ");
                        break;
                    default:
                        sb.Append(ch);
                        break;
                }
            }
            return sb.ToString();
        }
    }

    static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> ie, Action<T> action)
        {
            foreach (var i in ie)
            {
                action(i);
            }
        }
    }
}
