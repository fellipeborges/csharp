using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Notifier.Business.Interfaces;
using System.Net;
using Newtonsoft.Json.Linq;
using System.IO;
using Notifier.Models;

namespace Notifier.Business.ImageSearch
{
    public class GifSearcher: IImageSearcher
    {
        const string _API_KEY = "dc6zaTOxFJmzC";
        const int _API_LIMIT = 5;
        public event AsyncCompletedEventHandler AsyncDownloadFileCompleted;
        public event EventHandler<FetchSearchInformationEventArgs> FetchSearchInformation;

        public void Search(string searchTerm, int offset)
        {
            searchTerm = searchTerm.Replace(" ", "+");
            offset = offset * _API_LIMIT;
            string queryString = String.Format("https://api.giphy.com/v1/gifs/search?q={0}&limit={1}&offset={2}&api_key={3}", searchTerm, _API_LIMIT, offset, _API_KEY);
            SearchGiphy(queryString);
        }
        public void GetTrending()
        {
            string queryString = String.Format("https://api.giphy.com/v1/gifs/trending?api_key={0}", _API_KEY);
            SearchGiphy(queryString);
        }

        //https://github.com/Giphy/GiphyAPI#giphy-sticker-api
        private void SearchGiphy(string queryString)
        {
            var rawResponse = new WebClient().DownloadString(queryString);
            JObject response = JObject.Parse(rawResponse);
            HandleBasicInformation(response);
            HandleFoundImages(response);
        }

        private void HandleFoundImages(JObject response)
        {
            JArray photos = (JArray)response["data"];
            foreach (JObject photo in photos)
            {
                string url = photo["images"]["fixed_height"]["url"].ToString();
                string caption = photo["slug"].ToString();
                downloadGiphy(url, caption);
            }
        }

        private void HandleBasicInformation(JObject response)
        {
            JToken pagination = response["pagination"];
            JToken totalCount = pagination["total_count"];
            JToken offset = pagination["offset"];
            if (pagination == null || totalCount == null || offset == null)
            {
                return;
            }
            
            string strtotalImagesFound = totalCount.ToString();
            int totalImagesFound = int.Parse(strtotalImagesFound);
            
            int offsetFrom = 0;
            int offsetTo = 0;

            if (totalImagesFound > 0)
            {
                string stroffsetFrom = offset.ToString();
                offsetFrom = int.Parse(stroffsetFrom);
                if (offsetFrom == 0)
                {
                    offsetFrom = 1;
                    offsetTo = _API_LIMIT;
                }
                else
                {
                    offsetTo = offsetFrom + _API_LIMIT;
                    offsetFrom = offsetFrom + 1;
                }
                if (offsetTo > totalImagesFound)
                {
                    offsetTo = totalImagesFound;
                }
            }

            FetchSearchInformationEventArgs e = new FetchSearchInformationEventArgs
            {
                TotalImagesFound = totalImagesFound,
                OffsetFrom = offsetFrom,
                OffsetTo = offsetTo
            };
            FetchSearchInformation(this, e);
        }

        private void downloadGiphy(string url, string caption)
        {
            string tempFileName = Path.GetTempFileName();
            tempFileName = tempFileName.Replace(".tmp", ".gif");

            ImageModel gifModel = new ImageModel(tempFileName, url, caption);
            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += AsyncDownloadFileCompleted;
            webClient.DownloadFileAsync(new Uri(gifModel.Url), gifModel.Filename, gifModel);
        }
    }
}
