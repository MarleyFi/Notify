namespace Notify
{
    partial class InputMessageBox
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
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.labelDesc = new System.Windows.Forms.Label();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.btnFolderBrowse = new System.Windows.Forms.Button();
            this.btnDropbox = new System.Windows.Forms.Button();
            this.btnGoogleDrive = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxInput
            // 
            this.textBoxInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.textBoxInput.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBoxInput.Location = new System.Drawing.Point(85, 22);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(291, 20);
            this.textBoxInput.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(85, 48);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(122, 24);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(294, 48);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(122, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelDesc
            // 
            this.labelDesc.AutoSize = true;
            this.labelDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.labelDesc.Location = new System.Drawing.Point(81, -1);
            this.labelDesc.Name = "labelDesc";
            this.labelDesc.Size = new System.Drawing.Size(89, 20);
            this.labelDesc.TabIndex = 3;
            this.labelDesc.Text = "Type value";
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Image = global::Notify.Properties.Resources.Info128;
            this.pictureBoxIcon.Location = new System.Drawing.Point(2, 1);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(77, 77);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxIcon.TabIndex = 4;
            this.pictureBoxIcon.TabStop = false;
            // 
            // btnFolderBrowse
            // 
            this.btnFolderBrowse.FlatAppearance.BorderSize = 0;
            this.btnFolderBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFolderBrowse.Image = global::Notify.Properties.Resources.Folder32;
            this.btnFolderBrowse.Location = new System.Drawing.Point(382, 12);
            this.btnFolderBrowse.Name = "btnFolderBrowse";
            this.btnFolderBrowse.Size = new System.Drawing.Size(34, 30);
            this.btnFolderBrowse.TabIndex = 5;
            this.btnFolderBrowse.UseVisualStyleBackColor = true;
            this.btnFolderBrowse.Click += new System.EventHandler(this.btnFolderBrowse_Click);
            // 
            // btnDropbox
            // 
            this.btnDropbox.Image = global::Notify.Properties.Resources.Dropbox32;
            this.btnDropbox.Location = new System.Drawing.Point(235, 44);
            this.btnDropbox.Name = "btnDropbox";
            this.btnDropbox.Size = new System.Drawing.Size(30, 30);
            this.btnDropbox.TabIndex = 6;
            this.btnDropbox.UseVisualStyleBackColor = true;
            this.btnDropbox.Visible = false;
            this.btnDropbox.Click += new System.EventHandler(this.btnDropbox_Click);
            // 
            // btnGoogleDrive
            // 
            this.btnGoogleDrive.Image = global::Notify.Properties.Resources.GoogleDrive24;
            this.btnGoogleDrive.Location = new System.Drawing.Point(264, 44);
            this.btnGoogleDrive.Name = "btnGoogleDrive";
            this.btnGoogleDrive.Size = new System.Drawing.Size(30, 30);
            this.btnGoogleDrive.TabIndex = 7;
            this.btnGoogleDrive.UseVisualStyleBackColor = true;
            this.btnGoogleDrive.Visible = false;
            this.btnGoogleDrive.Click += new System.EventHandler(this.btnGoogleDrive_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Image = global::Notify.Properties.Resources.Login32;
            this.btnLogin.Location = new System.Drawing.Point(380, 8);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(34, 34);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Visible = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // InputMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(419, 75);
            this.ControlBox = false;
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnGoogleDrive);
            this.Controls.Add(this.btnDropbox);
            this.Controls.Add(this.btnFolderBrowse);
            this.Controls.Add(this.pictureBoxIcon);
            this.Controls.Add(this.labelDesc);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.textBoxInput);
            this.Name = "InputMessageBox";
            this.ShowInTaskbar = false;
            this.Text = "InputMessageBox";
            this.Load += new System.EventHandler(this.InputMessageBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label labelDesc;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Button btnFolderBrowse;
        private System.Windows.Forms.Button btnDropbox;
        private System.Windows.Forms.Button btnGoogleDrive;
        private System.Windows.Forms.Button btnLogin;
    }
}