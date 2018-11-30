using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifier.Models
{
    public class ImageModel
    {
        private string _filename;
        private string _url;
        private string _caption;

        public ImageModel(string filename, string url, string caption)
        {
            this._filename = filename;
            this._url = url;
            this._caption = caption;
        }

        public string Filename
        {
            get
            {
                return _filename;
            }
        }

        public string Url
        {
            get
            {
                return _url;
            }
        }
        public string Caption
        {
            get
            {
                return _caption;
            }
        }

        public string GetCaptionOrName()
        {
            if (this._caption != "")
            {
                return this._caption;
            }
            return System.IO.Path.GetFileName(this._filename);
        }
    }
}
