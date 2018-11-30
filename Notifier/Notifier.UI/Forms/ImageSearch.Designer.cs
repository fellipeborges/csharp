namespace Notifier.UI.Forms
{
    partial class ImageSearch
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
            this.txtSearchterm = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.flowLayoutPanelImages = new System.Windows.Forms.FlowLayoutPanel();
            this.lnkFetchMore = new System.Windows.Forms.LinkLabel();
            this.btnGetTrending = new System.Windows.Forms.Button();
            this.panControls = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.trackBarImageSize = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarImageSize)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearchterm
            // 
            this.txtSearchterm.Location = new System.Drawing.Point(7, 16);
            this.txtSearchterm.MaxLength = 30;
            this.txtSearchterm.Name = "txtSearchterm";
            this.txtSearchterm.Size = new System.Drawing.Size(422, 20);
            this.txtSearchterm.TabIndex = 0;
            this.txtSearchterm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchterm_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(435, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "btnSearch";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // flowLayoutPanelImages
            // 
            this.flowLayoutPanelImages.AutoScroll = true;
            this.flowLayoutPanelImages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.flowLayoutPanelImages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelImages.Location = new System.Drawing.Point(3, 73);
            this.flowLayoutPanelImages.Name = "flowLayoutPanelImages";
            this.flowLayoutPanelImages.Size = new System.Drawing.Size(940, 478);
            this.flowLayoutPanelImages.TabIndex = 2;
            // 
            // lnkFetchMore
            // 
            this.lnkFetchMore.AutoSize = true;
            this.lnkFetchMore.Location = new System.Drawing.Point(7, 39);
            this.lnkFetchMore.Name = "lnkFetchMore";
            this.lnkFetchMore.Size = new System.Drawing.Size(72, 13);
            this.lnkFetchMore.TabIndex = 0;
            this.lnkFetchMore.TabStop = true;
            this.lnkFetchMore.Text = "lnkFetchMore";
            this.lnkFetchMore.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkFetchMore_LinkClicked);
            // 
            // btnGetTrending
            // 
            this.btnGetTrending.Location = new System.Drawing.Point(516, 13);
            this.btnGetTrending.Name = "btnGetTrending";
            this.btnGetTrending.Size = new System.Drawing.Size(75, 23);
            this.btnGetTrending.TabIndex = 3;
            this.btnGetTrending.Text = "btnGetTrending";
            this.btnGetTrending.UseVisualStyleBackColor = true;
            this.btnGetTrending.Click += new System.EventHandler(this.btnGetTrending_Click);
            // 
            // panControls
            // 
            this.panControls.Controls.Add(this.lblStatus);
            this.panControls.Controls.Add(this.lnkFetchMore);
            this.panControls.Controls.Add(this.trackBarImageSize);
            this.panControls.Controls.Add(this.txtSearchterm);
            this.panControls.Controls.Add(this.btnGetTrending);
            this.panControls.Controls.Add(this.btnSearch);
            this.panControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panControls.Location = new System.Drawing.Point(3, 3);
            this.panControls.Name = "panControls";
            this.panControls.Size = new System.Drawing.Size(940, 64);
            this.panControls.TabIndex = 4;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(85, 39);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 13);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "lblStatus";
            // 
            // trackBarImageSize
            // 
            this.trackBarImageSize.Dock = System.Windows.Forms.DockStyle.Right;
            this.trackBarImageSize.Location = new System.Drawing.Point(795, 0);
            this.trackBarImageSize.Maximum = 300;
            this.trackBarImageSize.Minimum = 100;
            this.trackBarImageSize.Name = "trackBarImageSize";
            this.trackBarImageSize.Size = new System.Drawing.Size(145, 64);
            this.trackBarImageSize.SmallChange = 25;
            this.trackBarImageSize.TabIndex = 4;
            this.trackBarImageSize.TickFrequency = 25;
            this.trackBarImageSize.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarImageSize.Value = 100;
            this.trackBarImageSize.Scroll += new System.EventHandler(this.trackBarImageSize_Scroll);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.flowLayoutPanelImages, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.panControls, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(946, 510);
            this.tableLayoutPanel.TabIndex = 5;
            // 
            // ImageSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 510);
            this.Controls.Add(this.tableLayoutPanel);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageSearch";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ImageSearch_FormTitle";
            this.Load += new System.EventHandler(this.ImageSearch_Load);
            this.panControls.ResumeLayout(false);
            this.panControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarImageSize)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearchterm;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelImages;
        private System.Windows.Forms.Button btnGetTrending;
        private System.Windows.Forms.Panel panControls;
        private System.Windows.Forms.TrackBar trackBarImageSize;
        private System.Windows.Forms.LinkLabel lnkFetchMore;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
    }
}