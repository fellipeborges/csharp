using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using System.Collections;
using AzureSearchPoC.Management;
using AzureSearchPoC.Model;

namespace AzureSearchPoC.Management
{
    public class Loader
    {        
        public void Load()
        {
            //get mocked data
            LoaderMockedData lmd = new LoaderMockedData();
            List<ContentModel> contentList = lmd.GetMockedData();

            //create the actions
            var actions = new List<IndexAction<ContentModel>>();
            foreach (var item in contentList)
            {
                actions.Add(IndexAction.MergeOrUpload(item));
            }

            //create the batch
            var batch = IndexBatch.New(actions);

            //load data into azure
            try
            {
                SearchServiceClient searchServiceClient = ServiceClient.CreateSearchServiceClient();
                SearchIndexClient indexClient = (SearchIndexClient)searchServiceClient.Indexes.GetClient("poc-content");
                indexClient.Documents.Index(batch);
            }
            catch (IndexBatchException e)
            {
                Console.WriteLine(
                    "Failed to index some of the documents: {0}",
                    String.Join(", ", e.IndexingResults.Where(r => !r.Succeeded).Select(r => r.Key)));
            }
        }

    }
}
