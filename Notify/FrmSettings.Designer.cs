namespace Notify
{
    partial class FrmSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSettings));
            this.listBox = new System.Windows.Forms.ListBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxToken = new System.Windows.Forms.TextBox();
            this.btnTokenFile = new System.Windows.Forms.Button();
            this.btnLogFile = new System.Windows.Forms.Button();
            this.btnShare = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBoxTokens = new System.Windows.Forms.GroupBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.richTextBoxPreview = new System.Windows.Forms.RichTextBox();
            this.labelTokenID = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.labelTokenName = new System.Windows.Forms.Label();
            this.checkBoxShowDownloadedContent = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGoogleDriveDirectLink = new System.Windows.Forms.Button();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.radioButtonJSON = new System.Windows.Forms.RadioButton();
            this.radioButtonStandard = new System.Windows.Forms.RadioButton();
            this.comboBoxDefaultPriority = new System.Windows.Forms.ComboBox();
            this.pictureBoxTokenURLCheck = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxUserTokenCheck = new System.Windows.Forms.PictureBox();
            this.pictureBoxLogCheck = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxTokenFileCheck = new System.Windows.Forms.PictureBox();
            this.labelUsertoken = new System.Windows.Forms.Label();
            this.comboBoxDefaultToken = new System.Windows.Forms.ComboBox();
            this.textBoxUsertoken = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnUserToken = new System.Windows.Forms.Button();
            this.pictureBoxOfflinemode = new System.Windows.Forms.PictureBox();
            this.labelFileURL = new System.Windows.Forms.Label();
            this.checkBoxLocalFile = new System.Windows.Forms.CheckBox();
            this.textBoxTokenURL = new System.Windows.Forms.TextBox();
            this.checkBoxAdvancedPingTest = new System.Windows.Forms.CheckBox();
            this.labelLogPath = new System.Windows.Forms.Label();
            this.textBoxLogPath = new System.Windows.Forms.TextBox();
            this.labelTokenPath = new System.Windows.Forms.Label();
            this.textBoxTokenPath = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxTokens.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.groupBoxSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTokenURLCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserTokenCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTokenFileCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOfflinemode)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(6, 123);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(371, 173);
            this.listBox.TabIndex = 3;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.textBoxName.Location = new System.Drawing.Point(42, 28);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(227, 26);
            this.textBoxName.TabIndex = 4;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // textBoxToken
            // 
            this.textBoxToken.Location = new System.Drawing.Point(42, 75);
            this.textBoxToken.Name = "textBoxToken";
            this.textBoxToken.Size = new System.Drawing.Size(336, 20);
            this.textBoxToken.TabIndex = 5;
            this.textBoxToken.TextChanged += new System.EventHandler(this.textBoxToken_TextChanged);
            // 
            // btnTokenFile
            // 
            this.btnTokenFile.FlatAppearance.BorderSize = 0;
            this.btnTokenFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTokenFile.Image = global::Notify.Properties.Resources.Document24;
            this.btnTokenFile.Location = new System.Drawing.Point(3, 186);
            this.btnTokenFile.Name = "btnTokenFile";
            this.btnTokenFile.Size = new System.Drawing.Size(35, 35);
            this.btnTokenFile.TabIndex = 10;
            this.btnTokenFile.UseVisualStyleBackColor = true;
            this.btnTokenFile.Click += new System.EventHandler(this.btnTokenFile_Click);
            // 
            // btnLogFile
            // 
            this.btnLogFile.FlatAppearance.BorderSize = 0;
            this.btnLogFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogFile.Image = global::Notify.Properties.Resources.Pencil;
            this.btnLogFile.Location = new System.Drawing.Point(3, 231);
            this.btnLogFile.Name = "btnLogFile";
            this.btnLogFile.Size = new System.Drawing.Size(35, 35);
            this.btnLogFile.TabIndex = 9;
            this.btnLogFile.UseVisualStyleBackColor = true;
            this.btnLogFile.Click += new System.EventHandler(this.btnLogFile_Click);
            // 
            // btnShare
            // 
            this.btnShare.FlatAppearance.BorderSize = 0;
            this.btnShare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShare.Image = global::Notify.Properties.Resources.Cloud24;
            this.btnShare.Location = new System.Drawing.Point(3, 145);
            this.btnShare.Name = "btnShare";
            this.btnShare.Size = new System.Drawing.Size(35, 35);
            this.btnShare.TabIndex = 8;
            this.btnShare.UseVisualStyleBackColor = true;
            this.btnShare.Click += new System.EventHandler(this.btnShare_Click);
            // 
            // btnDel
            // 
            this.btnDel.Enabled = false;
            this.btnDel.FlatAppearance.BorderSize = 0;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Image = global::Notify.Properties.Resources.Error;
            this.btnDel.Location = new System.Drawing.Point(47, 94);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(56, 30);
            this.btnDel.TabIndex = 7;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Image = global::Notify.Properties.Resources.Add;
            this.btnAdd.Location = new System.Drawing.Point(4, 94);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(54, 30);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::Notify.Properties.Resources.Save;
            this.btnSave.Location = new System.Drawing.Point(345, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(30, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBoxTokens
            // 
            this.groupBoxTokens.Controls.Add(this.textBoxName);
            this.groupBoxTokens.Controls.Add(this.pictureBox6);
            this.groupBoxTokens.Controls.Add(this.pictureBox5);
            this.groupBoxTokens.Controls.Add(this.richTextBoxPreview);
            this.groupBoxTokens.Controls.Add(this.labelTokenID);
            this.groupBoxTokens.Controls.Add(this.btnRefresh);
            this.groupBoxTokens.Controls.Add(this.labelTokenName);
            this.groupBoxTokens.Controls.Add(this.textBoxToken);
            this.groupBoxTokens.Controls.Add(this.listBox);
            this.groupBoxTokens.Controls.Add(this.btnDel);
            this.groupBoxTokens.Controls.Add(this.btnAdd);
            this.groupBoxTokens.Controls.Add(this.checkBoxShowDownloadedContent);
            this.groupBoxTokens.Location = new System.Drawing.Point(2, 322);
            this.groupBoxTokens.Name = "groupBoxTokens";
            this.groupBoxTokens.Size = new System.Drawing.Size(386, 301);
            this.groupBoxTokens.TabIndex = 11;
            this.groupBoxTokens.TabStop = false;
            this.groupBoxTokens.Text = "Tokens";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::Notify.Properties.Resources.Rename24;
            this.pictureBox6.Location = new System.Drawing.Point(7, 21);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(29, 37);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 29;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::Notify.Properties.Resources.Key24;
            this.pictureBox5.Location = new System.Drawing.Point(6, 59);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(30, 38);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 28;
            this.pictureBox5.TabStop = false;
            // 
            // richTextBoxPreview
            // 
            this.richTextBoxPreview.DetectUrls = false;
            this.richTextBoxPreview.Location = new System.Drawing.Point(6, 123);
            this.richTextBoxPreview.Name = "richTextBoxPreview";
            this.richTextBoxPreview.ReadOnly = true;
            this.richTextBoxPreview.Size = new System.Drawing.Size(370, 173);
            this.richTextBoxPreview.TabIndex = 13;
            this.richTextBoxPreview.Text = "";
            this.richTextBoxPreview.Visible = false;
            // 
            // labelTokenID
            // 
            this.labelTokenID.AutoSize = true;
            this.labelTokenID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.labelTokenID.Location = new System.Drawing.Point(42, 57);
            this.labelTokenID.Name = "labelTokenID";
            this.labelTokenID.Size = new System.Drawing.Size(32, 17);
            this.labelTokenID.TabIndex = 7;
            this.labelTokenID.Text = "Key";
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Image = global::Notify.Properties.Resources.Refresh;
            this.btnRefresh.Location = new System.Drawing.Point(355, 97);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(25, 25);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // labelTokenName
            // 
            this.labelTokenName.AutoSize = true;
            this.labelTokenName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.labelTokenName.Location = new System.Drawing.Point(42, 12);
            this.labelTokenName.Name = "labelTokenName";
            this.labelTokenName.Size = new System.Drawing.Size(45, 17);
            this.labelTokenName.TabIndex = 6;
            this.labelTokenName.Text = "Name";
            // 
            // checkBoxShowDownloadedContent
            // 
            this.checkBoxShowDownloadedContent.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxShowDownloadedContent.AutoSize = true;
            this.checkBoxShowDownloadedContent.Enabled = false;
            this.checkBoxShowDownloadedContent.FlatAppearance.BorderSize = 0;
            this.checkBoxShowDownloadedContent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxShowDownloadedContent.Image = global::Notify.Properties.Resources.Download24;
            this.checkBoxShowDownloadedContent.Location = new System.Drawing.Point(327, 94);
            this.checkBoxShowDownloadedContent.Name = "checkBoxShowDownloadedContent";
            this.checkBoxShowDownloadedContent.Size = new System.Drawing.Size(30, 30);
            this.checkBoxShowDownloadedContent.TabIndex = 14;
            this.toolTip.SetToolTip(this.checkBoxShowDownloadedContent, "Show downloaded Content");
            this.checkBoxShowDownloadedContent.UseVisualStyleBackColor = true;
            this.checkBoxShowDownloadedContent.CheckedChanged += new System.EventHandler(this.checkBoxShowDownloadedContent_CheckedChanged);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::Notify.Properties.Resources.Dropbox32;
            this.button1.Location = new System.Drawing.Point(278, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 9;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnGoogleDriveDirectLink
            // 
            this.btnGoogleDriveDirectLink.FlatAppearance.BorderSize = 0;
            this.btnGoogleDriveDirectLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoogleDriveDirectLink.Image = global::Notify.Properties.Resources.GoogleDrive24;
            this.btnGoogleDriveDirectLink.Location = new System.Drawing.Point(311, 13);
            this.btnGoogleDriveDirectLink.Name = "btnGoogleDriveDirectLink";
            this.btnGoogleDriveDirectLink.Size = new System.Drawing.Size(30, 30);
            this.btnGoogleDriveDirectLink.TabIndex = 8;
            this.btnGoogleDriveDirectLink.UseVisualStyleBackColor = true;
            this.btnGoogleDriveDirectLink.Click += new System.EventHandler(this.btnGoogleDriveDirectLink_Click);
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.pictureBox4);
            this.groupBoxSettings.Controls.Add(this.pictureBox3);
            this.groupBoxSettings.Controls.Add(this.radioButtonJSON);
            this.groupBoxSettings.Controls.Add(this.radioButtonStandard);
            this.groupBoxSettings.Controls.Add(this.button1);
            this.groupBoxSettings.Controls.Add(this.comboBoxDefaultPriority);
            this.groupBoxSettings.Controls.Add(this.btnGoogleDriveDirectLink);
            this.groupBoxSettings.Controls.Add(this.pictureBoxTokenURLCheck);
            this.groupBoxSettings.Controls.Add(this.label1);
            this.groupBoxSettings.Controls.Add(this.pictureBoxUserTokenCheck);
            this.groupBoxSettings.Controls.Add(this.btnSave);
            this.groupBoxSettings.Controls.Add(this.pictureBoxLogCheck);
            this.groupBoxSettings.Controls.Add(this.pictureBox2);
            this.groupBoxSettings.Controls.Add(this.pictureBoxTokenFileCheck);
            this.groupBoxSettings.Controls.Add(this.labelUsertoken);
            this.groupBoxSettings.Controls.Add(this.comboBoxDefaultToken);
            this.groupBoxSettings.Controls.Add(this.textBoxUsertoken);
            this.groupBoxSettings.Controls.Add(this.pictureBox1);
            this.groupBoxSettings.Controls.Add(this.btnUserToken);
            this.groupBoxSettings.Controls.Add(this.pictureBoxOfflinemode);
            this.groupBoxSettings.Controls.Add(this.labelFileURL);
            this.groupBoxSettings.Controls.Add(this.checkBoxLocalFile);
            this.groupBoxSettings.Controls.Add(this.textBoxTokenURL);
            this.groupBoxSettings.Controls.Add(this.checkBoxAdvancedPingTest);
            this.groupBoxSettings.Controls.Add(this.labelLogPath);
            this.groupBoxSettings.Controls.Add(this.textBoxLogPath);
            this.groupBoxSettings.Controls.Add(this.labelTokenPath);
            this.groupBoxSettings.Controls.Add(this.textBoxTokenPath);
            this.groupBoxSettings.Controls.Add(this.btnShare);
            this.groupBoxSettings.Controls.Add(this.btnLogFile);
            this.groupBoxSettings.Controls.Add(this.btnTokenFile);
            this.groupBoxSettings.Location = new System.Drawing.Point(3, 3);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(385, 313);
            this.groupBoxSettings.TabIndex = 12;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Notify.Properties.Resources.List24;
            this.pictureBox4.Location = new System.Drawing.Point(264, 123);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(24, 24);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 27;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Notify.Properties.Resources.JSON32;
            this.pictureBox3.Location = new System.Drawing.Point(264, 100);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 26;
            this.pictureBox3.TabStop = false;
            // 
            // radioButtonJSON
            // 
            this.radioButtonJSON.AutoSize = true;
            this.radioButtonJSON.Location = new System.Drawing.Point(291, 107);
            this.radioButtonJSON.Name = "radioButtonJSON";
            this.radioButtonJSON.Size = new System.Drawing.Size(53, 17);
            this.radioButtonJSON.TabIndex = 25;
            this.radioButtonJSON.TabStop = true;
            this.radioButtonJSON.Text = "JSON";
            this.radioButtonJSON.UseVisualStyleBackColor = true;
            this.radioButtonJSON.CheckedChanged += new System.EventHandler(this.radioButtonJSON_CheckedChanged);
            // 
            // radioButtonStandard
            // 
            this.radioButtonStandard.AutoSize = true;
            this.radioButtonStandard.Location = new System.Drawing.Point(291, 130);
            this.radioButtonStandard.Name = "radioButtonStandard";
            this.radioButtonStandard.Size = new System.Drawing.Size(68, 17);
            this.radioButtonStandard.TabIndex = 24;
            this.radioButtonStandard.TabStop = true;
            this.radioButtonStandard.Text = "Standard";
            this.radioButtonStandard.UseVisualStyleBackColor = true;
            // 
            // comboBoxDefaultPriority
            // 
            this.comboBoxDefaultPriority.FormattingEnabled = true;
            this.comboBoxDefaultPriority.Location = new System.Drawing.Point(205, 22);
            this.comboBoxDefaultPriority.Name = "comboBoxDefaultPriority";
            this.comboBoxDefaultPriority.Size = new System.Drawing.Size(59, 21);
            this.comboBoxDefaultPriority.TabIndex = 9;
            // 
            // pictureBoxTokenURLCheck
            // 
            this.pictureBoxTokenURLCheck.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxTokenURLCheck.Image")));
            this.pictureBoxTokenURLCheck.Location = new System.Drawing.Point(359, 153);
            this.pictureBoxTokenURLCheck.Name = "pictureBoxTokenURLCheck";
            this.pictureBoxTokenURLCheck.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxTokenURLCheck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTokenURLCheck.TabIndex = 22;
            this.pictureBoxTokenURLCheck.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(10, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Default token";
            // 
            // pictureBoxUserTokenCheck
            // 
            this.pictureBoxUserTokenCheck.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxUserTokenCheck.Image")));
            this.pictureBoxUserTokenCheck.Location = new System.Drawing.Point(358, 284);
            this.pictureBoxUserTokenCheck.Name = "pictureBoxUserTokenCheck";
            this.pictureBoxUserTokenCheck.Size = new System.Drawing.Size(24, 23);
            this.pictureBoxUserTokenCheck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxUserTokenCheck.TabIndex = 21;
            this.pictureBoxUserTokenCheck.TabStop = false;
            // 
            // pictureBoxLogCheck
            // 
            this.pictureBoxLogCheck.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogCheck.Image")));
            this.pictureBoxLogCheck.Location = new System.Drawing.Point(359, 244);
            this.pictureBoxLogCheck.Name = "pictureBoxLogCheck";
            this.pictureBoxLogCheck.Size = new System.Drawing.Size(24, 23);
            this.pictureBoxLogCheck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogCheck.TabIndex = 20;
            this.pictureBoxLogCheck.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Notify.Properties.Resources.Key24;
            this.pictureBox2.Location = new System.Drawing.Point(11, 21);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBoxTokenFileCheck
            // 
            this.pictureBoxTokenFileCheck.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxTokenFileCheck.Image")));
            this.pictureBoxTokenFileCheck.Location = new System.Drawing.Point(359, 198);
            this.pictureBoxTokenFileCheck.Name = "pictureBoxTokenFileCheck";
            this.pictureBoxTokenFileCheck.Size = new System.Drawing.Size(24, 23);
            this.pictureBoxTokenFileCheck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTokenFileCheck.TabIndex = 10;
            this.pictureBoxTokenFileCheck.TabStop = false;
            // 
            // labelUsertoken
            // 
            this.labelUsertoken.AutoSize = true;
            this.labelUsertoken.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.labelUsertoken.Location = new System.Drawing.Point(38, 267);
            this.labelUsertoken.Name = "labelUsertoken";
            this.labelUsertoken.Size = new System.Drawing.Size(78, 17);
            this.labelUsertoken.TabIndex = 18;
            this.labelUsertoken.Text = "User-token";
            // 
            // comboBoxDefaultToken
            // 
            this.comboBoxDefaultToken.FormattingEnabled = true;
            this.comboBoxDefaultToken.Location = new System.Drawing.Point(41, 22);
            this.comboBoxDefaultToken.Name = "comboBoxDefaultToken";
            this.comboBoxDefaultToken.Size = new System.Drawing.Size(158, 21);
            this.comboBoxDefaultToken.TabIndex = 7;
            this.comboBoxDefaultToken.Enter += new System.EventHandler(this.comboBoxDefaultToken_Enter);
            // 
            // textBoxUsertoken
            // 
            this.textBoxUsertoken.Location = new System.Drawing.Point(41, 288);
            this.textBoxUsertoken.Name = "textBoxUsertoken";
            this.textBoxUsertoken.ReadOnly = true;
            this.textBoxUsertoken.Size = new System.Drawing.Size(315, 20);
            this.textBoxUsertoken.TabIndex = 19;
            this.textBoxUsertoken.DoubleClick += new System.EventHandler(this.textBoxUsertoken_DoubleClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Notify.Properties.Resources.WifiSignal3_32;
            this.pictureBox1.Location = new System.Drawing.Point(264, 73);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btnUserToken
            // 
            this.btnUserToken.FlatAppearance.BorderSize = 0;
            this.btnUserToken.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserToken.Image = global::Notify.Properties.Resources.Pushover24;
            this.btnUserToken.Location = new System.Drawing.Point(3, 272);
            this.btnUserToken.Name = "btnUserToken";
            this.btnUserToken.Size = new System.Drawing.Size(35, 35);
            this.btnUserToken.TabIndex = 17;
            this.btnUserToken.UseVisualStyleBackColor = true;
            this.btnUserToken.Click += new System.EventHandler(this.btnUserToken_Click);
            // 
            // pictureBoxOfflinemode
            // 
            this.pictureBoxOfflinemode.Image = global::Notify.Properties.Resources.NoSignal24;
            this.pictureBoxOfflinemode.Location = new System.Drawing.Point(264, 45);
            this.pictureBoxOfflinemode.Name = "pictureBoxOfflinemode";
            this.pictureBoxOfflinemode.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxOfflinemode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxOfflinemode.TabIndex = 5;
            this.pictureBoxOfflinemode.TabStop = false;
            // 
            // labelFileURL
            // 
            this.labelFileURL.AutoSize = true;
            this.labelFileURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.labelFileURL.Location = new System.Drawing.Point(38, 137);
            this.labelFileURL.Name = "labelFileURL";
            this.labelFileURL.Size = new System.Drawing.Size(81, 17);
            this.labelFileURL.TabIndex = 14;
            this.labelFileURL.Text = "Token-URL";
            // 
            // checkBoxLocalFile
            // 
            this.checkBoxLocalFile.AutoSize = true;
            this.checkBoxLocalFile.Location = new System.Drawing.Point(291, 50);
            this.checkBoxLocalFile.Name = "checkBoxLocalFile";
            this.checkBoxLocalFile.Size = new System.Drawing.Size(85, 17);
            this.checkBoxLocalFile.TabIndex = 3;
            this.checkBoxLocalFile.Text = "Offline mode";
            this.checkBoxLocalFile.UseVisualStyleBackColor = true;
            this.checkBoxLocalFile.CheckedChanged += new System.EventHandler(this.checkBoxLocalFile_CheckedChanged);
            // 
            // textBoxTokenURL
            // 
            this.textBoxTokenURL.Location = new System.Drawing.Point(41, 157);
            this.textBoxTokenURL.Name = "textBoxTokenURL";
            this.textBoxTokenURL.ReadOnly = true;
            this.textBoxTokenURL.Size = new System.Drawing.Size(315, 20);
            this.textBoxTokenURL.TabIndex = 15;
            this.textBoxTokenURL.TextChanged += new System.EventHandler(this.textBoxTokenURL_TextChanged);
            this.textBoxTokenURL.DoubleClick += new System.EventHandler(this.textBoxTokenURL_DoubleClick);
            // 
            // checkBoxAdvancedPingTest
            // 
            this.checkBoxAdvancedPingTest.AutoSize = true;
            this.checkBoxAdvancedPingTest.Location = new System.Drawing.Point(291, 80);
            this.checkBoxAdvancedPingTest.Name = "checkBoxAdvancedPingTest";
            this.checkBoxAdvancedPingTest.Size = new System.Drawing.Size(99, 17);
            this.checkBoxAdvancedPingTest.TabIndex = 4;
            this.checkBoxAdvancedPingTest.Text = "Advanced Ping";
            this.checkBoxAdvancedPingTest.UseVisualStyleBackColor = true;
            // 
            // labelLogPath
            // 
            this.labelLogPath.AutoSize = true;
            this.labelLogPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.labelLogPath.Location = new System.Drawing.Point(38, 226);
            this.labelLogPath.Name = "labelLogPath";
            this.labelLogPath.Size = new System.Drawing.Size(55, 17);
            this.labelLogPath.TabIndex = 12;
            this.labelLogPath.Text = "Log-file";
            // 
            // textBoxLogPath
            // 
            this.textBoxLogPath.Location = new System.Drawing.Point(41, 247);
            this.textBoxLogPath.Name = "textBoxLogPath";
            this.textBoxLogPath.ReadOnly = true;
            this.textBoxLogPath.Size = new System.Drawing.Size(315, 20);
            this.textBoxLogPath.TabIndex = 13;
            this.textBoxLogPath.TextChanged += new System.EventHandler(this.textBoxLogPath_TextChanged);
            this.textBoxLogPath.DoubleClick += new System.EventHandler(this.textBoxLogPath_DoubleClick);
            // 
            // labelTokenPath
            // 
            this.labelTokenPath.AutoSize = true;
            this.labelTokenPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.labelTokenPath.Location = new System.Drawing.Point(38, 180);
            this.labelTokenPath.Name = "labelTokenPath";
            this.labelTokenPath.Size = new System.Drawing.Size(71, 17);
            this.labelTokenPath.TabIndex = 8;
            this.labelTokenPath.Text = "Token-file";
            // 
            // textBoxTokenPath
            // 
            this.textBoxTokenPath.Location = new System.Drawing.Point(41, 201);
            this.textBoxTokenPath.Name = "textBoxTokenPath";
            this.textBoxTokenPath.ReadOnly = true;
            this.textBoxTokenPath.Size = new System.Drawing.Size(315, 20);
            this.textBoxTokenPath.TabIndex = 11;
            this.textBoxTokenPath.TextChanged += new System.EventHandler(this.textBoxTokenPath_TextChanged);
            this.textBoxTokenPath.DoubleClick += new System.EventHandler(this.textBoxTokenPath_DoubleClick);
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 624);
            this.Controls.Add(this.groupBoxSettings);
            this.Controls.Add(this.groupBoxTokens);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSettings";
            this.Text = "Tokens";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTokens_FormClosing);
            this.groupBoxTokens.ResumeLayout(false);
            this.groupBoxTokens.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTokenURLCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserTokenCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTokenFileCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOfflinemode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxToken;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnShare;
        private System.Windows.Forms.Button btnLogFile;
        private System.Windows.Forms.Button btnTokenFile;
        private System.Windows.Forms.GroupBox groupBoxTokens;
        private System.Windows.Forms.Label labelTokenID;
        private System.Windows.Forms.Label labelTokenName;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.Label labelFileURL;
        private System.Windows.Forms.TextBox textBoxTokenURL;
        private System.Windows.Forms.Label labelLogPath;
        private System.Windows.Forms.TextBox textBoxLogPath;
        private System.Windows.Forms.Label labelTokenPath;
        private System.Windows.Forms.TextBox textBoxTokenPath;
        private System.Windows.Forms.CheckBox checkBoxLocalFile;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.CheckBox checkBoxAdvancedPingTest;
        private System.Windows.Forms.Label labelUsertoken;
        private System.Windows.Forms.TextBox textBoxUsertoken;
        private System.Windows.Forms.Button btnUserToken;
        private System.Windows.Forms.PictureBox pictureBoxOfflinemode;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox comboBoxDefaultToken;
        private System.Windows.Forms.ComboBox comboBoxDefaultPriority;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxTokenURLCheck;
        private System.Windows.Forms.PictureBox pictureBoxUserTokenCheck;
        private System.Windows.Forms.PictureBox pictureBoxLogCheck;
        private System.Windows.Forms.PictureBox pictureBoxTokenFileCheck;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnGoogleDriveDirectLink;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButtonJSON;
        private System.Windows.Forms.RadioButton radioButtonStandard;
        private System.Windows.Forms.RichTextBox richTextBoxPreview;
        private System.Windows.Forms.CheckBox checkBoxShowDownloadedContent;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}