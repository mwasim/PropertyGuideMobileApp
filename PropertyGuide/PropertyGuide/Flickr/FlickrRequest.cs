using PropertyGuide.Flickr.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace PropertyGuide.Flickr
{
    public class FlickrRequest : IFlickrRequest
    {
        public FlickrRequest()
        {
            ItemCount = 25;
            PageNumber = 1;
        }

        public int ItemCount { get; set; }
        public int PageNumber { get; set; }
        private const string AppId = "1c3d0f483bfecef4457f40522512cb29";


        public ICredentials Credentials => null;

        private string _searchTerm;

        public string SearchTerm
        {
            get { return _searchTerm; }
            set { _searchTerm = value; }
        }

        public string Url
        {
            get
            {
                return $"https://api.flickr.com/services/rest?api_key={AppId}&method=flickr.photos.search&content_type=1&text={SearchTerm}&per_page={ItemCount}&page={PageNumber}";
            }
        }

        public IEnumerable<SearchResultItem> Parse(string xml)
        {
            XElement responseXml = XElement.Parse(xml);

            return (from item in responseXml.Descendants("photo")
                    select new SearchResultItem
                    {
                        Title = new string(item.Attribute("title").Value.Take(50).ToArray()),
                        Url = string.Format("http://farm{0}.staticflickr.com/{1}/{2}_{3}_z.jpg",
                        item.Attribute("farm").Value, item.Attribute("server").Value, item.Attribute("id").Value,
                        item.Attribute("secret").Value),
                        ThumbnailUrl = string.Format("http://farm{0}.staticflickr.com/{1}/{2}_{3}_t.jpg",
                        item.Attribute("farm").Value, item.Attribute("server").Value, item.Attribute("id").Value,
                        item.Attribute("secret").Value),
                        Source = "Flickr"
                    }).ToList();
        }

    }
}
