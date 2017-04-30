using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Notify.Properties;

namespace Notify
{
    public partial class InputMessageBox : Form
    {
        #region Konstruktor

        /// <summary>
        /// Initializes a new instance of the <see cref="Notify.InputMessageBox"/> class.
        /// </summary>
        /// <param name="label">Label.</param>
        public InputMessageBox(string label)
        {
            InitializeComponent();
            this.Text = "Input value";
            labelDesc.Text = label;
            Init();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Notify.InputMessageBox"/> class.
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="descriptionText">Description text.</param>
        public InputMessageBox(string title, string descriptionText)
        {
            InitializeComponent();
            this.Text = title;
            labelDesc.Text = descriptionText;
            Init();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Notify.InputMessageBox"/> class.
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="descriptionText">Description text.</param>
        /// <param name="textBoxText">Text box text.</param>
        public InputMessageBox(string title, string descriptionText, string textBoxText)
        {
            InitializeComponent();
            this.Text = title;
            labelDesc.Text = descriptionText;
            textBoxInput.Text = textBoxText;
            Init();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Notify.InputMessageBox"/> class.
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="descriptionText">Description text.</param>
        /// <param name="textBoxText">Text box text.</param>
        /// <param name="pic">Pic.</param>
        /// <param name="fileBrowser">If set to <c>true</c> file browser.</param>
        public InputMessageBox(string title, string descriptionText, string textBoxText, Bitmap pic, bool fileBrowser = false)
        {
            InitializeComponent();
            this.Text = title;
            labelDesc.Text = descriptionText;
            textBoxInput.Text = textBoxText;
            pictureBoxIcon.Image = pic;
            //preferedFileName = standartFileName;
            btnFolderBrowse.Visible = fileBrowser;
            btnDropbox.Visible = fileBrowser;
            btnGoogleDrive.Visible = fileBrowser;
            Init();
        }

        /// <summary>
        /// UserToken input 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="descriptionText"></param>
        /// <param name="textBoxText"></param>
        /// <param name="btn"></param>
        public InputMessageBox(string title, string descriptionText, string textBoxText, Button btn)
        {
            InitializeComponent();
            this.Text = title;
            labelDesc.Text = descriptionText;
            textBoxInput.Text = textBoxText;
            pictureBoxIcon.Image = Resources.Pushover512;
            btnLogin.Visible = true;
            btnFolderBrowse.Visible = false;
            btnLogin = btn;
            Init();
        }

        #endregion Konstruktor

        #region Interne Variablen

        private DataStore dataStore;

        string preferedFileName;

        #endregion Interne Variablen

        #region Methoden

        private void Init()
        {
            dataStore = FrmNotify.dataStore;
        }

        private void TryFindDropbox(/*string fileName*/)
        {
            string dropboxNotifyPath;
            string userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string defaultDropboxPath = Path.Combine(userPath, "Dropbox");
            if (/*Directory.Exists(defaultDropboxPath)*/false) {
                dropboxNotifyPath = Path.Combine(defaultDropboxPath, "Apps", "Notify");
                Directory.CreateDirectory(dropboxNotifyPath);
                OpenFileBrowserDialog(dropboxNotifyPath);
            }
            else
            {
                try
                {
                    var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Dropbox\\host.db");
                    var dbBase64Text = Convert.FromBase64String(File.ReadAllText(dbPath));
                    var folderPath = System.Text.ASCIIEncoding.ASCII.GetString(dbBase64Text);
                    dropboxNotifyPath = Path.Combine(folderPath, "Apps", "Notify");
                    Directory.CreateDirectory(dropboxNotifyPath);
                    OpenFileBrowserDialog(dropboxNotifyPath);
                }
                catch (Exception)
                {
                    OpenFileBrowserDialog(userPath);
                }
                
            }
        }

        private void TryFindGoogleDrive(/*string filename*/)
        {
            string googleDriveNotifyPath;
            string userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string defaultGoogleDrivePath = Path.Combine(userPath, "Google Drive");

            if (Directory.Exists(defaultGoogleDrivePath))
            {
                googleDriveNotifyPath = Path.Combine(defaultGoogleDrivePath, "Apps", "Notify");
                Directory.CreateDirectory(googleDriveNotifyPath);
                OpenFileBrowserDialog(googleDriveNotifyPath);
            }
            else
            {
                OpenFileBrowserDialog(userPath);
            }
        }

        #endregion Methoden

        #region Buttons & Controls

        private void btnOK_Click(object sender, EventArgs e)
        {
            Settings.Default.lastInputCorrect = true;
            Settings.Default.lastInputString = textBoxInput.Text;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Settings.Default.lastInputCorrect = false;
            Close();
        }

        private void btnFolderBrowse_Click(object sender, EventArgs e)
        {
            OpenFileBrowserDialog();

            #endregion Buttons & Controls
        }

        private void OpenFileBrowserDialog(string path = null)
        {
            string defaultPath;
            if (path != null && Directory.Exists(path))
            {
                defaultPath = path;
            }
            else
            {
                defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); 
            }
            
            FolderBrowserDialogEx folderBrowse = new FolderBrowserDialogEx()
            {
                Description = "Choose a directory",
                ShowNewFolderButton = true,
                SelectedPath = Directory.Exists(defaultPath) ? defaultPath : textBoxInput.Text,
                ShowEditBox = true,
                ShowFullPathInEditBox = true,
            };
            folderBrowse.ShowDialog();
            if (Directory.Exists(folderBrowse.SelectedPath) || File.Exists(folderBrowse.SelectedPath) /*|| folderBrowse.SelectedPath != (Directory.Exists(path) ? path : defaultPath)*/)
            {
                textBoxInput.Text = folderBrowse.SelectedPath;
            }
        }

        private void btnDropbox_Click(object sender, EventArgs e)
        {
            TryFindDropbox(/*preferedFileName*/);
        }

        private void btnGoogleDrive_Click(object sender, EventArgs e)
        {
            TryFindGoogleDrive(/*preferedFileName*/);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            FrmNotify.OpenLogin();
            this.Close();
        }

        private void InputMessageBox_Load(object sender, EventArgs e)
        {

        }
    }
}