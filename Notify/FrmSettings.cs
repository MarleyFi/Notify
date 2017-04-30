using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Notify.Properties;

namespace Notify
{
    public partial class FrmSettings : Form
    {
        #region Konstruktor

        /// <summary>
        /// Initializes a new instance of the <see cref="Notify.FrmSettings"/> class.
        /// </summary>
        public FrmSettings()
        {
            InitializeComponent();
            Init();
        }

        #endregion Konstruktor

        #region Interne Variablen

        /// <summary>
        /// 
        /// </summary>
        private DataStore dataStore;

        private bool itemSwitch;

        #endregion Interne Variablen

        #region Methoden

        /// <summary>
        /// Erweiterter Konstruktor
        /// </summary>
        private void Init()
        {
            dataStore = FrmNotify.dataStore;
            LoadSettings();
            FillListBox();
        }

        //public void HelpUser(int index)
        //{

        //}

        private void LoadSettings()
        {
            checkBoxAdvancedPingTest.Checked = Settings.Default.SettingAdvancedPing;
            checkBoxLocalFile.Checked = Settings.Default.SettingUseLocalFile;
            radioButtonJSON.Checked = Settings.Default.SettingUseJSON;
            radioButtonStandard.Checked = !Settings.Default.SettingUseJSON;
            textBoxTokenPath.Text = Settings.Default.filePath;
            textBoxLogPath.Text = Settings.Default.logFilePath;
            textBoxUsertoken.Text = Settings.Default.userToken;
            comboBoxDefaultToken.DataSource = dataStore.TokenNames;
            if (dataStore.TokenIDs.Length >= 1)
                comboBoxDefaultToken.SelectedIndex = Settings.Default.defaultTokenOnStart;
            comboBoxDefaultPriority.DataSource = dataStore.Prioritys;
            comboBoxDefaultPriority.SelectedIndex = Settings.Default.defaultPriority;
            SwitchFileMode(checkBoxLocalFile.Checked);
            Check();
        }

        /// <summary>
        /// 
        /// </summary>
        private void FillListBox()
        {
            //List<string> items = new List<string>();
            for (int i = 0; i < dataStore.TokenNames.Length; i++)
            {
                listBox.Items.Add(string.Format("{0} - {1}", dataStore.TokenNames[i], dataStore.TokenIDs[i]));
            }
            //listBox.DataSource = items;
            btnRefresh.Enabled = true;
            checkBoxShowDownloadedContent.Enabled = true;
            FormatToJSON();
        }

        private void FormatToJSON()
        {
            if (Settings.Default.SettingUseJSON)
            {
                richTextBoxPreview.Text = Settings.Default.SettingUseLocalFile ? Supporter.FormatJson(File.ReadAllText(Settings.Default.filePath)) : File.ReadAllText(Settings.Default.filePath);
            }
            else
            {
                richTextBoxPreview.Text = File.ReadAllText(Settings.Default.filePath);
            }
        }

        private void SwitchFileMode(bool isLocal)
        {
            textBoxTokenURL.Text = isLocal ? Settings.Default.filePath : Settings.Default.fileURL;
            textBoxTokenURL.Enabled = !isLocal;
            labelFileURL.Enabled = !isLocal;
            pictureBoxOfflinemode.Image = isLocal ? Resources.NoSignal24 : Resources.Signal24;
        }

        private void Check()
        {
            if (Settings.Default.SettingUseLocalFile)
            {
                pictureBoxTokenURLCheck.Image = File.Exists(Settings.Default.filePath) ? Resources.TickSmall : Resources.Exclamation24;
            }
            else
            {
                dataStore.IsFileURLValid = Networker.CheckFileURL(Settings.Default.fileURL);
                pictureBoxTokenURLCheck.Image = dataStore.IsFileURLValid ? Resources.Tick32 : Resources.Warning32;
                toolTip.SetToolTip(pictureBoxTokenURLCheck, dataStore.IsFileURLValid ? "URL is responding but its not verified that the data is correct!" : "URL isn't responding");
            }

            pictureBoxUserTokenCheck.Image = Settings.Default.userIsLoggedIn ? Resources.Tick32 : Resources.Exclamation24;
            toolTip.SetToolTip(pictureBoxUserTokenCheck, Settings.Default.userIsLoggedIn ? Settings.Default.loginName + " is logged in" : "This field have to be valid in order to send notifications.\r\nPlease type or sign in");
            pictureBoxTokenFileCheck.Image = File.Exists(Settings.Default.filePath) ? Resources.TickSmall : Resources.Exclamation24;
            pictureBoxLogCheck.Image = File.Exists(Settings.Default.logFilePath) ? Resources.TickSmall : Resources.Exclamation24;
        }

