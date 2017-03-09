using PropertyGuide.Flickr.Contracts;
using System.Collections.ObjectModel;

namespace PropertyGuide.Flickr
{
    public class SearchInfo : BindableBase
    {
        private ObservableCollection<SearchResultItem> _list;
        public ObservableCollection<SearchResultItem> List => _list;

        public SearchInfo()
        {
            _list = new ObservableCollection<SearchResultItem>();
            _list.CollectionChanged += (sender, args) =>
            {
                OnPropertyChanged(nameof(List));
            };
        }


        private string _searchTerm;

        public string SearchTerm
        {
            get { return _searchTerm; }
            set { SetProperty(ref _searchTerm, value); }
        }
    }
}
