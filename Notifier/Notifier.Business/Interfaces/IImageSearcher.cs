using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Notifier.Business.ImageSearch;

namespace Notifier.Business.Interfaces
{
    public interface IImageSearcher
    {
        event AsyncCompletedEventHandler AsyncDownloadFileCompleted;
        event EventHandler<FetchSearchInformationEventArgs> FetchSearchInformation;
        void Search(string term, int offset);
    }
}
