using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using Notify.Properties;

namespace Notify
{
    public partial class DataStore
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Notify.DataStore"/> class.
        /// </summary>
        public DataStore()
        {
            Init();
        }

        #region Proteries

        /// <summary>
        /// Gibt an, ob das Programm alle nötigen komponenten zum Feuern eines Requests hat
        /// </summary>
        public bool NotifyIsExecutable { get; set; } = false;

        public bool HasInternetConnection { get; set; } = false;

        public long PingLatency { get; set; } = 1000;

        /// <summary>
        /// Bestimmt, ob die angegebene Datei-URL korrekt ist.
        /// </summary>
        public bool IsFileURLValid { get; set; }

        /// <summary>
        /// Gibt den Dateipfad zur Token-Datei an.
        /// </summary>
        public string TokenFilePath { get; set; }

        /// <summary>
        /// Gibt den Dateipfad zur Log-Datei an.
        /// </summary>
        public string LogFilePath { get; set; }

        /// <summary>
        /// Beinhaltet die konfigurierten Token-IDs
        /// </summary>
        public string[] TokenIDs { get; set; } = {
        };

        /// <summary>
        /// Beinhaltet die konfigurierten Token-Names
        /// </summary>
        public string[] TokenNames { get; set; } =
        {
        };

        /// <summary>
        /// Beinhaltet das UserToken
        /// </summary>
        public string UserToken { get; set; } = Settings.Default.userToken;

        /// <summary>
        ///
        /// </summary>
        public TokenListDAO TokenJSONList { get; set; }

        public string fileUrl { get; set; }

        /// <summary>
        /// Beinhaltet die vorkonfigurierten Prioritäten
        /// </summary>
        public string[] Prioritys { get; set; } =
                        {
            "Very low",
            "Low",
            "Normal",
            "High",
            "Emergency"
                };

        /// <summary>
        /// Beinhaltet die vorkonfigurierten Variablen
        /// </summary>
        public string[] Variables { get; set; } =
        {
            "{SystemTime}",
            "{SystemDate}",
            "{SystemDateString}",
            "{SystemDateTime}",
            "{SystemUsername}",
            "{SystemDomain}",
            "{SystemComputerName}",
            "{SystemDomainUsername}",
            //"{Temp}"
        };

        /// <summary>
        /// Beinhaltet die vorkonfigurierten Variablen-Beschreibungen
        /// </summary>
        public string[] VariablesDesc { get; set; } =
        {
            "Die Systemzeit",
            "Das Systemdatum als zahlenfolge",
            "Das Systemdatum als Text",
            "Systemzeit & datum",
            "Angemeldeter Nutzer",
            "Domain",
            "Computer",
            "Domain & Angemeldeter Benutzer",
            //"Sonstiges"
        };

        #endregion Proteries

        #region Interne Variablen

        /// <summary>
        /// Enthält das Form für den WebExceptionDialog
        /// </summary>
        private FrmChoice webExceptionDialog;

        /// <summary>
        /// Hilfvariable für FrmVariables (Kopieren und Einfügen)
        /// </summary>
        public string var;

        #endregion Interne Variablen

        #region Methoden

        /// <summary>
        /// Erweiterter Konstruktor
        /// </summary>
        private void Init()
        {
            CheckFiles();
            DecideArrays();
        }

        public void CheckFiles()
        {
            if (Settings.Default.filePath != string.Empty && File.Exists(Settings.Default.filePath)) // TokenFile Prüfen
            {
                TokenFilePath = Settings.Default.filePath;
                if (!File.Exists(TokenFilePath))
                {
                    File.Create(TokenFilePath);
                }
            }
            else
            {
                SetTokenPath(true);
            }

            if (Settings.Default.logFilePath != string.Empty && File.Exists(Settings.Default.logFilePath)) // LogFile Prüfen
            {
                LogFilePath = Settings.Default.logFilePath;
                if (!File.Exists(LogFilePath))
                {
                    File.Create(LogFilePath);
                }
            }
            else
            {
                SetLogPath(true);
            }

            if (Settings.Default.fileURL == string.Empty) // fileURL Prüfen
            {
                SetFileURL();
            }
        }

