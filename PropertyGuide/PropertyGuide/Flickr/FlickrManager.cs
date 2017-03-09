using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using PropertyGuide.Flickr.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace PropertyGuide.Flickr
{
    public class FlickrManager
    {
        private IFlickrRequest _request;

        public FlickrManager(IFlickrRequest request)
        {
            _request = request;
        }

        public async Task<IEnumerable<SearchResultItem>> GetSearchResultsAsync(CancellationToken cts)
        {
            //var clientHandler = new HttpClientHandler
            //{
            //    Credentials = _request.Credentials
            //};

            var list = new List<SearchResultItem>();
            //using (var client = new HttpClient(clientHandler))
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(_request.Url, cts);
                var resp = await response.Content.ReadAsStringAsync();


                await Task.Run(() =>
                {
                    var items = _request.Parse(resp);
                    foreach (var item in items)
                    {
                        cts.ThrowIfCancellationRequested();
                        list.Add(item);
                    }
                }, cts);
            }

            return list;
        }
    }
}