        private void Save()
        {
            textBoxTokenPath.Text = dataStore.CheckDataMode(Settings.Default.SettingUseJSON);
            int index = listBox.SelectedIndex;
            if (index >= 0)
            {
                dataStore.TokenNames[index] = textBoxName.Text;
                dataStore.TokenIDs[index] = textBoxToken.Text;
            }
            if (Settings.Default.SettingUseJSON)
            {
                dataStore.WriteJSONArrays();
            }
            else
            {
                dataStore.WriteArrays();
            }
            listBox.Items.Clear();
            listBox.ClearSelected();
            FillListBox();
            Settings.Default.SettingUseLocalFile = checkBoxLocalFile.Checked;
            Settings.Default.SettingUseJSON = radioButtonJSON.Checked;
            Settings.Default.SettingAdvancedPing = checkBoxAdvancedPingTest.Checked;
            Settings.Default.defaultTokenOnStart = comboBoxDefaultToken.SelectedIndex;
            Settings.Default.defaultPriority = comboBoxDefaultPriority.SelectedIndex;
            Settings.Default.Save();
            Check();
        }

        private bool HasChanges()
        {
            if (
            !checkBoxAdvancedPingTest.Checked == Settings.Default.SettingAdvancedPing ||
            !checkBoxLocalFile.Checked == Settings.Default.SettingUseLocalFile ||
            !radioButtonJSON.Checked == Settings.Default.SettingUseJSON ||
            !(textBoxTokenPath.Text == Settings.Default.filePath) ||
            !(textBoxLogPath.Text == Settings.Default.logFilePath) ||
            !(textBoxUsertoken.Text == Settings.Default.userToken) ||
            !(comboBoxDefaultToken.SelectedIndex == Settings.Default.defaultTokenOnStart) ||
            !(comboBoxDefaultPriority.SelectedIndex == Settings.Default.defaultPriority)
              )
            {
                btnSave.Enabled = true;
                return true;
            }
            btnSave.Enabled = false;
            return false;
        }

        private void UpdateListBox(int index, bool itemSwitch)
        {
            if(!itemSwitch)
            {
                if (index >= 0)
                {
                    dataStore.TokenNames[index] = (textBoxName.Text == string.Empty && !Supporter.ArrayContains(dataStore.TokenNames, textBoxName.Text)) ? dataStore.TokenNames[index] : textBoxName.Text;
                    dataStore.TokenIDs[index] = (textBoxToken.Text == string.Empty && !Supporter.ArrayContains(dataStore.TokenIDs, textBoxToken.Text)) ? dataStore.TokenIDs[index] : textBoxToken.Text;
                    listBox.Items[index] = string.Format("{0} - {1}", dataStore.TokenNames[index], dataStore.TokenIDs[index]);
                }
            }
            itemSwitch = false;
        }

        private void ListToArrays()
        {
        }

        #endregion Methoden

