using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Windows.Forms;
using Notify.Properties;

namespace Notify
{
    public partial class FrmNotify : Form
    {
        #region Konstruktor

        /// <summary>
        /// Initializes a new instance of the <see cref="Notify.FrmNotify"/> class.
        /// </summary>
        public FrmNotify()
        {

            InitializeComponent();
            Init();
        }

        /// <summary>
        /// Erweiterter Konstruktor
        /// </summary>
        private void Init()
        {
            dataStore = new DataStore();
            if ((ModifierKeys.HasFlag(Keys.RShiftKey) || ModifierKeys.HasFlag(Keys.ControlKey)) && dataStore.CheckStatus() && Networker.CheckConnectionByPing())
            {
                bool success = Networker.FireAutomatedRequest(Settings.Default.defaultTitle, Settings.Default.defaultBody, Settings.Default.defaultHTML, Settings.Default.defaultVariables, Settings.Default.defaultToken, Settings.Default.defaultPriority);
                if (success)
                {
                    Close();
                    return;
                }
            }
            LoadSettings();
        }

        /// <summary>
        /// Lädt die Einstellungen in die Formen
        /// </summary>
        private void LoadSettings()
        {
            comboBoxTokens.DataSource = dataStore.TokenNames;
            tokenIndex = comboBoxTokens.SelectedIndex;
            comboBoxPriority.DataSource = dataStore.Prioritys;
            checkBoxToken.Checked = Settings.Default.tokenEnabled;
            comboBoxTokens.Enabled = Settings.Default.tokenEnabled;
            checkBoxPriority.Checked = Settings.Default.priorityEnabled;
            comboBoxPriority.Enabled = Settings.Default.priorityEnabled;
            comboBoxPriority.SelectedIndex = Settings.Default.selectedIndexPriority;
            checkBoxVariables.Checked = Settings.Default.defaultVariables;
            btnVariables.Visible = checkBoxVariables.Checked;

            if (dataStore.TokenIDs.Length >= 1)
                comboBoxTokens.SelectedIndex = Settings.Default.selectedIndexToken;


            pingTimer.Tick += PingTimer_Tick;
            NotifyIcon.BalloonTipClicked += NotifyIcon_BalloonTipClicked;
            NotifyIcon.MouseClick += NotifyIcon_MouseClick;
            NotifyIcon.MouseDoubleClick += NotifyIcon_MouseDoubleClick;
            PingTimer_Tick(this, null);
            pingTimer.Start();
        }

        #endregion Konstruktor

        #region Interne Variablen

        /// <summary>
        /// DataStore für Interne Daten
        /// </summary>
        public static DataStore dataStore { get; set; }

        /// <summary>
        /// System-Tray Icon
        /// </summary>
        public static NotifyIcon NotifyIcon = new NotifyIcon()
        {
            Visible = true,
            Icon = Resources.Notification
        };

        /// <summary>
        /// Aktuell ausgewählter TokenIndex
        /// </summary>
        private int tokenIndex = 0;

        /// <summary>
        /// 
        /// </summary>
        private Timer pingTimer = new Timer()
        {
            Interval = 10000
        };

        #endregion Interne Variablen

        #region Methoden

        #region Open-Functions

        /// <summary>
        /// Öffnet Notify
        /// </summary>
        private void OpenNotify()
        {
            this.Visible = true;
            //this.Location = new Point(100, 100);
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }

        /// <summary>
        /// Öffnet die Einstellungen
        /// </summary>
        public static void OpenSettings()
        {
            FrmSettings settings = new FrmSettings();
            settings.ShowDialog();
        }

        /// <summary>
        /// Öffnet den Login-Dialog
        /// </summary>
        public static void OpenLogin()
        {
            FrmLogin login = new FrmLogin();
            login.Show();
        }

        /// <summary>
        /// Öffnet den Login-Dialog
        /// </summary>
        public static void OpenVariables()
        {
            FrmVariables variables = new FrmVariables();
            variables.Show();
        }

        #endregion Open-Functions

        #region NotifyIcon-Events

        /// <summary>
        /// Öffnet notify wenn es minimiert ist
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenNotify();
        }

