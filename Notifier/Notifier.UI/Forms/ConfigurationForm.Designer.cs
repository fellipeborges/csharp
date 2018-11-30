namespace Notifier.UI.Forms
{
    partial class ConfigurationForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboLanguage = new System.Windows.Forms.ComboBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.chkUseAnimation = new System.Windows.Forms.CheckBox();
            this.chkStartsWithWindows = new System.Windows.Forms.CheckBox();
            this.lblGeneral = new System.Windows.Forms.Label();
            this.toolTipGeneral = new System.Windows.Forms.ToolTip(this.components);
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.configEndOfDay = new Notifier.UI.UserControls.ConfiguracoesUserControl();
            this.configLunchReturning = new Notifier.UI.UserControls.ConfiguracoesUserControl();
            this.configLunchLeaving = new Notifier.UI.UserControls.ConfiguracoesUserControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cboLanguage);
            this.panel1.Controls.Add(this.lblLanguage);
            this.panel1.Controls.Add(this.chkUseAnimation);
            this.panel1.Controls.Add(this.chkStartsWithWindows);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 93);
            this.panel1.TabIndex = 3;
            // 
            // cboLanguage
            // 
            this.cboLanguage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLanguage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboLanguage.FormattingEnabled = true;
            this.cboLanguage.Items.AddRange(new object[] {
            "English",
            "Português do Brasil",
            "Português do Gueto"});
            this.cboLanguage.Location = new System.Drawing.Point(78, 56);
            this.cboLanguage.Name = "cboLanguage";
            this.cboLanguage.Size = new System.Drawing.Size(224, 21);
            this.cboLanguage.TabIndex = 2;
            this.cboLanguage.TabStop = false;
            this.cboLanguage.SelectedIndexChanged += new System.EventHandler(this.cboLanguage_SelectedIndexChanged);
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(7, 61);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(65, 13);
            this.lblLanguage.TabIndex = 2;
            this.lblLanguage.Text = "lblLanguage";
            // 
            // chkUseAnimation
            // 
            this.chkUseAnimation.AutoSize = true;
            this.chkUseAnimation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUseAnimation.Location = new System.Drawing.Point(7, 36);
            this.chkUseAnimation.Name = "chkUseAnimation";
            this.chkUseAnimation.Size = new System.Drawing.Size(109, 17);
            this.chkUseAnimation.TabIndex = 1;
            this.chkUseAnimation.Text = "chkUseAnimation";
            this.chkUseAnimation.UseVisualStyleBackColor = true;
            this.chkUseAnimation.CheckedChanged += new System.EventHandler(this.chkUseAnimation_CheckedChanged);
            // 
            // chkStartsWithWindows
            // 
            this.chkStartsWithWindows.AutoSize = true;
            this.chkStartsWithWindows.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStartsWithWindows.Location = new System.Drawing.Point(7, 13);
            this.chkStartsWithWindows.Name = "chkStartsWithWindows";
            this.chkStartsWithWindows.Size = new System.Drawing.Size(137, 17);
            this.chkStartsWithWindows.TabIndex = 0;
            this.chkStartsWithWindows.Text = "chkStartsWithWindows";
            this.chkStartsWithWindows.UseVisualStyleBackColor = true;
            // 
            // lblGeneral
            // 
            this.lblGeneral.AutoSize = true;
            this.lblGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGeneral.Location = new System.Drawing.Point(19, 5);
            this.lblGeneral.Name = "lblGeneral";
            this.lblGeneral.Size = new System.Drawing.Size(64, 13);
            this.lblGeneral.TabIndex = 6;
            this.lblGeneral.Text = "lblGeneral";
            // 
            // configEndOfDay
            // 
            this.configEndOfDay.Location = new System.Drawing.Point(655, 111);
            this.configEndOfDay.Name = "configEndOfDay";
            this.configEndOfDay.Size = new System.Drawing.Size(318, 171);
            this.configEndOfDay.TabIndex = 5;
            // 
            // configLunchReturning
            // 
            this.configLunchReturning.Location = new System.Drawing.Point(331, 111);
            this.configLunchReturning.Name = "configLunchReturning";
            this.configLunchReturning.Size = new System.Drawing.Size(318, 171);
            this.configLunchReturning.TabIndex = 4;
            // 
            // configLunchLeaving
            // 
            this.configLunchLeaving.Location = new System.Drawing.Point(7, 111);
            this.configLunchLeaving.Name = "configLunchLeaving";
            this.configLunchLeaving.Size = new System.Drawing.Size(318, 171);
            this.configLunchLeaving.TabIndex = 3;
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 325);
            this.Controls.Add(this.configEndOfDay);
            this.Controls.Add(this.configLunchReturning);
            this.Controls.Add(this.configLunchLeaving);
            this.Controls.Add(this.lblGeneral);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "ConfigurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConfigurationForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigurationForm_FormClosing);
            this.Load += new System.EventHandler(this.ConfigurationForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkStartsWithWindows;
        private System.Windows.Forms.Label lblGeneral;
        private System.Windows.Forms.Timer tmrAlerts;
        private System.Windows.Forms.Timer tmrPostpone;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip toolTipGeneral;
        private System.Windows.Forms.CheckBox chkUseAnimation;
        private System.Windows.Forms.ColorDialog colorDialog;
        private UserControls.ConfiguracoesUserControl configLunchLeaving;
        private UserControls.ConfiguracoesUserControl configLunchReturning;
        private UserControls.ConfiguracoesUserControl configEndOfDay;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.ComboBox cboLanguage;
    }
}