        /// <summary>
        /// Checkt, ob Notify lauffähig ist und verändert 'NotifyIsExecutable' dementsprechend.
        /// </summary>
        /// <param name="focus"></param>
        /// <returns></returns>
        public bool CheckStatus(bool focus = false)
        {
            // FilePath
            // LogPath
            // FileURL
            // UserToken
            // UserTokenList
            // Defaults
            List<bool> configList = new List<bool>();
            configList.Add(File.Exists(Settings.Default.filePath));
            configList.Add(File.Exists(Settings.Default.logFilePath));
            configList.Add(Settings.Default.SettingUseLocalFile ? true : !string.IsNullOrEmpty(Settings.Default.fileURL));
            configList.Add(!string.IsNullOrEmpty(Settings.Default.userToken));
            configList.Add(TokenIDs.Length >= 1);
            configList.Add(Supporter.AreDefaultsValid());
            if (focus)
            {
                for (int i = 0; i < configList.Count; i++)
                {
                    if (!configList[i])
                    {
                        HelpUser(i);
                    }
                }
                foreach (bool configItem in configList)
                {
                    if (!configItem)
                        NotifyIsExecutable = false;
                }
                NotifyIsExecutable = true;
                return true;
            }
            else
            {
                foreach (bool configItem in configList)
                {
                    if (!configItem)
                        NotifyIsExecutable = false;
                    return false;
                }
                NotifyIsExecutable = true;
                return true;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public string CheckDataMode(bool isJSON)
        {
            string path = TokenFilePath;
            if (Supporter.FileIsJSON(path) != isJSON)
            {
                Settings.Default.filePath = Supporter.BuildPath(path, isJSON);
            }
            CheckFiles();
            return Settings.Default.filePath;
        }

        /// <summary>
        /// Gibt dem User hilfestellungen bei bestimmten Fehlerfällen
        /// </summary>
        /// <param name="index"></param>
        public void HelpUser(int index)
        {
            switch (index)
            {
                case 0:
                    MessageBox.Show("It seems like your Token-filepath is incorrect", "Configuration error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    SetTokenPath(true);
                    break;

                case 1:
                    MessageBox.Show("It seems like your Token-logpath is incorrect", "Configuration error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    SetLogPath(true);
                    break;

                case 2:
                    if (!Settings.Default.SettingUseLocalFile)
                    {
                        DialogResult result = MessageBox.Show("It seems like your Web-Tokenfile is not available.\r\nSwitch to offline mode?", "Configuration error", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (result == DialogResult.Yes)
                        {
                            Settings.Default.SettingUseLocalFile = true;
                        }
                        else
                        {
                            SetFileURL();
                        }
                    }
                    else
                    {
                        HelpUser(0);
                    }

                    break;

                case 3:
                    MessageBox.Show("It seems like your UserToken is incorrect", "Configuration error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    SetUserToken();
                    break;

                case 4:
                    MessageBox.Show("Your chosen token isn compatible.\r\nMake sure your Token-File is UpToDate and the Tokens are correctly written\r\n" +
                        (Settings.Default.SettingUseLocalFile ? "Your local filepath has been copied to you clipboard" : "The URL has been copied to your Clipboard")
                        , "Error in token-list", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Clipboard.SetText((Settings.Default.SettingUseLocalFile ? Settings.Default.filePath : Settings.Default.fileURL));
                    break;

                case 5:
                    MessageBox.Show("Your current configurated setting cannot be fired", "Error in data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
            }
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Read-Decider (Online/Offline)
        /// </summary>
        public void DecideArrays(bool startUp = true)
        {
            string path = Supporter.BuildPath(Settings.Default.filePath, Settings.Default.SettingUseJSON);
            if (!Settings.Default.SettingUseLocalFile)
            {
                try
                {
                    Networker.DownloadFile(2, startUp);
                }
                catch (Exception)
                {
                    Settings.Default.SettingUseLocalFile = true;
                    DecideArrays(startUp);
                }
            }

            if (Settings.Default.SettingUseJSON)
            {
                TryReadJSONArrays(path);
            }
            else
            {
                TryReadArrays(path);
            }
        }

        /// <summary>
        /// Zeigt den Dialog zum auswählen des Vorgehens bei mangelnder Internetverbindung
        /// </summary>
        public void WebExceptionDialog()
        {
            webExceptionDialog = new FrmChoice("Download error", Resources.Error);
            webExceptionDialog.choiceButton1.Text = "Offline-mode";
            webExceptionDialog.choiceButton1.Click += ChoiceButton1_Click;
            webExceptionDialog.choiceButton2.Text = "Retry";
            webExceptionDialog.choiceButton2.Click += ChoiceButton2_Click;
            webExceptionDialog.choiceButton3.Text = "Abort";
            webExceptionDialog.choiceButton3.Click += ChoiceButton3_Click;
            webExceptionDialog.ShowDialog();
        }

        #region WebExceptionDialogEvents

        /// <summary>
        /// Event für das Beenden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChoiceButton3_Click(object sender, EventArgs e)
        {
            webExceptionDialog.Close();
        }

        /// <summary>
        /// Event für das erneute versuchen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChoiceButton2_Click(object sender, EventArgs e)
        {
            webExceptionDialog.Close();
            Networker.DownloadFile();
        }

        /// <summary>
        /// Event für den Offline-Modus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChoiceButton1_Click(object sender, EventArgs e)
        {
            webExceptionDialog.Close();
            Settings.Default.SettingUseLocalFile = true;
            Settings.Default.Save();
            Supporter.ClearGarbageContainer();
            Application.Restart();
        }

        #endregion WebExceptionDialogEvents

        /// <summary>
        /// Liest die Offline vorhandene Datei oder aus dem Web gedownloadete Datei aus
        /// </summary>
        /// <param name="path"></param>
        private void TryReadArrays(string path)
        {
            string[] allLines = File.ReadAllLines(path);
            List<string> lines = new List<string>(allLines);
            if (!Settings.Default.SettingUseLocalFile && lines.Count >= 2 && (lines.Contains("<head>") || lines.Contains("<script>") || lines.Contains("</head>") || lines.Contains("</script>")))
            {
                Clipboard.SetText(Settings.Default.fileURL);
                DialogResult result = MessageBox.Show("Please verify the fileURL to be a directlink and no 'Sharelink' or something equal\r\n" +
                    "Try yourself by copy URL(copied to your clipboard) into the browsers URL-field and verify that you instantly download the requiered file.\r\n\r\n" +
                    "Switch to offline mode?", "Download error", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    Settings.Default.SettingUseLocalFile = true;
                    Settings.Default.Save();
                    DecideArrays();
                    return;
                }
                else
                {
                    return;
                }
            }
            List<string> names = new List<string>();
            List<string> tokens = new List<string>();
            try
            {
                for (int i = 0; i < allLines.Length; i++)
                {
                    names.Add(allLines[i]);
                    i++;
                    tokens.Add(allLines[i]);
                }
                TokenNames = names.ToArray();
                TokenIDs = tokens.ToArray();
            }
            catch (Exception)
            {
                try
                {
                    ReadJSONArrays(path);
                    Settings.Default.SettingUseJSON = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("List is not compatible\r\nPlease choose another one\r\n" + e.Message, "Error while parsing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ToDo: Disbale Main-Functions
            }
        }

        /// <summary>
        /// Liest die Offline vorhandene Datei oder aus dem Web gedownloadete Datei aus
        /// </summary>
        /// <param name="path"></param>
        private void TryReadJSONArrays(string path)
        {
            List<string> names = new List<string>();
            List<string> tokens = new List<string>();
            try
            {
                TokenJSONList = JsonConvert.DeserializeObject<TokenListDAO>(File.ReadAllText(path));
                for (int i = 0; i < (TokenJSONList.ApplicationTokens.Count - 1); i++)
                {
                    names.Add(TokenJSONList.ApplicationTokens[i].name);
                    tokens.Add(TokenJSONList.ApplicationTokens[i].id);
                }
                TokenNames = names.ToArray();
                TokenIDs = tokens.ToArray();
            }
            catch (Exception)
            {
                try
                {
                    ReadArrays(path);
                    Settings.Default.SettingUseJSON = false;
                }
                catch (Exception e)
                {
                    MessageBox.Show("List is not compatible\r\nPlease choose another one\r\n" + e.Message, "Error while parsing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ToDo: Disbale Main-Functions
            }
        }

        /// <summary>
        /// Liest die Offline vorhandene Datei oder aus dem Web gedownloadete Datei aus
        /// </summary>
        /// <param name="path"></param>
        private void ReadArrays(string path)
        {
            string[] allLines = File.ReadAllLines(path);
            List<string> lines = new List<string>(allLines);
            if (!Settings.Default.SettingUseLocalFile && lines.Count >= 2 && (lines.Contains("<head>") || lines.Contains("<script>") || lines.Contains("</head>") || lines.Contains("</script>")))
            {
                Clipboard.SetText(Settings.Default.fileURL);
                DialogResult result = MessageBox.Show("Please verify the fileURL to be a directlink and no 'Sharelink' or something equal\r\n" +
                    "Try yourself by copy URL(copied to your clipboard) into the browsers URL-field and verify that you instantly download the requiered file.\r\n\r\n" +
                    "Switch to offline mode?", "Download error", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    Settings.Default.SettingUseLocalFile = true;
                    Settings.Default.Save();
                    DecideArrays();
                    return;
                }
                else
                {
                    return;
                }
            }
            List<string> names = new List<string>();
            List<string> tokens = new List<string>();
            for (int i = 0; i < allLines.Length; i++)
            {
                names.Add(allLines[i]);
                i++;
                tokens.Add(allLines[i]);
            }
            TokenNames = names.ToArray();
            TokenIDs = tokens.ToArray();
        }

        /// <summary>
        /// Liest die Offline vorhandene Datei oder aus dem Web gedownloadete Datei aus
        /// </summary>
        /// <param name="path"></param>
        private void ReadJSONArrays(string path)
        {
            List<string> names = new List<string>();
            List<string> tokens = new List<string>();

            TokenJSONList = JsonConvert.DeserializeObject<TokenListDAO>(File.ReadAllText(path));
            for (int i = 0; i < (TokenJSONList.ApplicationTokens.Count - 1); i++)
            {
                names.Add(TokenJSONList.ApplicationTokens[i].name);
                tokens.Add(TokenJSONList.ApplicationTokens[i].id);
            }
            TokenNames = names.ToArray();
            TokenIDs = tokens.ToArray();
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Schreibt Änderungen in die Datei
        /// </summary>
        public void WriteArrays()
        {
            try
            {
                List<string> lines = new List<string>();

                for (int i = 0; i < TokenIDs.Length; i++)
                {
                    lines.Add(TokenNames[i]);
                    lines.Add(TokenIDs[i]);
                }
                Supporter.ClearGarbageContainer();
                File.WriteAllLines(TokenFilePath, lines);
            }
            catch (System.Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message, "Error while writing!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (result == DialogResult.Retry)
                {
                    Supporter.ClearGarbageContainer();
                    WriteArrays();
                }
            }
            // ToDo: GoogleDrive-Upload
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Schreibt Änderungen in die Datei
        /// </summary>
        public void WriteJSONArrays()
        {
            try
            {
                FillArrays();
                string jsonString = JsonConvert.SerializeObject(TokenJSONList);
                Supporter.ClearGarbageContainer();
                File.WriteAllText(TokenFilePath, jsonString);
            }
            catch (System.Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message, "Error while writing!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (result == DialogResult.Retry)
                {
                    Supporter.ClearGarbageContainer();
                    WriteArrays();
                }
            }
            // ToDo: GoogleDrive-Upload
        }

        ///// <summary>
        /////
        ///// </summary>
        //private void CreateDefaultArrays() // ToDo: Rausnehmen
        //{
        //    string[] nameArray =
        //        {
        //    "Notification.Default",
        //    "Ibo.Food.Order",
        //    "Ibo.Food.Success",
        //    "Pc.Started",
        //    "Ibo.Cake",
        //    "EMail.Inbox",
        //    "EMail.Private"
        //        };

        //    string[] tokenArray =
        //        {
        //        "aCbwemDsa3rwWmtqj1BGsecNVgjPK4",
        //    "arZjan33BPf5tQB9DHZCwA4kKXLEsT",
        //    "aygTN3PH58fh1VqRS2zdq5V2o858qH",
        //    "afh6e5289QD1X8efymoDZXunWoPmRb",
        //    "apGMNL9qgxeQVKdCR4crdE7GsstgY3",
        //    "aPbXdi9KALc6dqooGk2SPqJCnTaUdn",
        //    "abyYLX4tp5vdf6jK2XsEnShWNBjyar"
        //        };

        //    List<string> names = new List<string>(nameArray);
        //    List<string> tokens = new List<string>(tokenArray);
        //    names.AddRange(nameArray);
        //    tokens.AddRange(tokenArray);
        //    TokenNames = names.ToArray();
        //    TokenIDs = tokens.ToArray();
        //}

        /// <summary>
        /// Liefert die angeforderte Variable zurück
        /// </summary>
        /// <returns>The variable.</returns>
        /// <param name="expression">Expression.</param>
        public string GetVariable(string expression)
        {
            if (expression == Variables[0]) // Die Systemzeit
            {
                return string.Format("{0} {1}", DateTime.Now.ToShortTimeString(), Supporter.GetAM(DateTime.Now));
            }
            else if (expression == Variables[1]) // Das Systemdatum als zahlenfolge
            {
                return DateTime.Now.ToShortDateString();
            }
            else if (expression == Variables[2]) // Das Systemdatum als Text
            {
                return DateTime.Now.ToLongDateString();
            }
            else if (expression == Variables[3]) // Systemzeit & datum
            {
                return string.Format("{0} {1}", DateTime.Now.ToLongDateString(), string.Format("{0} {1}", DateTime.Now.ToShortTimeString(), Supporter.GetAM(DateTime.Now)));
            }
            else if (expression == Variables[4]) // Angemeldeter Nutzer
            {
                return Environment.UserName;
            }
            else if (expression == Variables[5]) // Domain
            {
                return Environment.UserDomainName;
            }
            else if (expression == Variables[6]) // Computer
            {
                return Environment.MachineName;
            }
            else if (expression == Variables[7]) // Domain & Angemeldeter Benutzer
            {
                return System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Setzt den Log-Datei-Pfad
        /// </summary>
        /// <param name="withDefault"></param>
        public void SetLogPath(bool withDefault = false)
        {
            InputMessageBox filePath = new InputMessageBox("Path of Log-File", "Insert your filepath", Settings.Default.logFilePath, Resources.Pencil128, /*"RequestLog.xml",*/ true);
            filePath.ShowDialog();
            if (Settings.Default.lastInputCorrect)
            {
                LogFilePath = Supporter.BuildPath(Settings.Default.lastInputString, Settings.Default.SettingUseJSON, "RequestLog");
                if (!File.Exists(LogFilePath))
                {
                    if (Directory.Exists(Path.GetDirectoryName(LogFilePath)))
                    {
                        File.Create(LogFilePath);
                    }
                    else
                    {
                        HelpUser(1);
                        return;
                    }
                }
                Settings.Default.logFilePath = LogFilePath;
                Settings.Default.Save();
            }
            else
            {
                if (withDefault)
                {
                    string path = Application.StartupPath + @"\RequestLog.txt";
                    LogFilePath = path;
                }
            }
        }

        /// <summary>
        /// Setzt den Token-Datei-Pfad
        /// </summary>
        /// <param name="withDefault"></param>
        public void SetTokenPath(bool withDefault = false)
        {
            InputMessageBox filePath = new InputMessageBox("Path of Token-File", "Insert your filepath", Settings.Default.filePath, Resources.Document128, /*"Tokens.xml",*/true);
            filePath.ShowDialog();
            if (Settings.Default.lastInputCorrect)
            {
                TokenFilePath = Supporter.BuildPath(Settings.Default.lastInputString, Settings.Default.SettingUseJSON, "Tokens");
                if (!File.Exists(TokenFilePath))
                {
                    if (Directory.Exists(Path.GetDirectoryName(TokenFilePath)))
                    {
                        File.Create(TokenFilePath);
                    }
                    else
                    {
                        HelpUser(0);
                        return;
                    }
                }
                Settings.Default.filePath = TokenFilePath;
                Settings.Default.Save();
            }
            else
            {
                if (withDefault)
                {
                    string path = Application.StartupPath + @"\Tokens.txt";
                    TokenFilePath = path;
                }
            }
        }

        /// <summary>
        /// Setzt das UserToken mit der gegebenen Option sich anzumelden
        /// </summary>
        /// <param name="withDefault"></param>
        public void SetUserToken()
        {
            Button btn = new Button()
            {
                Image = Resources.Login32,
                FlatStyle = FlatStyle.Flat,
                Visible = true
            };
            InputMessageBox usertoken = new InputMessageBox("Usertoken", "Insert token-ID", Settings.Default.userToken, btn);

            usertoken.ShowDialog();
            if (Settings.Default.lastInputCorrect)
            {
                UserToken = Settings.Default.lastInputString;
                Settings.Default.userToken = UserToken;
                Settings.Default.Save();
            }
        }

        /// <summary>
        /// Setzt die URL für die Datei aus dem Web
        /// </summary>
        public void SetFileURL()
        {
            InputMessageBox filePath = new InputMessageBox("URL of Token-File", "Insert your URL", Settings.Default.fileURL, Resources.Cloud128);
            filePath.ShowDialog();
            if (Settings.Default.lastInputCorrect)
            {
                fileUrl = Settings.Default.lastInputString;
                Settings.Default.fileURL = fileUrl;
                Settings.Default.Save();
            }
        }

        /// <summary>
        /// Liefert den angeforderten Token nach seinem Index in der Liste
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetTokenByIndex(int index)
        {
            return TokenIDs[index];
        }

        /// <summary>
        /// Liefert den zuvor als Standard eingestellten Token (Default: 0)
        /// </summary>
        /// <returns></returns>
        public string GetDefaultToken()
        {
            return TokenIDs[Settings.Default.defaultTokenOnStart];
        }

        /// <summary>
        /// Gibt den Index des zuvor eingestellten Default-Token
        /// </summary>
        /// <returns></returns>
        public int GetDefaultTokenIndex()
        {
            return Settings.Default.defaultTokenOnStart;
        }

        /// <summary>
        /// Gibt den Parameter für den Request als String von 0-4 (5 = Emergency)
        /// </summary>
        /// <param name="priorityIndex"></param>
        /// <returns></returns>
        public string GetPriority(int priorityIndex)
        {
            string priority;
            switch (priorityIndex)
            {
                case 0:
                    priority = "-2";
                    break;

                case 1:
                    priority = "-2";
                    break;

                case 2:
                    priority = "0";
                    break;

                case 3:
                    priority = "1";
                    break;

                case 4:
                    priority = "1";
                    break;

                default:
                    priority = "0";
                    break;
            }
            return priority;
        }

        /// <summary>
        /// Liefert die Anzahl an Zeilen in der angegeben Datei im Pfad
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private int GetCountOfLines(string path)
        {
            int lineCount = 0;
            using (var reader = File.OpenText(path))
            {
                while (reader.ReadLine() != null)
                {
                    lineCount++;
                }
                return lineCount;
            }
        }

        private void FillArrays()
        {
            for (int i = 0; i < (TokenJSONList.ApplicationTokens.Count - 1); i++)
            {
                TokenJSONList.ApplicationTokens[i].name = TokenNames[i];
                TokenJSONList.ApplicationTokens[i].id = TokenIDs[i];
            }
        }

        /// <summary>
        /// Fügt der Liste und den Arrays ein Token hinzu
        /// </summary>
        /// <param name="name"></param>
        /// <param name="token"></param>
        public void AddToken(string name, string token)
        {
            if (Settings.Default.SettingUseJSON)
            {
                TokenJSONList.AddToken(name, token);
            }
            List<string> names = new List<string>(TokenNames);
            List<string> tokens = new List<string>(TokenIDs);
            names.Add(name);
            tokens.Add(token);
            TokenNames = names.ToArray();
            TokenIDs = tokens.ToArray();
        }

        /// <summary>
        /// Löscht den Token an dem angegebenen Index sowohl in der Liste als auch im Array
        /// </summary>
        /// <param name="index"></param>
        public void DelToken(int index)
        {
            if (Settings.Default.SettingUseJSON)
            {
                TokenJSONList.DelToken(index);
            }
            if (index >= 0)
            {
                List<string> names = new List<string>(TokenNames);
                List<string> tokens = new List<string>(TokenIDs);
                names.RemoveAt(index);
                tokens.RemoveAt(index);
                TokenNames = names.ToArray();
                TokenIDs = tokens.ToArray();
            }
        }

        /// <summary>
        /// Schreibt die Parameter in die zuvor Konfigurierte Log-Datei.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="body"></param>
        /// <param name="userToken"></param>
        /// <param name="tokenIndex"></param>
        /// <param name="priority"></param>
        public void LogTransaction(string title, string body, string userToken, int tokenIndex, int priority, string id = "")
        {
            LogFilePath = Settings.Default.logFilePath;
            List<string> log = new List<string>();
            log.Add(string.Format("---=== Transaction #{0} ===---", Settings.Default.transactionCounter));
            log.Add(">-------------------- Title ---------------------<");
            log.Add(title);
            log.Add(">--------------------- Body ---------------------<");
            log.Add(body);
            log.Add(">--------------------- Infos --------------------<");
            log.Add("UserToken: " + userToken);
            log.Add(string.Format("Appliction-Token: {0} ({1})", TokenNames[tokenIndex], GetTokenByIndex(tokenIndex)));
            log.Add("Priority: " + Prioritys[priority]);
            log.Add("Date sent: " + DateTime.Now.ToString());
            log.Add((id == string.Empty) ? "" : "RequestID: " + id);
            log.Add(">----------------------------------------------<");
            log.Add("");
            log.Add("");
            Settings.Default.transactionCounter++;
            Settings.Default.Save();
            File.AppendAllLines(LogFilePath, log);
        }

        #endregion Methoden
    }
}