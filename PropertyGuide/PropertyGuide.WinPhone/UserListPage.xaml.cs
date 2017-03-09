using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PropertyGuide.WinPhone.ApplicationLayer.Managers;
using PropertyGuide.WinPhone.Resources;
using PropertyGuide.WinPhone.Utils;

namespace PropertyGuide.WinPhone
{
    public partial class UserListPage : PhoneApplicationPage
    {
        public UserListPage()
        {
            InitializeComponent();

            DataContext = App.UserListViewModel;

            //BuildLocalizedApplicationBar();
        }

        /*
        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            var appBarButtonBack = new ApplicationBarIconButton(new Uri("/Assets/AppBar/logout3.png", UriKind.Relative));
            appBarButtonBack.Text = AppResources.AppBarLogoutText;
            appBarButtonBack.Click += OnLogoutClick;
            ApplicationBar.Buttons.Add(appBarButtonBack);

            ApplicationBarMenuItem appBarAllUsersMenuItem = new ApplicationBarMenuItem(AppResources.AppBarPropertiesText);
            appBarAllUsersMenuItem.Click += (sender, args) =>
            {                
                NavigationUtils.NavigateToAllPropertiesPage(NavigationService);
            };

            ApplicationBar.MenuItems.Add(appBarAllUsersMenuItem);
        }*/

        protected void OnLogoutClick(object sender, EventArgs args)
        {
            UserSessionManager.LogoutUser(NavigationService);
        }

        //private void OnUserSelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    //TODO: Navigate to User Details Page
        //}

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Load data every time user navigates to this page
            App.UserListViewModel.LoadData();
            //if (!App.UserListViewModel.IsDataLoaded)
            //{
            //    App.UserListViewModel.LoadData();
            //}
        }

        private void HandleAllPropertiesClick(object sender, EventArgs e)
        {
            NavigationUtils.NavigateToAllPropertiesPage(NavigationService);
        }

        private void HandleAllUsersClick(object sender, EventArgs e)
        {
            NavigationUtils.NavigateToAllUsersPage(NavigationService);
        }

        private void HandleFlickrClick(object sender, EventArgs e)
        {
            NavigationUtils.NavigateToFlickrPage(NavigationService);
        }
    }
}