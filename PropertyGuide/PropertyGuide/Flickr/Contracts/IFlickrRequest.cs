using System.Net;
using System.Collections.Generic;

namespace PropertyGuide.Flickr.Contracts
{
    public interface IFlickrRequest
    {
        int ItemCount { get; set; }
        int PageNumber { get; set; }
        ICredentials Credentials { get; }
        string SearchTerm { get; set; }
        string Url { get;}
        IEnumerable<SearchResultItem> Parse(string xml);
    }
}