namespace Notifier.UI.Forms
{
    partial class Alert
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
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.btnDiscard = new System.Windows.Forms.Button();
            this.btnPostpone = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblSeparator = new System.Windows.Forms.Label();
            this.cboMinutesToWarnAgain = new System.Windows.Forms.ComboBox();
            this.panSuperiorLine = new System.Windows.Forms.Panel();
            this.tmrFormPosition = new System.Windows.Forms.Timer(this.components);
            this.tmrSetImage = new System.Windows.Forms.Timer(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.tmrAnimation = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Location = new System.Drawing.Point(0, 3);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(128, 128);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxImage.TabIndex = 1;
            this.pictureBoxImage.TabStop = false;
            this.pictureBoxImage.Visible = false;
            // 
            // btnDiscard
            // 
            this.btnDiscard.BackColor = System.Drawing.Color.White;
            this.btnDiscard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDiscard.FlatAppearance.BorderSize = 0;
            this.btnDiscard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiscard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDiscard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiscard.Location = new System.Drawing.Point(0, 189);
            this.btnDiscard.Name = "btnDiscard";
            this.btnDiscard.Size = new System.Drawing.Size(430, 45);
            this.btnDiscard.TabIndex = 4;
            this.btnDiscard.TabStop = false;
            this.btnDiscard.Text = "btnDiscard";
            this.btnDiscard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiscard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDiscard.UseVisualStyleBackColor = false;
            this.btnDiscard.Click += new System.EventHandler(this.btnDiscard_Click);
            // 
            // btnPostpone
            // 
            this.btnPostpone.BackColor = System.Drawing.Color.White;
            this.btnPostpone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPostpone.FlatAppearance.BorderSize = 0;
            this.btnPostpone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPostpone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPostpone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPostpone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPostpone.Location = new System.Drawing.Point(0, 143);
            this.btnPostpone.Name = "btnPostpone";
            this.btnPostpone.Size = new System.Drawing.Size(430, 45);
            this.btnPostpone.TabIndex = 3;
            this.btnPostpone.TabStop = false;
            this.btnPostpone.Text = " btnPostpone";
            this.btnPostpone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPostpone.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPostpone.UseVisualStyleBackColor = false;
            this.btnPostpone.Click += new System.EventHandler(this.btnPostpone_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(134, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(57, 18);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "lblTitle";
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDescription.Location = new System.Drawing.Point(134, 37);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(277, 92);
            this.lblDescription.TabIndex = 9;
            this.lblDescription.Text = "lblDescription";
            // 
            // lblSeparator
            // 
            this.lblSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSeparator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeparator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSeparator.Location = new System.Drawing.Point(-7, 140);
            this.lblSeparator.Name = "lblSeparator";
            this.lblSeparator.Size = new System.Drawing.Size(510, 10);
            this.lblSeparator.TabIndex = 11;
            // 
            // cboMinutesToWarnAgain
            // 
            this.cboMinutesToWarnAgain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboMinutesToWarnAgain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMinutesToWarnAgain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboMinutesToWarnAgain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMinutesToWarnAgain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboMinutesToWarnAgain.FormattingEnabled = true;
            this.cboMinutesToWarnAgain.Location = new System.Drawing.Point(193, 152);
            this.cboMinutesToWarnAgain.Name = "cboMinutesToWarnAgain";
            this.cboMinutesToWarnAgain.Size = new System.Drawing.Size(224, 24);
            this.cboMinutesToWarnAgain.TabIndex = 14;
            this.cboMinutesToWarnAgain.TabStop = false;
            // 
            // panSuperiorLine
            // 
            this.panSuperiorLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(114)))), ((int)(((byte)(37)))));
            this.panSuperiorLine.Location = new System.Drawing.Point(-5, -6);
            this.panSuperiorLine.Name = "panSuperiorLine";
            this.panSuperiorLine.Size = new System.Drawing.Size(450, 10);
            this.panSuperiorLine.TabIndex = 15;
            // 
            // tmrFormPosition
            // 
            this.tmrFormPosition.Enabled = true;
            this.tmrFormPosition.Interval = 1;
            this.tmrFormPosition.Tick += new System.EventHandler(this.tmrFormPosition_Tick);
            // 
            // tmrSetImage
            // 
            this.tmrSetImage.Interval = 1;
            this.tmrSetImage.Tick += new System.EventHandler(this.tmrSetImage_Tick);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(403, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(25, 25);
            this.btnClose.TabIndex = 16;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "X";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Alert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(430, 235);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panSuperiorLine);
            this.Controls.Add(this.cboMinutesToWarnAgain);
            this.Controls.Add(this.btnPostpone);
            this.Controls.Add(this.lblSeparator);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnDiscard);
            this.Controls.Add(this.pictureBoxImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Alert";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "AlertForm";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlertForm_FormClosing);
            this.Load += new System.EventHandler(this.AlertForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Button btnDiscard;
        private System.Windows.Forms.Button btnPostpone;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblSeparator;
        private System.Windows.Forms.ComboBox cboMinutesToWarnAgain;
        private System.Windows.Forms.Panel panSuperiorLine;
        private System.Windows.Forms.Timer tmrFormPosition;
        private System.Windows.Forms.Timer tmrSetImage;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Timer tmrAnimation;
    }
}