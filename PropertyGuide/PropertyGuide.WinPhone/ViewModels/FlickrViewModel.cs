using System.Windows.Threading;
using System.Windows;
using Windows.System.Threading;
using Ninject;
//using System.Net.Http;
using Windows.Web.Http;
using System.Threading;
using System.Threading.Tasks;
using PropertyGuide.Flickr;
using PropertyGuide.Flickr.Contracts;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using PropertyGuide.WinPhone.ApplicationLayer.Managers;

namespace PropertyGuide.WinPhone
{
    public class FlickrViewModel : BindableBase
    {
        private ObservableCollection<SearchResultItem> _list;
        public ObservableCollection<SearchResultItem> List => _list;

        //private CancellationToken _cts;

        [Inject]
        public IFlickrRequest FlickrRequest { get; set; }


        public FlickrViewModel()
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
            set
            {
                SetProperty(ref _searchTerm, value);
                FlickrRequest.SearchTerm = value;
            }
        }

        public bool IsUpdating { get; set; }
        public Visibility ListVisibility { get; set; }
        public Visibility NoDataVisibility { get; set; }

        public Visibility UpdatingVisibility
        {
            get
            {
                return (IsUpdating || List == null || List.Count == 0) ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private Dispatcher dispatcher;

        public async void BeginUpdateAsync(Dispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
            IsUpdating = true;
            _list = null;
            OnPropertyChanged(nameof(UpdatingVisibility));
            //await TestLoadSearchResultsAsync();

            await Windows.System.Threading.ThreadPool.RunAsync(async delegate
            {
                var list = await GetSearchResultsAsync();
                LoadSearchResults(list);
            });
        }

        /*
        private async Task TestLoadSearchResultsAsync()
        {
            _cts = new CancellationToken();

            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(new Uri(FlickrRequest.Url));

                //var response = await client.GetAsync(FlickrRequest.Url, _cts);
                //var resp = await response.Content.ReadAsStringAsync();
            }
        }*/

        private async Task<List<SearchResultItem>> GetSearchResultsAsync()
        {
            //_cts = new CancellationToken();
            var list = new List<SearchResultItem>();
            using (var client = new HttpClient())
            {
                //var response = await client.GetAsync(FlickrRequest.Url, _cts);
                //var resp = await response.Content.ReadAsStringAsync();

                var response = await client.GetStringAsync(new Uri(FlickrRequest.Url));

                var items = FlickrRequest.Parse(response);
                foreach (var item in items)
                {
                    //_cts.ThrowIfCancellationRequested();
                    list.Add(item);
                }
            }

            return list;
        }

        public void LoadSearchResults(List<SearchResultItem> list)
        {
            Action action = () =>
            {
                _list = new ObservableCollection<SearchResultItem>(
                     from e in list
                     select new SearchResultItem
                     {
                         Url = e.Url,
                         Source = e.Source,
                         ThumbnailUrl = e.ThumbnailUrl,
                         Title = e.Title
                     });

                OnPropertyChanged(nameof(List));

                ListVisibility = List.Count > 0 ? Visibility.Visible : Visibility.Collapsed;
                NoDataVisibility = List.Count == 0 ? Visibility.Visible : Visibility.Collapsed;
                IsUpdating = false;

                OnPropertyChanged(nameof(ListVisibility));
                OnPropertyChanged(nameof(NoDataVisibility));
                OnPropertyChanged(nameof(IsUpdating));
                OnPropertyChanged(nameof(UpdatingVisibility));
            };


            dispatcher.BeginInvoke(action);
        }

        #region "Loggedin User info"
        public string LoggedInUserName
        {
            get
            {
                var user = UserSessionManager.LoggedInUser;
                if (user == null) return string.Empty;

                return user.Name;
            }
        }

        public string WelcomeMessage
        {
            get { return $"Welcome {LoggedInUserName}!"; }
        }
        #endregion
    }
}