        /// <summary>
        /// Öffnet das Kontextmenü wenn der System-Tray-Icon angeklickt wird
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                BuildContextMenu().Show(Cursor.Position);
            }
        }

        /// <summary>
        /// Öffnet >Notify wenn auf den BallonTip geklickt wird
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void NotifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            OpenNotify();
        }

        #endregion NotifyIcon-Events

        /// <summary>
        /// Baut das ContextMenu für FrmVariables
        /// </summary>
        /// <returns></returns>


        #region ContextMenuEvents

        /// <summary>
        /// Schließt Notify
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Feuert den standard Request aus dem ContextMenü
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void FireRequest_Click(object sender, EventArgs e)
        {
            btnStart_Click(this, null);
        }

        /// <summary>
        /// Öffnet Notify wenn es im System-Tray minimiert ist
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void Open_Click(object sender, EventArgs e)
        {
            OpenNotify();
        }

        #endregion ContextMenuEvents

        /// <summary>
        /// Baut das ContextMenü für das System-Tray-Icon  
        /// </summary>
        /// <returns></returns>
        private ContextMenuStrip BuildContextMenu()
        {
            ToolStripMenuItem open = new ToolStripMenuItem("Open", Resources.Notification24);
            open.Click += Open_Click;
            ToolStripMenuItem fireRequest = new ToolStripMenuItem("Fire Request", Resources.Pushover24)
            {
                Enabled = dataStore.CheckStatus()
            };
            fireRequest.Click += FireRequest_Click;
            ToolStripMenuItem exit = new ToolStripMenuItem("Exit", Resources.Exit24);
            exit.Click += Exit_Click;
            ContextMenuStrip menu = new ContextMenuStrip();
            menu.Items.Add(open);
            menu.Items.Add(fireRequest);
            menu.Items.Add(exit);
            return menu;
        }

        /// <summary>
        /// Speichert die aktuell ausgewählten Einstellungen der Form in die DefaultSettings
        /// </summary>
        private void SaveDefault()
        {
            Settings.Default.defaultTitle = textBoxTitle.Text;
            Settings.Default.defaultBody = richTextBoxBody.Text;
            Settings.Default.defaultHTML = checkBoxHTML.Checked;
            Settings.Default.defaultVariables = checkBoxVariables.Checked;
            if (checkBoxToken.Checked)
            {
                Settings.Default.defaultToken = comboBoxTokens.SelectedIndex;
            }
            else
            {
                Settings.Default.defaultToken = dataStore.GetDefaultTokenIndex();
            }

            if (checkBoxPriority.Checked)
            {
                Settings.Default.defaultPriority = comboBoxPriority.SelectedIndex;
            }
            else
            {
                Settings.Default.defaultPriority = 2;
            }
            Settings.Default.Save();
            btnSave.Enabled = false;
        }

        /// <summary>
        /// Lädt die gespeicherten Standards in die Form
        /// </summary>
        private void RestoreDefault()
        {
            textBoxTitle.Text = Settings.Default.defaultTitle;
            richTextBoxBody.Text = Settings.Default.defaultBody;
            checkBoxHTML.Checked = Settings.Default.defaultHTML;
            comboBoxPriority.SelectedIndex = Settings.Default.defaultPriority;
            checkBoxVariables.Checked = Settings.Default.defaultVariables;
            checkBoxPriority.Checked = Settings.Default.priorityEnabled;
            checkBoxToken.Checked = Settings.Default.tokenEnabled;

            if (dataStore.TokenIDs.Length >= 1)
                comboBoxTokens.SelectedIndex = Settings.Default.defaultToken;
        }

        /// <summary>
        /// Prüft, ob die aktuelle Form von den Standard-Einstellungen abweicht und ändert den Save-Button dementsprechend
        /// </summary>
        private void GetChanges()
        {
            if (textBoxTitle.Text != Settings.Default.defaultTitle ||
                richTextBoxBody.Text != Settings.Default.defaultBody ||
                checkBoxHTML.Checked != Settings.Default.defaultHTML ||
                checkBoxPriority.Checked != Settings.Default.priorityEnabled ||
                checkBoxToken.Checked != Settings.Default.tokenEnabled ||
                checkBoxVariables.Checked != Settings.Default.defaultVariables ||
                comboBoxPriority.SelectedIndex != Settings.Default.defaultPriority ||
                comboBoxTokens.SelectedIndex != Settings.Default.defaultToken)
            {
                btnStart.Enabled = true;
                btnSave.Enabled = true;
                btnSave.Image = Resources.Tick32;
            }
            else
            {
                btnStart.Enabled = true;
                btnSave.Enabled = false;
                btnSave.Image = Resources.Star32;
            }

            if (string.IsNullOrWhiteSpace(richTextBoxBody.Text))
            {
                btnStart.Enabled = false;
                btnSave.Enabled = false;
                btnSave.Image = Resources.Exclamation24;
            }
        }

        /// <summary>
        /// Prüft die Verbindung zu einer bestimmten Domain und gibt ein Bild (32px) für die Visuelle Darstellung zurück
        /// </summary>
        /// <returns>The connection.</returns>
        private System.Drawing.Bitmap CheckConnection()
        {
            labelPreviewTime.Text = DateTime.Now.ToShortTimeString();
            string host = "google.com"/*"s.geiooo.net"*//*"neustar.us"*/;
            if (Settings.Default.SettingAdvancedPing)
            {
                long ping = Networker.CheckConnectionByPingLatency(host);
                dataStore.PingLatency = ping;
                toolTip.SetToolTip(pictureBoxInternetConnection, string.Format("{0}ms on {1}", ping, host));
                if (ping < 25)
                {
                    return Resources.WifiSignal3_32;
                }
                else if (ping < 100)
                {
                    return Resources.WifiSignal2_32;
                }
                else if (ping < 250)
                {
                    return Resources.WifiSignal1_32;
                }
                else if (ping < 500)
                {
                    return Resources.WifiSignal0_32;
                }
                else
                {
                    return Resources.WifiSignalOff;
                    toolTip.SetToolTip(pictureBoxInternetConnection, "No response in >1000ms on " + host);
                }
            }
            else
            {
                return (Networker.CheckConnectionByPing() ? Resources.WifiSignal3_32 : Resources.WifiSignalOff);
            }

        }

        #endregion Methoden

        #region Buttons & Controls

        /// <summary>
        /// Feuert den HTTP-POST
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (dataStore.CheckStatus(true))
            {
                labelProgress.Visible = true;
                labelProgress.Text = "requesting....";
                bool success = Networker.FireRequest(textBoxTitle.Text, richTextBoxBody.Text, checkBoxHTML.Checked, checkBoxVariables.Checked, comboBoxTokens.SelectedIndex, checkBoxToken.Checked, comboBoxPriority.SelectedIndex, checkBoxPriority.Checked);
                if(success)
                {
                    labelProgress.ForeColor = System.Drawing.Color.Green;
                    labelProgress.Text = "Success!";
                }
                else
                {
                    labelProgress.ForeColor = System.Drawing.Color.Red;
                    labelProgress.Text = "Request failed";
                }
            };
            
        }

        /// <summary>
        /// Speichert die aktuell konfiguerieten Einstellungen in die Standard-Settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dataStore.CheckStatus(true))
            {
                SaveDefault();
            };
        }

        /// <summary>
        /// Öffnet den Einstellungs-Dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTokens_Click(object sender, EventArgs e)
        {
            FrmNotify.OpenSettings();
        }

        /// <summary>
		/// Öffnet im Standardbrowser die Homepage des REST-API-Hosters (Pushover)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            OpenLogin();
        }

        /// <summary>
		/// Lädt die gespeicherten Standards in die Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRestoreDefaults_Click(object sender, EventArgs e)
        {
            if (Supporter.AreDefaultsValid())
            {
                RestoreDefault();
            }
        }

        /// <summary>
        /// Öffnet FrmVariables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVariables_Click(object sender, EventArgs e)
        {
            OpenVariables();
        }

        /// <summary>
        /// Aktiviert/Deaktiviert das Auswahlfeld für die Prioritäten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxPriority_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxPriority.Enabled = checkBoxPriority.Checked;
            GetChanges();
        }

        /// <summary>
		/// Aktiviert/Deaktiviert das Auswahlfeld für die Tokens
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxToken_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxTokens.Enabled = checkBoxToken.Checked;
            GetChanges();
        }

        /// <summary>
        /// Öffenet den Schriftart-Dialog
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void btnBold_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                richTextBoxBody.SelectionFont = dlg.Font;
            }
        }

        /// <summary>
        /// Öffnet den Schriftfarben-Dialog
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.ShowDialog();
            richTextBoxBody.SelectionColor = dlg.Color;
        }

        /// <summary>
        /// Feuert einen neuen Ping-Test
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void pictureBoxInternetConnection_Click(object sender, EventArgs e)
        {
            PingTimer_Tick(this, null);
        }

        #endregion Buttons & Controls

        #region Events

        /// <summary>
        /// Prüft alle 10sek die Internetverbindung
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PingTimer_Tick(object sender, EventArgs e)
        {
            pictureBoxInternetConnection.Image = CheckConnection();
            labelProgress.Visible = false;
        }

        /// <summary>
        /// Tritt ein, wenn sich das Hauptfenster Größenmäßig verändert und ändert die sichbarkeit des System-Tray-Icons dementsprechend
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmNotify_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                NotifyIcon.Visible = true;
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                NotifyIcon.Visible = false;
            }
        }

        /// <summary>
        /// Feuert, wenn sich der Text des Titels ändert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxTitle_TextChanged(object sender, EventArgs e)
        {
            GetChanges();
        }

        /// <summary>
		/// Feuert, wenn sich der Text des Bodys ändert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTextBoxBody_TextChanged(object sender, EventArgs e)
        {
            GetChanges();
        }

        /// <summary>
        /// Feuert, wenn sich der ausgewählte Index der Token-Combobox ändert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxTokens_SelectedIndexChanged(object sender, EventArgs e)
        {
            tokenIndex = comboBoxTokens.SelectedIndex;
            GetChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void checkBoxHTML_CheckedChanged(object sender, EventArgs e)
        {
            GetChanges();
        }

        private void checkBoxVariables_CheckedChanged(object sender, EventArgs e)
        {
            btnVariables.Visible = checkBoxVariables.Checked;
            GetChanges();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.selectedIndexPriority = comboBoxPriority.SelectedIndex;
            GetChanges();
            if (comboBoxPriority.SelectedIndex == 4)
            {
                MessageBox.Show("This feature is currently not available", "Not implemented", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxTokens_Enter(object sender, EventArgs e)
        {
            comboBoxTokens.DataSource = dataStore.TokenNames;
        }

        /// <summary>
        /// Speichert beim schließen der Hauptform die Einstellungen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmNotify_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }

        #endregion Events

        Dictionary<string, double> sums = new Dictionary<string, double>();

        public void DoThings()
        {
            sums.Add(GetDisplayText("FZEITTYP", AbweichungFehlzeiten.["ID"]));
        }

        public double GetSum(string typ)
        {
            double value = 0.0;
            foreach(KeyValuePair<string, double> sum in sums)
            {
                if(sum.Key == typ)
                {
                    value += sum.Value;
                }
            }
            return value;
        }

        public double CalcDiff(string typ)
        {
            double plan = AbweichungFehlzeiten.VORGABE;
            double ist = AbweichungFehlzeiten.TERMINE;
            double prognose = AbweichungFehlzeiten.PROGNOSE;
            double diff = 0;

            // die Prognose(falls vorhanden) ersetzt die Plantage
            if (AbweichungFehlzeiten["PROGNOSE"] != DBNull.Value)
            {
                diff = (prognose - ist);
                SumDiffGes += diff;
                switch (typ)
                {
                    case "Azubibetreuung":
                        return (AzubiBet += diff);
                    case "Krankheit":
                        return (Krank += diff);
                    case "Urlaub":
                        return (Urlaub += diff);
                    case "Weiterbildung":
                        return (Weiterbild += diff);
                    default:
                        return diff;
                }
            }
            else
            {
                diff = (plan - ist);
                SumDiffGes += diff;
                switch (typ)
                {
                    case "Azubibetreuung":
                        return (AzubiBet += diff);
                    case "Krankheit":
                        return (Krank += diff);
                    case "Urlaub":
                        return (Urlaub += diff);
                    case "Weiterbildung":
                        return (Weiterbild += diff);
                    default:
                        return diff;
                }
            }
        }
    }
}