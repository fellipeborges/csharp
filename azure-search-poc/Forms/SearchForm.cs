using AzureSearchPoC.Model;
using Microsoft.Azure.Search.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace AzureSearchPoC.Forms
{
    public partial class SearchForm : Form
    {
        private const string _INDEX_NAME = "poc-content";
        private const string _SUGESTER_NAME = "mainSugester";
        private const int _PAGE_SIZE = 5;
        private bool _formLoaded = false;
        private int _currentPage;
        private int _lastPage;
        private string _currentFilter;

        public SearchForm()
        {
            InitializeComponent();
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            InitializeFormComponents();
            _formLoaded = true;
        }

        private void InitializeFormComponents()
        {
            this.Width = 1095;
            this.Height = 685;
            ShowStatusBarMessage("Idle");
            cboSorting.SelectedIndex = 0;
            lblRecordsFound.Text = "Results";
            lblPage.Text = "";
            lblSearchDuration.Text = "";
            lstSuggestion.Width = txtSearchTerm.Width;
            lstSuggestion.Top = 52;
            lstSuggestion.Left = 10;
        }

        private void btnRebuildIndex_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "The index will be destroyed and recreated.\nDo you want to continue?","Warning",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                RebuildIndexAndLoadData();
            }
        }
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            PerformSearch(txtSearchTerm.Text, true, true);
        }
        
        private void lstSuggestion_DoubleClick(object sender, EventArgs e)
        {
            lstSuggestion.Visible = false;
            if (lstSuggestion.SelectedIndex == -1)
            {
                return;
            }
            PerformSearch(lstSuggestion.Text, true, true);
        }

        private void tmrSuggestion_Tick(object sender, EventArgs e)
        {
            tmrSuggestion.Enabled = false;
            PerformSuggestion(txtSearchTerm.Text);
        }

        private void lstContentType_DoubleClick(object sender, EventArgs e)
        {
            if (lstContentType.SelectedIndex == -1)
            {
                return;
            }
            string selectedText = lstContentType.Text.Substring(0, lstContentType.Text.IndexOf("(") - 1);
            double contentType = 0;
            switch (selectedText)
            {
                case "KB":
                    contentType = 1;
                    break;
                case "Training":
                    contentType = 2;
                    break;
            }
            PerformFacet("contentType", contentType);
        }


        private void btnNextPage_Click(object sender, EventArgs e)
        {
            MovePage(+1);
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            MovePage(-1);
        }

        private void btnLastsPage_Click(object sender, EventArgs e)
        {
            MovePage(_lastPage - _currentPage);
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            MovePage((_currentPage - 1) * -1);
        }
        private void lstCategory_DoubleClick(object sender, EventArgs e)
        {
            if (lstCategory.SelectedIndex == -1)
            {
                return;
            }
            string category = lstCategory.Text.Substring(0, lstCategory.Text.IndexOf("(") - 1);
            PerformFacet("category", category);
        }

        private void lstHasVideo_DoubleClick(object sender, EventArgs e)
        {
            if (lstHasVideo.SelectedIndex == -1)
            {
                return;
            }
            string selectedText = lstHasVideo.Text.Substring(0, lstHasVideo.Text.IndexOf("(") - 1);
            double hasVideo = 0;
            if (selectedText == "Yes")
            {
                hasVideo = 1;
            }
            PerformFacet("hasVideo", hasVideo);
        }

        private void txtSearchTerm_KeyUp(object sender, KeyEventArgs e)
        {
            tmrSuggestion.Enabled = false;
            if (e.KeyCode == Keys.Return)
            {
                PerformSearch(txtSearchTerm.Text, true, true);
                return;
            }
            if (txtSearchTerm.Text.Length >= 2)
            {
                tmrSuggestion.Enabled = true;
            }
            else
            {
                lstSuggestion.Items.Clear();
                lstSuggestion.Visible = false;
            }
        }

        private void cboSorting_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_formLoaded == true)
            {
                PerformSearch(txtSearchTerm.Text, true, false);
            }
        }

        private void SetPagingLabel(int numberOfPages)
        {
            
        }

        private void RebuildIndexAndLoadData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                ShowStatusBarMessage("Creating index...");
                new Management.Indexer().HandleIndexCration();

                ShowStatusBarMessage("Uploading data...");
                new Management.Loader().Load();
            }
            catch (Exception ex)
            {
                ShowDetailedError(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                ShowStatusBarMessage("Idle");
            }
        }

        private void PerformSuggestion(string searchTerm)
        {
            try
            {
                lstSuggestion.Items.Clear();
                if (searchTerm == "")
                {
                    return;
                }

                using (Searching.Suggester suggester = new Searching.Suggester())
                {
                    suggester.IndexName = _INDEX_NAME;
                    suggester.SuggesterName = _SUGESTER_NAME;
                    suggester.SearchText = searchTerm;
                    suggester.SearchFields = new[] { "title" };
                    suggester.Select = new[] { "title" };
                    suggester.Top = 5;
                    //suggester.HighlightPreTag = "<highlight>";
                    //suggester.HighlightPostTag = "</highlight>";
                    DocumentSuggestResult<SuggestResult> suggestResults = suggester.Suggest();

                    foreach (SuggestResult<SuggestResult> result in suggestResults.Results)
                    {
                        lstSuggestion.Items.Add(result.Text);
                    }
                    if (lstSuggestion.Items.Count > 0)
                    {
                        lstSuggestion.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lstSuggestion.Visible = false;
                ShowDetailedError(ex);
            }
        }

        private void MovePage(int direction)
        {
            _currentPage += direction;
            PerformSearch(txtSearchTerm.Text, false, false);
        }

        private void PerformSearch(string searchTerm, bool resetPagination, bool resetFilter)//ool moveNextPage = false)
        {
            try
            {
                //UI stuff
                lstSuggestion.Visible = false;
                if (searchTerm == "")
                {
                    return;
                }
                Cursor.Current = Cursors.WaitCursor;
                ShowStatusBarMessage("Searching...");

                //reset search stuff
                if (resetPagination) {
                    _currentPage = 1;
                    _lastPage = 1;
                }
                if (resetFilter) { _currentFilter = ""; }

                //skip stuff
                int skip = 0;
                if (_currentPage > 1)
                {
                    skip = ((_currentPage-1) * _PAGE_SIZE);
                }

                using (Searching.Searcher searcher = new Searching.Searcher())
                {
                    searcher.IndexName = _INDEX_NAME;
                    searcher.Select = new[] { "contentId", "title", "description", "category", "hasVideo" };
                    searcher.Term = searchTerm;
                    searcher.OrderBy = ReturnOrderBy();
                    searcher.Top = _PAGE_SIZE;
                    searcher.Skip = skip;
                    searcher.Filter = _currentFilter;
                    searcher.Facets = new[] { "hasVideo", "category", "contentType" };
                    searcher.HighlightFields = new[] { "title", "description" };
                    searcher.HighlightPreTag = "<highlight>";
                    searcher.HighlightPostTag = "</highlight>";

                    Stopwatch searchDuration = System.Diagnostics.Stopwatch.StartNew();
                    DocumentSearchResult<ContentModel> searchResults = searcher.Search();
                    searchDuration.Stop();
                    
                    ShowSearchDuration(searchDuration);
                    HandlePagination((int)searchResults.Count);
                    HandleFacets(searchResults);
                    CreateAndShowResultsHtml(searchResults);
                    ShowNumberOfRecordsFound(searchResults.Count);
                }

            }
            catch (Exception ex)
            {
                ShowDetailedError(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                ShowStatusBarMessage("Idle");
            }
        }

        private void ShowSearchDuration(Stopwatch searchDuration)
        {
            TimeSpan searchElapsed = searchDuration.Elapsed;
            //lblSearchDuration.Text = String.Format("Search duration: {0}sec{1}mil", searchElapsed.ToString("ss':'fff"));
            lblSearchDuration.Text = String.Format("Search duration: {0} sec {1} ms", searchElapsed.ToString("ss"), searchElapsed.ToString("fff"));
        }

        private void HandlePagination(int numberOfRecords)
        {
            if (numberOfRecords == 0)
            {
                lblPage.Text = "";
                _lastPage = 0;
                HandlePaginationButtonsStatus(false, false, false, false);
            }
            else
            {
                //discover number of pages
                int numberOfPages;
                if (numberOfRecords % _PAGE_SIZE == 0)
                {
                    numberOfPages = (numberOfRecords / _PAGE_SIZE);
                }
                else
                {
                    numberOfPages = (numberOfRecords / _PAGE_SIZE) + 1;
                }
                _lastPage = numberOfPages;
                lblPage.Text = String.Format("Page {0} of {1}", _currentPage, numberOfPages);

                bool firstPage = (_currentPage != 1);
                bool nextPage = (_currentPage != _lastPage);

                HandlePaginationButtonsStatus(firstPage, firstPage, nextPage, nextPage);
            }
        }

        private void HandlePaginationButtonsStatus(bool first, bool prev, bool next, bool last)
        {
            btnFirstPage.Enabled = first;
            btnPreviousPage.Enabled = prev;
            btnNextPage.Enabled = next;
            btnLastsPage.Enabled = last;
        }

        private void HandleFacets(DocumentSearchResult<ContentModel> searchResults)
        {
            //hasVideo
            Dictionary<int, string> dictionaryHasVideo = new Dictionary<int, string>();
            dictionaryHasVideo.Add(0, "No");
            dictionaryHasVideo.Add(1, "Yes");
            HandleFacet(searchResults, lstHasVideo, "hasVideo", dictionaryHasVideo);

            //category
            HandleFacet(searchResults, lstCategory, "category");

            //contentType
            Dictionary<int, string> dictionaryContentType = new Dictionary<int, string>();
            dictionaryContentType.Add(1, "KB");
            dictionaryContentType.Add(2, "Training");
            HandleFacet(searchResults, lstContentType, "contentType", dictionaryContentType);

        }
        private void HandleFacet(DocumentSearchResult<ContentModel> searchResults, 
                                 ListBox listBox, 
                                 string facetKey,
                                 Dictionary<int, string> dictionaryOfValues = null)
        {
            listBox.Items.Clear();
            IList<FacetResult> facets;
            if (searchResults.Facets.TryGetValue(facetKey, out facets) == true)
            {
                foreach (FacetResult facet in facets)
                {
                    string value = facet.Value.ToString();

                    //try to find string value at the dictionary (if exists)
                    if (dictionaryOfValues != null)
                    {
                        int intValue;
                        if (int.TryParse(value, out intValue) == true)
                        {
                            if (dictionaryOfValues.ContainsKey(intValue) == true)
                            {
                                value = dictionaryOfValues[intValue].ToString();
                            }
                        }
                    }

                    string item = String.Format("{0} ({1})", value, facet.Count);
                    listBox.Items.Add(item);
                }
            }
        }

        private string[] ReturnOrderBy()
        {
            string[] values = new[] { "" };

            switch (cboSorting.Text)
            {
                case "Default":
                    break;

                case "Content ID (Asc)":
                    values = new[] { "contentId" };
                    break;
                case "Content ID (Desc)":
                    values = new[] { "contentId desc" };
                    break;
                case "Title (Asc)":
                    values = new[] { "title" };
                    break;
                case "Title (Desc)":
                    values = new[] { "title desc" };
                    break;

                default:
                    break;
            }
            return values;
        }
        
        private void CreateAndShowResultsHtml(DocumentSearchResult<ContentModel> searchResults)
        {
            //creates the HTML
            string fullHtml = AzureSearchPoC.Properties.Resources.HtmlTemplateBody;
            string itemsHtml = "";
            foreach (SearchResult<ContentModel> result in searchResults.Results)
            {

                string item = AzureSearchPoC.Properties.Resources.HtmlTemplateItem;
                string title = ""; string category = ""; string description = ""; double hasVideo = 0; string hasVideoTag = "";
                GetItemInformation(result, out title, out category, out description, out hasVideo);

                if (hasVideo == 1)
                {
                    hasVideoTag = "<span class='tag'>video</span>";
                }

                item = item.Replace("$title$", title);
                item = item.Replace("$category$", category);
                item = item.Replace("$description$", description);
                item = item.Replace("$hasVideo$", hasVideoTag);
                itemsHtml += item;
            }
            fullHtml = fullHtml.Replace("<results />", itemsHtml);

            //creates the file on the disk
            string filePath = Path.GetTempPath() + Guid.NewGuid().ToString() + ".html";
            TextWriter tw = new StreamWriter(filePath, true);
            tw.WriteLine(fullHtml);
            tw.Close();

            //opens the html
            webBrowserResults.Navigate(filePath);
        }

        private void GetItemInformation(SearchResult<ContentModel> result,
                                        out string outTitle,
                                        out string outCategory, 
                                        out string outDescription,
                                        out double outHasVideo)
        {
            outTitle = "";
            outCategory = result.Document.Category;
            outDescription = "";
            outHasVideo = result.Document.HasVideo;

            if (result.Highlights != null)
            {
                foreach (var highlight in result.Highlights)
                {
                    switch (highlight.Key)
                    {
                        case "title":
                            outTitle = ChangeHighlightTags(highlight.Value[0].ToString());
                            break;
                        case "description":
                            outDescription = ChangeHighlightTags(highlight.Value[0].ToString());
                            break;
                    }
                }
            }

            if (outTitle == "")
            {
                outTitle = result.Document.Title;
            }
            outTitle = result.Document.ContentId + " - " + outTitle;
            if (outDescription == "")
            {
                outDescription = result.Document.Description;
            }
        }

        private void PerformFacet(string field, object value)
        {
            string filter = "";
            if (value.GetType() == typeof(string))
            {
                _currentFilter = string.Format("{0} eq '{1}'", field, value);
            }
            else if (value.GetType() == typeof(double))
            {
                _currentFilter = String.Format("{0} eq {1}", field, value);
            }
            PerformSearch(txtSearchTerm.Text, true, false);
        }

        private string ChangeHighlightTags(string text)
        {
            string textReturn = text;
            textReturn = textReturn.Replace("<highlight>", "<span class='highlight'>");
            textReturn = textReturn.Replace("</highlight>", "</span>");
            return textReturn;
        }

        private void ShowDetailedError(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        private void ShowStatusBarMessage(string message)
        {
            statusStripMain.Items["toolStripStatusLabel"].Text = message;
        }

        private void ShowNumberOfRecordsFound(long? number)
        {
            if (number == null)
            {
                number = 0;
            }
            lblRecordsFound.Text = String.Format("Results ({0})", number);
        }

    }
}
