namespace Notifier.UI.Forms
{
    partial class SetEntrance
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
            this.btnSet = new System.Windows.Forms.Button();
            this.txtMaskedTime = new System.Windows.Forms.MaskedTextBox();
            this.lblLeavingSuggestion = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(12, 49);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(67, 31);
            this.btnSet.TabIndex = 1;
            this.btnSet.Text = "btnSet";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // txtMaskedTime
            // 
            this.txtMaskedTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaskedTime.Location = new System.Drawing.Point(12, 12);
            this.txtMaskedTime.Mask = "00:00";
            this.txtMaskedTime.Name = "txtMaskedTime";
            this.txtMaskedTime.Size = new System.Drawing.Size(67, 31);
            this.txtMaskedTime.TabIndex = 0;
            this.txtMaskedTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMaskedTime.TextChanged += new System.EventHandler(this.txtMaskedTime_TextChanged);
            this.txtMaskedTime.Validating += new System.ComponentModel.CancelEventHandler(this.txtMaskedTime_Validating);
            // 
            // lblLeavingSuggestion
            // 
            this.lblLeavingSuggestion.AutoSize = true;
            this.lblLeavingSuggestion.Location = new System.Drawing.Point(12, 83);
            this.lblLeavingSuggestion.Name = "lblLeavingSuggestion";
            this.lblLeavingSuggestion.Size = new System.Drawing.Size(108, 13);
            this.lblLeavingSuggestion.TabIndex = 2;
            this.lblLeavingSuggestion.Text = "lblLeavingSuggestion";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // SetEntrance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 114);
            this.Controls.Add(this.lblLeavingSuggestion);
            this.Controls.Add(this.txtMaskedTime);
            this.Controls.Add(this.btnSet);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetEntrance";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "SetEntrance";
            this.Load += new System.EventHandler(this.SetEntrance_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.MaskedTextBox txtMaskedTime;
        private System.Windows.Forms.Label lblLeavingSuggestion;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}