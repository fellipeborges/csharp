using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureSearchPoC.Management;
using AzureSearchPoC.Model;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;

namespace AzureSearchPoC.Searching
{
    public class Suggester: IDisposable
    {
        public string IndexName { get; set; }
        public string SearchText { get; set; }
        public string SuggesterName { get; set; }
        public int Top { get; set; }
        public string[] SearchFields { get; set; }
        public string[] Select { get; set; }
        public string HighlightPreTag { get; set; }
        public string HighlightPostTag { get; set; }

        public Suggester()
        {
            this.SearchFields = new string[] { };
            this.Select = new string[] { };
            this.Top = 10;
            this.HighlightPreTag = "";
            this.HighlightPostTag = "";
        }

        public DocumentSuggestResult<SuggestResult> Suggest()
        {
            DocumentSuggestResult<SuggestResult> results;
            SearchIndexClient indexClient = ServiceClient.CreateSearchIndexClient(this.IndexName);
            SuggestParameters parameters = new SuggestParameters()
            {
                Top = this.Top,
                SearchFields = this.SearchFields,
                Select =this.Select,
                HighlightPreTag = this.HighlightPreTag,
                HighlightPostTag = this.HighlightPostTag
            };
            results = indexClient.Documents.Suggest<SuggestResult>(this.SearchText, this.SuggesterName, parameters);
            return results;
        }

        public void Dispose()
        {
        }
    }
}
