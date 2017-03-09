using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PropertyGuide.WinPhone.ApplicationLayer.Managers;
using PropertyGuide.WinPhone.Utils;

namespace PropertyGuide.WinPhone
{
    public partial class FlickrPage : PhoneApplicationPage
    {
        public FlickrPage()
        {
            InitializeComponent();

            DataContext = App.FlickrViewModel;
            Loaded += FlickrPage_Loaded;
        }

        private void FlickrPage_Loaded(object sender, RoutedEventArgs e)
        {
            const string defaultSearchTerm = "Properties in UK";
            LoadFlickrData(defaultSearchTerm);
        }

        private void OnSearchClick(object sender, RoutedEventArgs e)
        {
            LoadFlickrData();
        }

        private void LoadFlickrData(string searchTerm = null)
        {
            var viewModel = (FlickrViewModel)DataContext;

            if (!string.IsNullOrEmpty(searchTerm))
                viewModel.SearchTerm = searchTerm;

            viewModel.BeginUpdateAsync(Dispatcher);
        }

        private void HandleAllPropertiesClick(object sender, EventArgs e)
        {
            NavigationUtils.NavigateToAllPropertiesPage(NavigationService);
        }

        private void HandleAllUsersClick(object sender, EventArgs e)
        {
            NavigationUtils.NavigateToAllUsersPage(NavigationService);
        }

        private void HandleLogoutClick(object sender, EventArgs e)
        {
            UserSessionManager.LogoutUser(NavigationService);
        }
    }
}