        #region Buttons & Controls

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemSwitch = true;
            if (listBox.SelectedIndex >= 0)
            {
                int index = listBox.SelectedIndex;
                textBoxName.Text = dataStore.TokenNames[index];
                textBoxToken.Text = dataStore.TokenIDs[index];
                btnDel.Enabled = true;
            }
            else
            {
                btnDel.Enabled = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataStore.AddToken("<Application name>", "<Token-Guid>");
            FillListBox();
            listBox.SelectedIndex = (listBox.Items.Count - 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            dataStore.DelToken(listBox.SelectedIndex);
            FillListBox();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShare_Click(object sender, EventArgs e)
        {
            dataStore.SetFileURL();
            textBoxTokenURL.Text = Settings.Default.fileURL;
            Check();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            dataStore.DecideArrays(false);
            FillListBox();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTokenFile_Click(object sender, EventArgs e)
        {
            dataStore.SetTokenPath();
            textBoxTokenPath.Text = Settings.Default.filePath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUserToken_Click(object sender, EventArgs e)
        {
            dataStore.SetUserToken();
            textBoxUsertoken.Text = Settings.Default.userToken;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogFile_Click(object sender, EventArgs e)
        {
            dataStore.SetLogPath();
            textBoxLogPath.Text = Settings.Default.logFilePath;
        }

        #endregion Buttons & Controls

        #region Events
        private void FrmTokens_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (HasChanges())
            {
                DialogResult result = MessageBox.Show("There are some unsaved changes.\r\nDo you want to discard these?", "Unsaved changes", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    return;
                }
                Save();
                //else if(result == DialogResult.Abort)
                //{
                //    e.Cancel = true;
                //    base.OnFormClosing(e);
                //} 
            }
        }

        private void checkBoxLocalFile_CheckedChanged(object sender, EventArgs e)
        {
            SwitchFileMode(checkBoxLocalFile.Checked);
        }

        #endregion Events

        private void textBoxTokenPath_TextChanged(object sender, EventArgs e)
        {
            Check();
        }

        private void textBoxLogPath_TextChanged(object sender, EventArgs e)
        {
            Check();
        }

        private void textBoxTokenURL_TextChanged(object sender, EventArgs e)
        {
            Networker.CheckFileURL(textBoxTokenURL.Text);
            Check();
        }

        private void textBoxTokenURL_DoubleClick(object sender, EventArgs e)
        {
            dataStore.SetFileURL();
            textBoxTokenURL.Text = Settings.Default.fileURL;
        }

        private void textBoxTokenPath_DoubleClick(object sender, EventArgs e)
        {
            dataStore.SetTokenPath();
            textBoxTokenPath.Text = Settings.Default.filePath;
        }

        private void textBoxLogPath_DoubleClick(object sender, EventArgs e)
        {
            dataStore.SetLogPath();
            textBoxLogPath.Text = Settings.Default.logFilePath;
        }

        private void textBoxUsertoken_DoubleClick(object sender, EventArgs e)
        {
            dataStore.SetUserToken();
            textBoxUsertoken.Text = Settings.Default.userToken;
        }

        private void btnGoogleDriveDirectLink_Click(object sender, EventArgs e)
        {
            InputMessageBox directLink = new InputMessageBox("Get GoogleDrive-directLink", "Insert your sharing-link", string.Empty, Resources.GoogleDrive128, false);
            directLink.ShowDialog();
            if (Settings.Default.lastInputCorrect)
            {
                string link = Supporter.GetGoogleDriveDirectLink(Settings.Default.lastInputString);
                if (Settings.Default.lastInputCorrect)
                {
                    DialogResult result = MessageBox.Show("Do you want to use this directlink as new fileURL?\r\nOtherwise it will be copied to your clipboard", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        Settings.Default.fileURL = link;
                    }
                    else
                    {
                        Clipboard.SetText(link);
                    }
                }
                else
                {
                    MessageBox.Show("There was an error with the sharinglink.\r\nYou will be redirected to a website...", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Supporter.OpenBrowser("https://sites.google.com/site/gdocs2direct/");
                }
            }
        }

        private void comboBoxDefaultToken_Enter(object sender, EventArgs e)
        {
            comboBoxDefaultToken.DataSource = dataStore.TokenNames;
        }

        private void radioButtonJSON_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.SettingUseJSON = radioButtonJSON.Checked;
        }

        private void checkBoxShowDownloadedContent_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowDownloadedContent.Checked)
            {
                richTextBoxPreview.Text = Supporter.FormatJson(File.ReadAllText(Settings.Default.filePath));
                richTextBoxPreview.Visible = true;
            }
            else
            {
                richTextBoxPreview.Visible = false;
            }

        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            UpdateListBox(listBox.SelectedIndex, itemSwitch);
            itemSwitch = false;
        }

        private void textBoxToken_TextChanged(object sender, EventArgs e)
        {
            UpdateListBox(listBox.SelectedIndex, itemSwitch);
            itemSwitch = false;
        }
    }
}