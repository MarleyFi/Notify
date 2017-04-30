using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Newtonsoft.Json;
using Notify.Properties;

namespace Notify
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            dataStore = FrmNotify.dataStore;
            textBoxEMail.GotFocus += TextBoxEMail_GotFocus;
            textBoxEMail.Leave += TextBoxEMail_Leave;
            textBoxEMail.TextChanged += TextBoxEMail_TextChanged;
            textBoxPassword.GotFocus += TextBoxPassword_GotFocus;
            textBoxPassword.Leave += TextBoxPassword_Leave;
            textBoxPassword.TextChanged += TextBoxPassword_TextChanged;
            TextBoxPassword_Leave(this, null);
            TextBoxEMail_Leave(this, null);
            checkBoxSave.Focus();
            LoadLogin();
            Check(textBoxEMail.Text, textBoxPassword.Text);
            Login(Settings.Default.loginName);
        }

        private Timer labelTimer = new Timer()
        {
            Interval = 5000
        };

        private DataStore dataStore;

        private string eMail = "EMail-address";

        private string password = "Password";

        private bool invalid = false;

        private bool manual = false;

        public void Login(string eMail, bool manual = false)
        {
            if (eMail != string.Empty && textBoxPassword.Text != string.Empty && IsValidEmail(eMail))
            {
                if (checkBoxSave.Checked)
                {
                    Settings.Default.loginName = eMail;
                    Settings.Default.loginPassword = textBoxPassword.Text;
                    Settings.Default.Save();
                }
                Uri hostAddress = new Uri("https://api.pushover.net/1/users/login.json");
                var parameters = new NameValueCollection
                {
                { "email", eMail },
                { "password", textBoxPassword.Text },
                };

                try
                {
                    using (WebClient client = new WebClient())
                    {
                        client.UploadValuesCompleted += Client_UploadValuesCompleted;

                        labelInfo.Image = Resources.Notification24;
                        labelInfo.ForeColor = Color.Blue;
                        labelInfo.Text = "Requesting...";
                        this.manual = manual;
                        client.UploadValuesAsync(hostAddress, parameters);
                    }
                }
                catch (Exception e)
                {
                    if (textBoxEMail.Text == eMail || textBoxPassword.Text == password)
                    {
                        return;
                    }
                    else
                    {
                        MessageBox.Show(e.Message, "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void SwitchLogStatus(bool loggedIn)
        {
            labelUser.Visible = loggedIn;
            btnLogout.Visible = loggedIn;
            labelDate.Visible = loggedIn;
            textBoxEMail.Visible = !loggedIn;
            textBoxPassword.Visible = !loggedIn;
            btnLogin.Visible = !loggedIn;
            checkBoxSave.Visible = !loggedIn;
        }

        private void SetUpUser(string token, string secret)
        {
            if (Settings.Default.userToken == string.Empty) // Neu erstellen
            {
                Settings.Default.userToken = token;
                Settings.Default.userSecret = secret;
                LoginLabel(true);
            }
            else if (Settings.Default.userToken != string.Empty && Settings.Default.userToken != token) // Vorhandenen überschreiben
            {
                DialogResult result = MessageBox.Show("Override the existing account?\r\n" + Settings.Default.userToken, "Existing UserToken", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (result == DialogResult.Yes)
                {
                    Settings.Default.userToken = token;
                    Settings.Default.userSecret = secret;
                    LoginLabel(true);
                }
                else
                {
                    return;
                }
            }
            else
            {
                LoginLabel(true);
            }
            labelUser.Text = Settings.Default.loginName;
            labelDate.Text = string.Format("{0} {1}", Settings.Default.loginDate.ToLongDateString(), string.Format("{0} {1}", Settings.Default.loginDate.ToShortTimeString(), Supporter.GetAM(Settings.Default.loginDate)));
            Settings.Default.userIsLoggedIn = true;
            SwitchLogStatus(true);
            Settings.Default.Save();
        }

        private void LoginLabel(bool successfull)
        {
            labelTimer.Tick += LabelTimer_Tick; labelTimer.Start();
            labelInfo.Visible = true;
            labelInfo.Image = successfull ? Resources.Tick32 : Resources.Warning32;
            labelInfo.ForeColor = successfull ? Color.Green : Color.Red;
            labelInfo.Text = successfull ? "Successfully logged in" : "Login failed";
        }

        private void LabelTimer_Tick(object sender, EventArgs e)
        {
            labelTimer.Tick -= LabelTimer_Tick;
            labelTimer.Stop();
            labelInfo.Visible = false;
        }

        private void Client_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            if (e.Error == null && e.Result != null) // ToDo: Exception im Production-Build
            {
                LoginDAO response;
                byte[] jsonBytes = e.Result;

                labelInfo.Text = "Verifing...";
                try
                {
                    string jsonString = Encoding.ASCII.GetString(jsonBytes);
                    response = JsonConvert.DeserializeObject<LoginDAO>(jsonString);

                    labelInfo.Text = "Setting up...";

                    if (manual)
                    {
                        Settings.Default.loginDate = DateTime.Now;
                    }
                    SetUpUser(response.id, response.secret);
                    labelInfo.Text = "Successfully logged in!";
                    this.manual = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                if (e.Error.ToString().Contains("403")) // failed
                {
                    LoginLabel(false);
                }
            }

            //btnLogin.Enabled = false;
        }

        private void LoadLogin()
        {
            if (IsValidEmail(Settings.Default.loginName) && Settings.Default.loginPassword.Length > 4)
            {
                textBoxEMail.Text = Settings.Default.loginName;
                textBoxPassword.Text = Settings.Default.loginPassword;
                checkBoxSave.Checked = true;
            }
        }

        private void Check(string email, string password)
        {
            btnLogin.Enabled = (IsValidEmail(email) && (!string.IsNullOrWhiteSpace(password) && password != this.password && password.Length > 4));
        }

        private void TextBoxPassword_Leave(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == string.Empty || textBoxPassword.Text == password)
            {
                textBoxPassword.Text = password;
                textBoxPassword.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void TextBoxPassword_GotFocus(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == password)
            {
                textBoxPassword.Text = string.Empty;
                textBoxPassword.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void TextBoxEMail_Leave(object sender, EventArgs e)
        {
            if (textBoxEMail.Text == string.Empty || textBoxEMail.Text == eMail)
            {
                textBoxEMail.Text = eMail;
                textBoxEMail.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void TextBoxEMail_GotFocus(object sender, EventArgs e)
        {
            if (textBoxEMail.Text == eMail)
            {
                textBoxEMail.Text = string.Empty;
                textBoxEMail.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void TextBoxPassword_TextChanged(object sender, EventArgs e)
        {
            Check(this.textBoxEMail.Text, textBoxPassword.Text);
            //if (textBoxPassword.Text == password || textBoxPassword.Text == string.Empty)
            //{
            //    textBoxPassword.Text = string.Empty;
            //    textBoxPassword.ForeColor = System.Drawing.Color.Black;
            //}
        }

        private void TextBoxEMail_TextChanged(object sender, EventArgs e)
        {
            Check(this.textBoxEMail.Text, textBoxPassword.Text);
            //if (textBoxEMail.Text == eMail || textBoxEMail.Text == string.Empty)
            //{
            //    textBoxEMail.Text = string.Empty;
            //    textBoxEMail.ForeColor = System.Drawing.Color.Black;
            //}
        }

        public bool IsValidEmail(string strIn)
        {
            invalid = false;
            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            try
            {
                strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (invalid)
                return false;

            // Return true if strIn is in valid e-mail format.
            try
            {
                return Regex.IsMatch(strIn,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login(textBoxEMail.Text, true);
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            Supporter.OpenBrowser("https://pushover.net/api");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Settings.Default.userSecret = string.Empty;
            Settings.Default.userToken = string.Empty;
            Settings.Default.loginPassword = string.Empty;
            //Settings.Default.loginName = string.Empty;
            Settings.Default.userIsLoggedIn = false;
            textBoxPassword.Text = string.Empty;
            Settings.Default.Save();
            SwitchLogStatus(false);
        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btnLogin.Enabled)
                {
                    btnLogin_Click(this, null);
                }
            }
        }
    }
}