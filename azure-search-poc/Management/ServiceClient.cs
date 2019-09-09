using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Search;

namespace AzureSearchPoC.Management
{
    public static class ServiceClient
    {
        public static SearchServiceClient CreateSearchServiceClient()
        {
            string searchServiceName = (string)System.Configuration.ConfigurationManager.AppSettings["AzureSearchServiceName"];
            string searchServiceAdminApiKey = (string)System.Configuration.ConfigurationManager.AppSettings["AzureSearchServiceAdminKey"];
            SearchServiceClient serviceClient = new SearchServiceClient(searchServiceName, new SearchCredentials(searchServiceAdminApiKey));
            return serviceClient;
        }
        public static SearchIndexClient CreateSearchIndexClient(string indexName)
        {
            string searchServiceName = (string)System.Configuration.ConfigurationManager.AppSettings["AzureSearchServiceName"];
            string searchServiceQueryApiKey = (string)System.Configuration.ConfigurationManager.AppSettings["AzureSearchServiceQueryKey"];
            SearchIndexClient indexClient = new SearchIndexClient(searchServiceName, indexName, new SearchCredentials(searchServiceQueryApiKey));
            return indexClient;
        }
    }
}
