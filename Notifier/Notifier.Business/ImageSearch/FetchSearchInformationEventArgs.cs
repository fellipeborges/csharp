using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifier.Business.ImageSearch
{
    public class FetchSearchInformationEventArgs: EventArgs
    {
        public int TotalImagesFound { get; set; }
        public int OffsetFrom { get; set; }
        public int OffsetTo { get; set; }
    }
}
