using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Search;
using AzureSearchPoC.Management;
using Microsoft.Azure.Search.Models;

namespace AzureSearchPoC.Management
{
    public class Indexer
    {
        private const string _INDEX_NAME = "poc-content";
        private SearchServiceClient _searchServiceClient;

        public Indexer()
        {
            //creates the instance of the service client
            _searchServiceClient = ServiceClient.CreateSearchServiceClient();
        }

        public void HandleIndexCration()
        {
            //checks if the index already exists - if so, deletes it
            if (CheckIfIndexExists(_INDEX_NAME) == true)
            {
                DeleteIndex(_INDEX_NAME);
            }

            //creates the definition of the index
            var definition = new Index()
            {
                Name = _INDEX_NAME,
                Fields = new[]
                {
                    new Field("contentId", DataType.String)                     { IsKey = true, IsFilterable = true, IsSearchable = true, IsSortable = true },
                    new Field("contentType", DataType.Double)                   { IsFilterable = true, IsFacetable = true },
                    new Field("title", DataType.String)                         { IsSearchable = true, IsSortable = true },
                    new Field("description", DataType.String)                   { IsSearchable = true },
                    new Field("body", DataType.String)                          { IsSearchable = true },
                    new Field("body_ptbr_lucene", AnalyzerName.PtBRLucene),
                    new Field("category", DataType.String)                      { IsSearchable = true, IsFilterable = true, IsSortable = true, IsFacetable = true },
                    new Field("hasVideo", DataType.Double)                      { IsFilterable = true, IsFacetable = true },
                    new Field("tags", DataType.Collection(DataType.String))     { IsSearchable = true, IsFilterable = true, IsFacetable = true }
                },
                Suggesters = new[]
                {
                    new Suggester("mainSugester", SuggesterSearchMode.AnalyzingInfixMatching, new[] {"contentId", "title", "description", "body", "tags"})
                }
            };

            CreateIndex(definition);
        }

        private void DeleteIndex(string indexName)
        {
            _searchServiceClient.Indexes.Delete(indexName);
        }

        public void CreateIndex(Index indexDefinition)
        {
            _searchServiceClient.Indexes.Create(indexDefinition);
        }

        private bool CheckIfIndexExists(string indexName)
        {
            return _searchServiceClient.Indexes.Exists(_INDEX_NAME);
        }
    }
}
