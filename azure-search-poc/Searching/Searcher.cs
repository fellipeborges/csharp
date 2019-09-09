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
    public class Searcher: IDisposable
    {

        public string IndexName { get; set; }
        public int Skip { get; set; }
        public int Top { get; set; }
        public string Filter { get; set; }
        public string Term { get; set; }
        public string[] Select { get; set; }
        public string[] OrderBy { get; set; }
        public bool IncludeTotalResultCount { get; set; }
        public string[] Facets { get; set; }
        public string[] HighlightFields { get; set; }
        public string HighlightPreTag { get; set; }
        public string HighlightPostTag { get; set; }

        public Searcher()
        {
            this.Select = new string[] { };
            this.OrderBy = new string[] { };
            this.Filter = "";
            this.Top = 99999;
            this.Skip = 0;
            this.IncludeTotalResultCount = true;
            this.HighlightFields = new string[] { };
            this.HighlightPreTag = "";
            this.HighlightPostTag = "";
        }

        public DocumentSearchResult<ContentModel> Search()
        {
            SearchParameters parameters;
            DocumentSearchResult<ContentModel> results;
            SearchIndexClient indexClient = ServiceClient.CreateSearchIndexClient(this.IndexName);

            parameters = new SearchParameters()
            {
                Select = this.Select,
                OrderBy = this.OrderBy,
                Filter = this.Filter,
                Top = this.Top,
                Skip = this.Skip,
                IncludeTotalResultCount = this.IncludeTotalResultCount,
                Facets = this.Facets,
                HighlightFields = this.HighlightFields,
                HighlightPreTag = this.HighlightPreTag,
                HighlightPostTag = this.HighlightPostTag
            };

            results = indexClient.Documents.Search<ContentModel>(this.Term, parameters);
            return results;
        }

        public void Dispose()
        {
        }
    }
}
