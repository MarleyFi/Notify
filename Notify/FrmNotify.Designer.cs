namespace Notify
{
    partial class FrmNotify
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNotify));
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.comboBoxTokens = new System.Windows.Forms.ComboBox();
            this.richTextBoxBody = new System.Windows.Forms.RichTextBox();
            this.labelProgress = new System.Windows.Forms.Label();
            this.comboBoxPriority = new System.Windows.Forms.ComboBox();
            this.checkBoxPriority = new System.Windows.Forms.CheckBox();
            this.checkBoxToken = new System.Windows.Forms.CheckBox();
            this.checkBoxHTML = new System.Windows.Forms.CheckBox();
            this.checkBoxVariables = new System.Windows.Forms.CheckBox();
            this.btnVariables = new System.Windows.Forms.Button();
            this.btnRestoreDefaults = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnTokens = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnBold = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.pictureBoxInternetConnection = new System.Windows.Forms.PictureBox();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.labelPreviewTime = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInternetConnection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.BackColor = System.Drawing.Color.White;
            this.textBoxTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.textBoxTitle.Location = new System.Drawing.Point(101, 48);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(376, 22);
            this.textBoxTitle.TabIndex = 1;
            this.textBoxTitle.Text = "The Caption";
            this.textBoxTitle.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // comboBoxTokens
            // 
            this.comboBoxTokens.BackColor = System.Drawing.SystemColors.Control;
            this.comboBoxTokens.FormattingEnabled = true;
            this.comboBoxTokens.Location = new System.Drawing.Point(270, 141);
            this.comboBoxTokens.Name = "comboBoxTokens";
            this.comboBoxTokens.Size = new System.Drawing.Size(97, 21);
            this.comboBoxTokens.TabIndex = 2;
            this.comboBoxTokens.Text = "Choose token";
            this.comboBoxTokens.SelectedIndexChanged += new System.EventHandler(this.comboBoxTokens_SelectedIndexChanged);
            this.comboBoxTokens.Enter += new System.EventHandler(this.comboBoxTokens_Enter);
            // 
            // richTextBoxBody
            // 
            this.richTextBoxBody.BackColor = System.Drawing.Color.White;
            this.richTextBoxBody.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.richTextBoxBody.Location = new System.Drawing.Point(101, 79);
            this.richTextBoxBody.Name = "richTextBoxBody";
            this.richTextBoxBody.Size = new System.Drawing.Size(414, 49);
            this.richTextBoxBody.TabIndex = 3;
            this.richTextBoxBody.Text = "The body";
            this.richTextBoxBody.TextChanged += new System.EventHandler(this.richTextBoxBody_TextChanged);
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProgress.Location = new System.Drawing.Point(13, 148);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(65, 13);
            this.labelProgress.TabIndex = 9;
            this.labelProgress.Text = "Sending...";
            this.labelProgress.Visible = false;
            // 
            // comboBoxPriority
            // 
            this.comboBoxPriority.BackColor = System.Drawing.SystemColors.Control;
            this.comboBoxPriority.FormattingEnabled = true;
            this.comboBoxPriority.Location = new System.Drawing.Point(149, 141);
            this.comboBoxPriority.Name = "comboBoxPriority";
            this.comboBoxPriority.Size = new System.Drawing.Size(97, 21);
            this.comboBoxPriority.TabIndex = 10;
            this.comboBoxPriority.Text = "Choose priority";
            this.comboBoxPriority.SelectedIndexChanged += new System.EventHandler(this.comboBoxPriority_SelectedIndexChanged);
            // 
            // checkBoxPriority
            // 
            this.checkBoxPriority.AutoSize = true;
            this.checkBoxPriority.BackColor = System.Drawing.SystemColors.Control;
            this.checkBoxPriority.Location = new System.Drawing.Point(128, 144);
            this.checkBoxPriority.Name = "checkBoxPriority";
            this.checkBoxPriority.Size = new System.Drawing.Size(15, 14);
            this.checkBoxPriority.TabIndex = 11;
            this.checkBoxPriority.UseVisualStyleBackColor = false;
            this.checkBoxPriority.CheckedChanged += new System.EventHandler(this.checkBoxPriority_CheckedChanged);
            // 
            // checkBoxToken
            // 
            this.checkBoxToken.AutoSize = true;
            this.checkBoxToken.BackColor = System.Drawing.SystemColors.Control;
            this.checkBoxToken.Location = new System.Drawing.Point(252, 144);
            this.checkBoxToken.Name = "checkBoxToken";
            this.checkBoxToken.Size = new System.Drawing.Size(15, 14);
            this.checkBoxToken.TabIndex = 12;
            this.checkBoxToken.UseVisualStyleBackColor = false;
            this.checkBoxToken.CheckedChanged += new System.EventHandler(this.checkBoxToken_CheckedChanged);
            // 
            // checkBoxHTML
            // 
            this.checkBoxHTML.AutoSize = true;
            this.checkBoxHTML.BackColor = System.Drawing.SystemColors.Control;
            this.checkBoxHTML.Location = new System.Drawing.Point(372, 143);
            this.checkBoxHTML.Name = "checkBoxHTML";
            this.checkBoxHTML.Size = new System.Drawing.Size(56, 17);
            this.checkBoxHTML.TabIndex = 15;
            this.checkBoxHTML.Text = "HTML";
            this.checkBoxHTML.UseVisualStyleBackColor = false;
            this.checkBoxHTML.CheckedChanged += new System.EventHandler(this.checkBoxHTML_CheckedChanged);
            // 
            // checkBoxVariables
            // 
            this.checkBoxVariables.AutoSize = true;
            this.checkBoxVariables.BackColor = System.Drawing.SystemColors.Control;
            this.checkBoxVariables.Location = new System.Drawing.Point(434, 143);
            this.checkBoxVariables.Name = "checkBoxVariables";
            this.checkBoxVariables.Size = new System.Drawing.Size(69, 17);
            this.checkBoxVariables.TabIndex = 16;
            this.checkBoxVariables.Text = "Variables";
            this.checkBoxVariables.UseVisualStyleBackColor = false;
            this.checkBoxVariables.CheckedChanged += new System.EventHandler(this.checkBoxVariables_CheckedChanged);
            // 
            // btnVariables
            // 
            this.btnVariables.FlatAppearance.BorderSize = 0;
            this.btnVariables.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVariables.Image = global::Notify.Properties.Resources.Variable24;
            this.btnVariables.Location = new System.Drawing.Point(497, 135);
            this.btnVariables.Name = "btnVariables";
            this.btnVariables.Size = new System.Drawing.Size(30, 30);
            this.btnVariables.TabIndex = 17;
            this.btnVariables.UseVisualStyleBackColor = true;
            this.btnVariables.Click += new System.EventHandler(this.btnVariables_Click);
            // 
            // btnRestoreDefaults
            // 
            this.btnRestoreDefaults.BackColor = System.Drawing.SystemColors.Control;
            this.btnRestoreDefaults.FlatAppearance.BorderSize = 0;
            this.btnRestoreDefaults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestoreDefaults.Image = global::Notify.Properties.Resources.Refresh;
            this.btnRestoreDefaults.Location = new System.Drawing.Point(84, 12);
            this.btnRestoreDefaults.Name = "btnRestoreDefaults";
            this.btnRestoreDefaults.Size = new System.Drawing.Size(22, 22);
            this.btnRestoreDefaults.TabIndex = 14;
            this.btnRestoreDefaults.UseVisualStyleBackColor = false;
            this.btnRestoreDefaults.Click += new System.EventHandler(this.btnRestoreDefaults_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Enabled = false;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::Notify.Properties.Resources.Star32;
            this.btnSave.Location = new System.Drawing.Point(12, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(30, 30);
            this.btnSave.TabIndex = 13;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnLogin.Image = global::Notify.Properties.Resources.Pushover24;
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogin.Location = new System.Drawing.Point(283, 6);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(100, 25);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "Account";
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnTokens
            // 
            this.btnTokens.FlatAppearance.BorderSize = 0;
            this.btnTokens.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTokens.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnTokens.Image = global::Notify.Properties.Resources.SettingsGear;
            this.btnTokens.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTokens.Location = new System.Drawing.Point(389, 6);
            this.btnTokens.Name = "btnTokens";
            this.btnTokens.Size = new System.Drawing.Size(100, 25);
            this.btnTokens.TabIndex = 4;
            this.btnTokens.Text = "Settings";
            this.btnTokens.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTokens.UseVisualStyleBackColor = true;
            this.btnTokens.Click += new System.EventHandler(this.btnTokens_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.Control;
            this.btnStart.Enabled = false;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Image = global::Notify.Properties.Resources.Notification24;
            this.btnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStart.Location = new System.Drawing.Point(48, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(30, 30);
            this.btnStart.TabIndex = 0;
            this.btnStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnBold
            // 
            this.btnBold.FlatAppearance.BorderSize = 0;
            this.btnBold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBold.Location = new System.Drawing.Point(69, 135);
            this.btnBold.Name = "btnBold";
            this.btnBold.Size = new System.Drawing.Size(29, 23);
            this.btnBold.TabIndex = 20;
            this.btnBold.Text = "B";
            this.btnBold.UseVisualStyleBackColor = true;
            this.btnBold.Visible = false;
            this.btnBold.Click += new System.EventHandler(this.btnBold_Click);
            // 
            // btnColor
            // 
            this.btnColor.FlatAppearance.BorderSize = 0;
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColor.Location = new System.Drawing.Point(93, 135);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(29, 23);
            this.btnColor.TabIndex = 21;
            this.btnColor.Text = "C";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Visible = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // pictureBoxInternetConnection
            // 
            this.pictureBoxInternetConnection.Image = global::Notify.Properties.Resources.WifiSignal3_32;
            this.pictureBoxInternetConnection.Location = new System.Drawing.Point(495, 2);
            this.pictureBoxInternetConnection.Name = "pictureBoxInternetConnection";
            this.pictureBoxInternetConnection.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxInternetConnection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxInternetConnection.TabIndex = 22;
            this.pictureBoxInternetConnection.TabStop = false;
            this.pictureBoxInternetConnection.Click += new System.EventHandler(this.pictureBoxInternetConnection_Click);
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPreview.Image = global::Notify.Properties.Resources.NotifyPreview;
            this.pictureBoxPreview.Location = new System.Drawing.Point(9, 39);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(518, 98);
            this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPreview.TabIndex = 24;
            this.pictureBoxPreview.TabStop = false;
            // 
            // labelPreviewTime
            // 
            this.labelPreviewTime.AutoSize = true;
            this.labelPreviewTime.BackColor = System.Drawing.Color.White;
            this.labelPreviewTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.labelPreviewTime.Location = new System.Drawing.Point(447, 48);
            this.labelPreviewTime.Name = "labelPreviewTime";
            this.labelPreviewTime.Size = new System.Drawing.Size(68, 17);
            this.labelPreviewTime.TabIndex = 25;
            this.labelPreviewTime.Text = "11:11 PM";
            // 
            // FrmNotify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(532, 167);
            this.Controls.Add(this.labelPreviewTime);
            this.Controls.Add(this.richTextBoxBody);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.pictureBoxPreview);
            this.Controls.Add(this.pictureBoxInternetConnection);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.btnBold);
            this.Controls.Add(this.btnVariables);
            this.Controls.Add(this.checkBoxVariables);
            this.Controls.Add(this.checkBoxHTML);
            this.Controls.Add(this.btnRestoreDefaults);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.checkBoxToken);
            this.Controls.Add(this.checkBoxPriority);
            this.Controls.Add(this.comboBoxPriority);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnTokens);
            this.Controls.Add(this.comboBoxTokens);
            this.Controls.Add(this.btnStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmNotify";
            this.Text = "Notify";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmNotify_FormClosing);
            this.Resize += new System.EventHandler(this.FrmNotify_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInternetConnection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.ComboBox comboBoxTokens;
        private System.Windows.Forms.RichTextBox richTextBoxBody;
        private System.Windows.Forms.Button btnTokens;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.ComboBox comboBoxPriority;
        private System.Windows.Forms.CheckBox checkBoxPriority;
        private System.Windows.Forms.CheckBox checkBoxToken;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRestoreDefaults;
        private System.Windows.Forms.CheckBox checkBoxHTML;
        private System.Windows.Forms.CheckBox checkBoxVariables;
        private System.Windows.Forms.Button btnVariables;
        private System.Windows.Forms.Button btnBold;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.PictureBox pictureBoxInternetConnection;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.Label labelPreviewTime;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

