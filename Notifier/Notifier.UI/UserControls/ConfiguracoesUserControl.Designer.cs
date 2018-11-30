namespace Notifier.UI.UserControls
{
    partial class ConfiguracoesUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.chkWarn = new System.Windows.Forms.CheckBox();
            this.btnColorPicker = new System.Windows.Forms.Button();
            this.txtRgbColor = new System.Windows.Forms.TextBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.lnkTestAlert = new System.Windows.Forms.LinkLabel();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblWarnMe = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.btnSoundBrowse = new System.Windows.Forms.Button();
            this.numMinutes = new System.Windows.Forms.NumericUpDown();
            this.btnImageBrowse = new System.Windows.Forms.Button();
            this.cboImage = new System.Windows.Forms.ComboBox();
            this.lblWarningImage = new System.Windows.Forms.Label();
            this.cboSound = new System.Windows.Forms.ComboBox();
            this.lblWarningSound = new System.Windows.Forms.Label();
            this.lblWarnMeAfter = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.btnSoundTest = new System.Windows.Forms.Button();
            this.btnImageTest = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.toolTipGeneral = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuImageFinder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemFileSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemGifSearcher = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutes)).BeginInit();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.contextMenuImageFinder.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkWarn
            // 
            this.chkWarn.AutoSize = true;
            this.chkWarn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkWarn.Location = new System.Drawing.Point(11, 0);
            this.chkWarn.Name = "chkWarn";
            this.chkWarn.Size = new System.Drawing.Size(77, 17);
            this.chkWarn.TabIndex = 4;
            this.chkWarn.Text = "chkWarn";
            this.chkWarn.UseVisualStyleBackColor = true;
            this.chkWarn.CheckedChanged += new System.EventHandler(this.chkWarn_CheckedChanged);
            // 
            // btnColorPicker
            // 
            this.btnColorPicker.Location = new System.Drawing.Point(140, 77);
            this.btnColorPicker.Name = "btnColorPicker";
            this.btnColorPicker.Size = new System.Drawing.Size(24, 22);
            this.btnColorPicker.TabIndex = 15;
            this.btnColorPicker.Text = "...";
            this.btnColorPicker.UseVisualStyleBackColor = true;
            this.btnColorPicker.Click += new System.EventHandler(this.btnColorPicker_Click);
            // 
            // txtRgbColor
            // 
            this.txtRgbColor.Location = new System.Drawing.Point(80, 78);
            this.txtRgbColor.Name = "txtRgbColor";
            this.txtRgbColor.Size = new System.Drawing.Size(58, 20);
            this.txtRgbColor.TabIndex = 4;
            // 
            // lblColor
            // 
            this.lblColor.Location = new System.Drawing.Point(8, 81);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(69, 13);
            this.lblColor.TabIndex = 14;
            this.lblColor.Text = "lblColor";
            this.lblColor.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lnkTestAlert
            // 
            this.lnkTestAlert.ActiveLinkColor = System.Drawing.Color.Gray;
            this.lnkTestAlert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkTestAlert.LinkColor = System.Drawing.Color.Gray;
            this.lnkTestAlert.Location = new System.Drawing.Point(140, 7);
            this.lnkTestAlert.Name = "lnkTestAlert";
            this.lnkTestAlert.Size = new System.Drawing.Size(162, 13);
            this.lnkTestAlert.TabIndex = 13;
            this.lnkTestAlert.TabStop = true;
            this.lnkTestAlert.Text = "lnkTestAlert";
            this.lnkTestAlert.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkTestAlert.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkTestAlert_LinkClicked);
            // 
            // lblTime
            // 
            this.lblTime.Location = new System.Drawing.Point(8, 28);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(69, 13);
            this.lblTime.TabIndex = 12;
            this.lblTime.Text = "lblTime";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblWarnMe
            // 
            this.lblWarnMe.Location = new System.Drawing.Point(8, 52);
            this.lblWarnMe.Name = "lblWarnMe";
            this.lblWarnMe.Size = new System.Drawing.Size(69, 13);
            this.lblWarnMe.TabIndex = 11;
            this.lblWarnMe.Text = "lblWarnMe";
            this.lblWarnMe.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "HH:mm";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(80, 24);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.ShowUpDown = true;
            this.dateTimePicker.Size = new System.Drawing.Size(58, 20);
            this.dateTimePicker.TabIndex = 2;
            // 
            // btnSoundBrowse
            // 
            this.btnSoundBrowse.Enabled = false;
            this.btnSoundBrowse.Location = new System.Drawing.Point(275, 103);
            this.btnSoundBrowse.Name = "btnSoundBrowse";
            this.btnSoundBrowse.Size = new System.Drawing.Size(24, 23);
            this.btnSoundBrowse.TabIndex = 6;
            this.btnSoundBrowse.Text = "...";
            this.btnSoundBrowse.UseVisualStyleBackColor = true;
            this.btnSoundBrowse.Click += new System.EventHandler(this.btnSoundBrowse_Click);
            // 
            // numMinutes
            // 
            this.numMinutes.Location = new System.Drawing.Point(80, 50);
            this.numMinutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numMinutes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMinutes.Name = "numMinutes";
            this.numMinutes.Size = new System.Drawing.Size(38, 20);
            this.numMinutes.TabIndex = 3;
            this.numMinutes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnImageBrowse
            // 
            this.btnImageBrowse.Enabled = false;
            this.btnImageBrowse.Location = new System.Drawing.Point(275, 130);
            this.btnImageBrowse.Name = "btnImageBrowse";
            this.btnImageBrowse.Size = new System.Drawing.Size(24, 23);
            this.btnImageBrowse.TabIndex = 8;
            this.btnImageBrowse.Text = "...";
            this.btnImageBrowse.UseVisualStyleBackColor = true;
            this.btnImageBrowse.Click += new System.EventHandler(this.btnImageBrowse_Click);
            // 
            // cboImage
            // 
            this.cboImage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboImage.FormattingEnabled = true;
            this.cboImage.Location = new System.Drawing.Point(80, 131);
            this.cboImage.Name = "cboImage";
            this.cboImage.Size = new System.Drawing.Size(165, 21);
            this.cboImage.TabIndex = 7;
            this.cboImage.SelectedIndexChanged += new System.EventHandler(this.cboImage_SelectedIndexChanged);
            // 
            // lblWarningImage
            // 
            this.lblWarningImage.Location = new System.Drawing.Point(5, 134);
            this.lblWarningImage.Name = "lblWarningImage";
            this.lblWarningImage.Size = new System.Drawing.Size(72, 13);
            this.lblWarningImage.TabIndex = 5;
            this.lblWarningImage.Text = "lblWarningImage";
            this.lblWarningImage.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboSound
            // 
            this.cboSound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSound.FormattingEnabled = true;
            this.cboSound.Location = new System.Drawing.Point(80, 104);
            this.cboSound.Name = "cboSound";
            this.cboSound.Size = new System.Drawing.Size(165, 21);
            this.cboSound.TabIndex = 5;
            this.cboSound.SelectedIndexChanged += new System.EventHandler(this.cboSound_SelectedIndexChanged);
            // 
            // lblWarningSound
            // 
            this.lblWarningSound.Location = new System.Drawing.Point(9, 107);
            this.lblWarningSound.Name = "lblWarningSound";
            this.lblWarningSound.Size = new System.Drawing.Size(68, 13);
            this.lblWarningSound.TabIndex = 3;
            this.lblWarningSound.Text = "lblWarningSound";
            this.lblWarningSound.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblWarnMeAfter
            // 
            this.lblWarnMeAfter.AutoSize = true;
            this.lblWarnMeAfter.Location = new System.Drawing.Point(118, 52);
            this.lblWarnMeAfter.Name = "lblWarnMeAfter";
            this.lblWarnMeAfter.Size = new System.Drawing.Size(80, 13);
            this.lblWarnMeAfter.TabIndex = 1;
            this.lblWarnMeAfter.Text = "lblWarnMeAfter";
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.pictureBoxImage);
            this.panelMain.Controls.Add(this.btnSoundTest);
            this.panelMain.Controls.Add(this.btnImageTest);
            this.panelMain.Controls.Add(this.btnColorPicker);
            this.panelMain.Controls.Add(this.txtRgbColor);
            this.panelMain.Controls.Add(this.lblColor);
            this.panelMain.Controls.Add(this.lnkTestAlert);
            this.panelMain.Controls.Add(this.lblTime);
            this.panelMain.Controls.Add(this.lblWarnMe);
            this.panelMain.Controls.Add(this.dateTimePicker);
            this.panelMain.Controls.Add(this.btnSoundBrowse);
            this.panelMain.Controls.Add(this.numMinutes);
            this.panelMain.Controls.Add(this.btnImageBrowse);
            this.panelMain.Controls.Add(this.cboImage);
            this.panelMain.Controls.Add(this.lblWarningImage);
            this.panelMain.Controls.Add(this.cboSound);
            this.panelMain.Controls.Add(this.lblWarningSound);
            this.panelMain.Controls.Add(this.lblWarnMeAfter);
            this.panelMain.Location = new System.Drawing.Point(5, 7);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(310, 162);
            this.panelMain.TabIndex = 3;
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxImage.Location = new System.Drawing.Point(121, 149);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(128, 128);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxImage.TabIndex = 18;
            this.pictureBoxImage.TabStop = false;
            this.pictureBoxImage.Visible = false;
            // 
            // btnSoundTest
            // 
            this.btnSoundTest.Enabled = false;
            this.btnSoundTest.Image = global::Notifier.UI.Properties.Resources.ImgPlay;
            this.btnSoundTest.Location = new System.Drawing.Point(249, 103);
            this.btnSoundTest.Name = "btnSoundTest";
            this.btnSoundTest.Size = new System.Drawing.Size(24, 23);
            this.btnSoundTest.TabIndex = 16;
            this.btnSoundTest.UseVisualStyleBackColor = true;
            this.btnSoundTest.Click += new System.EventHandler(this.btnSoundTest_Click);
            // 
            // btnImageTest
            // 
            this.btnImageTest.Image = global::Notifier.UI.Properties.Resources.ImgEye;
            this.btnImageTest.Location = new System.Drawing.Point(249, 130);
            this.btnImageTest.Name = "btnImageTest";
            this.btnImageTest.Size = new System.Drawing.Size(24, 23);
            this.btnImageTest.TabIndex = 17;
            this.btnImageTest.UseVisualStyleBackColor = true;
            this.btnImageTest.Click += new System.EventHandler(this.btnImageTest_Click);
            this.btnImageTest.Leave += new System.EventHandler(this.btnImageTest_Leave);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuImageFinder
            // 
            this.contextMenuImageFinder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFileSystem,
            this.toolStripMenuItemGifSearcher});
            this.contextMenuImageFinder.Name = "contextMenuStrip2";
            this.contextMenuImageFinder.Size = new System.Drawing.Size(181, 48);
            // 
            // toolStripMenuItemFileSystem
            // 
            this.toolStripMenuItemFileSystem.Name = "toolStripMenuItemFileSystem";
            this.toolStripMenuItemFileSystem.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemFileSystem.Text = "toolStripMenuItem1";
            this.toolStripMenuItemFileSystem.Click += new System.EventHandler(this.toolStripMenuItemFileSystem_Click);
            // 
            // toolStripMenuItemGifSearcher
            // 
            this.toolStripMenuItemGifSearcher.Name = "toolStripMenuItemGifSearcher";
            this.toolStripMenuItemGifSearcher.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemGifSearcher.Text = "toolStripMenuItem2";
            this.toolStripMenuItemGifSearcher.Click += new System.EventHandler(this.toolStripMenuItemGifSearcher_Click);
            // 
            // ConfiguracoesUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkWarn);
            this.Controls.Add(this.panelMain);
            this.Name = "ConfiguracoesUserControl";
            this.Size = new System.Drawing.Size(318, 171);
            this.Load += new System.EventHandler(this.ConfiguracoesUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numMinutes)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.contextMenuImageFinder.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkWarn;
        private System.Windows.Forms.Button btnColorPicker;
        private System.Windows.Forms.TextBox txtRgbColor;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.LinkLabel lnkTestAlert;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblWarnMe;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button btnSoundBrowse;
        private System.Windows.Forms.NumericUpDown numMinutes;
        private System.Windows.Forms.Button btnImageBrowse;
        private System.Windows.Forms.ComboBox cboImage;
        private System.Windows.Forms.Label lblWarningImage;
        private System.Windows.Forms.ComboBox cboSound;
        private System.Windows.Forms.Label lblWarningSound;
        private System.Windows.Forms.Label lblWarnMeAfter;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ToolTip toolTipGeneral;
        private System.Windows.Forms.Button btnSoundTest;
        private System.Windows.Forms.Button btnImageTest;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuImageFinder;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFileSystem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemGifSearcher;
    }
}
