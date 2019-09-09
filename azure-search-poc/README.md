# Azure Search Service - Proof of Concept

This is a simple implementation of the [Azure Search](https://azure.microsoft.com/en-us/services/search/) service by Microsoft.
This PoC implements:
  - Index managing (check, create, delete)
  - Document loading
  - Searching
  - Paging
  - Sorting
  - Term suggestion
  - Faceted navigation
  - Highlight results
  

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

You will need:
 - A Microsoft Azure account
 - An active search service at Azure
 - Two API keys: one for admin stuff and other for querying documents


### Installing

This project requires the following references (all available through Nuget):
 - Microsoft.Azure.Search
 - Newtonsoft.Json

You'll need to add the needed configuration to a App.config file. The project contains a template file named [App.Template.config](App.Template.config). Example:

```
  <appSettings>
    <add key="AzureSearchServiceName" value="YOR_AZURE_SERVICE_NAME" />
    <add key="AzureSearchServiceAdminKey" value="YOR_AZURE_ADMIN_KEY" />
    <add key="AzureSearchServiceQueryKey" value="YOR_AZURE_QUERY_KEY" />
  </appSettings>
```

### Creating the index and suggester

The file [Management/Indexer.cs](Management/Indexer.cs) contains an example of basic index and suggester creation. You can change it as you need.


### Loading the documents

The file [Management/Loader.cs](Management/Loader.cs) contains an example of basic document loading through a batch. It uses mocked data from the class [LoaderMockedData.cs](Management/LoaderMockedData.cs) to fulfill the index. Feel free to change it and upload your own data.


### Now you're good to go

After installing the necessary packages through Nuget, creating an index and loading some documents, you must be now able to run your firt search query.

Have fun!
