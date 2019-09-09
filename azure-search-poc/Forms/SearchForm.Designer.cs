namespace AzureSearchPoC.Forms
{
    partial class SearchForm
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
            this.cboSorting = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchTerm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lstContentType = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lstCategory = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lstHasVideo = new System.Windows.Forms.ListBox();
            this.btnRebuildIndex = new System.Windows.Forms.Button();
            this.lblRecordsFound = new System.Windows.Forms.Label();
            this.webBrowserResults = new System.Windows.Forms.WebBrowser();
            this.toolStripStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrSuggestion = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lstSuggestion = new System.Windows.Forms.ListBox();
            this.lblPage = new System.Windows.Forms.Label();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnPreviousPage = new System.Windows.Forms.Button();
            this.btnLastsPage = new System.Windows.Forms.Button();
            this.btnFirstPage = new System.Windows.Forms.Button();
            this.lblSearchDuration = new System.Windows.Forms.Label();
            this.statusStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboSorting
            // 
            this.cboSorting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSorting.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSorting.FormattingEnabled = true;
            this.cboSorting.Items.AddRange(new object[] {
            "Default",
            "Content ID (Asc)",
            "Content ID (Desc)",
            "Title (Asc)",
            "Title (Desc)"});
            this.cboSorting.Location = new System.Drawing.Point(826, 25);
            this.cboSorting.Name = "cboSorting";
            this.cboSorting.Size = new System.Drawing.Size(239, 26);
            this.cboSorting.TabIndex = 2;
            this.cboSorting.SelectedIndexChanged += new System.EventHandler(this.cboSorting_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(823, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Sort field";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(745, 24);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 28);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchTerm
            // 
            this.txtSearchTerm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchTerm.Location = new System.Drawing.Point(10, 25);
            this.txtSearchTerm.Name = "txtSearchTerm";
            this.txtSearchTerm.Size = new System.Drawing.Size(729, 26);
            this.txtSearchTerm.TabIndex = 0;
            this.txtSearchTerm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearchTerm_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search term";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Content type";
            // 
            // lstContentType
            // 
            this.lstContentType.FormattingEnabled = true;
            this.lstContentType.Location = new System.Drawing.Point(12, 105);
            this.lstContentType.Name = "lstContentType";
            this.lstContentType.Size = new System.Drawing.Size(203, 43);
            this.lstContentType.TabIndex = 3;
            this.lstContentType.DoubleClick += new System.EventHandler(this.lstContentType_DoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Category";
            // 
            // lstCategory
            // 
            this.lstCategory.FormattingEnabled = true;
            this.lstCategory.Location = new System.Drawing.Point(10, 175);
            this.lstCategory.Name = "lstCategory";
            this.lstCategory.Size = new System.Drawing.Size(203, 290);
            this.lstCategory.TabIndex = 4;
            this.lstCategory.DoubleClick += new System.EventHandler(this.lstCategory_DoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 477);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Has video";
            // 
            // lstHasVideo
            // 
            this.lstHasVideo.FormattingEnabled = true;
            this.lstHasVideo.Location = new System.Drawing.Point(12, 493);
            this.lstHasVideo.Name = "lstHasVideo";
            this.lstHasVideo.Size = new System.Drawing.Size(203, 121);
            this.lstHasVideo.TabIndex = 5;
            this.lstHasVideo.DoubleClick += new System.EventHandler(this.lstHasVideo_DoubleClick);
            // 
            // btnRebuildIndex
            // 
            this.btnRebuildIndex.Location = new System.Drawing.Point(12, 630);
            this.btnRebuildIndex.Name = "btnRebuildIndex";
            this.btnRebuildIndex.Size = new System.Drawing.Size(201, 26);
            this.btnRebuildIndex.TabIndex = 5;
            this.btnRebuildIndex.Text = "Rebuild index and load data";
            this.btnRebuildIndex.UseVisualStyleBackColor = true;
            this.btnRebuildIndex.Click += new System.EventHandler(this.btnRebuildIndex_Click);
            // 
            // lblRecordsFound
            // 
            this.lblRecordsFound.AutoSize = true;
            this.lblRecordsFound.Location = new System.Drawing.Point(228, 89);
            this.lblRecordsFound.Name = "lblRecordsFound";
            this.lblRecordsFound.Size = new System.Drawing.Size(87, 13);
            this.lblRecordsFound.TabIndex = 3;
            this.lblRecordsFound.Text = "lblRecordsFound";
            // 
            // webBrowserResults
            // 
            this.webBrowserResults.Location = new System.Drawing.Point(231, 105);
            this.webBrowserResults.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserResults.Name = "webBrowserResults";
            this.webBrowserResults.Size = new System.Drawing.Size(835, 476);
            this.webBrowserResults.TabIndex = 0;
            // 
            // toolStripStatusLabelStatus
            // 
            this.toolStripStatusLabelStatus.Name = "toolStripStatusLabelStatus";
            this.toolStripStatusLabelStatus.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabelStatus.Text = "toolStripStatusLabel1";
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStripMain.Location = new System.Drawing.Point(0, 700);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(1362, 22);
            this.statusStripMain.TabIndex = 5;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(112, 17);
            this.toolStripStatusLabel.Text = "toolStripStatusLabel";
            // 
            // tmrSuggestion
            // 
            this.tmrSuggestion.Interval = 250;
            this.tmrSuggestion.Tick += new System.EventHandler(this.tmrSuggestion_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(12, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1053, 1);
            this.panel1.TabIndex = 13;
            // 
            // lstSuggestion
            // 
            this.lstSuggestion.FormattingEnabled = true;
            this.lstSuggestion.Location = new System.Drawing.Point(1086, 506);
            this.lstSuggestion.Name = "lstSuggestion";
            this.lstSuggestion.Size = new System.Drawing.Size(282, 95);
            this.lstSuggestion.TabIndex = 14;
            this.lstSuggestion.Visible = false;
            this.lstSuggestion.DoubleClick += new System.EventHandler(this.lstSuggestion_DoubleClick);
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.Location = new System.Drawing.Point(228, 590);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(42, 13);
            this.lblPage.TabIndex = 15;
            this.lblPage.Text = "lblPage";
            // 
            // btnNextPage
            // 
            this.btnNextPage.Enabled = false;
            this.btnNextPage.Location = new System.Drawing.Point(1015, 586);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(27, 26);
            this.btnNextPage.TabIndex = 16;
            this.btnNextPage.Text = ">";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Enabled = false;
            this.btnPreviousPage.Location = new System.Drawing.Point(989, 586);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(27, 26);
            this.btnPreviousPage.TabIndex = 17;
            this.btnPreviousPage.Text = "<";
            this.btnPreviousPage.UseVisualStyleBackColor = true;
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            // 
            // btnLastsPage
            // 
            this.btnLastsPage.Enabled = false;
            this.btnLastsPage.Location = new System.Drawing.Point(1041, 586);
            this.btnLastsPage.Name = "btnLastsPage";
            this.btnLastsPage.Size = new System.Drawing.Size(27, 26);
            this.btnLastsPage.TabIndex = 18;
            this.btnLastsPage.Text = ">|";
            this.btnLastsPage.UseVisualStyleBackColor = true;
            this.btnLastsPage.Click += new System.EventHandler(this.btnLastsPage_Click);
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.Enabled = false;
            this.btnFirstPage.Location = new System.Drawing.Point(963, 586);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(27, 26);
            this.btnFirstPage.TabIndex = 19;
            this.btnFirstPage.Text = "|<";
            this.btnFirstPage.UseVisualStyleBackColor = true;
            this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
            // 
            // lblSearchDuration
            // 
            this.lblSearchDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchDuration.Location = new System.Drawing.Point(868, 89);
            this.lblSearchDuration.Name = "lblSearchDuration";
            this.lblSearchDuration.Size = new System.Drawing.Size(196, 13);
            this.lblSearchDuration.TabIndex = 20;
            this.lblSearchDuration.Text = "lblSearchDuration";
            this.lblSearchDuration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 722);
            this.Controls.Add(this.lblSearchDuration);
            this.Controls.Add(this.btnFirstPage);
            this.Controls.Add(this.btnLastsPage);
            this.Controls.Add(this.btnPreviousPage);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.lblPage);
            this.Controls.Add(this.lstSuggestion);
            this.Controls.Add(this.cboSorting);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblRecordsFound);
            this.Controls.Add(this.lstContentType);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSearchTerm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstCategory);
            this.Controls.Add(this.webBrowserResults);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.lstHasVideo);
            this.Controls.Add(this.btnRebuildIndex);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "SearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Azure Search Proof of Concept";
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtSearchTerm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cboSorting;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.WebBrowser webBrowserResults;
        private System.Windows.Forms.Button btnRebuildIndex;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatus;
        private System.Windows.Forms.Label lblRecordsFound;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstHasVideo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstCategory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lstContentType;
        private System.Windows.Forms.Timer tmrSuggestion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lstSuggestion;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnPreviousPage;
        private System.Windows.Forms.Button btnLastsPage;
        private System.Windows.Forms.Button btnFirstPage;
        private System.Windows.Forms.Label lblSearchDuration;
    }
}