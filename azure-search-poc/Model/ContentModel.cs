using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Search.Models;

namespace AzureSearchPoC.Model
{
    [SerializePropertyNamesAsCamelCase]
    public class ContentModel
    {
        public string ContentId { get; set; }
        public ContentType ContentType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public string Category { get; set; }
        public double HasVideo { get; set; }
        public string[] Tags { get; set; }
    }

    public enum ContentType
    {
        KB = 1,
        Training = 2
    }
}
