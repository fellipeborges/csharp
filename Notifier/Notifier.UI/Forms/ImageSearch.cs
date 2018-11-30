using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Notifier.Business.ImageSearch;
using Notifier.Models;
using Notifier.Localization;

namespace Notifier.UI.Forms
{
    public partial class ImageSearch : Form
    {
        GifSearcher _gifSearcher;
        int _imageWidth = 150;
        int _imageHeight = 150;
        int _currentOffset = 0;
        string _currentSearchTerm = "";

        public string SelectedFile { get; internal set; }
        public string SelectedName { get; internal set; }

        public ImageSearch()
        {
            InitializeComponent();
        }

        private void ImageSearch_Load(object sender, EventArgs e)
        {
            FillLabels();
            this.SelectedFile = "";
            this.SelectedName = "";
        }

        private void FillLabels()
        {
            this.Text = LocalizationManager.GetText("ImageSearch_FormTitle");
            btnGetTrending.Text = LocalizationManager.GetText("ImageSearch_GetTrending");
            btnSearch.Text = LocalizationManager.GetText("ImageSearch_Search");
            lnkFetchMore.Text = LocalizationManager.GetText("ImageSearch_FetchMore");
            lblStatus.Text = "";
        }

        private void ExecuteSearch()
        {
            CleanImages();
            CreateGifSearcher();
            _gifSearcher.Search(_currentSearchTerm, _currentOffset);
        }

        private void GetTrending()
        {
            lblStatus.Text = "";
            CleanImages();
            CreateGifSearcher();
            _gifSearcher.GetTrending();
        }

        private void CreateGifSearcher()
        {
            if (_gifSearcher != null)
            {
                _gifSearcher = null;
            }
            _gifSearcher = new GifSearcher();
            _gifSearcher.AsyncDownloadFileCompleted += AddImageToGrid;
            _gifSearcher.FetchSearchInformation += FetchSearchInformation;
        }

        private void FetchSearchInformation(object sender, FetchSearchInformationEventArgs e)
        {
            lblStatus.Text = String.Format(LocalizationManager.GetText("ImageSearch_Status"), e.TotalImagesFound, e.OffsetFrom, e.OffsetTo);
        }

        private void CleanImages()
        {
            while(flowLayoutPanelImages.Controls.Count > 0)
            {
                flowLayoutPanelImages.Controls.RemoveAt(0);
            }
        }

        private void AddImageToGrid(object sender, AsyncCompletedEventArgs e)
        {
            ImageModel imgModel = (ImageModel)e.UserState;
            PictureBoxCtrl picBox = CreatePictureBox(imgModel);
            flowLayoutPanelImages.Controls.Add(picBox);
        }

        PictureBoxCtrl CreatePictureBox(ImageModel imgModel)
        {
            PictureBoxCtrl picBox = new PictureBoxCtrl();
            picBox.SizeMode = PictureBoxSizeMode.StretchImage;
            picBox.Height = _imageHeight;
            picBox.Width = _imageWidth;
            picBox.WaitOnLoad = false;
            picBox.LoadAsync(imgModel.Filename);
            picBox.Name = imgModel.GetCaptionOrName();
            picBox.Tag = imgModel.Filename;
            picBox.Cursor = Cursors.Hand;
            picBox.DoubleClick += SelectImage;
            picBox.MouseClick += HighlightImage;
            return picBox;
        }

        private void HighlightImage(object picSender, MouseEventArgs evntArgs)
        {
            foreach (Control control in flowLayoutPanelImages.Controls)
            {
                PictureBox tempPic = (PictureBox)control;
                tempPic.BorderStyle = BorderStyle.None;
            }
            PictureBox pic = (PictureBox)picSender;
            pic.BorderStyle = BorderStyle.Fixed3D;
            
        }
        private void SelectImage(object picSender, EventArgs evntArgs)
        {
            PictureBox pic = (PictureBox)picSender;
            this.SelectedFile = pic.Tag.ToString();
            this.SelectedName = txtSearchterm.Text;
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            StartNewSearch();
        }

        private void StartNewSearch()
        {
            lblStatus.Text = "";
            _currentOffset = 0;
            _currentSearchTerm = txtSearchterm.Text;
            if (_currentSearchTerm != "")
            {
                ExecuteSearch();
            }
        }

        private void btnGetTrending_Click(object sender, EventArgs e)
        {
            GetTrending();
        }

        private void trackBarImageSize_Scroll(object sender, EventArgs e)
        {
            ResizeImagesSize(trackBarImageSize.Value);
        }

        private void ResizeImagesSize(int size)
        {
            _imageHeight = size;
            _imageWidth = size;
            foreach (Control control in flowLayoutPanelImages.Controls)
            {
                PictureBox tempPic = (PictureBox)control;
                tempPic.Height = _imageHeight;
                tempPic.Width = _imageWidth;
            }
        }

        private void txtSearchterm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                StartNewSearch();
            }
        }

        private void lnkFetchMore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FetchMoreImages();
        }

        private void FetchMoreImages()
        {
            _currentOffset += 1;
            ExecuteSearch();
        }
    }

    class PictureBoxCtrl : System.Windows.Forms.PictureBox
    {
        // Note that the DoubleClickTime property gets 
        // the maximum number of milliseconds allowed between 
        // mouse clicks for a double-click to be valid.
        int previousClick = SystemInformation.DoubleClickTime;
        public new event EventHandler DoubleClick;

        protected override void OnClick(EventArgs e)
        {
            int now = System.Environment.TickCount;
            // A double-click is detected if the the time elapsed
            // since the last click is within DoubleClickTime.
            if (now - previousClick <= SystemInformation.DoubleClickTime)
            {
                // Raise the DoubleClick event.
                if (DoubleClick != null)
                    DoubleClick(this, EventArgs.Empty);
            }
            // Set previousClick to now so that 
            // subsequent double-clicks can be detected.
            previousClick = now;
            // Allow the base class to raise the regular Click event.
            base.OnClick(e);
        }

        // Event handling code for the DoubleClick event.
        protected new virtual void OnDoubleClick(EventArgs e)
        {
            if (this.DoubleClick != null)
                this.DoubleClick(this, e);
        }
    }
}
